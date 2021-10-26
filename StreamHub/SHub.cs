using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchLib.Api;
using TwitchLib.Api.Helix.Models.Users;
using TwitchLib.Api.V5.Models.Channels;
using TwitchLib.Api.Core.Models.Undocumented.RecentMessages;
using TwitchLib.Api.Core.Models.Undocumented.Chatters;
using TwitchLib.Api.V5.Models.Clips;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;
using TwitchLib.Client;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Enums;



namespace StreamHub
{
    public partial class SHub : Form
    {
        private TwitchAPI api;
        private ChannelAuthed Chan;
        private TwitchPubSub clientPubSub;
        private TwitchClient client;

        public SHub()
        {
            InitializeComponent();

            api = new TwitchAPI();
            client = new TwitchClient();
            api.Settings.ClientId = "ClientId";
            api.Settings.AccessToken = "AccessToken"; // App Secret is not an Accesstoken

            _ = Calls();

        }

        private async Task Calls()
        {
            try
            {
                ConnectionCredentials credentials = new ConnectionCredentials("lix_danssonlabo", "AccessToken");
                var clientOptions = new ClientOptions
                {
                    MessagesAllowedInPeriod = 750,
                    ThrottlingPeriod = TimeSpan.FromSeconds(30)
                };
                WebSocketClient customClient = new WebSocketClient(clientOptions);
                client = new TwitchClient(customClient);
                client.Initialize(credentials, "lix_danssonlabo");
                client.OnLog += Client_OnLog;
                client.OnJoinedChannel += Client_OnJoinedChannel;
                client.OnMessageReceived += Client_OnMessageReceived;
                client.OnWhisperReceived += Client_OnWhisperReceived;
                client.OnNewSubscriber += Client_OnNewSubscriber;
                client.OnConnected += Client_OnConnected;

                client.Connect();

                Chan = await api.V5.Channels.GetChannelAsync("AccessToken");
                liveState.Checked = await api.V5.Streams.BroadcasterOnlineAsync(Chan.Id);

                clientPubSub = new TwitchPubSub();

                clientPubSub.OnPubSubServiceConnected += onPubSubServiceConnected;
                clientPubSub.OnPrediction += OnPubSubPrediction;
                clientPubSub.OnListenResponse += onListenResponse;

                clientPubSub.ListenToPredictions(Chan.Id);
                clientPubSub.Connect();

                OnLineTime.Text = $"Online since : {await api.V5.Streams.GetUptimeAsync(Chan.Id)}";
            }
            catch(Exception e)
            {
                MessageBox.Show($"[Exception] {e}");
            }

        }



        private void Client_OnLog(object sender, TwitchLib.Client.Events.OnLogArgs e)
        {
            Console.WriteLine($"{e.DateTime.ToString()}: {e.BotUsername} - {e.Data}");
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine("Hey guys! I am a bot connected via TwitchLib!");
            client.SendMessage(e.Channel, "Hey guys! I am a bot connected via TwitchLib!");
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message == "&pnj")
            {
                Invoke(new Action(() => Tchat.Items.Add($"{e.ChatMessage.DisplayName}")));
            }
            

            if (e.ChatMessage.Message == "&roll" && Tchat.Items.Contains(e.ChatMessage.DisplayName))
            {
                Random rnd = new Random(); 
                client.SendMessage(e.ChatMessage.Channel, $"{e.ChatMessage.DisplayName} tu obtiens un {rnd.Next(1,100)}");
            }
        }

        private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            if (e.WhisperMessage.Username == "my_friend")
                client.SendWhisper(e.WhisperMessage.Username, "Hey! Whispers are so cool!!");
        }

        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            if (e.Subscriber.SubscriptionPlan == SubscriptionPlan.Prime)
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points! So kind of you to use your Twitch Prime on this channel!");
            else
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points!");
        }


        private void onPubSubServiceConnected(object sender, EventArgs e)
        {
            // SendTopics accepts an oauth optionally, which is necessary for some topics
            clientPubSub.SendTopics();
        }

        private void onListenResponse(object sender, OnListenResponseArgs e)
        {
            Debug.WriteLine($"[Listener] {e.Topic} => {e.Response}");
            if (!e.Successful)
                throw new Exception($"Failed to listen! Response: {e.Response}");
        }

        private void OnPubSubPrediction(object sender, OnPredictionArgs e)
        {
            MessageBox.Show(e.Title);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ = ListViewers();
        }

        public async Task ListViewers()
        {
            try
            {
                listView1.Clear();
                List<ChannelFollow> o = await api.V5.Channels.GetAllFollowersAsync(Chan.Id);
                foreach (ChannelFollow f in o)
                {
                    listView1.Items.Add(f.User.Name);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"[Exception] {e}");
            }
        }

        public async Task GetChat()
        {
            try
            {
                List<ChatterFormatted> chatters = await api.Undocumented.GetChattersAsync(Chan.Id);
                foreach(ChatterFormatted c in chatters)
                {
                    Tchat.Items.Add(c.Username);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show($"[Exception] {e}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ = GetChat();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
