// This file is automatically generated.

using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SteamDiscountQualifier
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string szName;

        public uint uRequiredSubscription;
        public int bIsDisqualifier;
    };
}