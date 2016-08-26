using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using steamdirectoryfinder.Properties;

namespace steamdirectoryfinder.bothServerAndClient
{
    class ClientAndServer
    {
        public static void ExtractResourcesForBoth()
        {
            File.WriteAllBytes("HLExtract.exe", Resources.HLExtract);
            File.WriteAllBytes("HLLib.dll", Resources.HLLib);
            File.WriteAllBytes("7za.exe", Resources._7za);
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

        public static string GetDirectoryNamestring(string f)
        {
            try
            {
                return f.Substring(0, f.LastIndexOf('\\'));
            }
            catch
            {
                return String.Empty;
            }
        }

        public static IEnumerable<string> Returnallvpks(string dir)
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

        private static void Tasks(string ass)
        {
            var quotedVpk = MiscFunctions.PutIntoQuotes(ass);
            var vpkwithoutextend = ass;
            vpkwithoutextend = vpkwithoutextend.Remove(vpkwithoutextend.IndexOf('.'));
            var gamedir = Path.GetDirectoryName(vpkwithoutextend);
            var robocopyargs = MiscFunctions.PutIntoQuotes(gamedir + "\\root") + " " + MiscFunctions.PutIntoQuotes(gamedir) + "  /E /MOVE /IS  /MT:" +
                               Environment.ProcessorCount;
            //var xcopyargs = PutIntoQuotes(gamedir + "\\root\\*") + " " + PutIntoQuotes(gamedir + "\\") + " /f /s /i /y";
            var hlExtractargs = "-p " + quotedVpk + " -d " + MiscFunctions.PutIntoQuotes(gamedir) + " " + "-e \"\"";
            Performtasks("HLExtract.exe", hlExtractargs);
            Performtasks("robocopy", robocopyargs);

            // Performtasks("xcopy", xcopyargs);
            //Directory.Delete(gamedir + "\\root", true);
            //Performtasks("rd", "/q /s " )
        }
    }
}
