// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamGameServer006VTable
    {
        public IntPtr LogOn0;
        public IntPtr LogOff1;
        public IntPtr BLoggedOn2;
        public IntPtr BSecure3;
        public IntPtr GetSteamID4;
        public IntPtr SendUserConnectAndAuthenticate5;
        public IntPtr CreateUnauthenticatedUserConnection6;
        public IntPtr SendUserDisconnect7;
        public IntPtr BUpdateUserData8;
        public IntPtr BSetServerType9;
        public IntPtr UpdateServerStatus10;
        public IntPtr UpdateSpectatorPort11;
        public IntPtr SetGameType12;
        public IntPtr BGetUserAchievementStatus13;
        public IntPtr GetGameplayStats14;
        private IntPtr DTorISteamGameServer00615;
    };

    [InteropHelp.InterfaceVersionAttribute("SteamGameServer006")]
    public class SteamGameServer006 : InteropHelp.NativeWrapper<SteamGameServer006VTable>
    {
        public void LogOn()
        {
            GetFunction<NativeLogOn>(Functions.LogOn0)(ObjectAddress);
        }

        public void LogOff()
        {
            GetFunction<NativeLogOff>(Functions.LogOff1)(ObjectAddress);
        }

        public bool BLoggedOn()
        {
            return GetFunction<NativeBLoggedOn>(Functions.BLoggedOn2)(ObjectAddress);
        }

        public bool BSecure()
        {
            return GetFunction<NativeBSecure>(Functions.BSecure3)(ObjectAddress);
        }

        public CSteamId GetSteamId()
        {
            ulong ret = 0;
            GetFunction<NativeGetSteamId>(Functions.GetSteamID4)(ObjectAddress, ref ret);
            return new CSteamId(ret);
        }

        public bool SendUserConnectAndAuthenticate(uint unIpClient, byte[] pvAuthBlob, ref CSteamId pSteamIdUser)
        {
            ulong s0 = 0;
            var result =
                GetFunction<NativeSendUserConnectAndAuthenticateUbuc>(Functions.SendUserConnectAndAuthenticate5)(
                    ObjectAddress, unIpClient, pvAuthBlob, (uint)pvAuthBlob.Length, ref s0);
            pSteamIdUser = new CSteamId(s0);
            return result;
        }

        public CSteamId CreateUnauthenticatedUserConnection()
        {
            ulong ret = 0;
            GetFunction<NativeCreateUnauthenticatedUserConnection>(Functions.CreateUnauthenticatedUserConnection6)(
                ObjectAddress, ref ret);
            return new CSteamId(ret);
        }

        public void SendUserDisconnect(CSteamId steamIdUser)
        {
            GetFunction<NativeSendUserDisconnectC>(Functions.SendUserDisconnect7)(ObjectAddress,
                steamIdUser.ConvertToUint64());
        }

        public bool BUpdateUserData(CSteamId steamIdUser, string pchPlayerName, uint uScore)
        {
            return GetFunction<NativeBUpdateUserDataCsu>(Functions.BUpdateUserData8)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchPlayerName, uScore);
        }

        public bool BSetServerType(uint unServerFlags, uint unGameIp, ushort unGamePort, ushort unSpectatorPort,
            ushort usQueryPort, string pchGameDir, string pchVersion, bool bLanMode)
        {
            return GetFunction<NativeBSetServerTypeUuuuussb>(Functions.BSetServerType9)(ObjectAddress, unServerFlags,
                unGameIp, unGamePort, unSpectatorPort, usQueryPort, pchGameDir, pchVersion, bLanMode);
        }

        public void UpdateServerStatus(int cPlayers, int cPlayersMax, int cBotPlayers, string pchServerName,
            string pSpectatorServerName, string pchMapName)
        {
            GetFunction<NativeUpdateServerStatusIiisss>(Functions.UpdateServerStatus10)(ObjectAddress, cPlayers,
                cPlayersMax, cBotPlayers, pchServerName, pSpectatorServerName, pchMapName);
        }

        public void UpdateSpectatorPort(ushort unSpectatorPort)
        {
            GetFunction<NativeUpdateSpectatorPortU>(Functions.UpdateSpectatorPort11)(ObjectAddress, unSpectatorPort);
        }

        public void SetGameType(string pchGameType)
        {
            GetFunction<NativeSetGameTypeS>(Functions.SetGameType12)(ObjectAddress, pchGameType);
        }

        public bool BGetUserAchievementStatus(CSteamId steamId, string pchAchievementName)
        {
            return GetFunction<NativeBGetUserAchievementStatusCs>(Functions.BGetUserAchievementStatus13)(ObjectAddress,
                steamId.ConvertToUint64(), pchAchievementName);
        }

        public void GetGameplayStats()
        {
            GetFunction<NativeGetGameplayStats>(Functions.GetGameplayStats14)(ObjectAddress);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeLogOn(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeLogOff(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBLoggedOn(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBSecure(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeGetSteamId(IntPtr thisptr, ref ulong retarg);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSendUserConnectAndAuthenticateUbuc(
            IntPtr thisptr, uint unIpClient, byte[] pvAuthBlob, uint cubAuthBlobSize, ref ulong pSteamIdUser);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeCreateUnauthenticatedUserConnection(IntPtr thisptr, ref ulong retarg);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSendUserDisconnectC(IntPtr thisptr, ulong steamIdUser);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBUpdateUserDataCsu(
            IntPtr thisptr, ulong steamIdUser, string pchPlayerName, uint uScore);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBSetServerTypeUuuuussb(
            IntPtr thisptr, uint unServerFlags, uint unGameIp, ushort unGamePort, ushort unSpectatorPort,
            ushort usQueryPort, string pchGameDir, string pchVersion, [MarshalAs(UnmanagedType.I1)] bool bLanMode);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeUpdateServerStatusIiisss(
            IntPtr thisptr, int cPlayers, int cPlayersMax, int cBotPlayers, string pchServerName,
            string pSpectatorServerName, string pchMapName);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeUpdateSpectatorPortU(IntPtr thisptr, ushort unSpectatorPort);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetGameTypeS(IntPtr thisptr, string pchGameType);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBGetUserAchievementStatusCs(IntPtr thisptr, ulong steamId, string pchAchievementName
            );

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeGetGameplayStats(IntPtr thisptr);
    };
}