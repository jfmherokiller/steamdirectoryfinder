using System;
using System.Runtime.InteropServices;
using System.Text;

namespace steamdirectoryfinder
{
    internal static class NativeMethods
    {
        internal static class Mp3Play
        {
            private static string _command;
            private static bool _isOpen;

            [DllImport("winmm.dll", CharSet = CharSet.Unicode)]
            private static extern uint mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength,
                IntPtr hwndCallback);

            public static void Close()
            {
                _command = "close MediaFile";
                mciSendString(_command, null, 0, IntPtr.Zero);
                _isOpen = false;
            }

            public static void Open(string sFileName)
            {
                _command = "open \"" + sFileName + "\" type mpegvideo alias MediaFile";
                mciSendString(_command, null, 0, IntPtr.Zero);
                _isOpen = true;
            }

            public static void Play(bool loop)
            {
                if (_isOpen)
                {
                    _command = "play MediaFile";
                    if (loop)
                        _command += " REPEAT";
                    mciSendString(_command, null, 0, IntPtr.Zero);
                }
            }
        }

        public static class Otherstuff
        {
            public enum SymbolicLinkFlag
            {
                File = 0,
                Directory = 1
            }

            public static string GetShortPathName(string longPath)
            {
                var shortPath = new StringBuilder(longPath.Length + 1);

                if (0 == GetShortPathName(longPath, shortPath, shortPath.Capacity))
                {
                    return longPath;
                }

                return shortPath.ToString();
            }

            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            private static extern int GetShortPathName(string path, StringBuilder shortPath, int shortPathLength);

            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName,
                SymbolicLinkFlag dwFlags);
        }
    }
}