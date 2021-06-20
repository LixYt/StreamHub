
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.c_Overlay_FontSize = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.c_overlay_currentH = new System.Windows.Forms.Label();
            this.c_overlay_currentW = new System.Windows.Forms.Label();
            this.c_overlay_currentY = new System.Windows.Forms.Label();
            this.c_overlay_currentX = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.c_overlay_display = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.c_overlay_height = new System.Windows.Forms.TrackBar();
            this.c_overlay_width = new System.Windows.Forms.TrackBar();
            this.c_overlay_y = new System.Windows.Forms.TrackBar();
            this.c_overlay_x = new System.Windows.Forms.TrackBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.c_Twitch_ClientID = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_roles)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_Overlay_FontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_overlay_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_overlay_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_overlay_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_overlay_x)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_Save
            // 
            this.c_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_Save.Location = new System.Drawing.Point(695, 482);
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
            this.button2.Location = new System.Drawing.Point(776, 482);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel and Exit";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Client ID";
            // 
            // c_ClientID
            // 
            this.c_ClientID.Location = new System.Drawing.Point(124, 37);
            this.c_ClientID.MaxLength = 1000;
            this.c_ClientID.Name = "c_ClientID";
            this.c_ClientID.Size = new System.Drawing.Size(314, 23);
            this.c_ClientID.TabIndex = 3;
            // 
            // c_ChannelName
            // 
            this.c_ChannelName.Location = new System.Drawing.Point(124, 66);
            this.c_ChannelName.MaxLength = 1000;
            this.c_ChannelName.Name = "c_ChannelName";
            this.c_ChannelName.Size = new System.Drawing.Size(314, 23);
            this.c_ChannelName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Channel name";
            // 
            // c_AccessToken
            // 
            this.c_AccessToken.Location = new System.Drawing.Point(124, 95);
            this.c_AccessToken.MaxLength = 1000;
            this.c_AccessToken.Name = "c_AccessToken";
            this.c_AccessToken.PasswordChar = '*';
            this.c_AccessToken.Size = new System.Drawing.Size(314, 23);
            this.c_AccessToken.TabIndex = 7;
            this.c_AccessToken.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Acces Token";
            // 
            // c_RefreshToken
            // 
            this.c_RefreshToken.Location = new System.Drawing.Point(124, 124);
            this.c_RefreshToken.MaxLength = 1000;
            this.c_RefreshToken.Name = "c_RefreshToken";
            this.c_RefreshToken.PasswordChar = '*';
            this.c_RefreshToken.Size = new System.Drawing.Size(314, 23);
            this.c_RefreshToken.TabIndex = 9;
            this.c_RefreshToken.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 127);
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
            this.groupBox3.Location = new System.Drawing.Point(490, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(397, 137);
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
            this.c_CommandSymbol.Location = new System.Drawing.Point(124, 153);
            this.c_CommandSymbol.MaxLength = 1;
            this.c_CommandSymbol.Name = "c_CommandSymbol";
            this.c_CommandSymbol.Size = new System.Drawing.Size(35, 23);
            this.c_CommandSymbol.TabIndex = 14;
            this.c_CommandSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 156);
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
            this.groupBox4.Location = new System.Drawing.Point(19, 298);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(465, 205);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gameviewer Team Assembler";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(342, 23);
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
            this.c_roles.RowTemplate.Height = 25;
            this.c_roles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.c_roles.Size = new System.Drawing.Size(331, 150);
            this.c_roles.TabIndex = 9;
            // 
            // c_GTA_modeLIFO
            // 
            this.c_GTA_modeLIFO.AutoSize = true;
            this.c_GTA_modeLIFO.Location = new System.Drawing.Point(345, 118);
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
            this.c_GTA_modeFIFO.Location = new System.Drawing.Point(345, 93);
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
            this.c_GTA_mode_Rfull.Location = new System.Drawing.Point(344, 68);
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
            this.c_GTA_modeRR.Location = new System.Drawing.Point(344, 42);
            this.c_GTA_modeRR.Name = "c_GTA_modeRR";
            this.c_GTA_modeRR.Size = new System.Drawing.Size(109, 19);
            this.c_GTA_modeRR.TabIndex = 5;
            this.c_GTA_modeRR.Text = "Random by role";
            this.c_GTA_modeRR.UseVisualStyleBackColor = true;
            this.c_GTA_modeRR.CheckedChanged += new System.EventHandler(this.c_GTA_modeLIFO_CheckedChanged);
            // 
            // c_RemoveRole
            // 
            this.c_RemoveRole.Location = new System.Drawing.Point(344, 168);
            this.c_RemoveRole.Name = "c_RemoveRole";
            this.c_RemoveRole.Size = new System.Drawing.Size(89, 23);
            this.c_RemoveRole.TabIndex = 3;
            this.c_RemoveRole.Text = "Remove role";
            this.c_RemoveRole.UseVisualStyleBackColor = true;
            this.c_RemoveRole.Click += new System.EventHandler(this.c_RemoveRole_Click);
            // 
            // c_AddRole
            // 
            this.c_AddRole.Location = new System.Drawing.Point(344, 143);
            this.c_AddRole.Name = "c_AddRole";
            this.c_AddRole.Size = new System.Drawing.Size(89, 23);
            this.c_AddRole.TabIndex = 2;
            this.c_AddRole.Text = "Add role";
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
            this.c_BotName.Location = new System.Drawing.Point(244, 153);
            this.c_BotName.MaxLength = 1000;
            this.c_BotName.Name = "c_BotName";
            this.c_BotName.Size = new System.Drawing.Size(194, 23);
            this.c_BotName.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(178, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Bot Name";
            // 
            // GetToken
            // 
            this.GetToken.AutoSize = true;
            this.GetToken.Location = new System.Drawing.Point(342, 19);
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
            this.c_botVerif.Location = new System.Drawing.Point(270, 179);
            this.c_botVerif.Name = "c_botVerif";
            this.c_botVerif.Size = new System.Drawing.Size(168, 15);
            this.c_botVerif.TabIndex = 18;
            this.c_botVerif.TabStop = true;
            this.c_botVerif.Text = "Request twitch bot verification";
            this.c_botVerif.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.c_botVerif_LinkClicked);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.c_Overlay_FontSize);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.c_overlay_currentH);
            this.groupBox5.Controls.Add(this.c_overlay_currentW);
            this.groupBox5.Controls.Add(this.c_overlay_currentY);
            this.groupBox5.Controls.Add(this.c_overlay_currentX);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.c_overlay_display);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.c_overlay_height);
            this.groupBox5.Controls.Add(this.c_overlay_width);
            this.groupBox5.Controls.Add(this.c_overlay_y);
            this.groupBox5.Controls.Add(this.c_overlay_x);
            this.groupBox5.Location = new System.Drawing.Point(490, 151);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(397, 242);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Twitch screen overlay";
            // 
            // c_Overlay_FontSize
            // 
            this.c_Overlay_FontSize.Location = new System.Drawing.Point(230, 209);
            this.c_Overlay_FontSize.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.c_Overlay_FontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.c_Overlay_FontSize.Name = "c_Overlay_FontSize";
            this.c_Overlay_FontSize.Size = new System.Drawing.Size(120, 23);
            this.c_Overlay_FontSize.TabIndex = 28;
            this.c_Overlay_FontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(144, 211);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 15);
            this.label15.TabIndex = 27;
            this.label15.Text = "FontSize";
            // 
            // c_overlay_currentH
            // 
            this.c_overlay_currentH.AutoSize = true;
            this.c_overlay_currentH.Location = new System.Drawing.Point(18, 180);
            this.c_overlay_currentH.Name = "c_overlay_currentH";
            this.c_overlay_currentH.Size = new System.Drawing.Size(13, 15);
            this.c_overlay_currentH.TabIndex = 26;
            this.c_overlay_currentH.Text = "0";
            // 
            // c_overlay_currentW
            // 
            this.c_overlay_currentW.AutoSize = true;
            this.c_overlay_currentW.Location = new System.Drawing.Point(18, 147);
            this.c_overlay_currentW.Name = "c_overlay_currentW";
            this.c_overlay_currentW.Size = new System.Drawing.Size(13, 15);
            this.c_overlay_currentW.TabIndex = 25;
            this.c_overlay_currentW.Text = "0";
            // 
            // c_overlay_currentY
            // 
            this.c_overlay_currentY.AutoSize = true;
            this.c_overlay_currentY.Location = new System.Drawing.Point(18, 109);
            this.c_overlay_currentY.Name = "c_overlay_currentY";
            this.c_overlay_currentY.Size = new System.Drawing.Size(13, 15);
            this.c_overlay_currentY.TabIndex = 24;
            this.c_overlay_currentY.Text = "0";
            // 
            // c_overlay_currentX
            // 
            this.c_overlay_currentX.AutoSize = true;
            this.c_overlay_currentX.Location = new System.Drawing.Point(18, 71);
            this.c_overlay_currentX.Name = "c_overlay_currentX";
            this.c_overlay_currentX.Size = new System.Drawing.Size(13, 15);
            this.c_overlay_currentX.TabIndex = 23;
            this.c_overlay_currentX.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 15);
            this.label14.TabIndex = 22;
            this.label14.Text = "Screen";
            // 
            // c_overlay_display
            // 
            this.c_overlay_display.FormattingEnabled = true;
            this.c_overlay_display.Location = new System.Drawing.Point(103, 20);
            this.c_overlay_display.Name = "c_overlay_display";
            this.c_overlay_display.Size = new System.Drawing.Size(259, 23);
            this.c_overlay_display.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 15);
            this.label13.TabIndex = 20;
            this.label13.Text = "Height";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 15);
            this.label12.TabIndex = 19;
            this.label12.Text = "Width";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "V Position";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "H Position";
            // 
            // c_overlay_height
            // 
            this.c_overlay_height.Location = new System.Drawing.Point(103, 163);
            this.c_overlay_height.Name = "c_overlay_height";
            this.c_overlay_height.Size = new System.Drawing.Size(259, 45);
            this.c_overlay_height.TabIndex = 3;
            this.c_overlay_height.TickFrequency = 10;
            this.c_overlay_height.ValueChanged += new System.EventHandler(this.c_overlay_height_ValueChanged);
            // 
            // c_overlay_width
            // 
            this.c_overlay_width.Location = new System.Drawing.Point(103, 126);
            this.c_overlay_width.Name = "c_overlay_width";
            this.c_overlay_width.Size = new System.Drawing.Size(259, 45);
            this.c_overlay_width.TabIndex = 2;
            this.c_overlay_width.TickFrequency = 10;
            this.c_overlay_width.ValueChanged += new System.EventHandler(this.c_overlay_width_ValueChanged);
            // 
            // c_overlay_y
            // 
            this.c_overlay_y.Location = new System.Drawing.Point(103, 91);
            this.c_overlay_y.Name = "c_overlay_y";
            this.c_overlay_y.Size = new System.Drawing.Size(259, 45);
            this.c_overlay_y.TabIndex = 1;
            this.c_overlay_y.TickFrequency = 10;
            this.c_overlay_y.ValueChanged += new System.EventHandler(this.c_overlay_y_ValueChanged);
            // 
            // c_overlay_x
            // 
            this.c_overlay_x.Location = new System.Drawing.Point(103, 56);
            this.c_overlay_x.Name = "c_overlay_x";
            this.c_overlay_x.Size = new System.Drawing.Size(259, 45);
            this.c_overlay_x.TabIndex = 0;
            this.c_overlay_x.TickFrequency = 10;
            this.c_overlay_x.ValueChanged += new System.EventHandler(this.c_overlay_x_ValueChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.c_ClientID);
            this.groupBox6.Controls.Add(this.GetToken);
            this.groupBox6.Controls.Add(this.c_botVerif);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.c_ChannelName);
            this.groupBox6.Controls.Add(this.c_BotName);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.c_AccessToken);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.c_CommandSymbol);
            this.groupBox6.Controls.Add(this.c_RefreshToken);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Location = new System.Drawing.Point(19, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(465, 206);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Twitch configuration";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.c_Twitch_ClientID);
            this.groupBox7.Location = new System.Drawing.Point(19, 215);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(465, 72);
            this.groupBox7.TabIndex = 22;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Discord configuration";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 15);
            this.label16.TabIndex = 4;
            this.label16.Text = "Client ID";
            // 
            // c_Twitch_ClientID
            // 
            this.c_Twitch_ClientID.Location = new System.Drawing.Point(124, 24);
            this.c_Twitch_ClientID.MaxLength = 1000;
            this.c_Twitch_ClientID.Name = "c_Twitch_ClientID";
            this.c_Twitch_ClientID.Size = new System.Drawing.Size(314, 23);
            this.c_Twitch_ClientID.TabIndex = 5;
            // 
            // SHubConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 517);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_Overlay_FontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_overlay_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_overlay_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_overlay_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_overlay_x)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar c_overlay_height;
        private System.Windows.Forms.TrackBar c_overlay_width;
        private System.Windows.Forms.TrackBar c_overlay_y;
        private System.Windows.Forms.TrackBar c_overlay_x;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox c_overlay_display;
        private System.Windows.Forms.Label c_overlay_currentH;
        private System.Windows.Forms.Label c_overlay_currentW;
        private System.Windows.Forms.Label c_overlay_currentY;
        private System.Windows.Forms.Label c_overlay_currentX;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown c_Overlay_FontSize;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox c_Twitch_ClientID;
    }
}