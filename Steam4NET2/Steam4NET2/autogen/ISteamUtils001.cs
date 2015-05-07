// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamUtils001VTable
    {
        public IntPtr GetSecondsSinceAppActive0;
        public IntPtr GetSecondsSinceComputerActive1;
        public IntPtr GetConnectedUniverse2;
        public IntPtr GetServerRealTime3;
        private IntPtr DTorISteamUtils0014;
    };

    [InteropHelp.InterfaceVersionAttribute("SteamUtils001")]
    public class SteamUtils001 : InteropHelp.NativeWrapper<SteamUtils001VTable>
    {
        public uint GetSecondsSinceAppActive()
        {
            return GetFunction<NativeGetSecondsSinceAppActive>(Functions.GetSecondsSinceAppActive0)(ObjectAddress);
        }

        public uint GetSecondsSinceComputerActive()
        {
            return
                GetFunction<NativeGetSecondsSinceComputerActive>(Functions.GetSecondsSinceComputerActive1)(ObjectAddress);
        }

        public EUniverse GetConnectedUniverse()
        {
            return GetFunction<NativeGetConnectedUniverse>(Functions.GetConnectedUniverse2)(ObjectAddress);
        }

        public uint GetServerRealTime()
        {
            return GetFunction<NativeGetServerRealTime>(Functions.GetServerRealTime3)(ObjectAddress);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetSecondsSinceAppActive(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetSecondsSinceComputerActive(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EUniverse NativeGetConnectedUniverse(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetServerRealTime(IntPtr thisptr);
    };
}