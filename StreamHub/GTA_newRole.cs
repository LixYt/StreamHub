using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StreamHub
{
    public partial class GTA_newRole : Form
    {
        public string name { get { return c_name.Text; } set { c_name.Text = value; } }
        public string command { get { return c_cmd.Text; } set { c_cmd.Text = value; } }
        public int number { get { return int.Parse(c_nombre.Value.ToString()); } set { c_nombre.Value = value; } }

        public GTA_newRole()
        {
            InitializeComponent();
        }

        private void c_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void c_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
