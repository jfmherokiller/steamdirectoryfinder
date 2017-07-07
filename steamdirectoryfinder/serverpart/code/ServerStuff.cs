using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using steamdirectoryfinder.bothServerAndClient;
using steamdirectoryfinder.Properties;

namespace steamdirectoryfinder.serverpart.code
{
    internal class ServerFormStuffs
    {
        private static string _mainFolder;
        private static string _ocServerInstallPath;
        private  static string  _mounts;
        private static string _password;
        private static bool _steamauth;
        private static string _username;
        public static void OpenServerForm(string installpath)
        {
            using (var serverform = new ServerConfiguration(installpath))
            {
                serverform.ShowDialog();
                Dostuff();
            }
        }

        private static void Dostuff()
        {
            ServerStuff.DownloadSteamcmd();
            ServerStuff.ExtractServerResources(_ocServerInstallPath);
            ServerStuff.CheckifDirectoryexistsorcreateit(_ocServerInstallPath);
            ServerStuff.CheckifDirectoryexistsorcreateit(Path.Combine(Directory.GetCurrentDirectory() + @"steamcmd"));
            ServerStuff.InstallServer(_username, _password, _mainFolder, _steamauth, _mounts);

            ServerStuff.ExtractAndDelete(_mainFolder);
            ServerStuff.CreateNeededFiles(_mainFolder);
        }

        public static void SetStuff(String mainfolder,string ocinstall,string mounts,string password,bool steamauth,string username)
        {
            _mainFolder = mainfolder;
            _ocServerInstallPath = ocinstall;
            _mounts = mounts;
            _password = password;
            _steamauth = steamauth;
            _username = username;
        }
    }
    internal class DownloadTheLatestSourceModAndMetamod
    {
        private static readonly string Sourcemodlink = "https://www.sourcemod.net/downloads.php";
        private static readonly string Metamodlink = "http://www.metamodsource.net";

        private static string DownloadString(string address)
        {
            string reply;
            using (var client = new WebClient())
            {
                reply = client.DownloadString(address);
            }
            return reply;
        }

        //construct the download links from the pages
        public static Tuple<string, string> DownloadPAges()
        {
            var sourcemodstring = DownloadString(Sourcemodlink);
            var metamodstring = DownloadString(Metamodlink);
            //select and construct the download link
            sourcemodstring = "https://www.sourcemod.net" +
                              sourcemodstring.Substring(
                                  sourcemodstring.IndexOf("/smdrop/", StringComparison.OrdinalIgnoreCase), 47);
            //traverse the metamod pages and select the first mirror
            metamodstring = Metamodlink +
                            metamodstring.Substring(
                                metamodstring.IndexOf("/downloads/", StringComparison.OrdinalIgnoreCase), 38);
            metamodstring = DownloadString(metamodstring);
            metamodstring = metamodstring.Substring(metamodstring.IndexOf("http://www.gsptalk.com/mirror", StringComparison.OrdinalIgnoreCase), 67);

            return new Tuple<string, string>(metamodstring, sourcemodstring);
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
            var myIp = new WebClient().DownloadString("http://ipv4.icanhazip.com").Trim();
            var startBat = @"srcds.exe -console -condebug -game obsidian -ip " + myIp +
                           @" -port 27015 +map oc_lobby +maxplayers 32 +hostname ""(SteamPipe) Basic Server""";

            File.WriteAllText(installpath + "\\StartServer.bat", startBat);
        }

        public static void DownloadSteamcmd()
        {
            using (var client = new WebClient())
            {
                var cool = DownloadTheLatestSourceModAndMetamod.DownloadPAges();
                client.DownloadFile("http://media.steampowered.com/installer/steamcmd.zip", "steamcmd.zip");
                client.DownloadFile(cool.Item1,
                    "mmsource.zip");
                client.DownloadFile(cool.Item2,
                    "sourcemod.zip");
            }
        }

        public static void ExtractAndDelete(string theserverfolder)
        {
            ClientAndServer.ExtractResourcesForBoth();

             ClientAndServer.Runoneachvpk(ClientAndServer.Returndirvpks(theserverfolder));
            ClientAndServer.DeleteVpks(ClientAndServer.Returnallvpks(theserverfolder));
            var resourceData = Resources.files_to_delete_1_;
            var words = resourceData.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToList();
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
                    MiscFunctions.DeleteDir(Path.Combine(theserverfolder, lines));
                }
                else
                {
                    MiscFunctions.DeleteFile(Path.Combine(theserverfolder, lines));
                }
            });
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
            DownloadSteamcmd();
            ExtractServerResources(_ocServerInstallPath);
            InstallServer(_username, _password, _mainFolder, _steamauth, _mounts);
            ExtractAndDelete(_mainFolder);
            CreateNeededFiles(_mainFolder);
        }

        private static int InstallMountsFromintstring(string mounts, string steamcmdbase, string basecmd,
            string endofcmd)
        {
            if (!(mounts != "" & mounts.Contains(@"0"))) return 0;
            var fuckme = mounts.Split(',');
            if (!fuckme[0].Contains("1"))
            {
                ClientAndServer.Performtasks(steamcmdbase, basecmd + "220" + endofcmd);
            }
            if (!fuckme[1].Contains("1"))
            {
                ClientAndServer.Performtasks(steamcmdbase, basecmd + "380" + endofcmd);
            }
            if (!fuckme[2].Contains("1"))
            {
                ClientAndServer.Performtasks(steamcmdbase, basecmd + "340" + endofcmd);
            }
            if (!fuckme[3].Contains("1"))
            {
                ClientAndServer.Performtasks(steamcmdbase, basecmd + "420" + endofcmd);
            }
            if (!fuckme[4].Contains("1"))
            {
                ClientAndServer.Performtasks(steamcmdbase, basecmd + "280" + endofcmd);
            }
            if (!fuckme[5].Contains("1"))
            {
               ClientAndServer.Performtasks(steamcmdbase, basecmd + "240" + endofcmd);
            }
            if (!fuckme[6].Contains("1"))
            {
                ClientAndServer.Performtasks(steamcmdbase, basecmd + "300" + endofcmd);
            }
            if (true)
            {
                ClientAndServer.Performtasks(steamcmdbase, basecmd + "310" + endofcmd);
            }
            return 1;
        }

        private static void InstallMountsFromnames(string mounts, string steamcmdbase, string basecmd, string endofcmd)
        {
            if (mounts == "" || !mounts.Contains("hl2"))
            {
                ClientAndServer.Performtasks(steamcmdbase, basecmd + "220" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("ep1"))
            {
                ClientAndServer.Performtasks(steamcmdbase, basecmd + "380" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("lostcoast"))
            {
                ClientAndServer.Performtasks(steamcmdbase, basecmd + "340" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("ep2"))
            {
                ClientAndServer.Performtasks(steamcmdbase, basecmd + "420" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("hl1"))
            {
                ClientAndServer.Performtasks(steamcmdbase, basecmd + "280" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("css"))
            {
                ClientAndServer.Performtasks(steamcmdbase, basecmd + "240" + endofcmd);
            }
            if (mounts == "" || !mounts.Contains("dod"))
            {
                ClientAndServer.Performtasks(steamcmdbase, basecmd + "300" + endofcmd);
            }
            if (true)
            {
                ClientAndServer.Performtasks(steamcmdbase, basecmd + "310" + endofcmd);
            }
        }
    }
}