using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace StreamerGame
{
    public partial class SGame : Form
    {
        private TwitchClient client;
        private StreamConfig config;
        private string channel;

        public SGame(StreamConfig cfg)
        {
            InitializeComponent();

            #region Load Configuration
            cfg ??= new StreamConfig();
            config = cfg;
            #endregion

            #region Twitch
            client = new TwitchClient();

            try
            {
                var clientOptions = new ClientOptions
                {
                    MessagesAllowedInPeriod = 750,
                    ThrottlingPeriod = TimeSpan.FromSeconds(30)
                };
                WebSocketClient customClient = new WebSocketClient(clientOptions);
                client = new TwitchClient(customClient);
                client.Initialize(config.GetCredential(), config.ChannelName);
                client.OnLog += Client_OnLog;
                client.OnJoinedChannel += Client_OnJoinedChannel;
                client.OnMessageReceived += Client_OnMessageReceived;
                client.OnWhisperReceived += Client_OnWhisperReceived;
                client.OnNewSubscriber += Client_OnNewSubscriber;
                client.OnConnected += Client_OnConnected;
                client.OnUserJoined += Client_OnUserJoined;
                client.OnUserLeft += Client_OnUserLeft;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            #endregion

            tabControl1.TabPages["tabConfig"].Select();
        }

        public class DbInitTest : System.Data.Entity.DropCreateDatabaseIfModelChanges<StreamerGameContext>
        {
            protected override void Seed(StreamerGameContext context)
            {
                List<BattleCard> battleCards = new List<BattleCard>()
                {
                    new BattleCard{CardName="Lix", Attaque=1000, Defense=1000, Description="Carte de test-démo", Life=9999, Rarity=1, Picture=null}
                };
                battleCards.ForEach(s => context.BattleCards.Add(s));
                context.SaveChanges();
            }

        }

        private void C_BotOnOff_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                client.Disconnect();
                C_BotOnOff.Text = "Turn bot Off";
            }
            else
            {
                client.Connect();
                C_BotOnOff.Text = "Turn bot on";
            }
        }

        #region Twitch Events
        private void Client_OnLog(object sender, OnLogArgs e)
        {

        }
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {

        }
        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            channel = e.Channel;
        }
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (!e.ChatMessage.Message.StartsWith(config.CommandSymbol)) //message is not a command
            {
                

                return;
            }
            else //message is a command
            {

            }
        }
        private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {

        }
        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {

        }
        private void Client_OnUserJoined(object sender, OnUserJoinedArgs e)
        {
            try
            {
                //if (ExcludedNames.Contains(e.Username)) return;
                //Invoke(new Action(() => UsersList.Add(new GameUser() { UserName = e.Username, Connection = DateTime.Now, Disconnection = null })));
            }
            catch (Exception ex) { Debug.WriteLine($"Twitch[OnUserJoined]({e.Username}) {ex.Message}"); }
        }
        private void Client_OnUserLeft(object sender, OnUserLeftArgs e)
        {
            try
            {
                //GameUser g = ConnectedUsers.FindLast(x => x.UserName == e.Username);
                //g.Disconnection = DateTime.Now;
            }
            catch (Exception ex) { Debug.WriteLine($"Twitch[OnUserJoined]({e.Username}) {ex.Message}"); }
        }

        #endregion

    }
}
