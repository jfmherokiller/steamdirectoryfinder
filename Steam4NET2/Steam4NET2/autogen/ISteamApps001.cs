// This file is automatically generated.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamApps001VTable
    {
        public IntPtr GetAppData0;
        private IntPtr DTorISteamApps0011;
    };

    [InteropHelp.InterfaceVersionAttribute("STEAMAPPS_INTERFACE_VERSION001")]
    public class SteamApps001 : InteropHelp.NativeWrapper<SteamApps001VTable>
    {
        public int GetAppData(uint nAppId, string pchKey, StringBuilder pchValue)
        {
            return GetFunction<NativeGetAppDataUssi>(Functions.GetAppData0)(ObjectAddress, nAppId, pchKey, pchValue,
                pchValue.Capacity);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetAppDataUssi(
            IntPtr thisptr, uint nAppId, string pchKey, StringBuilder pchValue, int cchValueMax);
    };
}