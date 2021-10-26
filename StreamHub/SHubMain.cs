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
using System.Text.RegularExpressions;
using System.IO;
using GameOverlay.Drawing;
using GameOverlay.Windows;
using Color = System.Drawing.Color;
using Graphics = GameOverlay.Drawing.Graphics;
using SolidBrush = GameOverlay.Drawing.SolidBrush;
using Font = GameOverlay.Drawing.Font;
using Image = GameOverlay.Drawing.Image;
using Rectangle = GameOverlay.Drawing.Rectangle;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using Point = GameOverlay.Drawing.Point;

namespace StreamHub
{
    public partial class SHubMain : Form
    {
        private TwitchClient client;
        private SHubConfig config;

        private bool ViewerPool_Status = false;
        private bool GTA_status = false;
        private bool RoleVote_status = false;
        string channel = "";
        string BotName = "";

        public List<string> ViewerPoolList { get; set; } = new List<string>();
        public List<GTA_User> GTAPoolList { get; set; } = new List<GTA_User>();
        public List<string> Voters { get; set; } = new List<string>();
        public List<GameUser> ConnectedUsers { get; set; } = new List<GameUser>();

        private BindingList<GameUser> UsersList;
        private BindingList<GTA_User> GTAList;
        private BindingList<RoleVote> VoteList;
        private string SelectedUser = "";

        private readonly GraphicsWindow _window;
        private readonly Dictionary<string, SolidBrush> _brushes;
        private readonly Dictionary<string, Font> _fonts;
        private readonly Dictionary<string, Image> _images;

        private Geometry _gridGeometry;

        private List<string> LastLines = new List<string>();

        private readonly DiscordSocketClient _client;

        List<string> ExcludedNames = new List<string>();

        public SHubMain(SHubConfig cfg)
        {
            InitializeComponent();

            #region Load Configuration
            cfg = cfg ?? new SHubConfig();
            config = cfg;

            config.Overlay_FontSize = (config.Overlay_FontSize == 0 ? 14 : config.Overlay_FontSize);

            SHubConfigPanel ConfigPannel = new SHubConfigPanel(config);
            while (!config.isSetup())
            {
                DialogResult r = MessageBox.Show("Setting incomplete. Retry or Quit software ?", "Configuration issue", MessageBoxButtons.RetryCancel);
                if (r == DialogResult.Retry) { ConfigPannel.ShowDialog(); }
                else { Load += (s, e) => Close(); break; }
            }

            Text = $"{config.BotName}";
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

                client.Connect();

                ExcludedNames.Add(client.TwitchUsername);
                //ExcludedNames.Add(client.JoinedChannels)
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            #endregion

            #region Twitch_Features
            c_GTAPool.AutoGenerateColumns = true;

            //Bindings
            GTAList = new BindingList<GTA_User>(GTAPoolList);
            BindingSource source = new BindingSource(GTAList, null);
            c_GTAPool.DataSource = source;

            VoteList = new BindingList<RoleVote>(config.RoleVotes);
            BindingSource sourceVoteRole = new BindingSource(VoteList, null);
            c_VotesRoles.DataSource = sourceVoteRole;

            UsersList = new BindingList<GameUser>(ConnectedUsers);
            BindingSource sourceUsers = new BindingSource(UsersList, null);
            c_ConnectedUsers.DataSource = sourceUsers;

            //txt File output for OBS
            UpdateObsFiles();
            UpdateGTACount();
            #endregion

            #region Overlay
            _brushes = new Dictionary<string, SolidBrush>();
            _fonts = new Dictionary<string, Font>();
            _images = new Dictionary<string, Image>();

            var gfx = new Graphics()
            {
                MeasureFPS = true,
                PerPrimitiveAntiAliasing = true,
                TextAntiAliasing = true
            };
            
            _window = new GraphicsWindow(config.Overlay_width, 1080-config.Overlay_height, config.Overlay_width, config.Overlay_height, gfx)
            {
                FPS = 30,
                IsTopmost = true,
                IsVisible = true
            };

            _window.DestroyGraphics += _window_DestroyGraphics;
            _window.DrawGraphics += _window_DrawGraphics;
            _window.SetupGraphics += _window_SetupGraphics;

            _window.Create();
            //_window.Join(); //seems to replace or take over the WinForm
            #endregion

            #region Discord
            _client = new DiscordSocketClient();

            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;
            _client.MessageReceived += MessageReceivedAsync;

            _ = DiscordTask();
            #endregion

            #region RolesVoteFeature
            
            #endregion
        }



