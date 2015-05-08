using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.Win32;
using steamdirectoryfinder.Properties;

namespace steamdirectoryfinder
{
    internal static class Program
    {
        private const uint SourceSdk2007Id = 218;
        private static readonly uint[] Requiredmountids = { 220, 240, 280, 300, 340, 380, 420 };
        private static string _sourcesdk2007Installationpath = "";

        public static void DeleteDir(string fun, bool hex)
        {
            try
            {
                Directory.Delete(fun, hex);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(@"opps symlink Directory not Found");
            }
        }

        public static void DeleteFile(string fun)
        {
            try
            {
                File.Delete(fun);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(@"opps File not found");
            }
        }

        public static void DeleteVpks(IEnumerable<string> ass)
        {
            foreach (var avv in ass)
            {
                if (!avv.Contains("platform"))
                {
                    DeleteFile(avv);
                }
            }
        }

        public static void ExtractClientResources()
        {
            File.WriteAllBytes("HLExtract.exe", Resources.HLExtract);
            File.WriteAllBytes("HLLib.dll", Resources.HLLib);
            // File.WriteAllBytes("Steam4NET.dll", steamdirectoryfinder.Properties.Resources.Steam4NET_dll);
        }

        private static string Gamename(uint a)
        {
            var sb = new StringBuilder(256);
            Steamstuff.SteamApps2.GetAppData(a, "name", sb);

            var name = sb.ToString();
            return name;
        }

        [STAThread]
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += Shutdown; 
            using (new ConsoleCopy("mylogfile.txt"))
            {
                Perfominitializations();
                if (args.Length == 0)
                {
                    OpenMenuIfnocmdArguments();
                }
                else if (args[0].ToLower().Contains("-help"))
                {
                    Console.WriteLine(@"Usage!");
                    Console.WriteLine(@"-server ""<serverdirectory\obsidian>""");
                    Console.WriteLine(@"-server ""<serverdirectory\obsidian>"" <username> <password>");
                    Console.WriteLine(@"-server ""<serverdirectory\obsidian>"" <username> <password> -steamauth");
                    Console.WriteLine(@"-server ""<serverdirectory\obsidian>"" <username> <password> ""hl2,ep1,lostcoast,ep2,hl1,css,dod""");
                    Console.WriteLine(@"-server ""<serverdirectory\obsidian>"" <username> <password> -steamauth ""hl2,ep1,lostcoast,ep2,hl1,css,dod""");
                    Console.WriteLine(@"-client");
                }
                else if (args[0].ToLower().Contains("-client"))
                {
                    Client();
                }
                else if (args[0].ToLower().Contains("-server"))
                {
                    if (args.Length == 1)
                    {
                        var fun = args[1];
                        fun = fun.Trim('"');
                        fun = NativeMethods.Otherstuff.GetShortPathName(fun);
                        Server(fun);
                    }
                    else if (args.Length == 4)
                    {
                        var fun = args[1];
                        fun = fun.Trim('"');
                        fun = NativeMethods.Otherstuff.GetShortPathName(fun);
                        Server(fun, args[2], args[3]);
                    }
                    else if (args.Length == 5)
                    {
                        var fun = args[1];
                        fun = fun.Trim('"');
                        fun = NativeMethods.Otherstuff.GetShortPathName(fun);
                        if (args[4].Contains("-steamauth"))
                        {
                            Server(fun, args[2], args[3], true);
                        }
                        else
                        {
                            Server(fun, args[2], args[3], false, args[4]);
                        }
                    }
                    else if (args.Length == 6)
                    {
                        var fun = args[1];
                        fun = fun.Trim('"');
                        fun = NativeMethods.Otherstuff.GetShortPathName(fun);
                        Server(fun, args[2], args[3], true, args[5]);
                    }

                }
            }
        }

