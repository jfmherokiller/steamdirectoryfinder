using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using steamdirectoryfinder.clientpart.mountlocation;
using steamdirectoryfinder.Properties;
using steamdirectoryfinder.serverpart.code;

namespace steamdirectoryfinder
{
    internal static class Program
    {
        private static string Checkforrootpath(string ass)
        {
            if (!Directory.Exists(ass))
            {
                Directory.CreateDirectory(ass);
            }
            DirectoryInfo d = new DirectoryInfo(ass);
            if (d.Parent == null)
            {
                MessageBox.Show("Please specify a directory that is not Letter:\\ ");
                Environment.Exit(1);
            }
            else
            {
                if (ass.EndsWith("obsidian"))
                {
                    return ass;
                }
                else
                {
                    return ass + "\\obsidian";
                }
            }
            return null;
        }


        public static void DeleteVpks(IEnumerable<string> ass)
        {
            foreach (var avv in ass.Where(avv => !avv.Contains(@"platform")))
            {
                MiscFunctions.DeleteFile(avv);
            }
        }



        [STAThread]
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += Shutdown;
            //using (new ConsoleCopy(@"mylogfile.txt"))
            //{
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
                Console.WriteLine(
                    @"-server ""<serverdirectory\obsidian>"" <username> <password> ""hl2,ep1,lostcoast,ep2,hl1,css,dod""");
                Console.WriteLine(@"-server ""<serverdirectory\obsidian>"" <username> <password> ""0,0,0,0,0,0,0,0""");
                Console.WriteLine(
                    @"-server ""<serverdirectory\obsidian>"" <username> <password> -steamauth ""hl2,ep1,lostcoast,ep2,hl1,css,dod""");
                Console.WriteLine(
                    @"-server ""<serverdirectory\obsidian>"" <username> <password> -steamauth ""0,0,0,0,0,0,0,0""");
                Console.WriteLine(@"-client");
                Console.WriteLine(@"-client -y");
                Console.WriteLine(@"-client -n ""hl2,ep1,lostcoast,ep2,hl1,css,dod""");
            }
            else if (args[0].ToLower().Contains(@"-client"))
            {
                if ((args.Length == 2) & (args[1] == "-y"))
                {
                    OldWay.ClientNohook("-y");
                }
                else if (args.Length == 3)
                {
                    OldWay.ClientNohook("-n", args[2]);
                }
                else
                {
                    OldWay.ClientNohook();
                }
            }
            else if (args[0].ToLower().Contains(@"-server"))
            {
                var fun = Checkforrootpath(args[1]);
                if (fun == null)
                {
                    MessageBox.Show("Please create the server directory then rerun the mountfix");
                    Environment.Exit(1);
                }
                switch (args.Length)
                {
                    case 2:
                    {
                        fun = fun.Trim('"');
                        fun = NativeMethods.Otherstuff.GetShortPathName(fun);
                        Server(fun);
                    }
                        break;

                    case 4:
                    {
                        fun = fun.Trim('"');
                        fun = NativeMethods.Otherstuff.GetShortPathName(fun);
                        Server(fun, args[2], args[3]);
                    }
                        break;

                    case 5:
                    {
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
                        fun = fun.Trim('"');
                        fun = NativeMethods.Otherstuff.GetShortPathName(fun);
                        Server(fun, args[2], args[3], true, args[5]);
                    }
                        break;
                }
            }
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
                    MiscFunctions.PlaySong();
                    continue;
                }
                Console.WriteLine(@"Error server or client not found");
            }
        }



        private static void OpenMenuIfnocmdArguments()
        {
            var choice = CheckifClientOrServer();
            if (choice)
            {
                OldWay.ClientNohook();
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

        private static void Server(string installpath, string username = "", string password = "",
            bool steamauth = false, string mounts = "")
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
                    input = MiscFunctions.PutIntoQuotes(input);
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
            MiscFunctions.DeleteFile(@"HLExtract.exe");
            MiscFunctions.DeleteFile(@"HLLib.dll");
            MiscFunctions.DeleteFile(@"7za.exe");
            MiscFunctions.DeleteFile(@"steamcmd.zip");
            MiscFunctions.DeleteFile(@"sourcemod.zip");
            MiscFunctions.DeleteFile(@"mmsource.zip");
            MiscFunctions.DeleteFile(@"addons.zip");
            MiscFunctions.DeleteFile(@"clientpatches.7z");
            MiscFunctions.DeleteDir(@"steamcmd");
        }
    }
}