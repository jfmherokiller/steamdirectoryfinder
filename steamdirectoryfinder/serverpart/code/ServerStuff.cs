using steamdirectoryfinder.bothServerAndClient;
using steamdirectoryfinder.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace steamdirectoryfinder.serverpart.code
{
    internal class ServerFormStuffs
    {
        private static string _mainFolder;
        private static string _ocServerInstallPath;
        private static string _mounts;
        private static string _password;
        private static bool _steamauth;
        private static string _username;

        public void OpenServerForm(string installpath)
        {
            using (ServerConfiguration serverform = new ServerConfiguration(installpath))
            {
                serverform.ShowDialog();
                Dostuff();
            }
        }

        private void Dostuff()
        {
            ServerStuff.DownloadSourcemod();
            ServerStuff.DownloadMetamod();
            ServerStuff.DownloadSteamcmd();
            ServerStuff.ExtractServerResources(_ocServerInstallPath);
            ServerStuff.CheckifDirectoryexistsorcreateit(_ocServerInstallPath);
            ServerStuff.CheckifDirectoryexistsorcreateit(Path.Combine(Directory.GetCurrentDirectory() + @"steamcmd"));
            ServerStuff.InstallServer(_username, _password, _mainFolder, _steamauth, _mounts);

            ServerStuff.ExtractAndDelete(_mainFolder);
            ServerStuff.CreateNeededFiles(_mainFolder);
        }

        public void SetStuff(string mainfolder, string ocinstall, string mounts, string password, bool steamauth, string username)
        {
            _mainFolder = mainfolder;
            _ocServerInstallPath = ocinstall;
            _mounts = mounts;
            _password = password;
            _steamauth = steamauth;
            _username = username;
        }
    }

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
            string myIp = new WebClient().DownloadString("http://ipv4.icanhazip.com").Trim();
            string startBat = @"srcds.exe -console -condebug -game obsidian -ip " + myIp +
                           @" -port 27015 +map oc_lobby +maxplayers 32 +hostname ""(SteamPipe) Basic Server""";

            File.WriteAllText(installpath + "\\StartServer.bat", startBat);
        }


        public static void DownloadSourcemod()
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile("https://sm.alliedmods.net/smdrop/1.10/sourcemod-1.10.0-git6545-windows.zip", "sourcemod.zip");
            }
        }

        public static void DownloadMetamod()
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile("https://mms.alliedmods.net/mmsdrop/1.10/mmsource-1.10.7-git971-windows.zip", "mmsource.zip");
            }
        }


        public static void DownloadSteamcmd()
        {
            using (WebClient client = new WebClient())
            {
            client.DownloadFile("http://media.steampowered.com/installer/steamcmd.zip", "steamcmd.zip");
            }
        }

        public static void ExtractAndDelete(string theserverfolder)
        {
            ClientAndServer.ExtractResourcesForBoth();

            ClientAndServer.Runoneachvpk(ClientAndServer.Returndirvpks(theserverfolder));
            ClientAndServer.DeleteVpks(ClientAndServer.Returnallvpks(theserverfolder));
            string resourceData = Resources.delete;

            // var words = resourceData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] items = resourceData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Parallel.ForEach(items, lines =>
            {
                string fun = Path.Combine(theserverfolder, lines);

                FileAttributes attr = 0;
                if (File.Exists(fun) || Directory.Exists(fun))
                {
                    attr = File.GetAttributes(fun);
                }
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    MiscFunctions.DeleteDir(Path.Combine(theserverfolder, lines));
                }
                else
                {
                    MiscFunctions.DeleteFile(Path.Combine(theserverfolder, lines));
                }
            });
            string sourceFile1 = @"steamcmd\steam.dll";
            string destinationFile1 = theserverfolder + "\\steam.dll";
            string sourceFile2 = @"steamcmd\steamclient.dll";
            string destinationFile2 = theserverfolder + "\\steamclient.dll";
            string sourceFile3 = @"steamcmd\tier0_s.dll";
            string destinationFile3 = theserverfolder + "\\tier0_s.dll";
            string sourceFile4 = @"steamcmd\vstdlib_s.dll";
            string destinationFile4 = theserverfolder +"\\vstdlib_s.dll";
            System.IO.File.Copy(sourceFile1, destinationFile1);
            System.IO.File.Copy(sourceFile2, destinationFile2);
            System.IO.File.Copy(sourceFile3, destinationFile3);
            System.IO.File.Copy(sourceFile4, destinationFile4);
        }

        public static void ExtractServerResources(string ass)
        {
            File.WriteAllBytes("7za.exe", Resources._7za);
            ClientAndServer.Performtasks("7za.exe",
                "x steamcmd.zip -o" + MiscFunctions.PutIntoQuotes(Directory.GetCurrentDirectory() + "\\steamcmd") + " -aoa");
            File.WriteAllBytes("addons.zip", Resources.addons);

            ClientAndServer.Performtasks("7za.exe", "x mmsource.zip -o" + MiscFunctions.PutIntoQuotes(ass) + " -aoa");
            ClientAndServer.Performtasks("7za.exe", "x sourcemod.zip -o" + MiscFunctions.PutIntoQuotes(ass) + " -aoa");
            ClientAndServer.Performtasks("7za.exe", "x addons.zip -o" + MiscFunctions.PutIntoQuotes(ass) + " -aoa");
        }

        public static void InstallServer(string username, string password, string serverdirectory, bool steamauth,
            string mounts = "")
        {
            foreach (Process fub in Process.GetProcessesByName("steamcmd.exe"))
            {
                fub.Kill();
            }
            const string endofcmd = " validate +quit";
            string basecmd = " +force_install_dir " + NativeMethods.Otherstuff.GetShortPathName(serverdirectory) + " +login " + username + " " + password + 
                          " +app_update ";
            string currentdir = Directory.GetCurrentDirectory();
            string steamcmdbase = Path.Combine(currentdir, "steamcmd\\steamcmd.exe");
            if (steamauth)
            {
                ClientAndServer.Performtasksi(steamcmdbase, " +login " + username + " " + password + " +quit");
            }
            Thread.Sleep(5000);

            if (InstallMountsFromintstring(mounts, steamcmdbase, basecmd, endofcmd) != 1)
            {
                InstallMountsFromnames(mounts, steamcmdbase, basecmd, endofcmd);
            }
        }

        public void RunFun()
        {
            CheckifDirectoryexistsorcreateit(_ocServerInstallPath);
            CheckifDirectoryexistsorcreateit(Directory.GetCurrentDirectory() + "\\steamcmd");
            DownloadSourcemod();
            DownloadMetamod();
            DownloadSteamcmd();
            ExtractServerResources(_ocServerInstallPath);
            InstallServer(_username, _password, _mainFolder, _steamauth, _mounts);
            ExtractAndDelete(_mainFolder);
            CreateNeededFiles(_mainFolder);
        }

        private static int InstallMountsFromintstring(string mounts, string steamcmdbase, string basecmd, string endofcmd)
        {
            if (!(mounts != "" & mounts.Contains(@"0")))
            {
                return 0;
            }

            string[] fuckme = mounts.Split(',');
            if (!fuckme[0].Contains("1"))
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "220 -beta steam_legacy" + endofcmd);
            }
            if (!fuckme[1].Contains("1"))
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "380 -beta steam_legacy" + endofcmd);
            }
            if (!fuckme[2].Contains("1"))
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "340 -beta steam_legacy" + endofcmd);
            }
            if (!fuckme[3].Contains("1"))
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "420 -beta steam_legacy" + endofcmd);
            }
            if (!fuckme[4].Contains("1"))
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "280 -beta previous" + endofcmd);
            }
            if (!fuckme[5].Contains("1"))
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "240 -beta previous_build" + endofcmd);
            }
            if (!fuckme[6].Contains("1"))
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "300 -beta previous_build" + endofcmd);
            }
            if (true)
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "310" + endofcmd);
            }
            return 1;
        }

        private static void InstallMountsFromnames(string mounts, string steamcmdbase, string basecmd, string endofcmd)
        {
            if (mounts == "" || !mounts.Contains("hl2"))
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "220" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("ep1"))
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "380" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("lostcoast"))
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "340" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("ep2"))
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "420" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("hl1"))
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "280" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("css"))
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "240" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("dod"))
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "300" + endofcmd);
            }
            if (true)
            {
                ClientAndServer.Performtasksi(steamcmdbase, basecmd + "310" + endofcmd);
            }
        }
    }
}