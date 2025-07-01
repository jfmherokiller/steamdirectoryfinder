using steamdirectoryfinder.Properties;
using System.IO;

namespace steamdirectoryfinder
{
    public static class MiscFunctions
    {
        public static string PutIntoQuotes(string value)
        {
            return "\"" + value + "\"";
        }

        public static void DeleteDir(string fun)
        {
            if (Directory.Exists(fun))
            {
                Directory.Delete(fun, !File.GetAttributes(fun).HasFlag(FileAttributes.ReparsePoint));
            }
        }

        public static void CreateDir(string fun)
        {
            if (!Directory.Exists(fun))
            {
                Directory.CreateDirectory(fun);
            }
        }

        public static void DeleteFile(string fun)
        {
            if (File.Exists(fun))
            {
                File.Delete(fun);
            }
        }
    }
}