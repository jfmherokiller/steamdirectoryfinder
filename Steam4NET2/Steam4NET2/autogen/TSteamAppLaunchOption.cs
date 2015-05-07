// This file is automatically generated.

using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SteamAppLaunchOption
    {
        public string szDesc;
        public uint uMaxDescChars;
        public string szCmdLine;
        public uint uMaxCmdLineChars;
        public uint uIndex;
        public uint uIconIndex;
        public int bNoDesktopShortcut;
        public int bNoStartMenuShortcut;
        public int bIsLongRunningUnattended;
    };
}