        #region Discord Events
        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }
        private Task ReadyAsync()
        {
            Console.WriteLine($"{_client.CurrentUser} is connected!");

            return Task.CompletedTask;
        }
        private async Task MessageReceivedAsync(SocketMessage message)
        {
            // The bot should never respond to itself.
            if (message.Author.Id == _client.CurrentUser.Id)
                return;

            if (message.Content == "!ping")
                await message.Channel.SendMessageAsync("pong!");
        }
        #endregion

        #region Disocrd Actions
        private async Task DiscordTask()
        {
            await _client.LoginAsync(TokenType.Bot, config.Twitch_ClientID);
            await _client.StartAsync();
            //need to add an URL to join the bot to the discord server
            //https://discord.com/api/oauth2/authorize?client_id=157730590492196864&scope=bot&permissions=1
            //need a URL link to create a bot account + document it
            //https://discord.com/developers/applications#top
        }
        #endregion

        #region Overlay events
        private void _window_DestroyGraphics(object sender, DestroyGraphicsEventArgs e)
        {
            foreach (var pair in _brushes) pair.Value.Dispose();
            foreach (var pair in _fonts) pair.Value.Dispose();
            foreach (var pair in _images) pair.Value.Dispose();
        }
        private void _window_SetupGraphics(object sender, SetupGraphicsEventArgs e)
        {
            var gfx = e.Graphics;

            if (e.RecreateResources)
            {
                foreach (var pair in _brushes) pair.Value.Dispose();
                foreach (var pair in _images) pair.Value.Dispose();
            }

            _brushes["black"] = gfx.CreateSolidBrush(0, 0, 0);
            _brushes["white"] = gfx.CreateSolidBrush(255, 255, 255);
            _brushes["red"] = gfx.CreateSolidBrush(255, 0, 0);
            _brushes["green"] = gfx.CreateSolidBrush(0, 255, 0);
            _brushes["blue"] = gfx.CreateSolidBrush(0, 0, 255);
            _brushes["lightBlue"] = gfx.CreateSolidBrush(0, 255, 255);
            _brushes["background"] = gfx.CreateSolidBrush(0, 0, 0, 0);
            _brushes["grid"] = gfx.CreateSolidBrush(255, 255, 255, 0.2f);
            _brushes["random"] = gfx.CreateSolidBrush(0, 0, 0);

            if (e.RecreateResources) return;

            SetOverlayFonts();

            //_gridBounds = new Rectangle(20, 60, gfx.Width - 20, gfx.Height - 20);
            _gridGeometry = gfx.CreateGeometry();

            _gridGeometry.Close();
        }

        public void SetOverlayFonts()
        {
            var gfx = _window.Graphics;

            _fonts.Clear();
            _fonts["arial"] = gfx.CreateFont("Arial", 12);
            _fonts["consolas"] = gfx.CreateFont("Consolas", config.Overlay_FontSize);
        }

