// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class ClientGameServerStatsVTable
    {
        public IntPtr RequestUserStats0;
        public IntPtr GetUserStat1;
        public IntPtr GetUserStat2;
        public IntPtr GetUserAchievement3;
        public IntPtr SetUserStat4;
        public IntPtr SetUserStat5;
        public IntPtr UpdateUserAvgRateStat6;
        public IntPtr SetUserAchievement7;
        public IntPtr ClearUserAchievement8;
        public IntPtr StoreUserStats9;
        public IntPtr SetMaxStatsLoaded10;
        private IntPtr DTorIClientGameServerStats11;
    };

    [InteropHelp.InterfaceVersionAttribute("CLIENTGAMESERVERSTATS_INTERFACE_VERSION001")]
    public class ClientGameServerStats : InteropHelp.NativeWrapper<ClientGameServerStatsVTable>
    {
        public ulong RequestUserStats(CSteamId steamIdUser, CGameId gameId)
        {
            return GetFunction<NativeRequestUserStatsCc>(Functions.RequestUserStats0)(ObjectAddress,
                steamIdUser.ConvertToUint64(), gameId.ConvertToUint64());
        }

        public bool GetUserStat(CSteamId steamIdUser, CGameId gameId, string pchName, ref float pData)
        {
            return GetFunction<NativeGetUserStatCcsf>(Functions.GetUserStat1)(ObjectAddress,
                steamIdUser.ConvertToUint64(), gameId.ConvertToUint64(), pchName, ref pData);
        }

        public bool GetUserStat(CSteamId steamIdUser, CGameId gameId, string pchName, ref int pData)
        {
            return GetFunction<NativeGetUserStatCcsi>(Functions.GetUserStat2)(ObjectAddress,
                steamIdUser.ConvertToUint64(), gameId.ConvertToUint64(), pchName, ref pData);
        }

        public bool GetUserAchievement(CSteamId steamIdUser, CGameId gameId, string pchName, ref bool pbAchieved,
            ref uint prtTime)
        {
            return GetFunction<NativeGetUserAchievementCcsbu>(Functions.GetUserAchievement3)(ObjectAddress,
                steamIdUser.ConvertToUint64(), gameId.ConvertToUint64(), pchName, ref pbAchieved, ref prtTime);
        }

        public bool SetUserStat(CSteamId steamIdUser, CGameId gameId, string pchName, float fData)
        {
            return GetFunction<NativeSetUserStatCcsf>(Functions.SetUserStat4)(ObjectAddress,
                steamIdUser.ConvertToUint64(), gameId.ConvertToUint64(), pchName, fData);
        }

        public bool SetUserStat(CSteamId steamIdUser, CGameId gameId, string pchName, int nData)
        {
            return GetFunction<NativeSetUserStatCcsi>(Functions.SetUserStat5)(ObjectAddress,
                steamIdUser.ConvertToUint64(), gameId.ConvertToUint64(), pchName, nData);
        }

        public bool UpdateUserAvgRateStat(CSteamId steamIdUser, CGameId gameId, string pchName, float flCountThisSession,
            double dSessionLength)
        {
            return GetFunction<NativeUpdateUserAvgRateStatCcsfd>(Functions.UpdateUserAvgRateStat6)(ObjectAddress,
                steamIdUser.ConvertToUint64(), gameId.ConvertToUint64(), pchName, flCountThisSession, dSessionLength);
        }

        public bool SetUserAchievement(CSteamId steamIdUser, CGameId gameId, string pchName)
        {
            return GetFunction<NativeSetUserAchievementCcs>(Functions.SetUserAchievement7)(ObjectAddress,
                steamIdUser.ConvertToUint64(), gameId.ConvertToUint64(), pchName);
        }

        public bool ClearUserAchievement(CSteamId steamIdUser, CGameId gameId, string pchName)
        {
            return GetFunction<NativeClearUserAchievementCcs>(Functions.ClearUserAchievement8)(ObjectAddress,
                steamIdUser.ConvertToUint64(), gameId.ConvertToUint64(), pchName);
        }

        public ulong StoreUserStats(CSteamId steamIdUser, CGameId gameId)
        {
            return GetFunction<NativeStoreUserStatsCc>(Functions.StoreUserStats9)(ObjectAddress,
                steamIdUser.ConvertToUint64(), gameId.ConvertToUint64());
        }

        public void SetMaxStatsLoaded(uint uMax)
        {
            GetFunction<NativeSetMaxStatsLoadedU>(Functions.SetMaxStatsLoaded10)(ObjectAddress, uMax);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeRequestUserStatsCc(IntPtr thisptr, ulong steamIdUser, ulong gameId);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetUserStatCcsf(
            IntPtr thisptr, ulong steamIdUser, ulong gameId, string pchName, ref float pData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetUserStatCcsi(
            IntPtr thisptr, ulong steamIdUser, ulong gameId, string pchName, ref int pData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetUserAchievementCcsbu(
            IntPtr thisptr, ulong steamIdUser, ulong gameId, string pchName, ref bool pbAchieved, ref uint prtTime);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetUserStatCcsf(
            IntPtr thisptr, ulong steamIdUser, ulong gameId, string pchName, float fData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetUserStatCcsi(
            IntPtr thisptr, ulong steamIdUser, ulong gameId, string pchName, int nData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeUpdateUserAvgRateStatCcsfd(
            IntPtr thisptr, ulong steamIdUser, ulong gameId, string pchName, float flCountThisSession,
            double dSessionLength);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetUserAchievementCcs(
            IntPtr thisptr, ulong steamIdUser, ulong gameId, string pchName);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeClearUserAchievementCcs(
            IntPtr thisptr, ulong steamIdUser, ulong gameId, string pchName);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeStoreUserStatsCc(IntPtr thisptr, ulong steamIdUser, ulong gameId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetMaxStatsLoadedU(IntPtr thisptr, uint uMax);
    };
}