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

        private string nameValue;
        private string commandValue;
        private int nbrValue;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
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

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
