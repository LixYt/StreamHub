using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Client.Models;

namespace StreamerGame
{
    public class StreamConfig
    {
        public string ClientID = "";
        public string ChannelName = "";
        public string AccessToken = "";
        public string RefreshToken = "";

        public string CommandSymbol = "=";
        public string BotName = "TheBot";

        public ConnectionCredentials GetCredential()
        {
            return new ConnectionCredentials(ChannelName, AccessToken);
        }



    }
}
