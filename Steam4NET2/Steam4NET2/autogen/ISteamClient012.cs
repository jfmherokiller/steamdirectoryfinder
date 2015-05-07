// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamClient012VTable
    {
        public IntPtr CreateSteamPipe0;
        public IntPtr BReleaseSteamPipe1;
        public IntPtr ConnectToGlobalUser2;
        public IntPtr CreateLocalUser3;
        public IntPtr ReleaseUser4;
        public IntPtr GetISteamUser5;
        public IntPtr GetISteamGameServer6;
        public IntPtr SetLocalIPBinding7;
        public IntPtr GetISteamFriends8;
        public IntPtr GetISteamUtils9;
        public IntPtr GetISteamMatchmaking10;
        public IntPtr GetISteamMatchmakingServers11;
        public IntPtr GetISteamGenericInterface12;
        public IntPtr GetISteamUserStats13;
        public IntPtr GetISteamGameServerStats14;
        public IntPtr GetISteamApps15;
        public IntPtr GetISteamNetworking16;
        public IntPtr GetISteamRemoteStorage17;
        public IntPtr GetISteamScreenshots18;
        public IntPtr RunFrame19;
        public IntPtr GetIPCCallCount20;
        public IntPtr SetWarningMessageHook21;
        public IntPtr BShutdownIfAllPipesClosed22;
        public IntPtr GetISteamHTTP23;
        public IntPtr GetISteamUnifiedMessages24;
        public IntPtr GetISteamController25;
        private IntPtr DTorISteamClient01226;
    };

    [InteropHelp.InterfaceVersionAttribute("SteamClient012")]
    public class SteamClient012 : InteropHelp.NativeWrapper<SteamClient012VTable>
    {
        public int CreateSteamPipe()
        {
            return GetFunction<NativeCreateSteamPipe>(Functions.CreateSteamPipe0)(ObjectAddress);
        }

        public bool BReleaseSteamPipe(int hSteamPipe)
        {
            return GetFunction<NativeBReleaseSteamPipeI>(Functions.BReleaseSteamPipe1)(ObjectAddress, hSteamPipe);
        }

        public int ConnectToGlobalUser(int hSteamPipe)
        {
            return GetFunction<NativeConnectToGlobalUserI>(Functions.ConnectToGlobalUser2)(ObjectAddress, hSteamPipe);
        }

        public int CreateLocalUser(ref int phSteamPipe, EAccountType eAccountType)
        {
            return GetFunction<NativeCreateLocalUserIe>(Functions.CreateLocalUser3)(ObjectAddress, ref phSteamPipe,
                eAccountType);
        }

        public void ReleaseUser(int hSteamPipe, int hUser)
        {
            GetFunction<NativeReleaseUserIi>(Functions.ReleaseUser4)(ObjectAddress, hSteamPipe, hUser);
        }

        public TClass GetISteamUser<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamUserIis>(Functions.GetISteamUser5)(ObjectAddress, hSteamUser, hSteamPipe,
                        InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamGameServer<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamGameServerIis>(Functions.GetISteamGameServer6)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public void SetLocalIpBinding(uint unIp, ushort usPort)
        {
            GetFunction<NativeSetLocalIpBindingUu>(Functions.SetLocalIPBinding7)(ObjectAddress, unIp, usPort);
        }

        public TClass GetISteamFriends<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamFriendsIis>(Functions.GetISteamFriends8)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamUtils<TClass>(int hSteamPipe) where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamUtilsIs>(Functions.GetISteamUtils9)(ObjectAddress, hSteamPipe,
                        InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamMatchmaking<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamMatchmakingIis>(Functions.GetISteamMatchmaking10)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamMatchmakingServers<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamMatchmakingServersIis>(Functions.GetISteamMatchmakingServers11)(
                        ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamGenericInterface<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamGenericInterfaceIis>(Functions.GetISteamGenericInterface12)(
                        ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamUserStats<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamUserStatsIis>(Functions.GetISteamUserStats13)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamGameServerStats<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamGameServerStatsIis>(Functions.GetISteamGameServerStats14)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamApps<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamAppsIis>(Functions.GetISteamApps15)(ObjectAddress, hSteamUser, hSteamPipe,
                        InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamNetworking<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamNetworkingIis>(Functions.GetISteamNetworking16)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamRemoteStorage<TClass>(int hSteamuser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamRemoteStorageIis>(Functions.GetISteamRemoteStorage17)(ObjectAddress,
                        hSteamuser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamScreenshots<TClass>(int hSteamuser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamScreenshotsIis>(Functions.GetISteamScreenshots18)(ObjectAddress,
                        hSteamuser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public void RunFrame()
        {
            GetFunction<NativeRunFrame>(Functions.RunFrame19)(ObjectAddress);
        }

        public uint GetIpcCallCount()
        {
            return GetFunction<NativeGetIpcCallCount>(Functions.GetIPCCallCount20)(ObjectAddress);
        }

        public void SetWarningMessageHook(ref IntPtr pFunction)
        {
            GetFunction<NativeSetWarningMessageHookI>(Functions.SetWarningMessageHook21)(ObjectAddress, ref pFunction);
        }

        public bool BShutdownIfAllPipesClosed()
        {
            return GetFunction<NativeBShutdownIfAllPipesClosed>(Functions.BShutdownIfAllPipesClosed22)(ObjectAddress);
        }

        public TClass GetISteamHttp<TClass>(int hSteamuser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamHttpiis>(Functions.GetISteamHTTP23)(ObjectAddress, hSteamuser, hSteamPipe,
                        InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamUnifiedMessages<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamUnifiedMessagesIis>(Functions.GetISteamUnifiedMessages24)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetISteamController<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetISteamControllerIis>(Functions.GetISteamController25)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeCreateSteamPipe(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBReleaseSteamPipeI(IntPtr thisptr, int hSteamPipe);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeConnectToGlobalUserI(IntPtr thisptr, int hSteamPipe);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeCreateLocalUserIe(IntPtr thisptr, ref int phSteamPipe, EAccountType eAccountType);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeReleaseUserIi(IntPtr thisptr, int hSteamPipe, int hUser);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamUserIis(IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion
            );

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamGameServerIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetLocalIpBindingUu(IntPtr thisptr, uint unIp, ushort usPort);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamFriendsIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamUtilsIs(IntPtr thisptr, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamMatchmakingIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamMatchmakingServersIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamGenericInterfaceIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamUserStatsIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamGameServerStatsIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamAppsIis(IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion
            );

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamNetworkingIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamRemoteStorageIis(
            IntPtr thisptr, int hSteamuser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamScreenshotsIis(
            IntPtr thisptr, int hSteamuser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeRunFrame(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetIpcCallCount(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetWarningMessageHookI(IntPtr thisptr, ref IntPtr pFunction);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBShutdownIfAllPipesClosed(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamHttpiis(IntPtr thisptr, int hSteamuser, int hSteamPipe, string pchVersion
            );

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamUnifiedMessagesIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetISteamControllerIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);
    };
}