using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using steamdirectoryfinder.Properties;

namespace steamdirectoryfinder.clientpart.mountlocation
{
    class FindMounts
    {

        public static void ExtractClientResources()
        {
            bothServerAndClient.ClientAndServer.ExtractResourcesForBoth();
            File.WriteAllBytes("clientpatches.7z", Resources.clientpatches);
        }
        private static void InstallClientPatches(string ocinstalldir)
        {
            bothServerAndClient.ClientAndServer.Performtasks("7za.exe", "x clientpatches.7z -o" + MiscFunctions.PutIntoQuotes(ocinstalldir) + " -aoa");
        }
        public static void ClientNohook(string fun = "-n", string imounts = "")
        {
            var mounts = new List<string>();
            if (fun == "-y")
            {
                using (var myform = new Client_Configuration())
                {
                    var formresults = myform.ShowDialog();
                    mounts = myform.Mounts;
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
                        FileName = "cmd",
                        Arguments = "/c \"dir /s /b "
                    }
                };
                createfile.OutputDataReceived += delegate (object sender, DataReceivedEventArgs args)
                {
                    //string[] locations = { "steamapps\\common\\Half-Life 2\\hl2", "steamapps\\common\\Half-Life 2\\episodic", "steamapps\\common\\Half-Life 2\\ep2", "steamapps\\common\\Half-Life 2\\lostcoast", "steamapps\\common\\Half-Life 2\\hl1", "steamapps\\common\\Counter-Strike Source\\cstrike", "steamapps\\common\\Day of Defeat Source\\dod" };
                    if (args.Data == null)
                    {
                        return;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Half-Life 2\\hl2") & !mounts.Contains("hl2"))
                    {
                        hl2Installdir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Half-Life 2\\episodic") & !mounts.Contains("ep1"))
                    {
                        episodicinstalldir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Half-Life 2\\ep2") & !mounts.Contains("ep2"))
                    {
                        ep2Installdir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Half-Life 2\\lostcoast") & !mounts.Contains("lostcoast"))
                    {
                        lostcoastinstalldir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Half-Life 2\\hl1") & !mounts.Contains("hl1"))
                    {
                        hl1Installdir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Counter-Strike Source\\cstrike") &
                        !mounts.Contains("css"))
                    {
                        counterstrikesourceinstalldir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Day of Defeat Source\\dod") & !mounts.Contains("dod"))
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
        private static void InstallClientMounts2(string sourcesdk2007Installdir, IEnumerable<string> storedlocations,
            string ocinstalldir)
        {
            if (sourcesdk2007Installdir == "")
            {
                MessageBox.Show(
                    @"Error Please install Source sdk 2007 then click ok." + Environment.NewLine +
                    @"If you get this message box again please send the location of your source sdk 2007 installation to the creator so he can fix the mixup.",
                    @"mountfix problem",
                    MessageBoxButtons.OK);
                ClientNohook();
            }
            sourcesdk2007Installdir = bothServerAndClient.ClientAndServer.GetDirectoryNamestring(sourcesdk2007Installdir);
            //nonparalleloneachgame(sourcesdk2007Installdir, storedlocations, ocinstalldir);
            paralleloneachgame(sourcesdk2007Installdir, storedlocations, ocinstalldir);
            InstallClientPatches(ocinstalldir);
        }

        private static void paralleloneachgame(string sourcesdk2007Installdir, IEnumerable<string> storedlocations,
            string ocinstalldir)
        {
            Parallel.ForEach(storedlocations, game =>
            {
                if (game == " ")
                {
                }
                else if (game.EndsWith("hl2"))
                {
                    MiscFunctions.DeleteDir(sourcesdk2007Installdir + "\\hl2");
                    bothServerAndClient.ClientAndServer.Runoneachvpk(bothServerAndClient.ClientAndServer.Returndirvpks(game));
                    NativeMethods.Otherstuff.CreateSymbolicLink(sourcesdk2007Installdir + "\\hl2", game,
                        NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                }
                else
                {
                    var gamename = game.Split(Path.DirectorySeparatorChar).Last();
                    MiscFunctions.DeleteDir(sourcesdk2007Installdir + "\\" + gamename);
                    bothServerAndClient.ClientAndServer.Runoneachvpk(bothServerAndClient.ClientAndServer.Returndirvpks(game));
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
    }
}
