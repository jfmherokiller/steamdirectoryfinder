using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace steamdirectoryfinder
{
    public partial class Client_Configuration : Form
    {
        public List<string> Mounts = new List<string>();

        public Client_Configuration()
        {
            InitializeComponent();
        }

        private void Client_Configuration_Load(object sender, EventArgs e)
        {
        }

        private void dropmounts_Click(object sender, EventArgs e)
        {
            if (!hl1.Checked)
            {
                Mounts.Add("hl1");
            }
            if (!hl2.Checked)
            {
                Mounts.Add("hl2");
            }
            if (!cstrike.Checked)
            {
                Mounts.Add("css");
            }
            if (!ep2.Checked)
            {
                Mounts.Add("ep2");
            }
            if (!episodic.Checked)
            {
                Mounts.Add("ep1");
            }
            if (!lostcoast.Checked)
            {
                Mounts.Add("lostcoast");
            }
            if (!dod.Checked)
            {
                Mounts.Add("dod");
            }
            Close();
        }
    }
}