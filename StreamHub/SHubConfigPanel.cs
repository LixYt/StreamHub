using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StreamHub
{
    public partial class SHubConfigPanel : Form
    {
        SHubConfig SHubConfiguration;

        public SHubConfigPanel(SHubConfig config)
        {            
            InitializeComponent();

            SHubConfiguration = config;

            c_ClientID.Text = SHubConfiguration.ClientID;
            c_AccessToken.Text = SHubConfiguration.AccessToken;
            c_ChannelName.Text = SHubConfiguration.ChannelName;
            c_RefreshToken.Text = SHubConfiguration.RefreshToken;
            c_CommandSymbol.Text = SHubConfiguration.CommandSymbol;
            c_BotName.Text = SHubConfiguration.BotName;
            c_ViewerPool_SubBonus.Checked = SHubConfiguration.ViewerPool_SubBonus;
            c_ViewerPool_SubBonusByTiers.Checked = SHubConfiguration.ViewerPool_SubBonusByTiers;
            c_ViewerPool_RegisterCommand.Text = SHubConfiguration.ViewerPool_RegisterCommand;
            c_ViewerPool_CanRollDice.Checked = SHubConfiguration.ViewerPool_CanRollDice;
        }

        private void c_Save_Click(object sender, EventArgs e)
        {
            SHubConfiguration.ClientID = c_ClientID.Text;
            SHubConfiguration.ChannelName = c_ChannelName.Text;
            SHubConfiguration.AccessToken = c_AccessToken.Text;
            SHubConfiguration.RefreshToken = c_RefreshToken.Text;
            SHubConfiguration.CommandSymbol = c_CommandSymbol.Text;
            SHubConfiguration.BotName = c_BotName.Text;
            SHubConfiguration.ViewerPool_SubBonus = c_ViewerPool_SubBonus.Checked;
            SHubConfiguration.ViewerPool_SubBonusByTiers = c_ViewerPool_SubBonusByTiers.Checked;
            SHubConfiguration.ViewerPool_RegisterCommand = c_ViewerPool_RegisterCommand.Text;
            SHubConfiguration.ViewerPool_CanRollDice = c_ViewerPool_CanRollDice.Checked;
        }

        private void SHubConfigPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SHubConfiguration.isSetup()) { DialogResult = DialogResult.OK; }
        }

        private void TwitchOAuth_Click(object sender, EventArgs e)
        {
            
        }
    }
}
