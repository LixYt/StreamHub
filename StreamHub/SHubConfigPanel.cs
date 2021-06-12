using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StreamHub
{
    public partial class SHubConfigPanel : Form
    {
        SHubConfig SHubConfiguration;

        private BindingList<Role> GTARoles;

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

            switch (SHubConfiguration.GTA_mode)
            {
                case "c_GTA_modeFIFO": c_GTA_modeFIFO.Checked = true; break;
                case "c_GTA_modeLIFO": c_GTA_modeLIFO.Checked = true; break;
                case "c_GTA_modeRR": c_GTA_modeRR.Checked = true; break;
                case "c_GTA_mode_Rfull": c_GTA_mode_Rfull.Checked = true; break;
            }

            GTARoles = new BindingList<Role>(SHubConfiguration.GTA_roles);
            SHubConfiguration.GTA_roles ??= new List<Role>();
            BindingSource source = new BindingSource(GTARoles, null);
            c_roles.DataSource = source;
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

            if (c_GTA_modeFIFO.Checked) SHubConfiguration.GTA_mode = c_GTA_modeFIFO.Name;
            if (c_GTA_modeLIFO.Checked) SHubConfiguration.GTA_mode = c_GTA_modeLIFO.Name;
            if (c_GTA_modeRR.Checked) SHubConfiguration.GTA_mode = c_GTA_modeRR.Name;
            if (c_GTA_mode_Rfull.Checked) SHubConfiguration.GTA_mode = c_GTA_mode_Rfull.Name;
        }

        private void SHubConfigPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SHubConfiguration.isSetup()) { DialogResult = DialogResult.OK; }
        }

        private void GetToken_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://twitchtokengenerator.com/") { UseShellExecute = true });
            MessageBox.Show("Choose 'Custom Scope Token' and keep the information generated in safe place.\r\n" +
                "Check all Helix scope and uncheck all V5 scope.\r\n" +
                "Once Gathered, put this information in the software.");
        }

        private void c_AddRole_Click(object sender, EventArgs e)
        {
            GTA_newRole f = new GTA_newRole();
            if (f.ShowDialog() == DialogResult.OK)
            {
                GTARoles.Add(new Role() { command = f.command, name = f.name, nbr = f.number });
            }
        }

        private void c_GTA_modeLIFO_CheckedChanged(object sender, EventArgs e)
        {
            if (c_GTA_modeFIFO.Checked) SHubConfiguration.GTA_mode = c_GTA_modeFIFO.Name;
            if (c_GTA_modeLIFO.Checked) SHubConfiguration.GTA_mode = c_GTA_modeLIFO.Name;
            if (c_GTA_modeRR.Checked) SHubConfiguration.GTA_mode = c_GTA_modeRR.Name;
            if (c_GTA_mode_Rfull.Checked) SHubConfiguration.GTA_mode = c_GTA_mode_Rfull.Name;
        }

        private void c_RemoveRole_Click(object sender, EventArgs e)
        {
            Role r = (Role)c_roles.SelectedRows[0].DataBoundItem;
            GTARoles.Remove(r);
        }

        private void c_botVerif_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://dev.twitch.tv/limit-increase") { UseShellExecute = true });
        }
    }
}
