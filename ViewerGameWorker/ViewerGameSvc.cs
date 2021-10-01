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
        private int CountMsg = 0;
        ViewerGameContext ctx;
        
        public ViewerGameSvc(ILogger<ViewerGameSvc> logger)
        {
            _logger = logger;
            Console.WriteLine($"Current dir = {Directory.GetCurrentDirectory()}");
            if (Load())
            {
                Console.WriteLine("Config loaded");
                Setup_Twitch();
                try
                {
                    var connString = "Data Source=code-ex.fr;Initial Catalog=JarLix;Integrated Security=False;user id=bot;password=Azerty123+";
                    ctx = new ViewerGameContext(connString);
                }
                catch(Exception ex) { _logger.LogError(ex.Message); }
                
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
                _logger.LogInformation($"Channel is : {channel}");
                await Task.Delay(3000, stoppingToken);
            }*/
        }

        

        #region Twitch
        public void Setup_Twitch()
        {
            #region Twitch
            try
            {
                TwitchClient = new TwitchClient();
                TwitchClient.Initialize(config.GetCredential(), config.ChannelName);
                TwitchClient.OnLog += Client_OnLog;
                TwitchClient.OnJoinedChannel += Client_OnJoinedChannel;
                TwitchClient.OnMessageReceived += Client_OnMessageReceived;
                TwitchClient.OnWhisperReceived += Client_OnWhisperReceived;
                TwitchClient.OnNewSubscriber += Client_OnNewSubscriber;
                TwitchClient.OnConnected += Client_OnConnected;
                TwitchClient.OnUserJoined += Client_OnUserJoined;
                TwitchClient.OnUserLeft += Client_OnUserLeft;
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
            if (!e.ChatMessage.Message.StartsWith(config.CommandSymbol)) //message is not a command
            {
                CountMsg++;
                Console.WriteLine($"Chat Message : " + CountMsg);

                return;
            }
            else //message is a command
            {
                string msg = e.ChatMessage.Message.Substring(1);
                switch (msg)
                {
                    case "test":
                        TwitchClient.SendMessage(channel, "Test succesfull");
                        break;
                }
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
                TwitchClient.SendMessage(channel, $"Bienvenu {e.Username}");
            }
            catch (Exception ex) { Console.WriteLine($"Twitch[OnUserJoined]({e.Username}) {ex.Message}"); }
        }
        private void Client_OnUserLeft(object sender, OnUserLeftArgs e)
        {
            try
            {
                //GameUser g = ConnectedUsers.FindLast(x => x.UserName == e.Username);
                //g.Disconnection = DateTime.Now;
            }
            catch (Exception ex) { Console.WriteLine($"Twitch[OnUserJoined]({e.Username}) {ex.Message}"); }
        }
        #endregion
    }
}
