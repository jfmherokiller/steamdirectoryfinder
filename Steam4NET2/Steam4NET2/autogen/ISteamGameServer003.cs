// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamGameServer003VTable
    {
        public IntPtr LogOn0;
        public IntPtr LogOff1;
        public IntPtr BLoggedOn2;
        public IntPtr BSecure3;
        public IntPtr GetSteamID4;
        public IntPtr GetSteam2GetEncryptionKeyToSendToNewClient5;
        public IntPtr SendUserConnect6;
        public IntPtr RemoveUserConnect7;
        public IntPtr SendUserDisconnect8;
        public IntPtr SetSpawnCount9;
        public IntPtr SetServerType10;
        public IntPtr UpdateStatus11;
        public IntPtr CreateUnauthenticatedUser12;
        public IntPtr SetUserData13;
        public IntPtr UpdateSpectatorPort14;
        public IntPtr SetGameType15;
        public IntPtr GetUserAchievementStatus16;
        private IntPtr DTorISteamGameServer00317;
    };

    [InteropHelp.InterfaceVersionAttribute("SteamGameServer003")]
    public class SteamGameServer003 : InteropHelp.NativeWrapper<SteamGameServer003VTable>
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

        public bool GetSteam2GetEncryptionKeyToSendToNewClient(byte[] pvEncryptionKey, ref uint pcbEncryptionKey,
            uint cbMaxEncryptionKey)
        {
            return
                GetFunction<NativeGetSteam2GetEncryptionKeyToSendToNewClientBuu>(
                    Functions.GetSteam2GetEncryptionKeyToSendToNewClient5)(ObjectAddress, pvEncryptionKey,
                        ref pcbEncryptionKey, cbMaxEncryptionKey);
        }

        public bool SendUserConnect(uint arg0, uint arg1, ushort arg2, byte[] arg3, uint arg4)
        {
            return GetFunction<NativeSendUserConnectUuubu>(Functions.SendUserConnect6)(ObjectAddress, arg0, arg1, arg2,
                arg3, arg4);
        }

        public bool RemoveUserConnect(uint unUserId)
        {
            return GetFunction<NativeRemoveUserConnectU>(Functions.RemoveUserConnect7)(ObjectAddress, unUserId);
        }

        public bool SendUserDisconnect(CSteamId steamId, uint unUserId)
        {
            return GetFunction<NativeSendUserDisconnectCu>(Functions.SendUserDisconnect8)(ObjectAddress,
                steamId.ConvertToUint64(), unUserId);
        }

        public void SetSpawnCount(uint ucSpawn)
        {
            GetFunction<NativeSetSpawnCountU>(Functions.SetSpawnCount9)(ObjectAddress, ucSpawn);
        }

        public bool SetServerType(int nGameAppId, uint unServerFlags, uint unGameIp, ushort unGamePort,
            ushort usSpectatorPort, ushort usQueryPort, string pchGameDir, string pchVersion, bool bLanMode)
        {
            return GetFunction<NativeSetServerTypeIuuuuussb>(Functions.SetServerType10)(ObjectAddress, nGameAppId,
                unServerFlags, unGameIp, unGamePort, usSpectatorPort, usQueryPort, pchGameDir, pchVersion, bLanMode);
        }

        public bool UpdateStatus(int cPlayers, int cPlayersMax, int cBotPlayers, string pchServerName,
            string pSpectatorServerName, string pchMapName)
        {
            return GetFunction<NativeUpdateStatusIiisss>(Functions.UpdateStatus11)(ObjectAddress, cPlayers, cPlayersMax,
                cBotPlayers, pchServerName, pSpectatorServerName, pchMapName);
        }

        public bool CreateUnauthenticatedUser(ref CSteamId pSteamId)
        {
            ulong s0 = 0;
            var result =
                GetFunction<NativeCreateUnauthenticatedUserC>(Functions.CreateUnauthenticatedUser12)(ObjectAddress,
                    ref s0);
            pSteamId = new CSteamId(s0);
            return result;
        }

        public bool SetUserData(CSteamId steamIdUser, string pchPlayerName, uint uScore)
        {
            return GetFunction<NativeSetUserDataCsu>(Functions.SetUserData13)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchPlayerName, uScore);
        }

        public void UpdateSpectatorPort(ushort unSpectatorPort)
        {
            GetFunction<NativeUpdateSpectatorPortU>(Functions.UpdateSpectatorPort14)(ObjectAddress, unSpectatorPort);
        }

        public void SetGameType(string pchGameType)
        {
            GetFunction<NativeSetGameTypeS>(Functions.SetGameType15)(ObjectAddress, pchGameType);
        }

        public bool GetUserAchievementStatus(CSteamId steamId, string pchAchievementName)
        {
            return GetFunction<NativeGetUserAchievementStatusCs>(Functions.GetUserAchievementStatus16)(ObjectAddress,
                steamId.ConvertToUint64(), pchAchievementName);
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
        private delegate bool NativeGetSteam2GetEncryptionKeyToSendToNewClientBuu(
            IntPtr thisptr, byte[] pvEncryptionKey, ref uint pcbEncryptionKey, uint cbMaxEncryptionKey);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSendUserConnectUuubu(
            IntPtr thisptr, uint arg0, uint arg1, ushort arg2, byte[] arg3, uint arg4);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeRemoveUserConnectU(IntPtr thisptr, uint unUserId);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSendUserDisconnectCu(IntPtr thisptr, ulong steamId, uint unUserId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetSpawnCountU(IntPtr thisptr, uint ucSpawn);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetServerTypeIuuuuussb(
            IntPtr thisptr, int nGameAppId, uint unServerFlags, uint unGameIp, ushort unGamePort, ushort usSpectatorPort,
            ushort usQueryPort, string pchGameDir, string pchVersion, [MarshalAs(UnmanagedType.I1)] bool bLanMode);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeUpdateStatusIiisss(
            IntPtr thisptr, int cPlayers, int cPlayersMax, int cBotPlayers, string pchServerName,
            string pSpectatorServerName, string pchMapName);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeCreateUnauthenticatedUserC(IntPtr thisptr, ref ulong pSteamId);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetUserDataCsu(IntPtr thisptr, ulong steamIdUser, string pchPlayerName, uint uScore);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeUpdateSpectatorPortU(IntPtr thisptr, ushort unSpectatorPort);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetGameTypeS(IntPtr thisptr, string pchGameType);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetUserAchievementStatusCs(IntPtr thisptr, ulong steamId, string pchAchievementName);
    };
}