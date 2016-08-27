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
using steamdirectoryfinder.bothServerAndClient;
using steamdirectoryfinder.Properties;

namespace steamdirectoryfinder.clientpart.mountlocation
{
    class BothWays
    {
        private static List<string> OpenClientFormOrCheckForCommandLineMounts(string fun, List<string> mounts,string imounts)
        {
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
            return mounts;
        }
        private static void InstallClientPatches(string ocinstalldir)
        {
            ClientAndServer.Performtasks("7za.exe", "x clientpatches.7z -o" + MiscFunctions.PutIntoQuotes(ocinstalldir) + " -aoa");
        }
        public static void ExtractClientResources()
        {
            ClientAndServer.ExtractResourcesForBoth();
            File.WriteAllBytes("clientpatches.7z", Resources.clientpatches);
        }

        public static void ClientNohook(string fun = "-n", string imounts = "")
        {
            
            var mounts = new List<string>();
            List<string> storedlocations;
            var sourcesdk2007Installdir = "";
            var ocinstalldir = "";
            Tuple<string, string, List<string>> OcAnd2007AndLocations;
            mounts = OpenClientFormOrCheckForCommandLineMounts(fun, mounts,imounts);
            ExtractClientResources();
            if (mounts == null)
            {
                mounts = new List<string>();
            }
            OcAnd2007AndLocations = NewWay.NewWayStart(mounts);
            if (OcAnd2007AndLocations == null || (OcAnd2007AndLocations.Item1 == "" | OcAnd2007AndLocations.Item2 == ""))
            {
                OcAnd2007AndLocations = OldWay.oldwaysetup(mounts);
            }
            storedlocations = OcAnd2007AndLocations.Item3;
            ocinstalldir = OcAnd2007AndLocations.Item1;
            sourcesdk2007Installdir = OcAnd2007AndLocations.Item2;
            Console.WriteLine(@"Found The directories");
            Thread.Sleep(1000);
            Console.WriteLine(ocinstalldir);
            Console.WriteLine(sourcesdk2007Installdir);
            Console.WriteLine(String.Join(Environment.NewLine, storedlocations.Cast<string>().ToArray()));

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
                BothWays.ClientNohook();
            }
            //sourcesdk2007Installdir = ClientAndServer.GetDirectoryNamestring(sourcesdk2007Installdir);
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
                    ClientAndServer.Runoneachvpk(ClientAndServer.Returndirvpks(game));
                    NativeMethods.Otherstuff.CreateSymbolicLink(sourcesdk2007Installdir + "\\hl2", game,
                        NativeMethods.Otherstuff.SymbolicLinkFlag.Directory);
                }
                else
                {
                    var gamename = game.Split(Path.DirectorySeparatorChar).Last();
                    MiscFunctions.DeleteDir(sourcesdk2007Installdir + "\\" + gamename);
                    ClientAndServer.Runoneachvpk(ClientAndServer.Returndirvpks(game));
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
