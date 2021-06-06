
namespace StreamHub
{
    partial class GTA_newRole
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
            this.c_ok = new System.Windows.Forms.Button();
            this.c_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.c_name = new System.Windows.Forms.TextBox();
            this.c_cmd = new System.Windows.Forms.TextBox();
            this.c_nombre = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.c_nombre)).BeginInit();
            this.SuspendLayout();
            // 
            // c_ok
            // 
            this.c_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_ok.Location = new System.Drawing.Point(160, 170);
            this.c_ok.Name = "c_ok";
            this.c_ok.Size = new System.Drawing.Size(75, 23);
            this.c_ok.TabIndex = 0;
            this.c_ok.Text = "OK";
            this.c_ok.UseVisualStyleBackColor = true;
            this.c_ok.Click += new System.EventHandler(this.c_ok_Click);
            // 
            // c_cancel
            // 
            this.c_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_cancel.Location = new System.Drawing.Point(241, 170);
            this.c_cancel.Name = "c_cancel";
            this.c_cancel.Size = new System.Drawing.Size(75, 23);
            this.c_cancel.TabIndex = 1;
            this.c_cancel.Text = "Cancel";
            this.c_cancel.UseVisualStyleBackColor = true;
            this.c_cancel.Click += new System.EventHandler(this.c_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Role name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Command";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Number of player to be picked";
            // 
            // c_name
            // 
            this.c_name.Location = new System.Drawing.Point(13, 32);
            this.c_name.Name = "c_name";
            this.c_name.Size = new System.Drawing.Size(205, 23);
            this.c_name.TabIndex = 5;
            // 
            // c_cmd
            // 
            this.c_cmd.Location = new System.Drawing.Point(12, 76);
            this.c_cmd.Name = "c_cmd";
            this.c_cmd.Size = new System.Drawing.Size(205, 23);
            this.c_cmd.TabIndex = 5;
            // 
            // c_nombre
            // 
            this.c_nombre.Location = new System.Drawing.Point(14, 121);
            this.c_nombre.Name = "c_nombre";
            this.c_nombre.Size = new System.Drawing.Size(120, 23);
            this.c_nombre.TabIndex = 6;
            this.c_nombre.ThousandsSeparator = true;
            // 
            // GTA_newRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 205);
            this.Controls.Add(this.c_nombre);
            this.Controls.Add(this.c_cmd);
            this.Controls.Add(this.c_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c_cancel);
            this.Controls.Add(this.c_ok);
            this.Name = "GTA_newRole";
            this.Text = "New role for GTA";
            ((System.ComponentModel.ISupportInitialize)(this.c_nombre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button c_ok;
        private System.Windows.Forms.Button c_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox c_name;
        private System.Windows.Forms.TextBox c_cmd;
        private System.Windows.Forms.NumericUpDown c_n;
        private System.Windows.Forms.NumericUpDown c_nombre;
    }
}