﻿using steamdirectoryfinder.serverpart.code;
using System;
using System.IO;
using System.Windows.Forms;

namespace steamdirectoryfinder
{
    public partial class ServerConfiguration : Form
    {
        private static string _mainFolder;
        private static string _ocServerInstallPath;
        private readonly ServerFormStuffs Forminstance;

        public ServerConfiguration(string path)
        {
            InitializeComponent();
            _ocServerInstallPath = path;
            _mainFolder = Directory.GetParent(path.TrimEnd('\\')).ToString();
            Forminstance = new ServerFormStuffs();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Forminstance.SetStuff(_mainFolder, _ocServerInstallPath, textBox2.Text, textBox1.Text);
            Close();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void ServerConfiguration_Load(object sender, EventArgs e)
        {
        }

        private void SteamAuth_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}