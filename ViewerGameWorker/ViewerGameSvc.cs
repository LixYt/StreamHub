using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TwitchLib.Client;
using System.IO;
using System.Text.Json;
using TwitchLib.Client.Events;
using TwitchLib.PubSub;
using TwitchLib.Api.V5.Models.Channels;
using TwitchLib.Api;

namespace ViewerGameWorker
{
    public class ViewerGameSvc : BackgroundService
    {
        private readonly ILogger<ViewerGameSvc> _logger;
        private TwitchClient TwitchClient;
        private ViewerGameConfig config;
        private string channel;
        private string channel_id;
        ViewerGameContext ctx;
        private List<ViewerLive> ChattingViewers;
        private TwitchPubSub clientPubSub;
        private TwitchAPI api;
        private ChannelAuthed Chan;

        public bool isLiveOn = false;

        public ViewerGameSvc(ILogger<ViewerGameSvc> logger)
        {
            _logger = logger;
            ChattingViewers = new List<ViewerLive>();

            Console.WriteLine($"Current dir = {Directory.GetCurrentDirectory()}");
            if (Load())
            {
                Console.WriteLine("Config loaded");
                try
                {
                    ctx = new ViewerGameContext(config.DbString);
                }
                catch(Exception ex) { _logger.LogError(ex.Message); }

                TwitchClient_setup();
                _ = TwitchAPIandPubSub_setup();
            }
            else
            {
                Save();
                Console.WriteLine("Config saved");
            }

            
        }
        public override void Dispose()
        {
            foreach(ViewerLive v in ChattingViewers)
            {
                ViewerLiveToDatabase(v.UserName);
            }

            TwitchClient.Disconnect();
            ctx.Database.Connection.Close();
            base.Dispose();
        }

