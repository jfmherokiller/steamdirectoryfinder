using System;
using System.Runtime.InteropServices;
using System.Text;

namespace steamdirectoryfinder
{
    internal static class NativeMethods
    {
        public static class Otherstuff
        {
            public enum SymbolicLinkFlag
            {
                Directory = 1
            }

            [DllImport(@"kernel32.dll", CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName,
                SymbolicLinkFlag dwFlags);

            public static string GetShortPathName(string longPath)
            {
                StringBuilder shortPath = new StringBuilder(longPath.Length + 1);

                if (0 == GetShortPathName(longPath, shortPath, shortPath.Capacity))
                {
                    return longPath;
                }

                return shortPath.ToString();
            }

            [DllImport(@"kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            private static extern int GetShortPathName(string path, StringBuilder shortPath, int shortPathLength);
        }
    }
}