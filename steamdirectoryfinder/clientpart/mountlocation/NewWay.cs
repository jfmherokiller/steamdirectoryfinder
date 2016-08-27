using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace steamdirectoryfinder.clientpart.mountlocation
{
    class NewWay
    {
        public static Tuple<string, string, List<string>> NewWayStart(List<string> mounts)
        {
            var steaminstallpath = GetSteamInstallFromReg();
            var ocinstallpath = steaminstallpath + "\\steamapps\\sourcemods\\obsidian";
            var libraryPaths = GetLibraryPaths(steaminstallpath);
            var gamepaths = GetGamePaths(libraryPaths, mounts);
            var source2007path = gamepaths.Where((value => value.Contains("2007"))).FirstOrDefault();
            if (gamepaths.Count != 0 & source2007path.Length > 0)
            {
                gamepaths.Remove(source2007path);
                return new Tuple<string, string, List<string>>(ocinstallpath,source2007path,gamepaths);
            }
            return null;
        }

        private static List<String> GetGamePaths(List<string> libraryPaths, List<string> mounts)
        {
            var storedlocations = new List<String>();
            var searchpaths = new[]
            { new[] { "\\steamapps\\common\\Half-Life 2\\hl2","hl2"}, new[] { "\\steamapps\\common\\Half-Life 2\\episodic","ep1"},new[]  { "\\steamapps\\common\\Half-Life 2\\ep2","ep2"},
               new[]  { "\\steamapps\\common\\Half-Life 2\\lostcoast","lostcoast"}, new[] { "\\steamapps\\common\\Half-Life 2\\hl1","hl1"}, new[] { "\\steamapps\\common\\Counter-Strike Source\\cstrike", "css" }
            , new[] { "\\steamapps\\common\\Day of Defeat Source\\dod", "dod"}, new[] { "\\steamapps\\common\\Source SDK Base 2007", "2007"}};

            foreach (var libpath in libraryPaths)
            {
                foreach (var pathset in searchpaths)
                {
                    if (Directory.Exists(libpath + pathset[0]) & !mounts.Contains(pathset[1]))
                    {
                        if (Directory.GetFiles(libpath + pathset[0]).Length != 0)
                        {
                             storedlocations.Add(libpath + pathset[0]);
                        }
                    }
                }
                if (storedlocations.Count == 8)
                {
                    break;
                }
            }
            return storedlocations;
        }

        private static List<String> GetLibraryPaths(string steaminstallpath)
        {
            if (steaminstallpath == null) return null;
            var thing =
                File.ReadLines(steaminstallpath + "\\steamapps\\libraryfolders.vdf")
                    .Where((line => line.Contains(":")))
                    .ToList();
            for (int index = 0; index < thing.Count; index++)
            {
                var line = thing[index];
                var pathlength = (line.LastIndexOf("\"") - line.IndexOf(":") - 1) + 2;
                line = line.Substring(line.IndexOf(":") - 1, pathlength)
                    .Replace("\\\\", Path.DirectorySeparatorChar.ToString());
                thing[index] = line;
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
                        object path = key.GetValue("SteamPath");
                        if (path != null)
                        {
                            return (path as string)?.Replace("/", Path.DirectorySeparatorChar.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }
            return null;
        }
    }
}
