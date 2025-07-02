using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace steamdirectoryfinder.clientpart.mountlocation
{
    internal class OldWay
    {
        public static Tuple<string, string, List<string>> oldwaysetup()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            string ocinstalldir = " ";
            string sourcesdk2007Installdir = "";
            string ep2Installdir = " ";
            string hl2Installdir = " ";
            string hl1Installdir = " ";
            string lostcoastinstalldir = " ";
            string episodicinstalldir = " ";
            string dayofdefeatinstalldir = " ";
            string counterstrikesourceinstalldir = " ";
            List<string> storedlocations = new List<string>();
            Console.WriteLine(@"Now looking for the installation directories");

            foreach (DriveInfo drive in drives)
            {
                if (!drive.IsReady)
                {
                    continue;
                }
                Process createfile = new Process
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
                    if (args.Data.EndsWith("steamapps\\common\\Half-Life 2\\hl2"))
                    {
                        hl2Installdir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Half-Life 2\\episodic"))
                    {
                        episodicinstalldir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Half-Life 2\\ep2"))
                    {
                        ep2Installdir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Half-Life 2\\lostcoast"))
                    {
                        lostcoastinstalldir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Half-Life 2\\hl1"))
                    {
                        hl1Installdir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Counter-Strike Source\\cstrike"))
                    {
                        counterstrikesourceinstalldir = args.Data;
                    }
                    if (args.Data.EndsWith("steamapps\\common\\Day of Defeat Source\\dod"))
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