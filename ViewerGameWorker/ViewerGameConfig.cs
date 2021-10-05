using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Models;

namespace ViewerGameWorker
{
    class ViewerGameConfig
    {
        public string ClientID { get; set; } = "";
        public string ChannelName { get; set; } = "";
        public string AccessToken { get; set; } = "";
        public string RefreshToken { get; set; } = "";
        
        public string CommandSymbol { get; set; } = "#";
        public string BotName { get; set; } = "";
        public string DbString { get; set; } = "Data Source=SERVER;Initial Catalog=DATABASE;Integrated Security=False;user id=USER;password=PASSWORD";
        public string GameTitle { get; set; } = "Game Name";
        public ConnectionCredentials GetCredential()
        {
            return new ConnectionCredentials(ChannelName, AccessToken);
        }

    }
}
