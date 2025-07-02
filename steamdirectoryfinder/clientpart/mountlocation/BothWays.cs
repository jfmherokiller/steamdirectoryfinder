using steamdirectoryfinder.bothServerAndClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace steamdirectoryfinder.clientpart.mountlocation
{
    internal static class BothWays
    {
        public static void ClientNohook(string fun = "-n", string imounts = "")
        {
            string sourcesdk2007Installdir = "";
            string ocinstalldir = "";
            ClientAndServer.ExtractResourcesForBoth();
            
            Tuple<string, string, List<string>> ocAnd2007AndLocations = NewWay.NewWayStart();
            if (ocAnd2007AndLocations != null)
            {
            }
            if (ocAnd2007AndLocations == null || (ocAnd2007AndLocations.Item1 == "" | ocAnd2007AndLocations.Item2 == "" | ocAnd2007AndLocations.Item3.Count == 0))
            {
                ocAnd2007AndLocations = OldWay.oldwaysetup();
            }

            if (ocAnd2007AndLocations != null)
            {
                List<string> storedlocations = ocAnd2007AndLocations.Item3;
                ocinstalldir = ocAnd2007AndLocations.Item1;
                sourcesdk2007Installdir = ocAnd2007AndLocations.Item2;
                Console.WriteLine(@"Found The directories");
                Thread.Sleep(1000);
                Console.WriteLine(ocinstalldir);
                Console.WriteLine(sourcesdk2007Installdir);
                Console.WriteLine(string.Join(Environment.NewLine, storedlocations.Cast<string>().ToArray()));

                InstallClientMounts2(sourcesdk2007Installdir, storedlocations, ocinstalldir);
            }
            else
            {
                Console.WriteLine("Error Required Information not found");
                Console.WriteLine("Please make sure you have source SDK Base 2007 installed and try again.");
                Console.WriteLine("Press Any Key to close this window");
                Console.ReadKey();
                Environment.Exit(-1);
            }
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
                BothWays.ClientNohook();
            }
            Paralleloneachgame(sourcesdk2007Installdir, storedlocations, ocinstalldir);
        }

        private static void Paralleloneachgame(string sourcesdk2007Installdir, IEnumerable<string> storedlocations,
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
                    ClientAndServer.Runoneachvpk(ClientAndServer.Returndirvpks(game), ocinstalldir);
                    NativeMethods.Otherstuff.CreateSymbolicLink(sourcesdk2007Installdir + "\\hl2", game, NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                }
                else
                {
                    string gamename = game.Split(Path.DirectorySeparatorChar).Last();
                    MiscFunctions.DeleteDir(sourcesdk2007Installdir + "\\" + gamename);
                    ClientAndServer.Runoneachvpk(ClientAndServer.Returndirvpks(game), ocinstalldir);
                    NativeMethods.Otherstuff.CreateSymbolicLink(sourcesdk2007Installdir + "\\" + gamename, game, NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
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