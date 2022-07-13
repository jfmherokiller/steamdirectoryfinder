using steamdirectoryfinder.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace steamdirectoryfinder.bothServerAndClient
{
    internal static class ClientAndServer
    {
        public static void DeleteVpks(IEnumerable<string> listOfVpksToDelete)
        {
            foreach (string vpk in listOfVpksToDelete.Where(avv => !avv.Contains(@"platform")))
            {
                MiscFunctions.DeleteFile(vpk);
            }
        }

        public static void ExtractResourcesForBoth()
        {
            File.WriteAllBytes("HLExtract.exe", Resources.HLExtract);
            File.WriteAllBytes("HLLib.dll", Resources.HLLib);
            File.WriteAllBytes("msvcp100.dll", Resources.MSvcp);
            File.WriteAllBytes("msvcr100.dll", Resources.MSvcr);
            File.WriteAllBytes("7za.exe", Resources._7za);
        }

        public static void Performtasksi(string prog, string ass)
        {
            Process task = new Process
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

        public static IEnumerable<string> Returnallvpks(string dir)
        {
            return Directory.EnumerateFiles(dir, "*.vpk", SearchOption.AllDirectories);
        }

        public static IEnumerable<string> Returndirvpks(string dir)
        {
            IEnumerable<string> vpkfiles = Directory.EnumerateFiles(dir, "*_dir.vpk", SearchOption.AllDirectories);
            return vpkfiles;
        }

        public static void Runoneachvpk(IEnumerable<string> ass)
        {
            foreach (string avv in ass.Where(avv => !avv.Contains(@"platform")))
            {
                ExtractGameResources(avv);
            }
        }

        public static void Runoneachvpk(IEnumerable<string> ass, string ocinstalldir)
        {
            foreach (string avv in ass.Where(avv => !avv.Contains(@"platform")))
            {
                string gameName = new DirectoryInfo(Path.GetDirectoryName(avv)).Name;
                switch (gameName)
                {
                    //revert to orginal mount code if half life campaign is detected
                    case @"hl2":
                    case @"ep2":
                    case @"episodic":
                    case @"hl1":
                    case @"lostcoast":
					case @"cstrike":
					case @"dod":
                        ExtractGameResources(avv);
                        break;
                }
            }
        }

        public static void Performtasks(string prog, string ass)
        {
            Process task = new Process
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
        }

        private static void ExtractGameResources(string ass)
        {
            string quotedVpk = MiscFunctions.PutIntoQuotes(ass);
            string vpkwithoutextend = ass;
            vpkwithoutextend = vpkwithoutextend.Remove(vpkwithoutextend.IndexOf('.'));
            string gamedir = Path.GetDirectoryName(vpkwithoutextend);
            string robocopyargs = MiscFunctions.PutIntoQuotes(gamedir + "\\root") + " " + MiscFunctions.PutIntoQuotes(gamedir) + "  /E /MOVE /IS  /MT:" +
                               Environment.ProcessorCount;
            string hlExtractargs = "-p " + quotedVpk + " -d " + MiscFunctions.PutIntoQuotes(gamedir) + " " + "-e \"/\"";
            Performtasks("HLExtract.exe", hlExtractargs);
            Performtasks("robocopy", robocopyargs);
        }
    }
}