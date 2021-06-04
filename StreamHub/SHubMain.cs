using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwitchLib.Client;
using TwitchLib.Client.Models;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Enums;
using TwitchLib.Communication.Models;
using TwitchLib.Communication.Clients;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace StreamHub
{
    public partial class SHubMain : Form
    {
        private TwitchClient client;
        private SHubConfig config;

        private bool ViewerPool_Status = false;
        string channel = "";

        public List<string> ViewerPoolList = new List<string>();
        private string SelectedUser = "";

        public SHubMain(SHubConfig cfg)
        {
            InitializeComponent();

            client = new TwitchClient();
            config = cfg;

            if (!config.isSetup())
            {
                SHubConfigPanel ConfigPannel = new SHubConfigPanel(config);
                while (ConfigPannel.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Please configure this tool before using");
                    ConfigPannel.ShowDialog();
                }
            }

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

                client.Connect();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
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
            client.SendMessage(e.Channel, $"Le bot {config.BotName} est maintenant connecté et à l'écoute !");
            channel = e.Channel;
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            /* ViewerPool */
            if (ViewerPool_Status && e.ChatMessage.Message == config.CommandSymbol + config.ViewerPool_RegisterCommand)
            {
                if (ViewerPoolList.Contains(e.ChatMessage.Username))
                {
                    client.SendWhisper(e.ChatMessage.Username, "You are already in the pool.");
                }
                else
                {
                    Invoke(new Action(() => c_ViewerPool.Items.Add($"{e.ChatMessage.Username} ({(e.ChatMessage.IsSubscriber && config.ViewerPool_SubBonus ? 2 : 1)})")));
                    ViewerPoolList.Add(e.ChatMessage.Username);
                    client.SendWhisper(e.ChatMessage.Username, $"You are added in the pool with {(e.ChatMessage.IsSubscriber && config.ViewerPool_SubBonus ? 2 : 1)} chances.");
                    if (e.ChatMessage.IsSubscriber && config.ViewerPool_SubBonus) { ViewerPoolList.Add(e.ChatMessage.Username); }

                    UpdateObsFiles();
                }
            }

            string pattern = @"^(\d{1,2})d(\d{1,3})$";
            if (config.ViewerPool_CanRollDice && e.ChatMessage.Username == SelectedUser && Regex.Matches(e.ChatMessage.Message, pattern, RegexOptions.IgnoreCase).Count == 1) //+regex 0d000
            {
                int nb_dice = int.Parse(e.ChatMessage.Message.Split('d')[0]);
                int diceSize = int.Parse(e.ChatMessage.Message.Split('d')[1]);

                if (nb_dice < 1 || diceSize > 100 || diceSize < 2)
                {
                    client.SendMessage(e.ChatMessage.Channel, $"{e.ChatMessage.Username} tu as mal lancé les dès.");
                }
                else
                {
                    int result = 0;
                    string dices = "";
                    Random r = new Random();
                    for (int i = 1; i <= nb_dice; i++)
                    {
                        int a = r.Next(1, diceSize + 1);
                        result += a;
                        dices += $"{a},";
                    }

                    client.SendMessage(e.ChatMessage.Channel, $"{e.ChatMessage.Username} a lancé {e.ChatMessage.Message} et obtenu : ({dices.TrimEnd(',')}) pour un total de {result} !");
                }
            }

            /* ^^^ ViewerPool ^^^ */
        }

        public void UpdateObsFiles()
        {
            /* ViewerPool current list */
            using (StreamWriter sw = File.CreateText("OBS_ViewerPool.txt"))
            {
                string ViewerPoolTxt = "";
                foreach(string s in c_ViewerPool.Items)
                {
                    ViewerPoolTxt += $"{s}\r\n";
                }
                sw.WriteLine(ViewerPoolTxt);
            }


        }

        private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            /*if (e.WhisperMessage.Username == "my_friend")
                client.SendWhisper(e.WhisperMessage.Username, "Hey! Whispers are so cool!!");*/
        }

        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            /*if (e.Subscriber.SubscriptionPlan == SubscriptionPlan.Prime)
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points! So kind of you to use your Twitch Prime on this channel!");
            else
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points!");
            */
        }

        private void C_ConfigForm_Click(object sender, EventArgs e)
        {
            SHubConfigPanel ConfigPannel = new SHubConfigPanel(config);
            if (ConfigPannel.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Please configure this tool before using");
                ConfigPannel.ShowDialog();
                client.Disconnect();
                client.Connect();
            }
            
        }

        private void c_viewerpool_startstop_Click(object sender, EventArgs e)
        {
            if (ViewerPool_Status)
            {
                c_viewerpool_startstop.ForeColor = Color.Red;
                ViewerPool_Status = false;
                client.SendMessage(channel, "ViewerPool Stopped");
            }
            else
            {
                c_viewerpool_startstop.ForeColor = Color.Green;
                ViewerPool_Status = true; 
                client.SendMessage(channel, "ViewerPool Started");
            }
        }

        private void c_ViewerPool_Reset_Click(object sender, EventArgs e)
        {
            if (!ViewerPool_Status)
            {
                c_ViewerPool.Items.Clear();
                SelectedUser = "";
                ViewerPoolList.Clear();
                UpdateObsFiles();
            }
        }

        private void c_ViewerPool_Pick_Click(object sender, EventArgs e)
        {
            if (c_ViewerPool.Items.Count == 0) return;

            int max = c_ViewerPool.Items.Count;
            Random r = new Random();
            int selected = r.Next(0, max);
            SelectedUser = c_ViewerPool.Items[selected].ToString().Split(' ')[0];

            string msg = $"{c_ViewerPool.Items[selected]}, c'est ton tour de briller ! Tu es maintenant le responsable du PNJ !";
            client.SendMessage(channel, msg);
            client.SendWhisper(c_ViewerPool.Items[selected].ToString(), msg);
        }
    }
}
