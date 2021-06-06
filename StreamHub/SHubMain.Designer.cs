
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.c_ViewerPool_Reset = new System.Windows.Forms.Button();
            this.c_ViewerPool_Pick = new System.Windows.Forms.Button();
            this.c_ViewerPool = new System.Windows.Forms.ListBox();
            this.c_viewerpool_startstop = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.c_GTAPool = new System.Windows.Forms.DataGridView();
            this.c_GTA_Auto = new System.Windows.Forms.Button();
            this.c_GTA_Reset = new System.Windows.Forms.Button();
            this.c_GTA_startstop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_GTAPool)).BeginInit();
            this.SuspendLayout();
            // 
            // C_ConfigForm
            // 
            this.C_ConfigForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.C_ConfigForm.Location = new System.Drawing.Point(794, 12);
            this.C_ConfigForm.Name = "C_ConfigForm";
            this.C_ConfigForm.Size = new System.Drawing.Size(75, 23);
            this.C_ConfigForm.TabIndex = 0;
            this.C_ConfigForm.Text = "Config";
            this.C_ConfigForm.UseVisualStyleBackColor = true;
            this.C_ConfigForm.Click += new System.EventHandler(this.C_ConfigForm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.c_ViewerPool_Reset);
            this.groupBox1.Controls.Add(this.c_ViewerPool_Pick);
            this.groupBox1.Controls.Add(this.c_ViewerPool);
            this.groupBox1.Controls.Add(this.c_viewerpool_startstop);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 426);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pick a viewer from a  pool (ViewerPool)";
            // 
            // c_ViewerPool_Reset
            // 
            this.c_ViewerPool_Reset.Location = new System.Drawing.Point(115, 51);
            this.c_ViewerPool_Reset.Name = "c_ViewerPool_Reset";
            this.c_ViewerPool_Reset.Size = new System.Drawing.Size(107, 23);
            this.c_ViewerPool_Reset.TabIndex = 9;
            this.c_ViewerPool_Reset.Text = "Reset";
            this.c_ViewerPool_Reset.UseVisualStyleBackColor = true;
            this.c_ViewerPool_Reset.Click += new System.EventHandler(this.c_ViewerPool_Reset_Click);
            // 
            // c_ViewerPool_Pick
            // 
            this.c_ViewerPool_Pick.Location = new System.Drawing.Point(6, 51);
            this.c_ViewerPool_Pick.Name = "c_ViewerPool_Pick";
            this.c_ViewerPool_Pick.Size = new System.Drawing.Size(103, 23);
            this.c_ViewerPool_Pick.TabIndex = 8;
            this.c_ViewerPool_Pick.Text = "Pick someone";
            this.c_ViewerPool_Pick.UseVisualStyleBackColor = true;
            this.c_ViewerPool_Pick.Click += new System.EventHandler(this.c_ViewerPool_Pick_Click);
            // 
            // c_ViewerPool
            // 
            this.c_ViewerPool.FormattingEnabled = true;
            this.c_ViewerPool.ItemHeight = 15;
            this.c_ViewerPool.Location = new System.Drawing.Point(6, 80);
            this.c_ViewerPool.Name = "c_ViewerPool";
            this.c_ViewerPool.Size = new System.Drawing.Size(216, 334);
            this.c_ViewerPool.TabIndex = 7;
            // 
            // c_viewerpool_startstop
            // 
            this.c_viewerpool_startstop.ForeColor = System.Drawing.Color.Red;
            this.c_viewerpool_startstop.Location = new System.Drawing.Point(6, 22);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.c_GTAPool);
            this.groupBox2.Controls.Add(this.c_GTA_Auto);
            this.groupBox2.Controls.Add(this.c_GTA_Reset);
            this.groupBox2.Controls.Add(this.c_GTA_startstop);
            this.groupBox2.Location = new System.Drawing.Point(246, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 426);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GameViewer Team Assembler";
            // 
            // c_GTAPool
            // 
            this.c_GTAPool.AllowUserToAddRows = false;
            this.c_GTAPool.AllowUserToOrderColumns = true;
            this.c_GTAPool.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_GTAPool.Location = new System.Drawing.Point(6, 80);
            this.c_GTAPool.Name = "c_GTAPool";
            this.c_GTAPool.RowTemplate.Height = 25;
            this.c_GTAPool.Size = new System.Drawing.Size(225, 334);
            this.c_GTAPool.TabIndex = 12;
            // 
            // c_GTA_Auto
            // 
            this.c_GTA_Auto.Location = new System.Drawing.Point(6, 51);
            this.c_GTA_Auto.Name = "c_GTA_Auto";
            this.c_GTA_Auto.Size = new System.Drawing.Size(225, 23);
            this.c_GTA_Auto.TabIndex = 11;
            this.c_GTA_Auto.Text = "Build a team";
            this.c_GTA_Auto.UseVisualStyleBackColor = true;
            // 
            // c_GTA_Reset
            // 
            this.c_GTA_Reset.Location = new System.Drawing.Point(172, 22);
            this.c_GTA_Reset.Name = "c_GTA_Reset";
            this.c_GTA_Reset.Size = new System.Drawing.Size(59, 23);
            this.c_GTA_Reset.TabIndex = 10;
            this.c_GTA_Reset.Text = "Reset";
            this.c_GTA_Reset.UseVisualStyleBackColor = true;
            // 
            // c_GTA_startstop
            // 
            this.c_GTA_startstop.ForeColor = System.Drawing.Color.Red;
            this.c_GTA_startstop.Location = new System.Drawing.Point(6, 22);
            this.c_GTA_startstop.Name = "c_GTA_startstop";
            this.c_GTA_startstop.Size = new System.Drawing.Size(160, 23);
            this.c_GTA_startstop.TabIndex = 7;
            this.c_GTA_startstop.Text = "Start /Stop Assembler";
            this.c_GTA_startstop.UseVisualStyleBackColor = true;
            this.c_GTA_startstop.Click += new System.EventHandler(this.c_GTA_startstop_Click);
            // 
            // SHubMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 458);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.C_ConfigForm);
            this.Name = "SHubMain";
            this.Text = "SHubMain";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_GTAPool)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button C_ConfigForm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button c_ViewerPool_Pick;
        private System.Windows.Forms.ListBox c_ViewerPool;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button c_ViewerPool_Reset;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button c_GTA_;
        private System.Windows.Forms.Button c_GTA_Reset;
        private System.Windows.Forms.Button c_GTA_Auto;
        private System.Windows.Forms.Button c_viewerpool_startstop;
        private System.Windows.Forms.Button c_GTA_startstop;
        private System.Windows.Forms.DataGridView c_GTAPool;
    }
}