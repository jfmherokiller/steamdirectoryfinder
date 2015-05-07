// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamClient006VTable
    {
        public IntPtr CreateSteamPipe0;
        public IntPtr BReleaseSteamPipe1;
        public IntPtr CreateGlobalUser2;
        public IntPtr ConnectToGlobalUser3;
        public IntPtr CreateLocalUser4;
        public IntPtr ReleaseUser5;
        public IntPtr GetISteamUser6;
        public IntPtr GetIVAC7;
        public IntPtr GetISteamGameServer8;
        public IntPtr SetLocalIPBinding9;
        public IntPtr GetUniverseName10;
        public IntPtr GetISteamFriends11;
        public IntPtr GetISteamUtils12;
        public IntPtr GetISteamBilling13;
        public IntPtr GetISteamMatchmaking14;
        public IntPtr GetISteamContentServer15;
        public IntPtr GetISteamApps16;
        public IntPtr GetISteamMasterServerUpdater17;
        public IntPtr GetISteamMatchmakingServers18;
        public IntPtr RunFrame19;
        public IntPtr GetIPCCallCount20;
        private IntPtr DTorISteamClient00621;
    };

    [InteropHelp.InterfaceVersionAttribute("SteamClient006")]
    public class SteamClient006 : InteropHelp.NativeWrapper<SteamClient006VTable>
    {
        public int CreateSteamPipe()
        {
            return GetFunction<NativeCreateSteamPipe>(Functions.CreateSteamPipe0)(ObjectAddress);
        }

        public bool BReleaseSteamPipe(int hSteamPipe)
        {
            return GetFunction<NativeBReleaseSteamPipeI>(Functions.BReleaseSteamPipe1)(ObjectAddress, hSteamPipe);
        }

        public int CreateGlobalUser(ref int phSteamPipe)
        {
            return GetFunction<NativeCreateGlobalUserI>(Functions.CreateGlobalUser2)(ObjectAddress, ref phSteamPipe);
        }

        public int ConnectToGlobalUser(int hSteamPipe)
        {
            return GetFunction<NativeConnectToGlobalUserI>(Functions.ConnectToGlobalUser3)(ObjectAddress, hSteamPipe);
        }

        public int CreateLocalUser(ref int phSteamPipe)
        {
            return GetFunction<NativeCreateLocalUserI>(Functions.CreateLocalUser4)(ObjectAddress, ref phSteamPipe);
        }

        public void ReleaseUser(int hSteamPipe, int hUser)
        {
            GetFunction<NativeReleaseUserIi>(Functions.ReleaseUser5)(ObjectAddress, hSteamPipe, hUser);
        }

        public TClass GetISteamUser<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamUserIis>(Functions.GetISteamUser6)(ObjectAddress, hSteamUser, hSteamPipe,
                        InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIvac<TClass>(int hSteamUser) where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(GetFunction<NativeGetIvaci>(Functions.GetIVAC7)(ObjectAddress,
                    hSteamUser));
        }

        public TClass GetISteamGameServer<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamGameServerIis>(Functions.GetISteamGameServer8)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public void SetLocalIpBinding(uint unIp, ushort usPort)
        {
            GetFunction<NativeSetLocalIpBindingUu>(Functions.SetLocalIPBinding9)(ObjectAddress, unIp, usPort);
        }

        public string GetUniverseName(EUniverse eUniverse)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(
                        GetFunction<NativeGetUniverseNameE>(Functions.GetUniverseName10)(ObjectAddress, eUniverse)));
        }

        public TClass GetISteamFriends<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamFriendsIis>(Functions.GetISteamFriends11)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamUtils<TClass>(int hSteamPipe) where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamUtilsIs>(Functions.GetISteamUtils12)(ObjectAddress, hSteamPipe,
                        InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamBilling<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamBillingIis>(Functions.GetISteamBilling13)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamMatchmaking<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamMatchmakingIis>(Functions.GetISteamMatchmaking14)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamContentServer<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamContentServerIis>(Functions.GetISteamContentServer15)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamApps<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamAppsIis>(Functions.GetISteamApps16)(ObjectAddress, hSteamUser, hSteamPipe,
                        InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamMasterServerUpdater<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamMasterServerUpdaterIis>(Functions.GetISteamMasterServerUpdater17)(
                        ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamMatchmakingServers<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamMatchmakingServersIis>(Functions.GetISteamMatchmakingServers18)(
                        ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public void RunFrame()
        {
            GetFunction<NativeRunFrame>(Functions.RunFrame19)(ObjectAddress);
        }

        public uint GetIpcCallCount()
        {
            return GetFunction<NativeGetIpcCallCount>(Functions.GetIPCCallCount20)(ObjectAddress);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeCreateSteamPipe(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBReleaseSteamPipeI(IntPtr thisptr, int hSteamPipe);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeCreateGlobalUserI(IntPtr thisptr, ref int phSteamPipe);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeConnectToGlobalUserI(IntPtr thisptr, int hSteamPipe);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeCreateLocalUserI(IntPtr thisptr, ref int phSteamPipe);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeReleaseUserIi(IntPtr thisptr, int hSteamPipe, int hUser);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamUserIis(IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion
            );

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIvaci(IntPtr thisptr, int hSteamUser);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamGameServerIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetLocalIpBindingUu(IntPtr thisptr, uint unIp, ushort usPort);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetUniverseNameE(IntPtr thisptr, EUniverse eUniverse);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamFriendsIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamUtilsIs(IntPtr thisptr, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamBillingIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamMatchmakingIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamContentServerIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamAppsIis(IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion
            );

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamMasterServerUpdaterIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamMatchmakingServersIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeRunFrame(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetIpcCallCount(IntPtr thisptr);
    };
}