        public bool Load()
        {
            if (File.Exists("userSetting.sgc"))
            {
                try
                {
                    config = JsonSerializer.Deserialize<ViewerGameConfig>(File.ReadAllText("userSetting.sgc"));
                    return true;
                }
                catch (Exception Ex)
                {
                    config = new ViewerGameConfig();
                }
            }
            else
            {
                config = new ViewerGameConfig();
            }
            return false;
        }
        public void Save()
        {
            try
            {
                string s = JsonSerializer.Serialize(config);
                File.WriteAllText("userSetting.sgc", s);
            }
            catch (Exception ex)
            {
                
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            /*while (!stoppingToken.IsCancellationRequested)
            {
                if (ctx.Database.Connection.State == System.Data.ConnectionState.Open && TwitchClient.IsConnected)
                {
                    foreach (Viewer v in ctx.Viewers.Where(x => x.Points >= 1))
                    {
                        _logger.LogInformation($"{v.UserName} has {v.Points}");
                    }
                }
                await Task.Delay(1000, stoppingToken);
            }*/
        }

        public void TwitchClient_setup()
        {
            #region Twitch
            try
            {
                TwitchClient = new TwitchClient();
                TwitchClient.Initialize(config.GetBotCredential(), config.ChannelName, config.CommandSymbol.ToCharArray()[0], config.CommandSymbol.ToCharArray()[0], true);
                TwitchClient.OnLog += Client_OnLog;
                TwitchClient.OnJoinedChannel += Client_OnJoinedChannel;
                TwitchClient.OnMessageReceived += Client_OnMessageReceived;
                TwitchClient.OnWhisperReceived += Client_OnWhisperReceived;
                TwitchClient.OnNewSubscriber += Client_OnNewSubscriber;
                TwitchClient.OnReSubscriber += TwitchClient_OnReSubscriber;
                TwitchClient.OnConnected += Client_OnConnected;
                TwitchClient.OnUserJoined += Client_OnUserJoined;
                TwitchClient.OnUserLeft += Client_OnUserLeft;
                TwitchClient.OnRaidNotification += TwitchClient_OnRaidNotification;
                TwitchClient.OnChatCommandReceived += TwitchClient_OnChatCommandReceived;
                TwitchClient.Connect();

                _logger.LogInformation("Twitch connection successfull");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                Console.WriteLine(e.Message);
                Dispose();
            }
            #endregion
        }
        public async Task TwitchAPIandPubSub_setup()
        {
            try
            {
                clientPubSub = new TwitchPubSub();
                api = new TwitchAPI();
                api.Settings.ClientId = config.BroadCaster_ClientID;
                api.Settings.AccessToken = config.BroadCaster_AccessToken;

                var respons = await api.Helix.Users.GetUsersAsync(null, new List<string>() { config.ChannelName });
                channel_id = respons.Users[0].Id;

                clientPubSub.OnPubSubServiceConnected += ClientPubSub_OnPubSubServiceConnected;
                clientPubSub.OnChannelPointsRewardRedeemed += ClientPubSub_OnChannelPointsRewardRedeemed;
                clientPubSub.OnBitsReceivedV2 += ClientPubSub_OnBitsReceivedV2;
                clientPubSub.OnStreamUp += ClientPubSub_OnStreamUp;
                clientPubSub.OnStreamDown += ClientPubSub_OnStreamDown;
                clientPubSub.OnListenResponse += ClientPubSub_OnListenResponse;

                clientPubSub.ListenToBitsEventsV2(channel_id);
                clientPubSub.ListenToChannelPoints(channel_id);
                clientPubSub.ListenToVideoPlayback(channel_id);

                clientPubSub.Connect();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                Console.WriteLine(e.Message);
                Dispose();
            }


        }

        


        #region PubSub Event
        private void ClientPubSub_OnChannelPointsRewardRedeemed(object sender, TwitchLib.PubSub.Events.OnChannelPointsRewardRedeemedArgs e)
        {
            RegisterTwitchUser(e.RewardRedeemed.Redemption.User.DisplayName, e.RewardRedeemed.Redemption.User.Id);
            int points = e.RewardRedeemed.Redemption.Reward.Cost / 100;
            RewardTwitchUser(e.RewardRedeemed.Redemption.User.DisplayName,
                points, $"redeeming channel points reward '{e.RewardRedeemed.Redemption.Reward.Title}'");
        }
        private void ClientPubSub_OnBitsReceivedV2(object sender, TwitchLib.PubSub.Events.OnBitsReceivedV2Args e)
        {
            RegisterTwitchUser(e.UserName, e.UserId);
            int points = e.TotalBitsUsed / 10;
            RewardTwitchUser(e.UserName, points, $"Cheers {e.TotalBitsUsed}");
        }
        private void ClientPubSub_OnListenResponse(object sender, TwitchLib.PubSub.Events.OnListenResponseArgs e)
        {
            _logger.LogInformation($"Succes = {e.Successful}, Topic = {e.Topic} , Error = {e.Response.Error}");
        }
        private void ClientPubSub_OnStreamDown(object sender, TwitchLib.PubSub.Events.OnStreamDownArgs e)
        {
            isLiveOn = false;
            TwitchClient.SendMessage(channel, $"{config.GameTitle} est maintenant désactivé");
            // fermer toutes les sessions ChattingViewers en cours quand le live se coupe !!!
        }
        private void ClientPubSub_OnStreamUp(object sender, TwitchLib.PubSub.Events.OnStreamUpArgs e)
        {
            isLiveOn = true;
            TwitchClient.SendMessage(channel, $"{config.GameTitle} est maintenant actif");
        }
        private void ClientPubSub_OnPubSubServiceConnected(object sender, EventArgs e)
        {
            clientPubSub.SendTopics(config.BroadCaster_AccessToken);
            _logger.LogInformation("PubSub connected");
        }
        #endregion

        #region TwitchClient Events
        private void Client_OnLog(object sender, OnLogArgs e)
        {
            //_logger.LogInformation("Connected to twitch chat");
        }
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {

        }
        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            channel = e.Channel;
            TwitchClient.SendMessage(channel, $"Jeu des viewers opérationnel");
        }
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            RegisterTwitchUser(e.ChatMessage.Username, e.ChatMessage.UserId);
            