        private void _window_DrawGraphics(object sender, DrawGraphicsEventArgs e)
        {
            try
            {
                Graphics gfx = e.Graphics;
                if (_window.X != config.Overlay_x || _window.Y != config.Overlay_y || _window.Width != config.Overlay_width || _window.Height != config.Overlay_height)
                {
                    _window.X = config.Overlay_x;
                    _window.Y = config.Overlay_y;
                    _window.Width = config.Overlay_width;
                    _window.Height = config.Overlay_height;
                    _window.Recreate();
                }

                if (_fonts["consolas"].FontSize != config.Overlay_FontSize) SetOverlayFonts();

                var infoText = new StringBuilder().ToString();
                foreach (string s in LastLines)
                {
                    string newLine = $"{s}\r\n";
                    Point p = gfx.MeasureString(_fonts["consolas"], config.Overlay_FontSize, newLine);

                    if (p.X > _window.Width)
                    {
                        string newLines = "";
                        newLine = s;

                        float ratio = _window.Width / p.X;
                        float part = p.X / _window.Width;
                        float lenString = ratio * newLine.Length;

                        for (int i = 1; i < part + 1; i++)
                        {
                            float lenNewLines = (newLine.Length < lenString ? newLine.Length - 1 : (int)lenString); ;
                            newLines += $"{newLine.Substring(0, (int)lenNewLines)}\r\n";
                            newLine = newLine[(int)lenNewLines..];
                        }

                        infoText = new StringBuilder().Append(infoText).Append(newLines).ToString();
                    }
                    else
                    {
                        infoText = new StringBuilder().Append(infoText).Append(newLine).ToString();
                    }
                }

                gfx.ClearScene(_brushes["background"]);

                gfx.DrawTextWithBackground(_fonts["consolas"], _brushes["lightBlue"], gfx.CreateSolidBrush(0, 0, 0, 128), 0, 0, infoText);
                gfx.DrawGeometry(_gridGeometry, _brushes["grid"], 1.0f);
            }
            catch (Exception ex) { Debug.WriteLine("An error has occured while updating twitch chat overlay."); }
            

        }
        #endregion

        #region Twitch Events
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
            if (!e.ChatMessage.Message.StartsWith(config.CommandSymbol))
            {
                LastLines.Add($"{e.ChatMessage.Username} : {e.ChatMessage.Message}");
                if (LastLines.Count > 15) LastLines.RemoveAt(0);

                /* VierwerPool dice tool */
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

                return;
            }

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
            /* vvv Role Voter */

