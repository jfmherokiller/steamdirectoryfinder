using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace steamdirectoryfinder.clientpart.mountlocation
{
    class OldWay
    {

        public static Tuple<string, string, List<string>> oldwaysetup(List<string> mounts)
        {
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
                createfile.OutputDataReceived += delegate(object sender, DataReceivedEventArgs args)
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
            return new Tuple<string, string, List<string>>(ocinstalldir, sourcesdk2007Installdir, storedlocations);
        }
    }
}