        private static void Perfominitializations()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Title = @"Source Sdk 2007 fud";
        }
        public static void Performtasksi(string prog, string ass)
        {
            var task = new Process
            {
                StartInfo =
                {
                    UseShellExecute = true,
                    FileName = prog,
                    Arguments = ass
                }
            };
            task.Start();
            
            task.WaitForExit();
            task.Close();
        }
        public static void Performtasks(string prog, string ass)
        {
            var task = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,

                    CreateNoWindow = true,
                    FileName = prog,
                    Arguments = ass
                }
            };
            task.Start();
            task.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
            task.BeginOutputReadLine();
            task.WaitForExit();
            task.Close();
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        public static string PutIntoQuotes(string value)
        {
            return "\"" + value + "\"";
        }

        public static string[] Returnallvpks(String dir)
        {
            return Directory.GetFiles(dir, "*.vpk", SearchOption.AllDirectories);
        }

        public static string[] Returndirvpks(string dir)
        {
            var vpkfiles = Directory.GetFiles(dir, "*_dir.vpk", SearchOption.AllDirectories);
            Array.Sort(vpkfiles, StringComparer.InvariantCulture);
            return vpkfiles;
        }

        public static void Runoneachvpk(IEnumerable<string> ass)
        {
            foreach (var avv in ass)
                if (!avv.Contains("platform"))
                {
                    Tasks(avv);
                }
        }

        private static void SetupClient()
        {
            ExtractClientResources();
            Steamstuff.InitClient();
        }

        private static void Shutdown(Object sender,EventArgs a)
        {
            Steamstuff.Shutdown();
            DeleteFile("HLExtract.exe");
            DeleteFile("HLLib.dll");
            DeleteFile("7za.exe");
            DeleteFile("steamcmd.zip");
            DeleteFile("sourcemod.zip");
            DeleteFile("addons.zip");
        }

        private static void Tasks(string ass)
        {
            var quotedVpk = PutIntoQuotes(ass);
            var vpkwithoutextend = ass;
            vpkwithoutextend = vpkwithoutextend.Remove(vpkwithoutextend.IndexOf('.'));
            var gamedir = Path.GetDirectoryName(vpkwithoutextend);
            var robocopyargs = PutIntoQuotes(gamedir + "\\root") + " " + PutIntoQuotes(gamedir) + "  /E /MOVE /IS";
            //var xcopyargs = PutIntoQuotes(gamedir + "\\root\\*") + " " + PutIntoQuotes(gamedir + "\\") + " /f /s /i /y";
            var hlExtractargs = "-p " + quotedVpk + " -d " + PutIntoQuotes(gamedir) + " " + "-e \"\"";
            Performtasks("HLExtract.exe", hlExtractargs);
            Performtasks("robocopy",robocopyargs);

           // Performtasks("xcopy", xcopyargs);
            //Directory.Delete(gamedir + "\\root", true);
            //Performtasks("rd", "/q /s " )
        }

        private static bool CheckifClientOrServer()
        {
            while (true)
            {
                Console.WriteLine(@"Please specify if client or server");
                var output = Console.ReadLine();
                if (output != null && output.ToLower() == "client")
                {
                    return true;
                }
                if (output != null && output.ToLower() == "server")
                {
                    return false;
                }
                if (output != null && output.ToLower() == "fun")
                {
                    var tehfile = Path.GetTempFileName();
                    File.WriteAllBytes(tehfile, Resources.CANYON);
                    NativeMethods.Mp3Play.Open(tehfile);
                    NativeMethods.Mp3Play.Play(true);
                    File.Delete(tehfile);
                    continue;
                }
                Console.WriteLine(@"Error server or client not found");
                continue;
            }
        }

        private static void Client()
        {
            //initalize the steam api binding code.
            SetupClient();
            //Check to see if Sourcesdk2007 is installed and if not then fail with message
            if (!Steamstuff.SteamApps.BIsAppInstalled(218))
            {
                Console.WriteLine(@"Error Source Sdk 2007 is not installed");
                Console.WriteLine(@"Source 2007 is required for the basics");
                Console.ReadKey();
                Environment.Exit(1);
            }
            //open valves registry key
            var key = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
            //if key does not exist then fail
            if (key == null) return;
            //select the source mod install path to find obsidian.
            var ocinstall = key.GetValue("SourceModInstallPath") + "\\obsidian";
            //gameinstalldir is used to store the location of the game installation directory
            var gameinstalldir = new StringBuilder(256);
            //use the steam api to read the location of the source sdk 2007 directory
            Steamstuff.SteamApps.GetAppInstallDir(SourceSdk2007Id, gameinstalldir);
            //store the sourcesdk2007 path seporately so it can be called throughout the program
            _sourcesdk2007Installationpath = gameinstalldir.ToString();
            foreach (var mymount in Requiredmountids)
            {
                if (!Steamstuff.SteamApps.BIsAppInstalled(mymount))
                {
                    Console.Beep();                   
                    continue;
                }
                Steamstuff.SteamApps.GetAppInstallDir(mymount, gameinstalldir);
                switch (Gamename(mymount))
                {
                    case "Half-Life 2":
                        var gamesubdir = "\\hl2";
                        DeleteDir(_sourcesdk2007Installationpath + gamesubdir, true);
                        Runoneachvpk(Returndirvpks(gameinstalldir + gamesubdir));
                        NativeMethods.Otherstuff.CreateSymbolicLink(_sourcesdk2007Installationpath + gamesubdir, gameinstalldir + gamesubdir,
                            NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                        Console.WriteLine(gameinstalldir + gamesubdir);
                        Console.WriteLine(_sourcesdk2007Installationpath + gamesubdir);
                        break;

                    case "Day of Defeat: Source":
                        gamesubdir = "\\dod";
                        DeleteDir(_sourcesdk2007Installationpath + gamesubdir, false);
                        Runoneachvpk(Returndirvpks(gameinstalldir + gamesubdir));
                        NativeMethods.Otherstuff.CreateSymbolicLink(_sourcesdk2007Installationpath + gamesubdir, gameinstalldir + gamesubdir,
                            NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                        Console.WriteLine(gameinstalldir + gamesubdir);
                        Console.WriteLine(_sourcesdk2007Installationpath + gamesubdir);
                        File.Create(ocinstall + "\\mounts\\dod");
                        break;

                    case "Counter-Strike: Source":
                        gamesubdir = "\\cstrike";
                        DeleteDir(_sourcesdk2007Installationpath + gamesubdir, false);
                        Runoneachvpk(Returndirvpks(gameinstalldir + gamesubdir));
                        NativeMethods.Otherstuff.CreateSymbolicLink(_sourcesdk2007Installationpath + gamesubdir, gameinstalldir + gamesubdir,
                            NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                        Console.WriteLine(gameinstalldir + gamesubdir);
                        Console.WriteLine(_sourcesdk2007Installationpath + gamesubdir);
                        File.Create(ocinstall + "\\mounts\\css");
                        break;

                    case "Half-Life: Source":
                        gamesubdir = "\\hl1";
                        DeleteDir(_sourcesdk2007Installationpath + gamesubdir, false);
                        Runoneachvpk(Returndirvpks(gameinstalldir + gamesubdir));
                        NativeMethods.Otherstuff.CreateSymbolicLink(_sourcesdk2007Installationpath + gamesubdir, gameinstalldir + gamesubdir,
                            NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                        Console.WriteLine(gameinstalldir + gamesubdir);
                        Console.WriteLine(_sourcesdk2007Installationpath + gamesubdir);
                        File.Create(ocinstall + "\\mounts\\hls");
                        break;

                    case "Half-Life 2: Lost Coast":
                        gamesubdir = "\\lostcoast";
                        DeleteDir(_sourcesdk2007Installationpath + gamesubdir, false);
                        Runoneachvpk(Returndirvpks(gameinstalldir + gamesubdir));
                        NativeMethods.Otherstuff.CreateSymbolicLink(_sourcesdk2007Installationpath + gamesubdir, gameinstalldir + gamesubdir,
                            NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                        Console.WriteLine(gameinstalldir + gamesubdir);
                        Console.WriteLine(_sourcesdk2007Installationpath + gamesubdir);
                        File.Create(ocinstall + "\\mounts\\lostcoast");
                        break;

                    case "Half-Life 2: Episode One":
                        gamesubdir = "\\episodic";
                        DeleteDir(_sourcesdk2007Installationpath + gamesubdir, false);
                        Runoneachvpk(Returndirvpks(gameinstalldir + gamesubdir));
                        NativeMethods.Otherstuff.CreateSymbolicLink(_sourcesdk2007Installationpath + gamesubdir, gameinstalldir + gamesubdir,
                            NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                        Console.WriteLine(gameinstalldir + gamesubdir);
                        Console.WriteLine(_sourcesdk2007Installationpath + gamesubdir);
                        File.Create(ocinstall + "\\mounts\\episodic");
                        break;

                    case "Half-Life 2: Episode Two":
                        gamesubdir = "\\ep2";
                        DeleteDir(_sourcesdk2007Installationpath + gamesubdir, false);
                        Runoneachvpk(Returndirvpks(gameinstalldir + gamesubdir));
                        NativeMethods.Otherstuff.CreateSymbolicLink(_sourcesdk2007Installationpath + gamesubdir, gameinstalldir + gamesubdir,
                            NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                        Console.WriteLine(gameinstalldir + gamesubdir);
                        Console.WriteLine(_sourcesdk2007Installationpath + gamesubdir);
                        File.Create(ocinstall + "\\mounts\\ep2");
                        break;

                    default:
                        Console.WriteLine(Gamename(mymount) + gameinstalldir);
                        break;
                }
            }
        }

        private static void OpenMenuIfnocmdArguments()
        {
            var choice = CheckifClientOrServer();
            if (choice)
            {
                Client();
            }
            else
            {
                Console.WriteLine(@"Please provide the oc server install path subdirectory");
                var input = Console.ReadLine();
                Server(input);
            }
        }

        private static void Server(string installpath, string username = "", string password = "",bool steamauth = false,string mounts = "")
        {
            if (installpath != null & username == "" & password == "")
            {
                var serverform = new ServerConfiguration(installpath);
                serverform.ShowDialog();
            }
            else if (installpath == null)
            {
                Console.WriteLine(@"Please specify where to install the server");
                var input = Console.ReadLine();
                if (input != null && input.Contains(" "))
                {
                    input = PutIntoQuotes(input);
                }
                Console.WriteLine(input);
                Console.ReadLine();
                var serverform = new ServerConfiguration(input);
                serverform.ShowDialog();
            }
            else if (username != null & password != null)
            {
                var fun = new ServerStuff(installpath, username, password);
                fun.RunFun();
            }else if (username != "" & password != "" & !steamauth & mounts == "")
            {
                var fun = new ServerStuff(installpath, username, password,true);
                fun.RunFun();
            }else if (username != "" & password != "" & steamauth & mounts != "" )
            {
                var fun = new ServerStuff(installpath,username,password,false,mounts);
                fun.RunFun();
            }else if (username != "" & password != "" & !steamauth & mounts != "")
            {
                var fun = new ServerStuff(installpath,username,password,true,mounts);
                fun.RunFun();
            }
        }
    }
}