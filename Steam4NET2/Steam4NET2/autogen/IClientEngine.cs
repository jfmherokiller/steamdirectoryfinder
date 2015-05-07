// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class ClientEngineVTable
    {
        public IntPtr CreateSteamPipe0;
        public IntPtr BReleaseSteamPipe1;
        public IntPtr CreateGlobalUser2;
        public IntPtr ConnectToGlobalUser3;
        public IntPtr CreateLocalUser4;
        public IntPtr CreatePipeToLocalUser5;
        public IntPtr ReleaseUser6;
        public IntPtr IsValidHSteamUserPipe7;
        public IntPtr GetIClientUser8;
        public IntPtr GetIClientGameServer9;
        public IntPtr SetLocalIPBinding10;
        public IntPtr GetUniverseName11;
        public IntPtr GetIClientFriends12;
        public IntPtr GetIClientUtils13;
        public IntPtr GetIClientBilling14;
        public IntPtr GetIClientMatchmaking15;
        public IntPtr GetIClientApps16;
        public IntPtr GetIClientContentServer17;
        public IntPtr GetIClientMatchmakingServers18;
        public IntPtr RunFrame19;
        public IntPtr GetIPCCallCount20;
        public IntPtr GetIClientUserStats21;
        public IntPtr GetIClientGameServerStats22;
        public IntPtr GetIClientNetworking23;
        public IntPtr GetIClientRemoteStorage24;
        public IntPtr GetIClientScreenshots25;
        public IntPtr SetWarningMessageHook26;
        public IntPtr GetIClientGameCoordinator27;
        public IntPtr SetOverlayNotificationPosition28;
        public IntPtr HookScreenshots29;
        public IntPtr IsOverlayEnabled30;
        public IntPtr GetAPICallResult31;
        public IntPtr GetIClientDepotBuilder32;
        public IntPtr GetIClientNetworkDeviceManager33;
        public IntPtr ConCommandInit34;
        public IntPtr GetIClientAppManager35;
        public IntPtr GetIClientConfigStore36;
        public IntPtr BOverlayNeedsPresent37;
        public IntPtr GetIClientGameStats38;
        public IntPtr GetIClientHTTP39;
        public IntPtr BShutdownIfAllPipesClosed40;
        public IntPtr GetIClientAudio41;
        public IntPtr GetIClientMusic42;
        public IntPtr GetIClientUnifiedMessages43;
        public IntPtr GetIClientController44;
        public IntPtr GetIClientParentalSettings45;
        public IntPtr GetIClientStreamLauncher46;
        public IntPtr GetIClientDeviceAuth47;
        private IntPtr DTorIClientEngine48;
    };

    [InteropHelp.InterfaceVersionAttribute("CLIENTENGINE_INTERFACE_VERSION002")]
    public class ClientEngine : InteropHelp.NativeWrapper<ClientEngineVTable>
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

        public int CreateLocalUser(ref int phSteamPipe, EAccountType eAccountType)
        {
            return GetFunction<NativeCreateLocalUserIe>(Functions.CreateLocalUser4)(ObjectAddress, ref phSteamPipe,
                eAccountType);
        }

        public void CreatePipeToLocalUser(int hSteamUser, ref int phSteamPipe)
        {
            GetFunction<NativeCreatePipeToLocalUserIi>(Functions.CreatePipeToLocalUser5)(ObjectAddress, hSteamUser,
                ref phSteamPipe);
        }

        public void ReleaseUser(int hSteamPipe, int hUser)
        {
            GetFunction<NativeReleaseUserIi>(Functions.ReleaseUser6)(ObjectAddress, hSteamPipe, hUser);
        }

        public bool IsValidHSteamUserPipe(int hSteamPipe, int hUser)
        {
            return GetFunction<NativeIsValidHSteamUserPipeIi>(Functions.IsValidHSteamUserPipe7)(ObjectAddress,
                hSteamPipe, hUser);
        }

        public TClass GetIClientUser<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientUserIis>(Functions.GetIClientUser8)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientGameServer<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientGameServerIis>(Functions.GetIClientGameServer9)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public void SetLocalIpBinding(uint unIp, ushort usPort)
        {
            GetFunction<NativeSetLocalIpBindingUu>(Functions.SetLocalIPBinding10)(ObjectAddress, unIp, usPort);
        }

        public string GetUniverseName(EUniverse eUniverse)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(
                        GetFunction<NativeGetUniverseNameE>(Functions.GetUniverseName11)(ObjectAddress, eUniverse)));
        }

        public TClass GetIClientFriends<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientFriendsIis>(Functions.GetIClientFriends12)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientUtils<TClass>(int hSteamPipe) where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientUtilsIs>(Functions.GetIClientUtils13)(ObjectAddress, hSteamPipe,
                        InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientBilling<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientBillingIis>(Functions.GetIClientBilling14)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientMatchmaking<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientMatchmakingIis>(Functions.GetIClientMatchmaking15)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientApps<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientAppsIis>(Functions.GetIClientApps16)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientContentServer<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientContentServerIis>(Functions.GetIClientContentServer17)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientMatchmakingServers<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientMatchmakingServersIis>(Functions.GetIClientMatchmakingServers18)(
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

        public TClass GetIClientUserStats<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientUserStatsIis>(Functions.GetIClientUserStats21)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientGameServerStats<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientGameServerStatsIis>(Functions.GetIClientGameServerStats22)(
                        ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientNetworking<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientNetworkingIis>(Functions.GetIClientNetworking23)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientRemoteStorage<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientRemoteStorageIis>(Functions.GetIClientRemoteStorage24)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientScreenshots<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientScreenshotsIis>(Functions.GetIClientScreenshots25)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public void SetWarningMessageHook(ref IntPtr pFunction)
        {
            GetFunction<NativeSetWarningMessageHookI>(Functions.SetWarningMessageHook26)(ObjectAddress, ref pFunction);
        }

        public TClass GetIClientGameCoordinator<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientGameCoordinatorIis>(Functions.GetIClientGameCoordinator27)(
                        ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public void SetOverlayNotificationPosition(ENotificationPosition eNotificationPosition)
        {
            GetFunction<NativeSetOverlayNotificationPositionE>(Functions.SetOverlayNotificationPosition28)(
                ObjectAddress, eNotificationPosition);
        }

        public bool HookScreenshots(bool bHook)
        {
            return GetFunction<NativeHookScreenshotsB>(Functions.HookScreenshots29)(ObjectAddress, bHook);
        }

        public bool IsOverlayEnabled()
        {
            return GetFunction<NativeIsOverlayEnabled>(Functions.IsOverlayEnabled30)(ObjectAddress);
        }

        public bool GetApiCallResult(int hSteamPipe, ulong hSteamApiCall, byte[] pCallback, int iCallbackExpected,
            ref bool pbFailed)
        {
            return GetFunction<NativeGetApiCallResultIubiib>(Functions.GetAPICallResult31)(ObjectAddress, hSteamPipe,
                hSteamApiCall, pCallback, pCallback.Length, iCallbackExpected, ref pbFailed);
        }

        public TClass GetIClientDepotBuilder<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientDepotBuilderIis>(Functions.GetIClientDepotBuilder32)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientNetworkDeviceManager<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientNetworkDeviceManagerIis>(Functions.GetIClientNetworkDeviceManager33)(
                        ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public void ConCommandInit(ref IntPtr pAccessor)
        {
            GetFunction<NativeConCommandInitI>(Functions.ConCommandInit34)(ObjectAddress, ref pAccessor);
        }

        public TClass GetIClientAppManager<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientAppManagerIis>(Functions.GetIClientAppManager35)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientConfigStore<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientConfigStoreIis>(Functions.GetIClientConfigStore36)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public bool BOverlayNeedsPresent()
        {
            return GetFunction<NativeBOverlayNeedsPresent>(Functions.BOverlayNeedsPresent37)(ObjectAddress);
        }

        public TClass GetIClientGameStats<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientGameStatsIis>(Functions.GetIClientGameStats38)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientHttp<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientHttpiis>(Functions.GetIClientHTTP39)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public bool BShutdownIfAllPipesClosed()
        {
            return GetFunction<NativeBShutdownIfAllPipesClosed>(Functions.BShutdownIfAllPipesClosed40)(ObjectAddress);
        }

        public TClass GetIClientAudio<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientAudioIis>(Functions.GetIClientAudio41)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientMusic<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientMusicIis>(Functions.GetIClientMusic42)(ObjectAddress, hSteamUser,
                        hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientUnifiedMessages<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientUnifiedMessagesIis>(Functions.GetIClientUnifiedMessages43)(
                        ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientController<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientControllerIis>(Functions.GetIClientController44)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientParentalSettings<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientParentalSettingsIis>(Functions.GetIClientParentalSettings45)(
                        ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientStreamLauncher<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientStreamLauncherIis>(Functions.GetIClientStreamLauncher46)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
        }

        public TClass GetIClientDeviceAuth<TClass>(int hSteamUser, int hSteamPipe)
            where TClass : InteropHelp.INativeWrapper, new()
        {
            return
                InteropHelp.CastInterface<TClass>(
                    GetFunction<NativeGetIClientDeviceAuthIis>(Functions.GetIClientDeviceAuth47)(ObjectAddress,
                        hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier(typeof(TClass))));
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
        private delegate int NativeCreateLocalUserIe(IntPtr thisptr, ref int phSteamPipe, EAccountType eAccountType);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeCreatePipeToLocalUserIi(IntPtr thisptr, int hSteamUser, ref int phSteamPipe);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeReleaseUserIi(IntPtr thisptr, int hSteamPipe, int hUser);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeIsValidHSteamUserPipeIi(IntPtr thisptr, int hSteamPipe, int hUser);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientUserIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientGameServerIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetLocalIpBindingUu(IntPtr thisptr, uint unIp, ushort usPort);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetUniverseNameE(IntPtr thisptr, EUniverse eUniverse);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientFriendsIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientUtilsIs(IntPtr thisptr, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientBillingIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientMatchmakingIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientAppsIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientContentServerIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientMatchmakingServersIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeRunFrame(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetIpcCallCount(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientUserStatsIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientGameServerStatsIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientNetworkingIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientRemoteStorageIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientScreenshotsIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetWarningMessageHookI(IntPtr thisptr, ref IntPtr pFunction);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientGameCoordinatorIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetOverlayNotificationPositionE(
            IntPtr thisptr, ENotificationPosition eNotificationPosition);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeHookScreenshotsB(IntPtr thisptr, [MarshalAs(UnmanagedType.I1)] bool bHook);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeIsOverlayEnabled(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetApiCallResultIubiib(
            IntPtr thisptr, int hSteamPipe, ulong hSteamApiCall, byte[] pCallback, int cubCallback,
            int iCallbackExpected, ref bool pbFailed);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientDepotBuilderIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientNetworkDeviceManagerIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeConCommandInitI(IntPtr thisptr, ref IntPtr pAccessor);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientAppManagerIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientConfigStoreIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBOverlayNeedsPresent(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientGameStatsIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientHttpiis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBShutdownIfAllPipesClosed(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientAudioIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientMusicIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientUnifiedMessagesIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientControllerIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientParentalSettingsIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientStreamLauncherIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIClientDeviceAuthIis(
            IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);
    };
}