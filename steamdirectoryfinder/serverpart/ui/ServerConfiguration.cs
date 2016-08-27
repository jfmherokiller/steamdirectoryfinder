using System;
using System.IO;
using System.Windows.Forms;
using steamdirectoryfinder.serverpart.code;

namespace steamdirectoryfinder
{
    public partial class ServerConfiguration : Form
    {
        private static string _mainFolder;
        private static string _ocServerInstallPath;

        public ServerConfiguration(string path)
        {
            InitializeComponent();
            _ocServerInstallPath = path;
            _mainFolder = Directory.GetParent(path.TrimEnd('\\')).ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var selectedmounts = "";
            if (ep1.Checked)
            {
                selectedmounts += "ep1";
            }
            if (ep2.Checked)
            {
                selectedmounts += "ep2";
            }
            if (hl1.Checked)
            {
                selectedmounts += "hl1";
            }
            if (css.Checked)
            {
                selectedmounts += "css";
            }
            if (dod.Checked)
            {
                selectedmounts += "dod";
            }
            if (hl2.Checked)
            {
                selectedmounts += "hl2";
            }
            ServerFormStuffs.SetStuff(_mainFolder,_ocServerInstallPath,selectedmounts, textBox2.Text,SteamAuth.Checked, textBox1.Text);
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void ServerConfiguration_Load(object sender, EventArgs e)
        {
        }
    }
}