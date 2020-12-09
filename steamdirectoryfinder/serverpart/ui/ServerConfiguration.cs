using steamdirectoryfinder.serverpart.code;
using System;
using System.IO;
using System.Windows.Forms;

namespace steamdirectoryfinder
{
    public partial class ServerConfiguration : Form
    {
        private static string _mainFolder;
        private static string _ocServerInstallPath;
        private ServerFormStuffs Forminstance;

        public ServerConfiguration(string path)
        {
            InitializeComponent();
            _ocServerInstallPath = path;
            _mainFolder = Directory.GetParent(path.TrimEnd('\\')).ToString();
            Forminstance = new ServerFormStuffs();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string selectedmounts = "";
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
            Forminstance.SetStuff(_mainFolder, _ocServerInstallPath, selectedmounts, textBox2.Text, SteamAuth.Checked, textBox1.Text);
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