
namespace StreamHub
{
    partial class SHub
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.liveState = new System.Windows.Forms.CheckBox();
            this.OnLineTime = new System.Windows.Forms.Label();
            this.Tchat = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(324, 138);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(335, 326);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(487, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // liveState
            // 
            this.liveState.AutoSize = true;
            this.liveState.Location = new System.Drawing.Point(487, 62);
            this.liveState.Name = "liveState";
            this.liveState.Size = new System.Drawing.Size(94, 19);
            this.liveState.TabIndex = 2;
            this.liveState.Text = "Live ON/OFF";
            this.liveState.UseVisualStyleBackColor = true;
            // 
            // OnLineTime
            // 
            this.OnLineTime.AutoSize = true;
            this.OnLineTime.Location = new System.Drawing.Point(487, 107);
            this.OnLineTime.Name = "OnLineTime";
            this.OnLineTime.Size = new System.Drawing.Size(78, 15);
            this.OnLineTime.TabIndex = 3;
            this.OnLineTime.Text = "Online since :";
            // 
            // Tchat
            // 
            this.Tchat.FormattingEnabled = true;
            this.Tchat.ItemHeight = 15;
            this.Tchat.Location = new System.Drawing.Point(12, 12);
            this.Tchat.Name = "Tchat";
            this.Tchat.Size = new System.Drawing.Size(259, 439);
            this.Tchat.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(333, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SHub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 486);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Tchat);
            this.Controls.Add(this.OnLineTime);
            this.Controls.Add(this.liveState);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Name = "SHub";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox liveState;
        private System.Windows.Forms.Label OnLineTime;
        private System.Windows.Forms.ListBox Tchat;
        private System.Windows.Forms.Button button3;
    }
}

