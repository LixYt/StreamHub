using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
using System.IO;
using System.Text.Json;
using TwitchLib.Client.Events;
using TwitchLib.Client.Enums;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;

namespace ViewerGameWorker
{
    public class ViewerGameSvc : BackgroundService
    {
        private readonly ILogger<ViewerGameSvc> _logger;
        private TwitchClient TwitchClient;
        private ViewerGameConfig config;
        private string channel;
        ViewerGameContext ctx;
        private List<ViewerLive> ChattingViewers;

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

                Twitch_setup();
            }
            else
            {
                Save();
                Console.WriteLine("Config saved");
            }

            
        }
        public override void Dispose()
        {
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

        

        #region Twitch
        public void Twitch_setup()
        {
            #region Twitch
            try
            {
                TwitchClient = new TwitchClient();
                TwitchClient.Initialize(config.GetCredential(), config.ChannelName, config.CommandSymbol.ToCharArray()[0], config.CommandSymbol.ToCharArray()[0], true);
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

        private void TwitchClient_OnReSubscriber(object sender, OnReSubscriberArgs e)
        {
            RegisterTwitchUser(e.ReSubscriber.DisplayName.ToLower());
            RewardTwitchUser(e.ReSubscriber.DisplayName.ToLower(), 20);
        }

        private void TwitchClient_OnRaidNotification(object sender, OnRaidNotificationArgs e)
        {
            RegisterTwitchUser(e.RaidNotification.DisplayName.ToLower());
            RewardTwitchUser(e.RaidNotification.DisplayName.ToLower(), 20);
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

                case "drawcard": //Action Card
                    int.TryParse(e.Command.ArgumentsAsString, out int usedPointsA);
                    if (usedPointsA == 0) 
                    { TwitchClient.SendMessage(channel, $"{e.Command.ChatMessage.Username}, tu dois indiquer le nombre de points à dépenser !"); }
                    else if (usedPointsA < ctx.Viewers.Where(x => x.UserName == e.Command.ChatMessage.Username).First().Points)
                    { TwitchClient.SendMessage(channel, $"{e.Command.ChatMessage.Username}, tu n'as pas assez {usedPointsA} points sur ton compte !"); }
                    else
                    {

                    }
                    break;

                case "echange":
                    List<string> args = e.Command.ArgumentsAsList;

                    break;

                default:
                    TwitchClient.SendMessage(channel, $"La commande {e.Command.CommandText} n'existe pas.");
                    break;
            }
        }

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
            TwitchClient.SendMessage(channel, $"{e.BotUsername} opérationnel");
        }
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            RegisterTwitchUser(e.ChatMessage.Username, e.ChatMessage.UserId);
            
            if (!e.ChatMessage.Message.StartsWith(config.CommandSymbol)) //message is not a command
            { 
                int points = (int)Math.Ceiling((decimal)e.ChatMessage.Message.Trim().Length / 20);
                if (e.ChatMessage.IsSubscriber) points *= 2;

                RewardTwitchUser(e.ChatMessage.Username, points);
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
            ViewerLive v = ChattingViewers.FindLast(x => x.UserName == e.Username && x.Disconnected == null);
            v.Disconnected = DateTime.Now;
            TimeSpan t = ((TimeSpan)(v.Disconnected - v.Connected));
            RewardTwitchUser(v.UserName, (int)t.TotalMinutes/2);
        }
        #endregion
    
        public void RegisterTwitchUser(string UserName, string UserId="")
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
        
        public void RewardTwitchUser(string UserName, int points)
        {
            ctx.Viewers.Where(x => x.UserName == UserName).First().Points += points;
            ctx.SaveChanges();
        }
        public void DrawCard(string UserName, int usedPoints)
        {

        }
            
    }
}
