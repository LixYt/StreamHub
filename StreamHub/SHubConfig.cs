using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Client.Models;


namespace StreamHub
{
    [Serializable]
    public class SHubConfig
    {
        public string ClientID = "";
        public string ChannelName = "";
        public string AccessToken = "";
        public string RefreshToken = "";

        public string CommandSymbol = "=";
        public string BotName = "TheBot";

        public bool ViewerPool_SubBonus = false;
        public bool ViewerPool_SubBonusByTiers = false;
        public string ViewerPool_RegisterCommand = "";
        public bool ViewerPool_CanRollDice = false;


        public SHubConfig()
        {

        }

        public bool isSetup()
        {
            return (ClientID != "" && ChannelName != "" && AccessToken != "" && RefreshToken != "");
        }

        public ConnectionCredentials GetCredential()
        {
            return new ConnectionCredentials(ChannelName, AccessToken);
        }


    }
}
