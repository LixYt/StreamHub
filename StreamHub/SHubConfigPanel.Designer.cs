
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
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.c_BotName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.GetToken = new System.Windows.Forms.LinkLabel();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.groupBox4.Controls.Add(this.radioButton4);
            this.groupBox4.Controls.Add(this.radioButton3);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.listView1);
            this.groupBox4.Location = new System.Drawing.Point(13, 329);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(383, 234);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gameviewer Team Assembler";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(174, 199);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(110, 19);
            this.radioButton4.TabIndex = 8;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Last In, First Out";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(174, 174);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(111, 19);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "First In, First Out";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(173, 149);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(90, 19);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Random full";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(173, 123);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(109, 19);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Random by role";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(106, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(212, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "role + comande + quantité dans le role";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(87, 204);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Remove";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 205);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "New";
            this.button3.UseVisualStyleBackColor = true;
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
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(5, 47);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(157, 151);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
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
            // SHubConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 616);
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox c_ChannelName;
        private System.Windows.Forms.TextBox c_ommand;
        private System.Windows.Forms.TextBox c_BotName;
        private System.Windows.Forms.CheckBox c_ViewerPool_SubBonusByTiers;
        private System.Windows.Forms.TextBox c_ViewerPool_RegisterCommand;
        private System.Windows.Forms.Button c_Save;
        private System.Windows.Forms.LinkLabel GetToken;
    }
}