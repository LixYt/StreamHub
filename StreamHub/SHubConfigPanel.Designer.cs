
namespace StreamHub
{
    partial class SHubConfigPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.c_Save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.c_ClientID = new System.Windows.Forms.TextBox();
            this.c_ChannelName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.c_AccessToken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.c_RefreshToken = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.c_ViewerPool_SubBonus = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.c_ViewerPool_SubBonusByTiers = new System.Windows.Forms.CheckBox();
            this.c_ViewerPool_CanRollDice = new System.Windows.Forms.CheckBox();
            this.c_ViewerPool_RegisterCommand = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.c_CommandSymbol = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.c_roles = new System.Windows.Forms.DataGridView();
            this.c_GTA_modeLIFO = new System.Windows.Forms.RadioButton();
            this.c_GTA_modeFIFO = new System.Windows.Forms.RadioButton();
            this.c_GTA_mode_Rfull = new System.Windows.Forms.RadioButton();
            this.c_GTA_modeRR = new System.Windows.Forms.RadioButton();
            this.c_RemoveRole = new System.Windows.Forms.Button();
            this.c_AddRole = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.c_BotName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.GetToken = new System.Windows.Forms.LinkLabel();
            this.c_botVerif = new System.Windows.Forms.LinkLabel();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_roles)).BeginInit();
            this.SuspendLayout();
            // 
            // c_Save
            // 
            this.c_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_Save.Location = new System.Drawing.Point(440, 581);
            this.c_Save.Name = "c_Save";
            this.c_Save.Size = new System.Drawing.Size(75, 23);
            this.c_Save.TabIndex = 0;
            this.c_Save.Text = "Save";
            this.c_Save.UseVisualStyleBackColor = true;
            this.c_Save.Click += new System.EventHandler(this.c_Save_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(521, 581);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel and Exit";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Client ID";
            // 
            // c_ClientID
            // 
            this.c_ClientID.Location = new System.Drawing.Point(125, 10);
            this.c_ClientID.MaxLength = 1000;
            this.c_ClientID.Name = "c_ClientID";
            this.c_ClientID.Size = new System.Drawing.Size(359, 23);
            this.c_ClientID.TabIndex = 3;
            // 
            // c_ChannelName
            // 
            this.c_ChannelName.Location = new System.Drawing.Point(125, 39);
            this.c_ChannelName.MaxLength = 1000;
            this.c_ChannelName.Name = "c_ChannelName";
            this.c_ChannelName.Size = new System.Drawing.Size(359, 23);
            this.c_ChannelName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Channel name";
            // 
            // c_AccessToken
            // 
            this.c_AccessToken.Location = new System.Drawing.Point(125, 68);
            this.c_AccessToken.MaxLength = 1000;
            this.c_AccessToken.Name = "c_AccessToken";
            this.c_AccessToken.PasswordChar = '*';
            this.c_AccessToken.Size = new System.Drawing.Size(359, 23);
            this.c_AccessToken.TabIndex = 7;
            this.c_AccessToken.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Acces Token";
            // 
            // c_RefreshToken
            // 
            this.c_RefreshToken.Location = new System.Drawing.Point(125, 97);
            this.c_RefreshToken.MaxLength = 1000;
            this.c_RefreshToken.Name = "c_RefreshToken";
            this.c_RefreshToken.PasswordChar = '*';
            this.c_RefreshToken.Size = new System.Drawing.Size(359, 23);
            this.c_RefreshToken.TabIndex = 9;
            this.c_RefreshToken.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Refresh Token";
            // 
            // c_ViewerPool_SubBonus
            // 
            this.c_ViewerPool_SubBonus.AutoSize = true;
            this.c_ViewerPool_SubBonus.Location = new System.Drawing.Point(15, 22);
            this.c_ViewerPool_SubBonus.Name = "c_ViewerPool_SubBonus";
            this.c_ViewerPool_SubBonus.Size = new System.Drawing.Size(214, 19);
            this.c_ViewerPool_SubBonus.TabIndex = 10;
            this.c_ViewerPool_SubBonus.Text = "Sub have more chance to be picked";
            this.c_ViewerPool_SubBonus.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(-104, 253);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(-116, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.c_ViewerPool_SubBonusByTiers);
            this.groupBox3.Controls.Add(this.c_ViewerPool_CanRollDice);
            this.groupBox3.Controls.Add(this.c_ViewerPool_RegisterCommand);
            this.groupBox3.Controls.Add(this.c_ViewerPool_SubBonus);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(384, 142);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ViewerPool";
            // 
            // c_ViewerPool_SubBonusByTiers
            // 
            this.c_ViewerPool_SubBonusByTiers.AutoSize = true;
            this.c_ViewerPool_SubBonusByTiers.Enabled = false;
            this.c_ViewerPool_SubBonusByTiers.Location = new System.Drawing.Point(45, 47);
            this.c_ViewerPool_SubBonusByTiers.Name = "c_ViewerPool_SubBonusByTiers";
            this.c_ViewerPool_SubBonusByTiers.Size = new System.Drawing.Size(227, 19);
            this.c_ViewerPool_SubBonusByTiers.TabIndex = 16;
            this.c_ViewerPool_SubBonusByTiers.Text = "Sub T1 = x2 ; Sub T2 = x3 ; Sub T3 = x4";
            this.c_ViewerPool_SubBonusByTiers.UseVisualStyleBackColor = true;
            // 
            // c_ViewerPool_CanRollDice
            // 
            this.c_ViewerPool_CanRollDice.AutoSize = true;
            this.c_ViewerPool_CanRollDice.Location = new System.Drawing.Point(15, 106);
            this.c_ViewerPool_CanRollDice.Name = "c_ViewerPool_CanRollDice";
            this.c_ViewerPool_CanRollDice.Size = new System.Drawing.Size(180, 19);
            this.c_ViewerPool_CanRollDice.TabIndex = 15;
            this.c_ViewerPool_CanRollDice.Text = "Selected Viewer can roll dices";
            this.c_ViewerPool_CanRollDice.UseVisualStyleBackColor = true;
            // 
            // c_ViewerPool_RegisterCommand
            // 
            this.c_ViewerPool_RegisterCommand.Location = new System.Drawing.Point(175, 77);
            this.c_ViewerPool_RegisterCommand.Name = "c_ViewerPool_RegisterCommand";
            this.c_ViewerPool_RegisterCommand.Size = new System.Drawing.Size(187, 23);
            this.c_ViewerPool_RegisterCommand.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Enter The Pool command";
            // 
            // c_CommandSymbol
            // 
            this.c_CommandSymbol.Location = new System.Drawing.Point(125, 126);
            this.c_CommandSymbol.MaxLength = 1;
            this.c_CommandSymbol.Name = "c_CommandSymbol";
            this.c_CommandSymbol.Size = new System.Drawing.Size(35, 23);
            this.c_CommandSymbol.TabIndex = 14;
            this.c_CommandSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Command symbol";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.c_roles);
            this.groupBox4.Controls.Add(this.c_GTA_modeLIFO);
            this.groupBox4.Controls.Add(this.c_GTA_modeFIFO);
            this.groupBox4.Controls.Add(this.c_GTA_mode_Rfull);
            this.groupBox4.Controls.Add(this.c_GTA_modeRR);
            this.groupBox4.Controls.Add(this.c_RemoveRole);
            this.groupBox4.Controls.Add(this.c_AddRole);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(13, 329);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(619, 234);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gameviewer Team Assembler";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(494, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Selection mode";
            // 
            // c_roles
            // 
            this.c_roles.AllowUserToAddRows = false;
            this.c_roles.AllowUserToDeleteRows = false;
            this.c_roles.AllowUserToOrderColumns = true;
            this.c_roles.AllowUserToResizeRows = false;
            this.c_roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_roles.Location = new System.Drawing.Point(7, 42);
            this.c_roles.MultiSelect = false;
            this.c_roles.Name = "c_roles";
            this.c_roles.ReadOnly = true;
            this.c_roles.RowTemplate.Height = 25;
            this.c_roles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.c_roles.Size = new System.Drawing.Size(464, 150);
            this.c_roles.TabIndex = 9;
            // 
            // c_GTA_modeLIFO
            // 
            this.c_GTA_modeLIFO.AutoSize = true;
            this.c_GTA_modeLIFO.Location = new System.Drawing.Point(495, 126);
            this.c_GTA_modeLIFO.Name = "c_GTA_modeLIFO";
            this.c_GTA_modeLIFO.Size = new System.Drawing.Size(110, 19);
            this.c_GTA_modeLIFO.TabIndex = 8;
            this.c_GTA_modeLIFO.Text = "Last In, First Out";
            this.c_GTA_modeLIFO.UseVisualStyleBackColor = true;
            this.c_GTA_modeLIFO.CheckedChanged += new System.EventHandler(this.c_GTA_modeLIFO_CheckedChanged);
            // 
            // c_GTA_modeFIFO
            // 
            this.c_GTA_modeFIFO.AutoSize = true;
            this.c_GTA_modeFIFO.Location = new System.Drawing.Point(495, 101);
            this.c_GTA_modeFIFO.Name = "c_GTA_modeFIFO";
            this.c_GTA_modeFIFO.Size = new System.Drawing.Size(111, 19);
            this.c_GTA_modeFIFO.TabIndex = 7;
            this.c_GTA_modeFIFO.Text = "First In, First Out";
            this.c_GTA_modeFIFO.UseVisualStyleBackColor = true;
            this.c_GTA_modeFIFO.CheckedChanged += new System.EventHandler(this.c_GTA_modeLIFO_CheckedChanged);
            // 
            // c_GTA_mode_Rfull
            // 
            this.c_GTA_mode_Rfull.AutoSize = true;
            this.c_GTA_mode_Rfull.Checked = true;
            this.c_GTA_mode_Rfull.Location = new System.Drawing.Point(494, 76);
            this.c_GTA_mode_Rfull.Name = "c_GTA_mode_Rfull";
            this.c_GTA_mode_Rfull.Size = new System.Drawing.Size(90, 19);
            this.c_GTA_mode_Rfull.TabIndex = 6;
            this.c_GTA_mode_Rfull.TabStop = true;
            this.c_GTA_mode_Rfull.Text = "Random full";
            this.c_GTA_mode_Rfull.UseVisualStyleBackColor = true;
            this.c_GTA_mode_Rfull.CheckedChanged += new System.EventHandler(this.c_GTA_modeLIFO_CheckedChanged);
            // 
            // c_GTA_modeRR
            // 
            this.c_GTA_modeRR.AutoSize = true;
            this.c_GTA_modeRR.Location = new System.Drawing.Point(494, 50);
            this.c_GTA_modeRR.Name = "c_GTA_modeRR";
            this.c_GTA_modeRR.Size = new System.Drawing.Size(109, 19);
            this.c_GTA_modeRR.TabIndex = 5;
            this.c_GTA_modeRR.Text = "Random by role";
            this.c_GTA_modeRR.UseVisualStyleBackColor = true;
            this.c_GTA_modeRR.CheckedChanged += new System.EventHandler(this.c_GTA_modeLIFO_CheckedChanged);
            // 
            // c_RemoveRole
            // 
            this.c_RemoveRole.Location = new System.Drawing.Point(87, 197);
            this.c_RemoveRole.Name = "c_RemoveRole";
            this.c_RemoveRole.Size = new System.Drawing.Size(75, 23);
            this.c_RemoveRole.TabIndex = 3;
            this.c_RemoveRole.Text = "Remove";
            this.c_RemoveRole.UseVisualStyleBackColor = true;
            this.c_RemoveRole.Click += new System.EventHandler(this.c_RemoveRole_Click);
            // 
            // c_AddRole
            // 
            this.c_AddRole.Location = new System.Drawing.Point(6, 198);
            this.c_AddRole.Name = "c_AddRole";
            this.c_AddRole.Size = new System.Drawing.Size(75, 23);
            this.c_AddRole.TabIndex = 2;
            this.c_AddRole.Text = "New";
            this.c_AddRole.UseVisualStyleBackColor = true;
            this.c_AddRole.Click += new System.EventHandler(this.c_AddRole_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Roles";
            // 
            // c_BotName
            // 
            this.c_BotName.Location = new System.Drawing.Point(245, 126);
            this.c_BotName.MaxLength = 1000;
            this.c_BotName.Name = "c_BotName";
            this.c_BotName.Size = new System.Drawing.Size(239, 23);
            this.c_BotName.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(179, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Bot Name";
            // 
            // GetToken
            // 
            this.GetToken.AutoSize = true;
            this.GetToken.Location = new System.Drawing.Point(521, 10);
            this.GetToken.Name = "GetToken";
            this.GetToken.Size = new System.Drawing.Size(96, 15);
            this.GetToken.TabIndex = 18;
            this.GetToken.TabStop = true;
            this.GetToken.Text = "Get Twitch Token";
            this.GetToken.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GetToken_LinkClicked);
            // 
            // c_botVerif
            // 
            this.c_botVerif.AutoSize = true;
            this.c_botVerif.Location = new System.Drawing.Point(316, 152);
            this.c_botVerif.Name = "c_botVerif";
            this.c_botVerif.Size = new System.Drawing.Size(168, 15);
            this.c_botVerif.TabIndex = 18;
            this.c_botVerif.TabStop = true;
            this.c_botVerif.Text = "Request twitch bot verification";
            this.c_botVerif.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.c_botVerif_LinkClicked);
            // 
            // SHubConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 616);
            this.Controls.Add(this.c_botVerif);
            this.Controls.Add(this.GetToken);
            this.Controls.Add(this.c_BotName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.c_CommandSymbol);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.c_RefreshToken);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.c_AccessToken);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.c_ChannelName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.c_ClientID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.c_Save);
            this.Name = "SHubConfigPanel";
            this.Text = "Configuration panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SHubConfigPanel_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_roles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox c_ClientID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox c_AccessToken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox c_RefreshToken;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox c_ViewerPool_SubBonus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox c;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox c_ViewerPool_CanRollDice;
        private System.Windows.Forms.TextBox c_CommandSymbol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button c_AddRoke;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.RadioButton c_GTA_modeFIFO;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton c_GTA_modeRR;
        private System.Windows.Forms.RadioButton c_GTA_modeLIFO;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox c_ChannelName;
        private System.Windows.Forms.TextBox c_ommand;
        private System.Windows.Forms.TextBox c_BotName;
        private System.Windows.Forms.CheckBox c_ViewerPool_SubBonusByTiers;
        private System.Windows.Forms.TextBox c_ViewerPool_RegisterCommand;
        private System.Windows.Forms.Button c_Save;
        private System.Windows.Forms.LinkLabel GetToken;
        private System.Windows.Forms.Button c_AddRole;
        private System.Windows.Forms.Button c_RemoveRole;
        private System.Windows.Forms.DataGridView c_roles;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton c_GTA_mode_Rfull;
        private System.Windows.Forms.LinkLabel c_botVerif;
    }
}