            if (!e.ChatMessage.Message.StartsWith(config.CommandSymbol)) //message is not a command
            { 
                int points = (int)Math.Ceiling((decimal)e.ChatMessage.Message.Trim().Length / 20);
                if (e.ChatMessage.IsSubscriber) points *= 2;

                RewardTwitchUser(e.ChatMessage.Username, points, "chating");
            }
        }
        private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {

        }
        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            ctx.Viewers.Where(x => x.UserName == e.Subscriber.DisplayName.ToLower()).First().Points += 50;
            _logger.LogTrace($"Attempt to give 50 points to {e.Subscriber.DisplayName}");
        }
        private void Client_OnUserJoined(object sender, OnUserJoinedArgs e)
        {
            RegisterTwitchUser(e.Username);
            if (ChattingViewers.Where(x => x.UserName == e.Username && x.Disconnected == null).Count() == 0)
            {
                ChattingViewers.Add(new ViewerLive() { Connected = DateTime.Now, UserName = e.Username });
            }
        }
        private void Client_OnUserLeft(object sender, OnUserLeftArgs e)
        {
            ViewerLiveToDatabase(e.Username);
        }
        private void TwitchClient_OnReSubscriber(object sender, OnReSubscriberArgs e)
        {
            RegisterTwitchUser(e.ReSubscriber.DisplayName.ToLower());
            RewardTwitchUser(e.ReSubscriber.DisplayName.ToLower(), 20, "Subscribing to this channel");
        }
        private void TwitchClient_OnRaidNotification(object sender, OnRaidNotificationArgs e)
        {
            RegisterTwitchUser(e.RaidNotification.DisplayName.ToLower());
            RewardTwitchUser(e.RaidNotification.DisplayName.ToLower(), 20, "Raiding this channel");
        }
        private void TwitchClient_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            switch (e.Command.CommandText.ToLower())
            {
                case "score":
                    TwitchClient.SendMessage(channel, $"{e.Command.ChatMessage.Username} tu as {ctx.Viewers.Where(x => x.UserName == e.Command.ChatMessage.Username).First().Points} points.");
                    break;

                case "linkdiscord":
                    ctx.Viewers.Where(x => x.UserName == e.Command.ChatMessage.Username).First().DiscordTag = e.Command.ArgumentsAsString;
                    ctx.SaveChanges();
                    break;

                case "drawcard": 
                    int.TryParse(e.Command.ArgumentsAsString, out int usedPointsA);
                    if (usedPointsA == 0)
                    { TwitchClient.SendMessage(channel, $"{e.Command.ChatMessage.Username}, il faut dépenser au moins 1 points (2500 points max seront utilisés) !"); }
                    else if (usedPointsA > ctx.Viewers.Where(x => x.UserName == e.Command.ChatMessage.Username).First().Points)
                    { TwitchClient.SendMessage(channel, $"{e.Command.ChatMessage.Username}, tu n'as pas assez {usedPointsA} points sur ton compte !"); }
                    else
                    {
                        { TwitchClient.SendMessage(channel, $"{e.Command.ChatMessage.Username}, cette fonction n'est pas encore prête"); }
                        DrawCard(e.Command.ChatMessage.Username, usedPointsA);
                    }
                    break;

                case "echange":
                    List<string> args = e.Command.ArgumentsAsList;
                    TwitchClient.SendMessage(channel, $"{e.Command.ChatMessage.Username}, cette fonction n'est pas encore prête");
                    break;

                default:
                    TwitchClient.SendMessage(channel, $"La commande {e.Command.CommandText} n'existe pas.");
                    break;
            }
        }
        #endregion

        #region Twitch to Database Methods
        public void ViewerLiveToDatabase(string UserName)
        {
            if (!isLiveOn) { _logger.LogInformation($"This channel is offline ({UserName}, being connected to IRC)"); return; }
            ViewerLive v = ChattingViewers.FindLast(x => x.UserName == UserName && x.Disconnected == null);
            v.Disconnected = DateTime.Now;
            TimeSpan t = ((TimeSpan)(v.Disconnected - v.Connected));
            RewardTwitchUser(v.UserName, (int)t.TotalMinutes / 2, "Spending time in here");
            _logger.LogInformation($"{v.UserName} earn {(int)t.TotalMinutes / 2} while being on the stream");
        }
        public void RegisterTwitchUser(string UserName, string UserId = "")
        {
            if (ctx.Viewers.Where(x => x.UserName == UserName).Count() == 0)
            {
                if (UserId != "" && ctx.Viewers.Where(x => x.UserId == UserId && x.UserName != UserName).Count() == 1)
                {
                    ctx.Viewers.Where(x => x.UserId == UserId).First().UserName = UserName;
                    ctx.SaveChanges();
                }
                else
                {
                    ctx.Viewers.Add(new Viewer() { UserId = UserId, UserName = UserName, Points = 0, Money = 0 });
                    ctx.SaveChanges();
                }
            }

            if (ctx.Viewers.Where(x => x.UserName == UserName && x.UserId == "").Count() == 1)
            {
                ctx.Viewers.Where(x => x.UserName == UserName).First().UserId = UserId;
                ctx.SaveChanges();
            }


        }
        public void RewardTwitchUser(string UserName, int points, string message = "")
        {
            if (!isLiveOn) { _logger.LogInformation($"This channel is offline ({UserName}, {message})"); return; }
            ctx.Viewers.Where(x => x.UserName == UserName).First().Points += points;
            ctx.SaveChanges();
            _logger.LogInformation($"{UserName} wins {points}, rewarded for : {(message == "" ? "" : message)}");
        }
        public void DrawCard(string UserName, int usedPoints) //100 pts = 1% de plus de chance, limité à 25% max
        {
            try 
            {
                List<Card> Cards = new List<Card>();
                foreach(ActionCard a in ctx.ActionCards)
                {
                    Cards.Add(a.ToCard());
                }
                foreach (BattleCard b in ctx.BattleCards)
                {
                    Cards.Add(b.ToCard());
                }                

                List<Card> OrderedCards = Cards.OrderBy(c => c.Rarity).ToList();

                if (OrderedCards.Count() == 0) { _logger.LogInformation("Cards are not set yet !"); return; }
                //Rarity = 1 => 50%; Rarity = 2 => 25%; Rarity = 3 => 15%; Rarity = 4 => 9%; Rarity = 5 => 1%

                int Choice = new Random().Next(1, 100);
                if (usedPoints > 0)
                {
                    int AddPoints = usedPoints / 100;
                    if (AddPoints > 25) { usedPoints = 2500; AddPoints = 25; }
                    Choice += AddPoints;
                }

                List<Card> CarteTirable;
                if (Choice <= 50)
                {
                    CarteTirable = OrderedCards.Where(x => x.Rarity == 1).ToList();
                }
                else if (Choice > 50 && Choice <= 75)
                {
                    CarteTirable = OrderedCards.Where(x => x.Rarity == 2).ToList();
                }
                else if (Choice > 75 && Choice <= 90)
                {
                    CarteTirable = OrderedCards.Where(x => x.Rarity == 3).ToList();
                }
                else if (Choice > 91 && Choice <= 99)
                {
                    CarteTirable = OrderedCards.Where(x => x.Rarity == 4).ToList();
                }
                else
                {
                    CarteTirable = OrderedCards.Where(x => x.Rarity == 5).ToList();
                }

                int ChoosenIndexCard = new Random().Next(1, CarteTirable.Count());
                Card ChoosenCard = CarteTirable[ChoosenIndexCard];

                Viewer v = ctx.Viewers.Where(x => x.UserName == UserName).First();
                v.Points -= usedPoints;
                if (ctx.ActionCards.Where(x => x.CardName == ChoosenCard.CardName).Count() == 1)
                {
                    v.OwnedActionCard.Add(ctx.ActionCards.Where(x => x.CardName == ChoosenCard.CardName).First());
                }
                else if (ctx.BattleCards.Where(x => x.CardName == ChoosenCard.CardName).Count() == 1)
                {
                    v.OwnedBattleCard.Add(ctx.BattleCards.Where(x => x.CardName == ChoosenCard.CardName).First());
                }
                else
                {
                    _logger.LogError($"Failed to retrieve the card {ChoosenCard.CardName}");
                }

                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            

        }
        #endregion


    }
}
