using steamdirectoryfinder.clientpart.mountlocation;
using steamdirectoryfinder.serverpart.code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace steamdirectoryfinder
{
    public static class Program
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
                if (ass.Contains(":\\obsidian"))
                {
                    return ass + "\\obsidian";
                }

                if (ass.EndsWith("obsidian"))
                {
                    return ass;
                }
            }

            return ass + "\\obsidian";
        }

        [STAThread]
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += Shutdown;
            using (new ConsoleCopy(@"mylogfile.txt"))
            {
                Perfominitializations();
                SelectArgOptions(args);
            }
        }


        private static void SelectArgOptions(string[] args)
        {
            if (args.Length == 0)
            {
                OpenMenuIfnocmdArguments();
                return;
            }

            string mainCommand = args[0].ToLower();

            if (mainCommand.Contains("-help"))
            {
                Console.WriteLine(@"Usage!");
                Console.WriteLine(@"-server ""<serverdirectory\obsidian>"" <username> <password>");
                Console.WriteLine(@"-client");
                return;
            }

            if (mainCommand.Contains("-client"))
            {
                HandleClientArgs(args);
                return;
            }

            if (mainCommand.Contains("-server"))
            {
                HandleServerArgs(args);
            }
        }

        private static void HandleClientArgs(string[] args)
        {
            BothWays.ClientNohook("-y");
        }

        private static void HandleServerArgs(string[] args)
        {
            if (args.Length <= 1)
            {
                MessageBox.Show(@"Please create the server directory then rerun the mountfix");
                Environment.Exit(1);
                return;
            }

            string fun = Checkforrootpath(args[1]);

            switch (args.Length)
            {
                case 2:
                    fun = fun.Trim('"');
                    fun = NativeMethods.Otherstuff.GetShortPathName(fun);
                    Server(fun);
                    break;

                case 4:
                    fun = fun.Trim('"');
                    fun = NativeMethods.Otherstuff.GetShortPathName(fun);
                    Server(fun, args[2], args[3]);
                    break;
                default:
                    MessageBox.Show(@"Please provide the correct amount of arguments");
                    Application.Exit();
                    break;
            }
        }

        private static bool CheckifClientOrServer()
        {
            while (true)
            {
                Console.WriteLine(@"Source SDK 2007 Mountfix Tool for Obsidian Conflict");
                Console.WriteLine(@" ");
                Console.WriteLine(
                    @"Notice: For client mode please follow the instructions at the following link first before proceeding.");
                Console.WriteLine(@" ");
                Console.WriteLine(@"https://github.com/RSDNTWK/steamdirectoryfinder/blob/master/install.txt");
                Console.WriteLine(@" ");
                Console.WriteLine(
                    @"If you have followed the steps and wish to continue type 'client' without ' and press enter.");
                Console.WriteLine(
                    @"For server mode you can continue by typing 'server' without ' and press enter to proceed the next steps.");
                Console.WriteLine(@" ");
                Console.WriteLine(@"Please specify if you are using a client or server:");
                string output = Console.ReadLine();
                if (output != null && output.ToLower() == @"client")
                {
                    return true;
                }

                if (output != null && output.ToLower() == @"server")
                {
                    return false;
                }

                Console.WriteLine(@"Error server or client not found");
            }
        }

        private static void OpenMenuIfnocmdArguments()
        {
            bool choice = CheckifClientOrServer();
            if (choice)
            {
                BothWays.ClientNohook();
            }
            else
            {
                Console.WriteLine(@"Please provide the oc server install path subdirectory");
                string input = Console.ReadLine();
                input = Checkforrootpath(input);
                Server(input);
            }
        }

        private static void Perfominitializations()
        {
            Console.Title = @"Mountfix Tool for Obsidian Conflict 0.1.3.5";
        }

        private static void Server(string installpath, string username = "", string password = "")
        {
            if (installpath != null & username == "" & password == "")
            {
                new ServerFormStuffs().OpenServerForm(installpath);
            }
            else if (installpath == null)
            {
                Console.WriteLine(@"Please specify where to install the server");
                string input = Console.ReadLine();
                if (input != null && input.Contains(@" "))
                {
                    input = MiscFunctions.PutIntoQuotes(input);
                }

                Console.WriteLine(input);
                Console.ReadLine();
                new ServerFormStuffs().OpenServerForm(input);
            }
            else if (username != null & password != null)
            {
                ServerStuff fun = new ServerStuff(installpath, username, password);
                fun.RunFun();
            }
        }

        private static void Shutdown(object sender, EventArgs a)
        {
            MiscFunctions.DeleteFile(@"vcredist_x86.exe");
            MiscFunctions.DeleteFile(@"HLExtract.exe");
            MiscFunctions.DeleteFile(@"HLLib.dll");
            MiscFunctions.DeleteFile(@"7za.exe");
            MiscFunctions.DeleteFile(@"steamcmd.zip");
            MiscFunctions.DeleteFile(@"sourcemod.zip");
            MiscFunctions.DeleteFile(@"mmsource.zip");
            MiscFunctions.DeleteFile(@"addons.zip");
            MiscFunctions.DeleteDir(@"steamcmd");
        }
    }
}