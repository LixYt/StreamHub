
namespace StreamerGame
{
    partial class SGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabViewers = new System.Windows.Forms.TabPage();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.C_BotOnOff = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabBattleCards = new System.Windows.Forms.TabPage();
            this.tabActionCards = new System.Windows.Forms.TabPage();
            this.dgv_BattleCards = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.tabBattleCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BattleCards)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabViewers);
            this.tabControl1.Controls.Add(this.tabConfig);
            this.tabControl1.Controls.Add(this.tabBattleCards);
            this.tabControl1.Controls.Add(this.tabActionCards);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1057, 583);
            this.tabControl1.TabIndex = 0;
            // 
            // tabViewers
            // 
            this.tabViewers.Location = new System.Drawing.Point(4, 24);
            this.tabViewers.Name = "tabViewers";
            this.tabViewers.Padding = new System.Windows.Forms.Padding(3);
            this.tabViewers.Size = new System.Drawing.Size(1049, 555);
            this.tabViewers.TabIndex = 1;
            this.tabViewers.Text = "Viewers";
            this.tabViewers.UseVisualStyleBackColor = true;
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.C_BotOnOff);
            this.tabConfig.Controls.Add(this.textBox6);
            this.tabConfig.Controls.Add(this.textBox5);
            this.tabConfig.Controls.Add(this.textBox3);
            this.tabConfig.Controls.Add(this.textBox4);
            this.tabConfig.Controls.Add(this.textBox2);
            this.tabConfig.Controls.Add(this.textBox1);
            this.tabConfig.Controls.Add(this.label6);
            this.tabConfig.Controls.Add(this.label5);
            this.tabConfig.Controls.Add(this.label4);
            this.tabConfig.Controls.Add(this.label3);
            this.tabConfig.Controls.Add(this.label2);
            this.tabConfig.Controls.Add(this.label1);
            this.tabConfig.Location = new System.Drawing.Point(4, 24);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(1049, 555);
            this.tabConfig.TabIndex = 2;
            this.tabConfig.Text = "Configuration";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // C_BotOnOff
            // 
            this.C_BotOnOff.Location = new System.Drawing.Point(9, 196);
            this.C_BotOnOff.Name = "C_BotOnOff";
            this.C_BotOnOff.Size = new System.Drawing.Size(160, 23);
            this.C_BotOnOff.TabIndex = 7;
            this.C_BotOnOff.Text = "Turn On Bot";
            this.C_BotOnOff.UseVisualStyleBackColor = true;
            this.C_BotOnOff.Click += new System.EventHandler(this.C_BotOnOff_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(116, 149);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(391, 23);
            this.textBox6.TabIndex = 6;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(116, 120);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(391, 23);
            this.textBox5.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(116, 62);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(391, 23);
            this.textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(116, 91);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(391, 23);
            this.textBox4.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(116, 33);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(391, 23);
            this.textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(391, 23);
            this.textBox1.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Bot name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "CommandSymbol";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Refresh Token";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Access Token";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Channel Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ClientID";
            // 
            // tabBattleCards
            // 
            this.tabBattleCards.Controls.Add(this.dgv_BattleCards);
            this.tabBattleCards.Location = new System.Drawing.Point(4, 24);
            this.tabBattleCards.Name = "tabBattleCards";
            this.tabBattleCards.Size = new System.Drawing.Size(1049, 555);
            this.tabBattleCards.TabIndex = 3;
            this.tabBattleCards.Text = "Battle Cards";
            this.tabBattleCards.UseVisualStyleBackColor = true;
            // 
            // tabActionCards
            // 
            this.tabActionCards.Location = new System.Drawing.Point(4, 24);
            this.tabActionCards.Name = "tabActionCards";
            this.tabActionCards.Size = new System.Drawing.Size(1049, 555);
            this.tabActionCards.TabIndex = 4;
            this.tabActionCards.Text = "Action Cards";
            this.tabActionCards.UseVisualStyleBackColor = true;
            // 
            // dgv_BattleCards
            // 
            this.dgv_BattleCards.AllowUserToOrderColumns = true;
            this.dgv_BattleCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_BattleCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_BattleCards.Location = new System.Drawing.Point(0, 0);
            this.dgv_BattleCards.Name = "dgv_BattleCards";
            this.dgv_BattleCards.RowTemplate.Height = 25;
            this.dgv_BattleCards.Size = new System.Drawing.Size(1049, 555);
            this.dgv_BattleCards.TabIndex = 0;
            // 
            // SGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 583);
            this.Controls.Add(this.tabControl1);
            this.Name = "SGame";
            this.Text = "Streamer  Game Bot";
            this.tabControl1.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            this.tabConfig.PerformLayout();
            this.tabBattleCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BattleCards)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabViewers;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button C_BotOnOff;
        private System.Windows.Forms.TabPage tabBattleCards;
        private System.Windows.Forms.TabPage tabActionCards;
        private System.Windows.Forms.DataGridView dgv_BattleCards;
    }
}

