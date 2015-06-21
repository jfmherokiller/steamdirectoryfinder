using steamdirectoryfinder.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace steamdirectoryfinder
{
    internal class ServerStuff
    {
        private static string _mainFolder;
        private static string _ocServerInstallPath;
        private readonly string _mounts;
        private readonly string _password;
        private readonly bool _steamauth;
        private readonly string _username;
        public ServerStuff(string path, string username, string password, bool steamfun = false, string mounts = "")
        {
            _ocServerInstallPath = path;
            _mainFolder = Directory.GetParent(path.TrimEnd('\\')).ToString();
            _username = username;
            _password = password;
            _steamauth = steamfun;
            _mounts = mounts;
        }

        public static void CheckifDirectoryexistsorcreateit(string fun)
        {
            Directory.CreateDirectory(fun);
        }

        public static void CreateNeededFiles(string installpath)
        {
            var myIp = new WebClient().DownloadString(@"http://ipv4.icanhazip.com").Trim();
            var startBat = @"srcds.exe -console -condebug -game obsidian -ip " + myIp + @" -port 27015 +map oc_lobby +maxplayers 32 +hostname ""(SteamPipe) Basic Server""";

            File.WriteAllText(installpath + "\\StartServer.bat", startBat);
        }

        public static void DownloadSteamcmd()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("http://media.steampowered.com/installer/steamcmd.zip", "steamcmd.zip");
                client.DownloadFile("http://www.gsptalk.com/mirror/sourcemod/mmsource-1.10.5-windows.zip",
                    "mmsource.zip");
                client.DownloadFile("http://www.gsptalk.com/mirror/sourcemod/sourcemod-1.7.2-windows.zip",
                    "sourcemod.zip");
            }
        }

        public static void ExtractAndDelete(string theserverfolder)
        {
            Program.ExtractClientResources();

            Program.Runoneachvpk(Program.Returndirvpks(theserverfolder));
            Program.DeleteVpks(Program.Returnallvpks(theserverfolder));
            var resourceData = Resources.files_to_delete_1_;
            var words = resourceData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Parallel.ForEach(words, lines =>
            {
                var fun = Path.Combine(theserverfolder, lines);
                FileAttributes attr = 0;
                if (File.Exists(fun) || Directory.Exists(fun))
                {
                    attr = File.GetAttributes(fun);
                }
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    Program.DeleteDir(Path.Combine(theserverfolder, lines));
                }
                else
                {
                    Program.DeleteFile(Path.Combine(theserverfolder, lines));
                }
            });
            //if (!Environment.Is64BitOperatingSystem) return;
            //var laafun = new LaaFile(theserverfolder + "\\srcds.exe");
            //if (laafun.LargeAddressAware == false)
            //{
            //    laafun.WriteCharacteristics(true);
            //}
        }

        public static void ExtractServerResources(string ass)
        {
            File.WriteAllBytes("7za.exe", Resources._7za);
            Program.Performtasks("7za.exe", "x steamcmd.zip -o" + Program.PutIntoQuotes(Directory.GetCurrentDirectory() + "\\steamcmd") + " -aoa");
            File.WriteAllBytes("addons.zip", Resources.addons);
            Program.Performtasks("7za.exe", "x addons.zip -o" + Program.PutIntoQuotes(ass) + " -aoa");
            Program.Performtasks("7za.exe", "x mmsource.zip -o" + Program.PutIntoQuotes(ass) + " -aoa");
            Program.Performtasks("7za.exe", "x sourcemod.zip -o" + Program.PutIntoQuotes(ass) + " -aoa");
        }

        public static void InstallServer(string username, string password, string serverdirectory, bool steamauth, string mounts = "")
        {
            foreach (var fub in Process.GetProcessesByName("steamcmd.exe"))
            {
                fub.Kill();
            }
            const string endofcmd = " validate +quit";
            var basecmd = " +login " + username + " " + password + " +force_install_dir " +
                          NativeMethods.Otherstuff.GetShortPathName(serverdirectory) +
                          " +app_update ";
            var currentdir = Directory.GetCurrentDirectory();
            var steamcmdbase = Path.Combine(currentdir, "steamcmd\\steamcmd.exe");
            if (steamauth)
            {
                Program.Performtasksi(steamcmdbase, " +login " + username + " " + password + " +quit");
            }
            System.Threading.Thread.Sleep(5000);

            if (InstallMountsFromintstring(mounts, steamcmdbase, basecmd, endofcmd) != 1)
            {
                InstallMountsFromnames(mounts, steamcmdbase, basecmd, endofcmd);
            }
            
        }

        public void RunFun()
        {
            CheckifDirectoryexistsorcreateit(_ocServerInstallPath);
            CheckifDirectoryexistsorcreateit(Directory.GetCurrentDirectory() + "\\steamcmd");
            DownloadSteamcmd();
            ExtractServerResources(_ocServerInstallPath);
            InstallServer(_username, _password, _mainFolder, _steamauth, _mounts);
            ExtractAndDelete(_mainFolder);
            CreateNeededFiles(_mainFolder);
        }

        private static int InstallMountsFromintstring(string mounts, string steamcmdbase, string basecmd, string endofcmd)
        {
            if (!(mounts != "" & (mounts.Contains(@"0")))) return 0;
            var fuckme = mounts.Split(',');
            if (!fuckme[0].Contains("1"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "220" + endofcmd);
            }
            if (!fuckme[1].Contains("1"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "380" + endofcmd);
            }
            if (!fuckme[2].Contains("1"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "340" + endofcmd);
            }
            if (!fuckme[3].Contains("1"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "420" + endofcmd);
            }
            if (!fuckme[4].Contains("1"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "280" + endofcmd);
            }
            if (!fuckme[5].Contains("1"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "240" + endofcmd);
            }
            if (!fuckme[6].Contains("1"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "300" + endofcmd);
            }
            if (true)
            {
                Program.Performtasks(steamcmdbase, basecmd + "310" + endofcmd);
            }
            return 1;
        }

        private static void InstallMountsFromnames(string mounts, string steamcmdbase, string basecmd, string endofcmd)
        {
            if (mounts == "" || !mounts.Contains("hl2"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "220" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("ep1"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "380" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("lostcoast"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "340" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("ep2"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "420" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("hl1"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "280" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("css"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "240" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("dod"))
            {
                Program.Performtasks(steamcmdbase, basecmd + "300" + endofcmd);
            }
            if (true)
            {
                Program.Performtasks(steamcmdbase, basecmd + "310" + endofcmd);
            }
        }
    }
}