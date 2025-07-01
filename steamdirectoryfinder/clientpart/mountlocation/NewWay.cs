using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace steamdirectoryfinder.clientpart.mountlocation
{
    internal static class NewWay
    {
        public static Tuple<string, string, List<string>> NewWayStart(List<string> mounts)
        {
            string steaminstallpath = GetSteamInstallFromReg();
            string ocinstallpath = steaminstallpath + @"\steamapps\sourcemods\obsidian";
            List<string> libraryPaths = GetLibraryPaths(steaminstallpath);
            if (!libraryPaths.Contains(steaminstallpath)) libraryPaths.Add(steaminstallpath);
            List<string> gamepaths = GetGamePaths(libraryPaths, mounts);
            string source2007Path = gamepaths.FirstOrDefault(value => value.Contains(@"2007"));
            gamepaths.Remove(source2007Path);
            if (gamepaths.Count != 0 & source2007Path.Length > 0)
            {
                return new Tuple<string, string, List<string>>(ocinstallpath, source2007Path, gamepaths);
            }
            return null;
        }

        private static List<string> GetGamePaths(List<string> libraryPaths, List<string> mounts)
        {
            List<string> storedlocations = new List<string>();
            string[][] searchpaths = new[]
            {
        new[] {@"\steamapps\common\Half-Life 2\hl2", "hl2"},
        new[] {@"\steamapps\common\Half-Life 2\episodic", "ep1"},
        new[] {@"\steamapps\common\Half-Life 2\ep2", "ep2"},
        new[] {@"\steamapps\common\Half-Life 2\lostcoast", "lostcoast"},
        new[] {@"\steamapps\common\Half-Life 2\hl1", "hl1"},
        new[] {@"\steamapps\common\Counter-Strike Source\cstrike", "css"},
        new[] {@"\steamapps\common\Day of Defeat Source\dod", "dod"},
        new[] {@"\steamapps\common\Source SDK Base 2007", "2007"}
    };

            Console.WriteLine("found " + libraryPaths.Count() + " library paths");
            foreach (string libpath in libraryPaths)
            {
                foreach (string[] pathset in searchpaths)
                {
                    if (Directory.Exists(libpath + pathset[0]) & !mounts.Contains(pathset[1]))
                    {
                        if (Directory.GetFiles(libpath + pathset[0]).Length != 0)
                        {
                            storedlocations.Add(libpath + pathset[0]);
                        }
                    }
                }
//                if (storedlocations.Count == 8)
//                {
//                    break;
//                }
            }

            bool foundDupe = false;
            foreach (string[] pathset in searchpaths)
            {
                List<string> loclist = storedlocations.Where(value => value.Contains(pathset[0])).ToList();
                if (loclist.Count() > 1)
                {

                    Console.WriteLine("found duplicate paths for " + pathset[1] + ":");
                    foreach (string path in loclist)
                    {
                        Console.WriteLine(path);
                    }
                    foundDupe = true;
                }
            }
            if (foundDupe)
            {
                Console.WriteLine("Unable to continue. Please remove the duplicate files/folders and try again.");
                Console.ReadLine();
                Environment.Exit(1);
            }

            return storedlocations;
        }

        private static List<string> GetLibraryPaths(string steaminstallpath)
        {
            if (steaminstallpath == null)
            {
                return null;
            }

            List<string> thing =
                File.ReadLines(steaminstallpath + @"\steamapps\libraryfolders.vdf")
                    .Where(line => line.Contains(":"))
                    .ToList();
            for (int index = 0; index < thing.Count; index++)
            {
                string line = thing[index];
                int pathlength = (line.LastIndexOf("\"", StringComparison.Ordinal) - line.IndexOf(":", StringComparison.Ordinal) - 1) + 2;
                line = line.Substring(line.IndexOf(":", StringComparison.Ordinal) - 1, pathlength)
                    .Replace(@"\\", Path.DirectorySeparatorChar.ToString());
                thing[index] = line.ToLower();
            }
            return thing;
        }

        private static string GetSteamInstallFromReg()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam"))
                {
                    if (key != null)
                    {
                        string path = key.GetValue("SteamPath") as string;
                        if (path != null)
                        {
                            return path.Replace("/", Path.DirectorySeparatorChar.ToString());
                        }
                    }
                }
            }
            catch (Exception)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }
            return null;
        }
    }
}