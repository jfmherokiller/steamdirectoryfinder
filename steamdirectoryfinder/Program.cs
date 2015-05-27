using steamdirectoryfinder.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace steamdirectoryfinder
{
    internal static class Program
    {
        public static void DeleteDir(string fun)
        {
            if (Directory.Exists(fun))
            {
                Directory.Delete(fun, !File.GetAttributes(fun).HasFlag(FileAttributes.ReparsePoint));
            }
        }

        public static void DeleteFile(string fun)
        {
            if (File.Exists(fun))
            {
                File.Delete(fun);
            }
        }

        public static void DeleteVpks(IEnumerable<string> ass)
        {
            foreach (var avv in ass.Where(avv => !avv.Contains(@"platform")))
            {
                DeleteFile(avv);
            }
        }

        public static void ExtractClientResources()
        {
            File.WriteAllBytes("HLExtract.exe", Resources.HLExtract);
            File.WriteAllBytes("HLLib.dll", Resources.HLLib);
        }

        [STAThread]
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += Shutdown;
            using (new ConsoleCopy(@"mylogfile.txt"))
            {
                Perfominitializations();
                if (args.Length == 0)
                {
                    OpenMenuIfnocmdArguments();
                }
                else if (args[0].ToLower().Contains(@"-help"))
                {
                    Console.WriteLine(@"Usage!");
                    Console.WriteLine(@"-server ""<serverdirectory\obsidian>""");
                    Console.WriteLine(@"-server ""<serverdirectory\obsidian>"" <username> <password>");
                    Console.WriteLine(@"-server ""<serverdirectory\obsidian>"" <username> <password> -steamauth");
                    Console.WriteLine(@"-server ""<serverdirectory\obsidian>"" <username> <password> ""hl2,ep1,lostcoast,ep2,hl1,css,dod""");
                    Console.WriteLine(@"-server ""<serverdirectory\obsidian>"" <username> <password> ""0,0,0,0,0,0,0,0""");
                    Console.WriteLine(@"-server ""<serverdirectory\obsidian>"" <username> <password> -steamauth ""hl2,ep1,lostcoast,ep2,hl1,css,dod""");
                    Console.WriteLine(@"-server ""<serverdirectory\obsidian>"" <username> <password> -steamauth ""0,0,0,0,0,0,0,0""");
                    Console.WriteLine(@"-client");
                }
                else if (args[0].ToLower().Contains(@"-client"))
                {
                    ClientNohook();
                }
                else if (args[0].ToLower().Contains(@"-server"))
                {
                    switch (args.Length)
                    {
                        case 2:
                            {
                                var fun = args[1];
                                fun = fun.Trim('"');
                                fun = NativeMethods.Otherstuff.GetShortPathName(fun);
                                Server(fun);
                            }
                            break;

                        case 4:
                            {
                                var fun = args[1];
                                fun = fun.Trim('"');
                                fun = NativeMethods.Otherstuff.GetShortPathName(fun);
                                Server(fun, args[2], args[3]);
                            }
                            break;

                        case 5:
                            {
                                var fun = args[1];
                                fun = fun.Trim('"');
                                fun = NativeMethods.Otherstuff.GetShortPathName(fun);
                                if (args[4].Contains(@"-steamauth"))
                                {
                                    Server(fun, args[2], args[3], true);
                                }
                                else
                                {
                                    Server(fun, args[2], args[3], false, args[4]);
                                }
                            }
                            break;

                        case 6:
                            {
                                var fun = args[1];
                                fun = fun.Trim('"');
                                fun = NativeMethods.Otherstuff.GetShortPathName(fun);
                                Server(fun, args[2], args[3], true, args[5]);
                            }
                            break;
                    }
                }
            }
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
            //Console.SetIn(new StreamReader(Console.OpenStandardInput()));
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

        public static string PutIntoQuotes(string value)
        {
            return "\"" + value + "\"";
        }

        public static IEnumerable<string> Returnallvpks(String dir)
        {
            return Directory.EnumerateFiles(dir, "*.vpk", SearchOption.AllDirectories);
        }

        public static IEnumerable<string> Returndirvpks(string dir)
        {
            var vpkfiles = Directory.EnumerateFiles(dir, "*_dir.vpk", SearchOption.AllDirectories);
            return vpkfiles;
        }

        public static void Runoneachvpk(IEnumerable<string> ass)
        {
            foreach (var avv in ass.Where(avv => !avv.Contains(@"platform")))
                Tasks(avv);
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
                    File.WriteAllBytes(tehfile, Resources.windows);
                    NativeMethods.Mp3Play.Open(tehfile);
                    NativeMethods.Mp3Play.Play(true);
                    File.Delete(tehfile);
                    continue;
                }
                Console.WriteLine(@"Error server or client not found");
            }
        }

        private static void ClientNohook()
        {
            ExtractClientResources();
            var drives = DriveInfo.GetDrives();
            var ocinstalldir = "";
            var sourcesdk2007Installdir = "";
            var ep2Installdir = "";
            var hl2Installdir = "";
            var hl1Installdir = "";
            var lostcoastinstalldir = "";
            var episodicinstalldir = "";
            var dayofdefeatinstalldir = "";
            var counterstrikesourceinstalldir = "";
            Parallel.ForEach(drives, (drive, state) =>
            {
                if (!drive.IsReady)
                {
                    state.Stop();
                }
                var createfile = new Process
                {
                    StartInfo =
                    {
                        UseShellExecute = false,
                        WorkingDirectory = drive.RootDirectory.FullName,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true,
                        FileName = "cmd",
                        Arguments = "/c \"dir /s /b "
                    }
                };
                createfile.OutputDataReceived += delegate(object sender, DataReceivedEventArgs args)
                {
                    if (args.Data == null)
                    {
                        return;
                    }
                    if (args.Data.Contains("Source SDK Base 2007") & !args.Data.Contains("Source SDK Base 2007\\"))
                    {
                        sourcesdk2007Installdir = args.Data;
                    }
                    if (args.Data.Contains("Half-Life 2\\hl2") & !args.Data.Contains("Half-Life 2\\hl2\\") &
                        !args.Data.Contains("Half-Life 2\\hl2.exe"))
                    {
                        hl2Installdir = args.Data;
                    }
                    if (args.Data.Contains("Half-Life 2\\episodic") & !args.Data.Contains("Half-Life 2\\episodic\\"))
                    {
                        episodicinstalldir = args.Data;
                    }
                    if (args.Data.Contains("Half-Life 2\\ep2") & !args.Data.Contains("Half-Life 2\\ep2\\"))
                    {
                        ep2Installdir = args.Data;
                    }
                    if (args.Data.Contains("Half-Life 2\\lostcoast") & !args.Data.Contains("Half-Life 2\\lostcoast\\"))
                    {
                        lostcoastinstalldir = args.Data;
                    }
                    if (args.Data.Contains("Half-Life 2\\hl1") & !args.Data.Contains("Half-Life 2\\hl1\\") &
                        !args.Data.Contains("Half-Life 2\\hl1_hd"))
                    {
                        hl1Installdir = args.Data;
                    }
                    if (args.Data.Contains("Counter-Strike Source\\cstrike") &
                        !args.Data.Contains("Counter-Strike Source\\cstrike\\"))
                    {
                        counterstrikesourceinstalldir = args.Data;
                    }
                    if (args.Data.Contains("Day of Defeat Source\\dod") &
                        !args.Data.Contains("Day of Defeat Source\\dod\\"))
                    {
                        dayofdefeatinstalldir = args.Data;
                    }
                    if (args.Data.EndsWith("sourcemods\\obsidian", true, CultureInfo.InvariantCulture) &
                        !args.Data.Contains("sourcemods\\obsidian\\"))
                    {
                        ocinstalldir = args.Data;
                    }
                };
                createfile.Start();
                createfile.BeginOutputReadLine();
                createfile.WaitForExit();
            });

            Console.WriteLine(ocinstalldir);
            Console.WriteLine(sourcesdk2007Installdir);
            Console.WriteLine(ep2Installdir);
            Console.WriteLine(hl2Installdir);
            Console.WriteLine(hl1Installdir);
            Console.WriteLine(episodicinstalldir);
            Console.WriteLine(lostcoastinstalldir);
            Console.WriteLine(counterstrikesourceinstalldir);
            Console.WriteLine(dayofdefeatinstalldir);
            InstallClientMounts(hl2Installdir, sourcesdk2007Installdir, episodicinstalldir, ocinstalldir, ep2Installdir, hl1Installdir, lostcoastinstalldir, counterstrikesourceinstalldir, dayofdefeatinstalldir);
            if (!Environment.Is64BitOperatingSystem) return;
            var laafun = new LaaFile(sourcesdk2007Installdir + "\\hl2.exe");
            if (laafun.LargeAddressAware == false)
            {
                laafun.WriteCharacteristics(true);
            }
        }

        private static void InstallClientMounts(string hl2Installdir, string sourcesdk2007Installdir, string episodicinstalldir,
            string ocinstalldir, string ep2Installdir, string hl1Installdir, string lostcoastinstalldir,
            string counterstrikesourceinstalldir, string dayofdefeatinstalldir)
        {
            if (hl2Installdir != "")
            {
                DeleteDir(sourcesdk2007Installdir + "\\hl2");
                Runoneachvpk(Returndirvpks(hl2Installdir));
                NativeMethods.Otherstuff.CreateSymbolicLink(sourcesdk2007Installdir + "\\hl2", hl2Installdir,
                    NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
            }
            if (episodicinstalldir != "")
            {
                DeleteDir(sourcesdk2007Installdir + "\\episodic");
                Runoneachvpk(Returndirvpks(episodicinstalldir));
                NativeMethods.Otherstuff.CreateSymbolicLink(sourcesdk2007Installdir + "\\episodic", episodicinstalldir,
                    NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                File.Create(ocinstalldir + "\\mounts\\episodic");
            }
            if (ep2Installdir != "")
            {
                DeleteDir(sourcesdk2007Installdir + "\\ep2");
                Runoneachvpk(Returndirvpks(ep2Installdir));
                NativeMethods.Otherstuff.CreateSymbolicLink(sourcesdk2007Installdir + "\\ep2", ep2Installdir,
                    NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                File.Create(ocinstalldir + "\\mounts\\ep2");
            }
            if (hl1Installdir != "")
            {
                DeleteDir(sourcesdk2007Installdir + "\\hl1");
                Runoneachvpk(Returndirvpks(hl1Installdir));
                NativeMethods.Otherstuff.CreateSymbolicLink(sourcesdk2007Installdir + "\\hl1", hl1Installdir,
                    NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                File.Create(ocinstalldir + "\\mounts\\hls");
            }
            if (lostcoastinstalldir != "")
            {
                DeleteDir(sourcesdk2007Installdir + "\\lostcoast");
                Runoneachvpk(Returndirvpks(lostcoastinstalldir));
                NativeMethods.Otherstuff.CreateSymbolicLink(sourcesdk2007Installdir + "\\lostcoast", lostcoastinstalldir,
                    NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                File.Create(ocinstalldir + "\\mounts\\lostcoast");
            }
            if (counterstrikesourceinstalldir != "")
            {
                DeleteDir(sourcesdk2007Installdir + "\\cstrike");
                Runoneachvpk(Returndirvpks(counterstrikesourceinstalldir));
                NativeMethods.Otherstuff.CreateSymbolicLink(sourcesdk2007Installdir + "\\cstrike", counterstrikesourceinstalldir,
                    NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                File.Create(ocinstalldir + "\\mounts\\css");
            }
            if (dayofdefeatinstalldir != "")
            {
                DeleteDir(sourcesdk2007Installdir + "\\dod");
                Runoneachvpk(Returndirvpks(dayofdefeatinstalldir));
                NativeMethods.Otherstuff.CreateSymbolicLink(sourcesdk2007Installdir + "\\dod", dayofdefeatinstalldir,
                    NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                File.Create(ocinstalldir + "\\mounts\\dod");
            }
        }

        private static void OpenMenuIfnocmdArguments()
        {
            var choice = CheckifClientOrServer();
            if (choice)
            {
                ClientNohook();
            }
            else
            {
                Console.WriteLine(@"Please provide the oc server install path subdirectory");
                var input = Console.ReadLine();
                Server(input);
            }
        }

        private static void Perfominitializations()
        {
            Console.Title = @"Source Sdk 2007 steampipe fix";
        }
        private static void Server(string installpath, string username = "", string password = "", bool steamauth = false, string mounts = "")
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
            else if (username != null & password != null & !steamauth & mounts == "")
            {
                var fun = new ServerStuff(installpath, username, password);
                fun.RunFun();
            }
            else if (username != "" & password != "" & steamauth & mounts == "")
            {
                var fun = new ServerStuff(installpath, username, password, true);
                fun.RunFun();
            }
            else if (username != "" & password != "" & !steamauth & mounts != "")
            {
                var fun = new ServerStuff(installpath, username, password, false, mounts);
                fun.RunFun();
            }
            else if (username != "" & password != "" & steamauth & mounts != "")
            {
                var fun = new ServerStuff(installpath, username, password, true, mounts);
                fun.RunFun();
            }
        }

        private static void Shutdown(object sender, EventArgs a)
        {
            DeleteFile(@"HLExtract.exe");
            DeleteFile(@"HLLib.dll");
            DeleteFile(@"7za.exe");
            DeleteFile(@"steamcmd.zip");
            DeleteFile(@"sourcemod.zip");
            DeleteFile(@"addons.zip");
            DeleteDir(@"steamcmd");
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
            Performtasks("robocopy", robocopyargs);

            // Performtasks("xcopy", xcopyargs);
            //Directory.Delete(gamedir + "\\root", true);
            //Performtasks("rd", "/q /s " )
        }
    }
}