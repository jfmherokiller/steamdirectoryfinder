using steamdirectoryfinder.Properties;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace steamdirectoryfinder
{
    internal class ServerStuff
    {
        private static string _ocServerInstallPath;
        private static string _mainFolder;
        private readonly string _password;
        private readonly string _username;
        private readonly bool _steamauth;
        private readonly string _mounts;
        public ServerStuff(string path, string username, string password,bool steamfun = false,string mounts = "")
        {
            _ocServerInstallPath = path;
            _mainFolder = Directory.GetParent(_ocServerInstallPath).FullName;
            _username = username;
            _password = password;
            _steamauth = steamfun;
            _mounts = mounts;
        }
        public static void InstallServer(string username, string password, string serverdirectory,bool steamauth,string mounts = "")
        {
            const string endofcmd = "validate +quit";
            var basecmd = " +login " + username + " " + password + " +force_install_dir " +
                          NativeMethods.Otherstuff.GetShortPathName(serverdirectory) +
                          " +app_update ";
            var steamcmdbase = Directory.GetCurrentDirectory() + "\\steamcmd" + "\\steamcmd.exe";
            if (steamauth)
            {
                Program.Performtasksi(steamcmdbase," +login " + username + " " + password + " +quit");
            }
            if (mounts != "" && mounts == "") return;
            if (true)
            {
                Program.Performtasks(steamcmdbase, basecmd + "220 " + endofcmd); 
            }
            if (mounts == "" || !mounts.Contains("ep1"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "380 " + endofcmd); 
            }
            if (mounts == "" || !mounts.Contains("lostcoast"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "340 " + endofcmd); 
            }
            if (mounts == "" || !mounts.Contains("ep2"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "420 " + endofcmd); 
            }
            if (mounts == "" || !mounts.Contains("hl1"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "280 " + endofcmd); 
            }
            if (mounts == "" || !mounts.Contains("css"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "240 " + endofcmd); 
            }
            if (mounts == "" || !mounts.Contains("dod"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "300 " + endofcmd); 
            }
            if (true)
            {
                Program.Performtasks(steamcmdbase, basecmd + "310 " + endofcmd); 
            }
        }

        public static void DownloadSteamcmd()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("http://media.steampowered.com/installer/steamcmd.zip", "steamcmd.zip");
                client.DownloadFile("http://www.gsptalk.com/mirror/sourcemod/mmsource-1.10.4-windows.zip",
                    "mmsource.zip");
                client.DownloadFile("http://www.gsptalk.com/mirror/sourcemod/sourcemod-1.7.1-windows.zip",
                    "sourcemod.zip");
            }
        }

        public static void CheckifDirectoryexistsorcreateit(string fun)
        {
            Directory.CreateDirectory(fun);
        }

        public static void ExtractServerResources(string ass)
        {
            File.WriteAllBytes("7za.exe", Resources._7za);
            Program.Performtasks("7za.exe","x steamcmd.zip -o" + Program.PutIntoQuotes(Directory.GetCurrentDirectory() + "\\steamcmd") + " -aoa");
            File.WriteAllBytes("addons.zip", Resources.addons);
            Program.Performtasks("7za.exe", "x addons.zip -o" + Program.PutIntoQuotes(ass) + " -aoa");
            Program.Performtasks("7za.exe", "x mmsource.zip -o" + Program.PutIntoQuotes(ass) + " -aoa");
            Program.Performtasks("7za.exe", "x sourcemod.zip -o" + Program.PutIntoQuotes(ass) + " -aoa");
        }

        public void RunFun()
        {
            CheckifDirectoryexistsorcreateit(_ocServerInstallPath);
            CheckifDirectoryexistsorcreateit(Directory.GetCurrentDirectory() + "\\steamcmd");
            DownloadSteamcmd();
            ExtractServerResources(_ocServerInstallPath);
            InstallServer(_username, _password, _mainFolder,_steamauth,_mounts);
            ExtractAndDelete(_mainFolder);
            CreateNeededFiles(_mainFolder);
        }

        public static void CreateNeededFiles(string installpath)
        {
            var myIp = new WebClient().DownloadString(@"http://icanhazip.com").Trim();
            var startBat = "srcds.exe -console -condebug -game obsidian -ip " + myIp +" -port 27015 +map oc_lobby +maxplayers 32 +hostname \"(SteamPipe) Basic Server\"";
            File.WriteAllText(installpath + "\\StartServer.bat", startBat);
        }

        public static void ExtractAndDelete(string theserverfolder)
        {
            //MainFolder = Directory.GetParent(fucky).FullName;
            Program.ExtractClientResources();

            Program.Runoneachvpk(Program.Returndirvpks(theserverfolder));
            Program.DeleteVpks(Program.Returnallvpks(theserverfolder));
            var resourceData = Resources.files_to_delete_1_;
            var words = resourceData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach(string lines in words)
            {
                var attr = File.GetAttributes(theserverfolder + "\\" + lines);
                try
                {
                    if (attr.HasFlag(FileAttributes.Directory))
                    {
                        Program.DeleteDir(theserverfolder + "\\" + lines, true);
                    }
                    else
                    {
                        Program.DeleteFile(theserverfolder + "\\" + lines);
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e);
                }
            });
        }
    }
}