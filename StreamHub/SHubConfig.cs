using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        public List<Role> GTA_roles = new List<Role>();
        public string GTA_mode = "";

        public int Overlay_x = 1;
        public int Overlay_y = 1;
        public int Overlay_width = 800;
        public int Overlay_height = 600;
        public string Overlay_monitor = "";
        public int Overlay_FontSize = 20;

        public List<RoleVote> RoleVotes = new List<RoleVote>();

        public string Twitch_ClientID = "";
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

    [Serializable]
    public class Role : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() { return nameValue; }

        public string name { get { return nameValue; } set { nameValue = value; NotifyPropertyChanged(); } }
        public string command { get { return commandValue; } set { commandValue = value; NotifyPropertyChanged(); } }
        public int nbr { get { return nbrValue; } set { nbrValue = value; NotifyPropertyChanged(); } }

        public string FormatteCommand(string Symbol) { return Symbol + command; }

        protected string nameValue;
        protected string commandValue;
        protected int nbrValue;

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Serializable]
    public class RoleVote : Role
    {
        public string UserNames { get { return UserNamesValue; } set { UserNamesValue = value; NotifyPropertyChanged(); } }
        protected string UserNamesValue = "";

        public string FormattedCommandDont(string Symbol) { return Symbol + "Dont" + command; }
    }

    [Serializable]
    public class GTA_User : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() { return userName; }

        public string userName { get { return userNameValue; } set { userNameValue = value; NotifyPropertyChanged(); } }
        public Role role { get { return roleValue; } set { roleValue = value; NotifyPropertyChanged(); } }
        public bool selected { get { return selectedValue; } set { selectedValue = value; NotifyPropertyChanged(); } }

        private string userNameValue;
        private Role roleValue;
        private bool selectedValue;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Serializable]
    public class GameUser : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public string UserName { get { return userNameValue; } set { userNameValue = value; NotifyPropertyChanged(); } }
        public DateTime? Connection { get { return connectionValue; } set { connectionValue = value; NotifyPropertyChanged(); } }
        public DateTime? Disconnection { get { return disconnectionValue; } set { disconnectionValue = value; NotifyPropertyChanged(); } }

        private string userNameValue;
        private DateTime? connectionValue;
        private DateTime? disconnectionValue;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
