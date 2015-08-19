using steamdirectoryfinder.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace steamdirectoryfinder
{
    internal static class Program
    {
        private static void Checkforrootpath(string ass)
        {
            if (!Directory.Exists(ass)) return;
            var roottest = Directory.GetParent(ass.TrimEnd('\\')).ToString();
            if (Path.GetPathRoot(roottest) == roottest)
            {
                Environment.Exit(1);
            }
        }

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
            File.WriteAllBytes("7za.exe", Resources._7za);
            File.WriteAllBytes("clientpatches.7z",Resources.clientpatches);

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
                    Console.WriteLine(@"-client -y");
                    Console.WriteLine(@"-client -n ""hl2,ep1,lostcoast,ep2,hl1,css,dod""");
                }
                else if (args[0].ToLower().Contains(@"-client"))
                {
                    if ((args.Length == 2) & (args[1] == "-y"))
                    {
                        ClientNohook("-y");
                    }
                    else if (args.Length == 3)
                    {
                        ClientNohook("-n",args[2]);
                    }
                    else
                    {
                        ClientNohook();
                    }
                }
                else if (args[0].ToLower().Contains(@"-server"))
                {
                    Checkforrootpath(args[1]);
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
                if (output != null && output.ToLower() == @"client")
                {
                    //PlaySong();
                    return true;
                }
                if (output != null && output.ToLower() == @"server")
                {
                    return false;
                }
                if (output != null && output.ToLower() == @"fun")
                {
                    PlaySong();
                    continue;
                }
                Console.WriteLine(@"Error server or client not found");
            }
        }

        private static void PlaySong()
        {
            var tehfile = Path.GetTempFileName();
            File.WriteAllBytes(tehfile, Resources.windows);
            NativeMethods.Mp3Play.Open(tehfile);
            NativeMethods.Mp3Play.Play(true);
            File.Delete(tehfile);
        }

        private static void ClientNohook(string fun = "-n",string imounts ="")
        {
            var mounts = new List<string>();
            if (fun == "-y")
            {
                using (var myform = new Client_Configuration())
                {
                    //Console.WriteLine("Do You wish to select mounts?[y/n]");
                    //var ans = Console.ReadKey();
                    //Console.WriteLine();
                    //if (ans.KeyChar == 'y')
                   // {
                        
                        mounts = myform.Mounts;
                    //}
                }
            }
            if (imounts != "")
            {
                mounts = imounts.Split(',').ToList();
            }
            ExtractClientResources();
            var drives = DriveInfo.GetDrives();
            var ocinstalldir = " ";
            var sourcesdk2007Installdir = "";
            var ep2Installdir = " ";
            var hl2Installdir = " ";
            var hl1Installdir = " ";
            var lostcoastinstalldir = " ";
            var episodicinstalldir = " ";
            var dayofdefeatinstalldir = " ";
            var counterstrikesourceinstalldir = " ";
            var storedlocations = new List<string>();
			var programfilename = "cmd";
			var programargs = "/c \"dir /s /b ";

			if (Environment.OSVersion.Platform.Equals (PlatformID.Unix)) 
			{
				programfilename = "find";
				programargs = ".";
			}
            Console.WriteLine(@"Now looking for the installation directories");

            foreach (var drive in drives)
            {
                if (!drive.IsReady)
                {
                    continue;
                }
                var createfile = new Process
                {
                    StartInfo =
                    {
                        UseShellExecute = false,
                        WorkingDirectory = drive.RootDirectory.FullName,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true,
						FileName = programfilename,
						Arguments = programargs
                    }
                };
                createfile.OutputDataReceived += delegate (object sender, DataReceivedEventArgs args)
                {
                    //string[] locations = { "steamapps\\common\\Half-Life 2\\hl2", "steamapps\\common\\Half-Life 2\\episodic", "steamapps\\common\\Half-Life 2\\ep2", "steamapps\\common\\Half-Life 2\\lostcoast", "steamapps\\common\\Half-Life 2\\hl1", "steamapps\\common\\Counter-Strike Source\\cstrike", "steamapps\\common\\Day of Defeat Source\\dod" };
                    if (args.Data == null)
                    {
                        return;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Half-Life 2\\hl2") & (!mounts.Contains("hl2")))
                    {
                        hl2Installdir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Half-Life 2\\episodic") & (!mounts.Contains("ep1")))
                    {
                        episodicinstalldir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Half-Life 2\\ep2") & (!mounts.Contains("ep2")))
                    {
                        ep2Installdir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Half-Life 2\\lostcoast") & (!mounts.Contains("lostcoast")))
                    {
                        lostcoastinstalldir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Half-Life 2\\hl1") & (!mounts.Contains("hl1")))
                    {
                        hl1Installdir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Counter-Strike Source\\cstrike") & (!mounts.Contains("css")))
                    {
                        counterstrikesourceinstalldir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Day of Defeat Source\\dod") & (!mounts.Contains("dod")))
                    {
                        dayofdefeatinstalldir = args.Data;
                    }
                    if (args.Data.EndsWith("Source SDK Base 2007\\hl2.exe"))
                    {
                        sourcesdk2007Installdir = args.Data;
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
            }
            storedlocations.Add(hl2Installdir);
            storedlocations.Add(episodicinstalldir);
            storedlocations.Add(ep2Installdir);
            storedlocations.Add(lostcoastinstalldir);
            storedlocations.Add(hl1Installdir);
            storedlocations.Add(counterstrikesourceinstalldir);
            storedlocations.Add(dayofdefeatinstalldir);

            Console.WriteLine(@"Found The directories");
            Thread.Sleep(1000);
            Console.WriteLine(ocinstalldir);
            Console.WriteLine(sourcesdk2007Installdir);
            Console.WriteLine(string.Join(Environment.NewLine, storedlocations.Cast<string>().ToArray()));

            InstallClientMounts2(sourcesdk2007Installdir, storedlocations, ocinstalldir);
        }

        private static string GetDirectoryNamestring(string f)
        {
            try
            {
                return f.Substring(0, f.LastIndexOf('\\'));
            }
            catch
            {
                return string.Empty;
            }
        }

        private static void InstallClientMounts2(string sourcesdk2007Installdir, IEnumerable<string> storedlocations, string ocinstalldir)
        {
            if (sourcesdk2007Installdir == "")
            {
                MessageBox.Show(@"Error Please install Source sdk 2007 then click ok." + Environment.NewLine + @"If you get this message box again please send the location of your source sdk 2007 installation to the creator so he can fix the mixup.", @"mountfix problem",
                    MessageBoxButtons.OK);
                ClientNohook();
            }
            sourcesdk2007Installdir = GetDirectoryNamestring(sourcesdk2007Installdir);
            //nonparalleloneachgame(sourcesdk2007Installdir, storedlocations, ocinstalldir);
            paralleloneachgame(sourcesdk2007Installdir, storedlocations, ocinstalldir);
            InstallClientPatches(ocinstalldir);
        }

        private static void paralleloneachgame(string sourcesdk2007Installdir, IEnumerable<string> storedlocations, string ocinstalldir)
        {
            Parallel.ForEach(storedlocations, game =>
            {
                if (game == " ")
                {
                }
                else if (game.EndsWith("hl2"))
                {
                    DeleteDir(sourcesdk2007Installdir + "\\hl2");
                    Runoneachvpk(Returndirvpks(game));
                    NativeMethods.Otherstuff.CreateSymbolicLink(sourcesdk2007Installdir + "\\hl2", game,
                        NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                }
                else
                {
                    var gamename = game.Split(Path.DirectorySeparatorChar).Last();
                    DeleteDir(sourcesdk2007Installdir + "\\" + gamename);
                    Runoneachvpk(Returndirvpks(game));
                    NativeMethods.Otherstuff.CreateSymbolicLink(sourcesdk2007Installdir + "\\" + gamename, game,
                        NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                    if (gamename.Equals(@"cstrike"))
                    {
                        File.Create(ocinstalldir + "\\mounts\\css");
                    }
                    else if (gamename.Equals(@"hl1"))
                    {
                        File.Create(ocinstalldir + "\\mounts\\hls");
                    }
                    else
                    {
                        File.Create(ocinstalldir + "\\mounts\\" + gamename);
                    }
                }
            });
        }

/*
        private static void nonparalleloneachgame(string sourcesdk2007Installdir, IEnumerable<string> storedlocations,
            string ocinstalldir)
        {
            foreach (var game in storedlocations)
            {
                if (game == " ")
                {
                }
                else if (game.EndsWith("hl2"))
                {
                    DeleteDir(sourcesdk2007Installdir + "\\hl2");
                    Runoneachvpk(Returndirvpks(game));
                    NativeMethods.Otherstuff.CreateSymbolicLink(sourcesdk2007Installdir + "\\hl2", game,
                        NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                }
                else
                {
                    var gamename = game.Split(Path.DirectorySeparatorChar).Last();
                    DeleteDir(sourcesdk2007Installdir + "\\" + gamename);
                    Runoneachvpk(Returndirvpks(game));
                    NativeMethods.Otherstuff.CreateSymbolicLink(sourcesdk2007Installdir + "\\" + gamename, game,
                        NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                    if (gamename.Equals(@"cstrike"))
                    {
                        File.Create(ocinstalldir + "\\mounts\\css");
                    }
                    else if (gamename.Equals(@"hl1"))
                    {
                        File.Create(ocinstalldir + "\\mounts\\hls");
                    }
                    else
                    {
                        File.Create(ocinstalldir + "\\mounts\\" + gamename);
                    }
                }
            }
        }
*/

        private static void InstallClientPatches(string ocinstalldir)
        {
            Program.Performtasks("7za.exe", "x clientpatches.7z -o" + Program.PutIntoQuotes(ocinstalldir) + " -aoa");
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
                Checkforrootpath(input);
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
                OpenServerForm(installpath);
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
                OpenServerForm(input);
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

        private static void OpenServerForm(string installpath)
        {
            using (var serverform = new ServerConfiguration(installpath))
            {
                serverform.ShowDialog();
            }
                
        }

        private static void Shutdown(object sender, EventArgs a)
        {
            DeleteFile(@"HLExtract.exe");
            DeleteFile(@"HLLib.dll");
            DeleteFile(@"7za.exe");
            DeleteFile(@"steamcmd.zip");
            DeleteFile(@"sourcemod.zip");
            DeleteFile(@"mmsource.zip");
            DeleteFile(@"addons.zip");
            DeleteFile(@"clientpatches.7z");
            DeleteDir(@"steamcmd");
        }

        private static void Tasks(string ass)
        {
            var quotedVpk = PutIntoQuotes(ass);
            var vpkwithoutextend = ass;
            vpkwithoutextend = vpkwithoutextend.Remove(vpkwithoutextend.IndexOf('.'));
            var gamedir = Path.GetDirectoryName(vpkwithoutextend);
            var robocopyargs = PutIntoQuotes(gamedir + "\\root") + " " + PutIntoQuotes(gamedir) + "  /E /MOVE /IS  /MT:" +Environment.ProcessorCount;
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