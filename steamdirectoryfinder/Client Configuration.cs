using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                this.Mounts.Add("hl1");
            }
            if (!hl2.Checked)
            {
                this.Mounts.Add("hl2");
            }
            if (!cstrike.Checked)
            {
                this.Mounts.Add("css");
            }
            if (!ep2.Checked)
            {
                this.Mounts.Add("ep2");
            }
            if (!episodic.Checked)
            {
                this.Mounts.Add("ep1");
            }
            if (!lostcoast.Checked)
            {
                this.Mounts.Add("lostcoast");
            }
            if (!dod.Checked)
            {
                this.Mounts.Add("dod");
            }
            this.Close();
        }
    }
}
