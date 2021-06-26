
namespace StreamHub
{
    partial class SHubMain
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
            this.C_ConfigForm = new System.Windows.Forms.Button();
            this.c_ViewerPool_Reset = new System.Windows.Forms.Button();
            this.c_ViewerPool_Pick = new System.Windows.Forms.Button();
            this.c_ViewerPool = new System.Windows.Forms.ListBox();
            this.c_viewerpool_startstop = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.c_ResetSelection = new System.Windows.Forms.Button();
            this.c_GTAPool = new System.Windows.Forms.DataGridView();
            this.c_GTA_Auto = new System.Windows.Forms.Button();
            this.c_GTA_Reset = new System.Windows.Forms.Button();
            this.c_GTA_startstop = new System.Windows.Forms.Button();
            this.c_features = new System.Windows.Forms.TabControl();
            this.tab_ViewerPool = new System.Windows.Forms.TabPage();
            this.tab_GTA = new System.Windows.Forms.TabPage();
            this.c_nbr = new System.Windows.Forms.Label();
            this.tab_Data = new System.Windows.Forms.TabPage();
            this.c_ConnectedUsers = new System.Windows.Forms.DataGridView();
            this.c_VisualMode = new System.Windows.Forms.Button();
            this.c_Overlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.c_GTAPool)).BeginInit();
            this.c_features.SuspendLayout();
            this.tab_ViewerPool.SuspendLayout();
            this.tab_GTA.SuspendLayout();
            this.tab_Data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_ConnectedUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // C_ConfigForm
            // 
            this.C_ConfigForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.C_ConfigForm.Location = new System.Drawing.Point(545, 5);
            this.C_ConfigForm.Name = "C_ConfigForm";
            this.C_ConfigForm.Size = new System.Drawing.Size(75, 23);
            this.C_ConfigForm.TabIndex = 0;
            this.C_ConfigForm.Text = "Config";
            this.C_ConfigForm.UseVisualStyleBackColor = true;
            this.C_ConfigForm.Click += new System.EventHandler(this.C_ConfigForm_Click);
            // 
            // c_ViewerPool_Reset
            // 
            this.c_ViewerPool_Reset.Location = new System.Drawing.Point(345, 13);
            this.c_ViewerPool_Reset.Name = "c_ViewerPool_Reset";
            this.c_ViewerPool_Reset.Size = new System.Drawing.Size(107, 23);
            this.c_ViewerPool_Reset.TabIndex = 9;
            this.c_ViewerPool_Reset.Text = "Reset";
            this.c_ViewerPool_Reset.UseVisualStyleBackColor = true;
            this.c_ViewerPool_Reset.Click += new System.EventHandler(this.c_ViewerPool_Reset_Click);
            // 
            // c_ViewerPool_Pick
            // 
            this.c_ViewerPool_Pick.Location = new System.Drawing.Point(236, 13);
            this.c_ViewerPool_Pick.Name = "c_ViewerPool_Pick";
            this.c_ViewerPool_Pick.Size = new System.Drawing.Size(103, 23);
            this.c_ViewerPool_Pick.TabIndex = 8;
            this.c_ViewerPool_Pick.Text = "Pick someone";
            this.c_ViewerPool_Pick.UseVisualStyleBackColor = true;
            this.c_ViewerPool_Pick.Click += new System.EventHandler(this.c_ViewerPool_Pick_Click);
            // 
            // c_ViewerPool
            // 
            this.c_ViewerPool.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c_ViewerPool.BackColor = System.Drawing.SystemColors.Control;
            this.c_ViewerPool.FormattingEnabled = true;
            this.c_ViewerPool.ItemHeight = 15;
            this.c_ViewerPool.Location = new System.Drawing.Point(3, 51);
            this.c_ViewerPool.Name = "c_ViewerPool";
            this.c_ViewerPool.Size = new System.Drawing.Size(614, 364);
            this.c_ViewerPool.TabIndex = 7;
            // 
            // c_viewerpool_startstop
            // 
            this.c_viewerpool_startstop.ForeColor = System.Drawing.Color.Red;
            this.c_viewerpool_startstop.Location = new System.Drawing.Point(14, 13);
            this.c_viewerpool_startstop.Name = "c_viewerpool_startstop";
            this.c_viewerpool_startstop.Size = new System.Drawing.Size(216, 23);
            this.c_viewerpool_startstop.TabIndex = 5;
            this.c_viewerpool_startstop.Text = "Start / Stop pool";
            this.c_viewerpool_startstop.UseVisualStyleBackColor = true;
            this.c_viewerpool_startstop.Click += new System.EventHandler(this.c_viewerpool_startstop_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(106, 72);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Start pool";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // c_ResetSelection
            // 
            this.c_ResetSelection.Location = new System.Drawing.Point(484, 8);
            this.c_ResetSelection.Name = "c_ResetSelection";
            this.c_ResetSelection.Size = new System.Drawing.Size(97, 23);
            this.c_ResetSelection.TabIndex = 11;
            this.c_ResetSelection.Text = "Reset Selection";
            this.c_ResetSelection.UseVisualStyleBackColor = true;
            this.c_ResetSelection.Click += new System.EventHandler(this.c_ResetSelection_Click);
            // 
            // c_GTAPool
            // 
            this.c_GTAPool.AllowUserToAddRows = false;
            this.c_GTAPool.AllowUserToOrderColumns = true;
            this.c_GTAPool.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c_GTAPool.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_GTAPool.Location = new System.Drawing.Point(3, 37);
            this.c_GTAPool.Name = "c_GTAPool";
            this.c_GTAPool.RowTemplate.Height = 25;
            this.c_GTAPool.Size = new System.Drawing.Size(614, 378);
            this.c_GTAPool.TabIndex = 12;
            // 
            // c_GTA_Auto
            // 
            this.c_GTA_Auto.Location = new System.Drawing.Point(291, 8);
            this.c_GTA_Auto.Name = "c_GTA_Auto";
            this.c_GTA_Auto.Size = new System.Drawing.Size(122, 23);
            this.c_GTA_Auto.TabIndex = 11;
            this.c_GTA_Auto.Text = "Build a team";
            this.c_GTA_Auto.UseVisualStyleBackColor = true;
            this.c_GTA_Auto.Click += new System.EventHandler(this.c_GTA_Auto_Click);
            // 
            // c_GTA_Reset
            // 
            this.c_GTA_Reset.Location = new System.Drawing.Point(419, 8);
            this.c_GTA_Reset.Name = "c_GTA_Reset";
            this.c_GTA_Reset.Size = new System.Drawing.Size(59, 23);
            this.c_GTA_Reset.TabIndex = 10;
            this.c_GTA_Reset.Text = "Reset";
            this.c_GTA_Reset.UseVisualStyleBackColor = true;
            this.c_GTA_Reset.Click += new System.EventHandler(this.c_GTA_Reset_Click);
            // 
            // c_GTA_startstop
            // 
            this.c_GTA_startstop.ForeColor = System.Drawing.Color.Red;
            this.c_GTA_startstop.Location = new System.Drawing.Point(8, 8);
            this.c_GTA_startstop.Name = "c_GTA_startstop";
            this.c_GTA_startstop.Size = new System.Drawing.Size(160, 23);
            this.c_GTA_startstop.TabIndex = 7;
            this.c_GTA_startstop.Text = "Start /Stop Assembler";
            this.c_GTA_startstop.UseVisualStyleBackColor = true;
            this.c_GTA_startstop.Click += new System.EventHandler(this.c_GTA_startstop_Click);
            // 
            // c_features
            // 
            this.c_features.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c_features.Controls.Add(this.tab_ViewerPool);
            this.c_features.Controls.Add(this.tab_GTA);
            this.c_features.Controls.Add(this.tab_Data);
            this.c_features.Location = new System.Drawing.Point(0, 12);
            this.c_features.Name = "c_features";
            this.c_features.SelectedIndex = 0;
            this.c_features.Size = new System.Drawing.Size(628, 446);
            this.c_features.TabIndex = 7;
            // 
            // tab_ViewerPool
            // 
            this.tab_ViewerPool.Controls.Add(this.c_ViewerPool);
            this.tab_ViewerPool.Controls.Add(this.c_ViewerPool_Reset);
            this.tab_ViewerPool.Controls.Add(this.c_viewerpool_startstop);
            this.tab_ViewerPool.Controls.Add(this.c_ViewerPool_Pick);
            this.tab_ViewerPool.Location = new System.Drawing.Point(4, 24);
            this.tab_ViewerPool.Name = "tab_ViewerPool";
            this.tab_ViewerPool.Padding = new System.Windows.Forms.Padding(3);
            this.tab_ViewerPool.Size = new System.Drawing.Size(620, 418);
            this.tab_ViewerPool.TabIndex = 0;
            this.tab_ViewerPool.Text = "ViewerPool";
            this.tab_ViewerPool.UseVisualStyleBackColor = true;
            // 
            // tab_GTA
            // 
            this.tab_GTA.Controls.Add(this.c_nbr);
            this.tab_GTA.Controls.Add(this.c_GTAPool);
            this.tab_GTA.Controls.Add(this.c_ResetSelection);
            this.tab_GTA.Controls.Add(this.c_GTA_startstop);
            this.tab_GTA.Controls.Add(this.c_GTA_Reset);
            this.tab_GTA.Controls.Add(this.c_GTA_Auto);
            this.tab_GTA.Location = new System.Drawing.Point(4, 24);
            this.tab_GTA.Name = "tab_GTA";
            this.tab_GTA.Padding = new System.Windows.Forms.Padding(3);
            this.tab_GTA.Size = new System.Drawing.Size(620, 418);
            this.tab_GTA.TabIndex = 1;
            this.tab_GTA.Text = "Gameviewer Team Assembler";
            this.tab_GTA.UseVisualStyleBackColor = true;
            // 
            // c_nbr
            // 
            this.c_nbr.AutoSize = true;
            this.c_nbr.Location = new System.Drawing.Point(175, 13);
            this.c_nbr.Name = "c_nbr";
            this.c_nbr.Size = new System.Drawing.Size(104, 15);
            this.c_nbr.TabIndex = 13;
            this.c_nbr.Text = "x viewers in queue";
            // 
            // tab_Data
            // 
            this.tab_Data.Controls.Add(this.c_ConnectedUsers);
            this.tab_Data.Location = new System.Drawing.Point(4, 24);
            this.tab_Data.Name = "tab_Data";
            this.tab_Data.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Data.Size = new System.Drawing.Size(620, 418);
            this.tab_Data.TabIndex = 2;
            this.tab_Data.Text = "Data";
            this.tab_Data.UseVisualStyleBackColor = true;
            // 
            // c_ConnectedUsers
            // 
            this.c_ConnectedUsers.AllowUserToAddRows = false;
            this.c_ConnectedUsers.AllowUserToDeleteRows = false;
            this.c_ConnectedUsers.AllowUserToOrderColumns = true;
            this.c_ConnectedUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_ConnectedUsers.Location = new System.Drawing.Point(8, 15);
            this.c_ConnectedUsers.Name = "c_ConnectedUsers";
            this.c_ConnectedUsers.ReadOnly = true;
            this.c_ConnectedUsers.RowTemplate.Height = 25;
            this.c_ConnectedUsers.Size = new System.Drawing.Size(408, 222);
            this.c_ConnectedUsers.TabIndex = 0;
            // 
            // c_VisualMode
            // 
            this.c_VisualMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_VisualMode.Location = new System.Drawing.Point(426, 5);
            this.c_VisualMode.Name = "c_VisualMode";
            this.c_VisualMode.Size = new System.Drawing.Size(113, 23);
            this.c_VisualMode.TabIndex = 8;
            this.c_VisualMode.Text = "Light/DarkMode";
            this.c_VisualMode.UseVisualStyleBackColor = true;
            this.c_VisualMode.Click += new System.EventHandler(this.c_VisualMode_Click);
            // 
            // c_Overlay
            // 
            this.c_Overlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_Overlay.ForeColor = System.Drawing.Color.Green;
            this.c_Overlay.Location = new System.Drawing.Point(307, 5);
            this.c_Overlay.Name = "c_Overlay";
            this.c_Overlay.Size = new System.Drawing.Size(113, 23);
            this.c_Overlay.TabIndex = 9;
            this.c_Overlay.Text = "Overlay on/off";
            this.c_Overlay.UseVisualStyleBackColor = true;
            this.c_Overlay.Click += new System.EventHandler(this.c_Overlay_Click);
            // 
            // SHubMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 458);
            this.Controls.Add(this.c_Overlay);
            this.Controls.Add(this.c_VisualMode);
            this.Controls.Add(this.C_ConfigForm);
            this.Controls.Add(this.c_features);
            this.MinimumSize = new System.Drawing.Size(644, 497);
            this.Name = "SHubMain";
            this.Text = "SHubMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SHubMain_FormClosing);
            this.Load += new System.EventHandler(this.SHubMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_GTAPool)).EndInit();
            this.c_features.ResumeLayout(false);
            this.tab_ViewerPool.ResumeLayout(false);
            this.tab_GTA.ResumeLayout(false);
            this.tab_GTA.PerformLayout();
            this.tab_Data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_ConnectedUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button C_ConfigForm;
        private System.Windows.Forms.Button c_ViewerPool_Pick;
        private System.Windows.Forms.ListBox c_ViewerPool;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button c_ViewerPool_Reset;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button c_GTA_;
        private System.Windows.Forms.Button c_GTA_Reset;
        private System.Windows.Forms.Button c_GTA_Auto;
        private System.Windows.Forms.Button c_viewerpool_startstop;
        private System.Windows.Forms.Button c_GTA_startstop;
        private System.Windows.Forms.DataGridView c_GTAPool;
        private System.Windows.Forms.Button c_ResetSelection;
        private System.Windows.Forms.TabControl c_features;
        private System.Windows.Forms.TabPage tab_ViewerPool;
        private System.Windows.Forms.TabPage tab_GTA;
        private System.Windows.Forms.Label c_nbr;
        private System.Windows.Forms.Button c_VisualMode;
        private System.Windows.Forms.Button c_Overlay;
        private System.Windows.Forms.TabPage tab_Data;
        private System.Windows.Forms.DataGridView c_ConnectedUsers;
    }
}