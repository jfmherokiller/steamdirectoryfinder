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
            ServerStuff.InstallServer(_username, _password, _mainFolder, _mounts);

            ServerStuff.ExtractAndDelete(_mainFolder);
            ServerStuff.CreateNeededFiles(_mainFolder);
        }

        public void SetStuff(string mainfolder, string ocinstall, string mounts, string password, string username)
        {
            _mainFolder = mainfolder;
            _ocServerInstallPath = ocinstall;
            _mounts = mounts;
            _password = password;
            _username = username;
        }
    }

    internal class ServerStuff
    {
        private static string _mainFolder;
        private static string _ocServerInstallPath;
        private readonly string _mounts;
        private readonly string _password;
        private readonly string _username;

        public static class InstallerContext
        {
            public static string ServerDirectory { get; set; }
        }

        public ServerStuff(string path, string username, string password, string mounts = "")
        {
            _ocServerInstallPath = path;
            _mainFolder = Directory.GetParent(path.TrimEnd('\\')).ToString();
            _username = username;
            _password = password;
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

            string[] items = resourceData.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
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
            // Copy Updated Steam Files from steamcmd to allow srcds to connect to steam servers
            string steamdllsrc = @"steamcmd\steam.dll";
            string steamdlldes = theserverfolder + "\\steam.dll";
            string steamclientsrc = @"steamcmd\steamclient.dll";
            string steamclientdes = theserverfolder + "\\steamclient.dll";
            string tier0_ssrc = @"steamcmd\tier0_s.dll";
            string tier0_sdes = theserverfolder + "\\tier0_s.dll";
            string vstdlib_ssrc = @"steamcmd\vstdlib_s.dll";
            string vstdlib_sdes = theserverfolder + "\\vstdlib_s.dll";
            File.Copy(steamdllsrc, steamdlldes);
            File.Copy(steamclientsrc, steamclientdes);
            File.Copy(tier0_ssrc, tier0_sdes);
            File.Copy(vstdlib_ssrc, vstdlib_sdes);
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

        public static void InstallServer(string username, string password, string serverdirectory,
            string mounts = "")
        {
            foreach (Process fub in Process.GetProcessesByName("steamcmd.exe"))
            {
                fub.Kill();
            }
            string endofcmd = " validate +quit";
            string basecmd = " +force_install_dir " + NativeMethods.Otherstuff.GetShortPathName(serverdirectory) + " +login " + username + " " + password + 
                          " +app_update ";
            string currentdir = Directory.GetCurrentDirectory();
            string steamcmdbase = Path.Combine(currentdir, "steamcmd\\steamcmd.exe");
            //get auth token
            ClientAndServer.Performtasksi(steamcmdbase, " +login " + username + " " + password + " +quit");
            Thread.Sleep(5000);

            InstallMounts( steamcmdbase, basecmd, endofcmd);
        }

        public void RunFun()
        {
            CheckifDirectoryexistsorcreateit(_ocServerInstallPath);
            CheckifDirectoryexistsorcreateit(Directory.GetCurrentDirectory() + "\\steamcmd");
            DownloadSteamcmd();
            ExtractServerResources(_ocServerInstallPath);
            InstallServer(_username, _password, _mainFolder, _mounts);
            ExtractAndDelete(_mainFolder);
            CreateNeededFiles(_mainFolder);
        }

        private static int InstallMounts( string steamcmdbase, string basecmd,
            string endofcmd)
        {
            // Extract installation directory from basecmd
            string forceInstallDirPrefix = "+force_install_dir ";
            string loginPrefix = " +login ";

            int startIndex = basecmd.IndexOf(forceInstallDirPrefix);
            if (startIndex == -1)
            {
                throw new InvalidOperationException("force_install_dir not found in basecmd.");
            }

            startIndex += forceInstallDirPrefix.Length;
            int endIndex = basecmd.IndexOf(loginPrefix, startIndex);
            if (endIndex == -1)
            {
                throw new InvalidOperationException("login not found in basecmd after force_install_dir.");
            }

            string installationDirectory = basecmd.Substring(startIndex, endIndex - startIndex).Trim();
            if (string.IsNullOrEmpty(installationDirectory))
            {
                throw new InvalidOperationException("Installation directory is empty.");
            }

            // Normalize the path by replacing double backslashes with single backslashes
            InstallerContext.ServerDirectory = installationDirectory.Replace("\\\\", "\\");

            string SteamcmdCleanup = Path.Combine(InstallerContext.ServerDirectory, "steamapps");
            string hl2FolderPathForCleanup = Path.Combine(InstallerContext.ServerDirectory, "hl2");
            string tempHl2FolderPathForCleanup = Path.Combine(InstallerContext.ServerDirectory, "temp_hl2");
            
            //handle hl2+ep1+ep2+lostcoast mount
            ClientAndServer.Performtasksi(steamcmdbase, basecmd + "220 -beta steam_legacy" + endofcmd);

            // Delete Steamapps folder after every download to allow proper verification of each download
            if (Directory.Exists(SteamcmdCleanup))
            {
                Directory.Delete(SteamcmdCleanup, true);
            }

            // Rename the hl2 folder after the first download (appid 220)
            if (Directory.Exists(hl2FolderPathForCleanup))
            {
                Directory.Move(hl2FolderPathForCleanup, tempHl2FolderPathForCleanup);
            }

            //handle hl1 mount
            ClientAndServer.Performtasksi(steamcmdbase, basecmd + "280 -beta previous" + endofcmd);

            // Delete Steamapps folder after every download to allow proper verification of each download
            if (Directory.Exists(SteamcmdCleanup))
            {
                Directory.Delete(SteamcmdCleanup, true);
            }

            //handle css mount
            ClientAndServer.Performtasksi(steamcmdbase, basecmd + "240 -beta previous_build" + endofcmd);

            // Delete Steamapps folder after every download to allow proper verification of each download
            if (Directory.Exists(SteamcmdCleanup))
            {
                Directory.Delete(SteamcmdCleanup, true);
            }

            //handle dod mount
            ClientAndServer.Performtasksi(steamcmdbase, basecmd + "300 -beta previous_build" + endofcmd);

            // Delete Steamapps folder after every download to allow proper verification of each download
            if (Directory.Exists(SteamcmdCleanup))
            {
                Directory.Delete(SteamcmdCleanup, true);
            }

            //handle 2007 server content
            ClientAndServer.Performtasksi(steamcmdbase, basecmd + "310" + endofcmd);

            // Delete the newly created hl2 folder and rename the temp_hl2 folder back to hl2 after the last download (appid 310)
            if (Directory.Exists(hl2FolderPathForCleanup))
            {
                Directory.Delete(hl2FolderPathForCleanup, true);
            }
            if (Directory.Exists(tempHl2FolderPathForCleanup))
            {
                Directory.Move(tempHl2FolderPathForCleanup, hl2FolderPathForCleanup);
            }
            return 1;
        }
    }
}