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
        private bool GTA_status = false;
        string channel = "";

        public List<string> ViewerPoolList { get; set; } = new List<string>();
        public List<GTA_User> GTAPoolList { get; set; } = new List<GTA_User>();

        private BindingList<GTA_User> GTAList /*= new BindingList<GTA_User>()*/;

        private string SelectedUser = "";

        public SHubMain(SHubConfig cfg)
        {
            InitializeComponent();

            client = new TwitchClient();
            cfg = cfg ?? new SHubConfig();
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

            Text = $"{config.BotName}";

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

            //GTAList = GTAList ?? new List<GTA_User>();
            c_GTAPool.AutoGenerateColumns = true;

            GTAList = new BindingList<GTA_User>(GTAPoolList);
            BindingSource source = new BindingSource(GTAList, null);
            c_GTAPool.DataSource = source;

            UpdateObsFiles();
            UpdateGTACount();
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
            client.SendMessage(e.Channel, $"/me prêt à l'action et en attente d'instruction...");
            channel = e.Channel;
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (!e.ChatMessage.Message.StartsWith(config.CommandSymbol)) return;

            /* vvv ViewerPool vvv */
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

            /* vvv Gameveiwer Team Assembler vvv */

            
            if (config.GTA_roles.Exists(x => x.FormatteCommand(config.CommandSymbol) == e.ChatMessage.Message)
                && GTA_status && !GTAPoolList.Exists(x => x.userName == e.ChatMessage.Username))
            {
                Role r = config.GTA_roles.FindLast(x => x.FormatteCommand(config.CommandSymbol) == e.ChatMessage.Message);
                GTA_User u = new GTA_User() { userName = e.ChatMessage.Username, role = r, selected = false};
                Invoke(new Action(() => GTAList.Add(u)));
                client.SendMessage(e.ChatMessage.Channel, $"{e.ChatMessage.Username} is registred as {r.name} in Gameviewer queue.");

                UpdateObsFiles();
                Invoke(new Action(() => UpdateGTACount()));
            }
            if (config.GTA_roles.Exists(x => x.command == e.ChatMessage.Message.TrimStart(char.Parse(config.CommandSymbol)))
                && GTA_status && GTAPoolList.Exists(x => x.userName == e.ChatMessage.Username))
            {
                client.SendWhisper(e.ChatMessage.Username, "You are already registred in queue.");
            }
            if (e.ChatMessage.Message == $"{config.CommandSymbol}untag"
                && GTA_status && GTAPoolList.Exists(x => x.userName == e.ChatMessage.Username))
            {
                Invoke(new Action(() => GTAList.Remove(GTAPoolList.FindLast(x => x.userName == e.ChatMessage.Username)))); 
                client.SendWhisper(e.ChatMessage.Username, "You are now unregistred from the queue.");
                Invoke(new Action(() => UpdateGTACount()));
            }

            /* ^^^ Gameveiwer Team Assembler ^^^ */
        }

        public void UpdateObsFiles()
        {
            if (!Directory.Exists("OBS")) Directory.CreateDirectory("OBS");

            /* ViewerPool current list */
            using (StreamWriter sw = File.CreateText("OBS/ViewerPool.txt"))
            {
                string ViewerPoolTxt = "";
                foreach(string s in c_ViewerPool.Items)
                {
                    ViewerPoolTxt += $"{s}\r\n";
                }
                sw.WriteLine(ViewerPoolTxt);
            }

            using (StreamWriter sw = File.CreateText("OBS/GTAPoolList.txt"))
            {
                string GTAPool = "";
                foreach (GTA_User u in GTAPoolList)
                {
                    GTAPool += $"{u.userName} ({u.role.name})\r\n";
                }
                sw.WriteLine(GTAPool);
            }

            using (StreamWriter sw = File.CreateText("OBS/GTAPoolConfig.txt"))
            {
                string GTAConfig = $"Selection mode is {config.GTA_mode.Replace("c_", "")} \r\n";
                foreach (Role r in config.GTA_roles)
                {
                    GTAConfig += $"For {r.name} : use command {config.CommandSymbol}{r.command}. {r.nbr} will be picked.\r\n";
                }
                sw.WriteLine(GTAConfig);
            }
        }
        public void UpdateGTACount()
        {
            c_nbr.Text = $"{GTAPoolList.Count} viewers queueing";
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

        private void c_GTA_startstop_Click(object sender, EventArgs e)
        {
            if (GTA_status)
            {
                c_GTA_startstop.ForeColor = Color.Red;
                GTA_status = false;
                client.SendMessage(channel, "Gameviewer queue Stopped");
            }
            else
            {
                c_GTA_startstop.ForeColor = Color.Green;
                GTA_status = true;
                client.SendMessage(channel, "Gameviewer queue Started");
            }
        }

        private void c_GTA_Auto_Click(object sender, EventArgs e)
        {
            if (GTA_status) return;
            switch (config.GTA_mode)
            {
                case "c_GTA_modeFIFO":
                    GTA_FIFO();
                    break;

                case "c_GTA_modeLIFO":
                    GTA_LIFO();
                    break;

                case "c_GTA_modeRR":
                    GTA_RandomByRole();
                    break;

                case "c_GTA_mode_Rfull":
                default:
                    GTA_FullRandom();
                    break;
            }

            if (GTAPoolList.FindAll(x => x.selected).Count > 0)
            {
                string SelectedPlayers = "";
                foreach (GTA_User u in GTAPoolList.FindAll(x => x.selected)) { SelectedPlayers += $"{u.userName},"; }
                client.SendMessage(channel, $"Gameviewer will start with the following players : {SelectedPlayers.TrimEnd(',')}.");
            }
        }

        private void GTA_FullRandom()
        {
            int nbPlayers = 0;
            foreach(Role r in config.GTA_roles)
            {
                nbPlayers += r.nbr;
            }

            Random rand = new Random();

            int SelectedPlayersCount = GTAPoolList.FindAll(x => x.selected).Count;
            int NotSelectedPlayersCount = GTAPoolList.FindAll(x => !x.selected).Count;

            while (SelectedPlayersCount < nbPlayers && NotSelectedPlayersCount > 0)
            {
                int i = rand.Next(0, GTAPoolList.FindAll(x => !x.selected).Count-1);
                GTAPoolList.FindAll(x => !x.selected)[i].selected = true;
                                
                SelectedPlayersCount = GTAPoolList.FindAll(x => x.selected).Count;
                NotSelectedPlayersCount = GTAPoolList.FindAll(x => !x.selected).Count;
            }
        }

        private void GTA_RandomByRole()
        {
            Random rand = new Random();

            foreach (Role role in config.GTA_roles)
            {
                int SelectedPlayersCount = GTAPoolList.FindAll(x => x.selected && x.role.name == role.name).Count;
                int NotSelectedPlayersCount = GTAPoolList.FindAll(x => !x.selected && x.role.name == role.name).Count;

                while (SelectedPlayersCount < role.nbr && NotSelectedPlayersCount > 0)
                {
                    int i = rand.Next(0, NotSelectedPlayersCount - 1);
                    GTAPoolList.FindAll(x => !x.selected && x.role.name == role.name)[i].selected = true;

                    SelectedPlayersCount = GTAPoolList.FindAll(x => x.selected && x.role.name == role.name).Count;
                    NotSelectedPlayersCount = GTAPoolList.FindAll(x => !x.selected && x.role.name == role.name).Count;
                }
            }
        }

        private void GTA_FIFO()
        {
            foreach (Role role in config.GTA_roles)
            {
                int SelectedPlayersCount = GTAPoolList.FindAll(x => x.selected && x.role.name == role.name).Count;
                int NotSelectedPlayersCount = GTAPoolList.FindAll(x => !x.selected && x.role.name == role.name).Count;

                while (SelectedPlayersCount < role.nbr && NotSelectedPlayersCount > 0)
                {
                    GTAPoolList.FindAll(x => !x.selected && x.role.name == role.name)[0].selected = true;

                    SelectedPlayersCount = GTAPoolList.FindAll(x => x.selected && x.role.name == role.name).Count;
                    NotSelectedPlayersCount = GTAPoolList.FindAll(x => !x.selected && x.role.name == role.name).Count;
                }
            }
        }

        private void GTA_LIFO()
        {
            foreach (Role role in config.GTA_roles)
            {
                int SelectedPlayersCount = GTAPoolList.FindAll(x => x.selected && x.role.name == role.name).Count;
                int NotSelectedPlayersCount = GTAPoolList.FindAll(x => !x.selected && x.role.name == role.name).Count;

                while (SelectedPlayersCount < role.nbr && NotSelectedPlayersCount > 0)
                {
                    int i = GTAPoolList.FindAll(x => !x.selected && x.role.name == role.name).Count;
                    GTAPoolList.FindAll(x => !x.selected && x.role.name == role.name)[i - 1].selected = true;

                    SelectedPlayersCount = GTAPoolList.FindAll(x => x.selected && x.role.name == role.name).Count;
                    NotSelectedPlayersCount = GTAPoolList.FindAll(x => !x.selected && x.role.name == role.name).Count;
                }
            }
        }

        private void c_ResetSelection_Click(object sender, EventArgs e)
        {
            if (GTA_status) return;
            GTAPoolList.ForEach(x => x.selected = false);
        }

        private void c_GTA_Reset_Click(object sender, EventArgs e)
        {
            if (GTA_status) return;
            GTAList.Clear();
        }

        private void SHubMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.SendMessage(channel, $"{config.BotName}.exe a cessé de fonctionner.");
        }

        private void SHubMain_Load(object sender, EventArgs e)
        {
            GetControlsColors(Controls);
        }

        private void GetControlsColors(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                Debug.WriteLine($"[CONTROL={c.Name}] {c.ForeColor} | {c.BackColor}");
                if (c.Controls.Count > 0) GetControlsColors(c.Controls);
            }
        }

        private void SwitchColor(Control.ControlCollection controls)
        {
            foreach(Control c in controls)
            {
                switch (c.ForeColor.Name)
                {
                    case "ControlText":
                        c.ForeColor = Color.White;
                        break;

                    case "White":
                        c.ForeColor = SystemColors.ControlText;
                        break;

                    case "WindowText":
                        c.ForeColor = Color.LightCyan;
                        break;

                    case "LightCyan":
                        c.ForeColor = SystemColors.WindowText;
                        break;
                }

                switch (c.BackColor.Name)
                {
                    case "Control":
                        c.BackColor = SystemColors.ControlDark;
                        break;

                    case "ControlDark":
                        c.BackColor = SystemColors.Control;
                        break;
                }

                if (c.Controls.Count > 0) SwitchColor(c.Controls);
            }
        }

        private void c_VisualMode_Click(object sender, EventArgs e)
        {
            SwitchColor(Controls);
        }
    }
}
