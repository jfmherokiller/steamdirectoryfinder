using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace steamdirectoryfinder.clientpart.mountlocation
{
    internal static class NewWay
    {
        public static Tuple<string, string, List<string>> NewWayStart()
        {
            string steaminstallpath = GetSteamInstallFromReg();
            string ocinstallpath = steaminstallpath + @"\steamapps\sourcemods\obsidian";
            List<string> libraryPaths = GetLibraryPaths(steaminstallpath);
            if (!libraryPaths.Contains(steaminstallpath)) libraryPaths.Add(steaminstallpath);
            List<string> gamepaths = GetGamePaths(libraryPaths);
            string source2007Path = gamepaths.FirstOrDefault(value => value.Contains(@"2007"));
            gamepaths.Remove(source2007Path);
            if (gamepaths.Count != 0 & source2007Path.Length > 0)
            {
                return new Tuple<string, string, List<string>>(ocinstallpath, source2007Path, gamepaths);
            }
            return null;
        }

        private static List<string> GetGamePaths(List<string> libraryPaths)
        {
            List<string> storedlocations = new List<string>();
            string[][] searchpaths = {
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
                    if (Directory.Exists(libpath + pathset[0]))
                    {
                        if (Directory.GetFiles(libpath + pathset[0]).Length != 0)
                        {
                            storedlocations.Add(libpath + pathset[0]);
                        }
                    }
                }
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

            List<string> librarypaths = File.ReadAllLines(steaminstallpath + @"\steamapps\libraryfolders.vdf")
                .Where(line => line.Contains("path")).Select(line => line.Split('"')[3])
                .Select(line => line.Replace(@"\\", Path.DirectorySeparatorChar.ToString())).ToList();
            return librarypaths;
        }

        private static string GetSteamInstallFromReg()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam"))
                {
                    if (key != null)
                    {
                        if (key.GetValue("SteamPath") is string path)
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