            if (config.RoleVotes.Exists(x => x.FormatteCommand(config.CommandSymbol) == e.ChatMessage.Message)
                && RoleVote_status && !config.RoleVotes.Exists(x => x.UserNames.Contains(e.ChatMessage.Username)))
            {
                Invoke(new Action(() => config.RoleVotes.FindLast(x => x.command == e.ChatMessage.Message.Substring(1)).UserNames +=$"{e.ChatMessage.Username},"));
                Invoke(new Action(() => config.RoleVotes.FindLast(x => x.command == e.ChatMessage.Message.Substring(1)).nbr +=1));
            }
            if (config.RoleVotes.Exists(x => x.FormattedCommandDont(config.CommandSymbol) == e.ChatMessage.Message)
                && RoleVote_status && config.RoleVotes.Exists(x => x.UserNames.Contains(e.ChatMessage.Username)))
            {
                string NewUserNames = config.RoleVotes.FindLast(x => x.command == e.ChatMessage.Message.Substring(5)).UserNames;
                NewUserNames = NewUserNames.Replace($"{e.ChatMessage.Username},", "");
                Invoke(new Action(() => config.RoleVotes.FindLast(x => x.command == e.ChatMessage.Message.Substring(5)).UserNames = NewUserNames));
                Invoke(new Action(() => config.RoleVotes.FindLast(x => x.command == e.ChatMessage.Message.Substring(5)).nbr -= 1));
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
        private void Client_OnUserJoined(object sender, OnUserJoinedArgs e)
        {
            try
            {
                if (ExcludedNames.Contains(e.Username)) return;
                Invoke(new Action(() => UsersList.Add(new GameUser() { UserName = e.Username, Connection = DateTime.Now, Disconnection = null })));
            }
            catch (Exception ex) { Debug.WriteLine($"Twitch[OnUserJoined]({e.Username}) {ex.Message}"); }
        }
        private void Client_OnUserLeft(object sender, OnUserLeftArgs e)
        {
            try 
            {
                GameUser g = ConnectedUsers.FindLast(x => x.UserName == e.Username);
                g.Disconnection = DateTime.Now;
            }
            catch (Exception ex) { Debug.WriteLine($"Twitch[OnUserJoined]({e.Username}) {ex.Message}"); }
        }

        #endregion

        #region Twitch Actions
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
        private void GTA_FullRandom()
        {
            int nbPlayers = 0;
            foreach (Role r in config.GTA_roles)
            {
                nbPlayers += r.nbr;
            }

            Random rand = new Random();

            int SelectedPlayersCount = GTAPoolList.FindAll(x => x.selected).Count;
            int NotSelectedPlayersCount = GTAPoolList.FindAll(x => !x.selected).Count;

            while (SelectedPlayersCount < nbPlayers && NotSelectedPlayersCount > 0)
            {
                int i = rand.Next(0, GTAPoolList.FindAll(x => !x.selected).Count - 1);
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
        #endregion

        #region Form events
        private void SHubMain_Load(object sender, EventArgs e)
        {

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
            if (GTA_status || GTAPoolList.FindAll(x => x.selected).Count > 0) return;
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
            try { client.SendMessage(channel, $"/me a cessé de fonctionner."); } catch (Exception) { }
        }
        private void c_VisualMode_Click(object sender, EventArgs e)
        {
            SwitchColor(this);
        }
        private void c_Overlay_Click(object sender, EventArgs e)
        {
            if (!_window.IsPaused) { _window.Hide(); _window.Pause(); c_Overlay.ForeColor = Color.Red; }
            else { _window.Unpause(); _window.Show(); c_Overlay.ForeColor = Color.Green; }
        }
        #endregion

        #region Form Actions
        private void GetControlsColors(object o)
        {
            if (o is Form f)
            {
                Debug.WriteLine($"[CONTROL={f.Name}/{o.GetType()}] {f.ForeColor} | {f.BackColor}");
                if (f.Controls.Count > 0) GetControlsColors(f.Controls);
            }
            else if (o is Control c)
            {
                if (o is TabControl t) { foreach (TabPage p in t.TabPages) { GetControlsColors(p); } }
                if (o is TabPage pa) { foreach (Control cl in pa.Controls) { GetControlsColors(cl.Controls); } }

                Debug.WriteLine($"[CONTROL={c.Name}/{o.GetType()}] {c.ForeColor} | {c.BackColor}");
                foreach (Control cl in c.Controls)
                {
                    Debug.WriteLine($"[CONTROL={cl.Name}/{o.GetType()}] {cl.ForeColor} | {cl.BackColor}");
                    if (c.Controls.Count > 0) GetControlsColors(c.Controls);
                }
            }
            else if (o is ControlCollection cc)
            {
                foreach (Control cl in cc) { GetControlsColors(cl); }
            }
        }
        private void SwitchColor(object o)
        {
            if (o is Form f)
            {
                if (f.Controls.Count > 0) SwitchColor(f.Controls);

                f.ForeColor = (f.ForeColor == SystemColors.ControlText ? Color.White : SystemColors.ControlText);
                f.BackColor = (f.ForeColor == Color.White ? SystemColors.ControlDark : Color.White);
            }
            else if (o is Control c)
            {
                if (o is TabControl t) { foreach (TabPage p in t.TabPages) { SwitchColor(p); } }
                if (o is TabPage pa) { foreach (Control cl in pa.Controls) { SwitchColor(cl.Controls); } }

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
                    default:
                        Debug.WriteLine($"[Darkmode] Forecolor {c.ForeColor.Name} not defined in switch for {c.Name} as {c.GetType()}");
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
                    case "Transparent":
                        c.BackColor = SystemColors.ControlDark;
                        break;
                    default:
                        Debug.WriteLine($"[Darkmode] BackColor {c.BackColor.Name} not defined in switch for {c.Name} as {c.GetType()}");
                        break;
                }

                foreach (Control cl in c.Controls) { SwitchColor(cl.Controls); }
            }
            else if (o is ControlCollection cc)
            {
                foreach (Control cl in cc) { SwitchColor(cl); }
            }
        }


        #endregion

        private void c_StartStopVotes_Click(object sender, EventArgs e)
        {
            if (RoleVote_status)
            {
                c_StartStopVotes.ForeColor = Color.Red;
                RoleVote_status = false;
                client.SendMessage(channel, "Vote Stopped");
            }
            else
            {
                c_StartStopVotes.ForeColor = Color.Green;
                RoleVote_status = true;
                client.SendMessage(channel, "Vote Started");
            }
        }
    }
}
