// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamUserStats009VTable
    {
        public IntPtr RequestCurrentStats0;
        public IntPtr GetStat1;
        public IntPtr GetStat2;
        public IntPtr SetStat3;
        public IntPtr SetStat4;
        public IntPtr UpdateAvgRateStat5;
        public IntPtr GetAchievement6;
        public IntPtr SetAchievement7;
        public IntPtr ClearAchievement8;
        public IntPtr GetAchievementAndUnlockTime9;
        public IntPtr StoreStats10;
        public IntPtr GetAchievementIcon11;
        public IntPtr GetAchievementDisplayAttribute12;
        public IntPtr IndicateAchievementProgress13;
        public IntPtr RequestUserStats14;
        public IntPtr GetUserStat15;
        public IntPtr GetUserStat16;
        public IntPtr GetUserAchievement17;
        public IntPtr GetUserAchievementAndUnlockTime18;
        public IntPtr ResetAllStats19;
        public IntPtr FindOrCreateLeaderboard20;
        public IntPtr FindLeaderboard21;
        public IntPtr GetLeaderboardName22;
        public IntPtr GetLeaderboardEntryCount23;
        public IntPtr GetLeaderboardSortMethod24;
        public IntPtr GetLeaderboardDisplayType25;
        public IntPtr DownloadLeaderboardEntries26;
        public IntPtr DownloadLeaderboardEntriesForUsers27;
        public IntPtr GetDownloadedLeaderboardEntry28;
        public IntPtr UploadLeaderboardScore29;
        public IntPtr AttachLeaderboardUGC30;
        public IntPtr GetNumberOfCurrentPlayers31;
        private IntPtr DTorISteamUserStats00932;
    };

    [InteropHelp.InterfaceVersionAttribute("STEAMUSERSTATS_INTERFACE_VERSION009")]
    public class SteamUserStats009 : InteropHelp.NativeWrapper<SteamUserStats009VTable>
    {
        public bool RequestCurrentStats()
        {
            return GetFunction<NativeRequestCurrentStats>(Functions.RequestCurrentStats0)(ObjectAddress);
        }

        public bool GetStat(string pchName, ref float pData)
        {
            return GetFunction<NativeGetStatSf>(Functions.GetStat1)(ObjectAddress, pchName, ref pData);
        }

        public bool GetStat(string pchName, ref int pData)
        {
            return GetFunction<NativeGetStatSi>(Functions.GetStat2)(ObjectAddress, pchName, ref pData);
        }

        public bool SetStat(string pchName, float fData)
        {
            return GetFunction<NativeSetStatSf>(Functions.SetStat3)(ObjectAddress, pchName, fData);
        }

        public bool SetStat(string pchName, int nData)
        {
            return GetFunction<NativeSetStatSi>(Functions.SetStat4)(ObjectAddress, pchName, nData);
        }

        public bool UpdateAvgRateStat(string pchName, float flCountThisSession, double dSessionLength)
        {
            return GetFunction<NativeUpdateAvgRateStatSfd>(Functions.UpdateAvgRateStat5)(ObjectAddress, pchName,
                flCountThisSession, dSessionLength);
        }

        public bool GetAchievement(string pchName, ref bool pbAchieved)
        {
            return GetFunction<NativeGetAchievementSb>(Functions.GetAchievement6)(ObjectAddress, pchName, ref pbAchieved);
        }

        public bool SetAchievement(string pchName)
        {
            return GetFunction<NativeSetAchievementS>(Functions.SetAchievement7)(ObjectAddress, pchName);
        }

        public bool ClearAchievement(string pchName)
        {
            return GetFunction<NativeClearAchievementS>(Functions.ClearAchievement8)(ObjectAddress, pchName);
        }

        public bool GetAchievementAndUnlockTime(string pchName, ref bool pbAchieved, ref uint prtTime)
        {
            return
                GetFunction<NativeGetAchievementAndUnlockTimeSbu>(Functions.GetAchievementAndUnlockTime9)(
                    ObjectAddress, pchName, ref pbAchieved, ref prtTime);
        }

        public bool StoreStats()
        {
            return GetFunction<NativeStoreStats>(Functions.StoreStats10)(ObjectAddress);
        }

        public int GetAchievementIcon(string pchName)
        {
            return GetFunction<NativeGetAchievementIconS>(Functions.GetAchievementIcon11)(ObjectAddress, pchName);
        }

        public string GetAchievementDisplayAttribute(string pchName, string pchKey)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(
                        GetFunction<NativeGetAchievementDisplayAttributeSs>(Functions.GetAchievementDisplayAttribute12)(
                            ObjectAddress, pchName, pchKey)));
        }

        public bool IndicateAchievementProgress(string pchName, uint nCurProgress, uint nMaxProgress)
        {
            return
                GetFunction<NativeIndicateAchievementProgressSuu>(Functions.IndicateAchievementProgress13)(
                    ObjectAddress, pchName, nCurProgress, nMaxProgress);
        }

        public ulong RequestUserStats(CSteamId steamIdUser)
        {
            return GetFunction<NativeRequestUserStatsC>(Functions.RequestUserStats14)(ObjectAddress,
                steamIdUser.ConvertToUint64());
        }

        public bool GetUserStat(CSteamId steamIdUser, string pchName, ref float pData)
        {
            return GetFunction<NativeGetUserStatCsf>(Functions.GetUserStat15)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchName, ref pData);
        }

        public bool GetUserStat(CSteamId steamIdUser, string pchName, ref int pData)
        {
            return GetFunction<NativeGetUserStatCsi>(Functions.GetUserStat16)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchName, ref pData);
        }

        public bool GetUserAchievement(CSteamId steamIdUser, string pchName, ref bool pbAchieved)
        {
            return GetFunction<NativeGetUserAchievementCsb>(Functions.GetUserAchievement17)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchName, ref pbAchieved);
        }

        public bool GetUserAchievementAndUnlockTime(CSteamId steamIdUser, string pchName, ref bool pbAchieved,
            ref uint prtTime)
        {
            return
                GetFunction<NativeGetUserAchievementAndUnlockTimeCsbu>(Functions.GetUserAchievementAndUnlockTime18)(
                    ObjectAddress, steamIdUser.ConvertToUint64(), pchName, ref pbAchieved, ref prtTime);
        }

        public bool ResetAllStats(bool bAchievementsToo)
        {
            return GetFunction<NativeResetAllStatsB>(Functions.ResetAllStats19)(ObjectAddress, bAchievementsToo);
        }

        public ulong FindOrCreateLeaderboard(string pchLeaderboardName, ELeaderboardSortMethod eLeaderboardSortMethod,
            ELeaderboardDisplayType eLeaderboardDisplayType)
        {
            return GetFunction<NativeFindOrCreateLeaderboardSee>(Functions.FindOrCreateLeaderboard20)(ObjectAddress,
                pchLeaderboardName, eLeaderboardSortMethod, eLeaderboardDisplayType);
        }

        public ulong FindLeaderboard(string pchLeaderboardName)
        {
            return GetFunction<NativeFindLeaderboardS>(Functions.FindLeaderboard21)(ObjectAddress, pchLeaderboardName);
        }

        public string GetLeaderboardName(ulong hSteamLeaderboard)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(
                        GetFunction<NativeGetLeaderboardNameU>(Functions.GetLeaderboardName22)(ObjectAddress,
                            hSteamLeaderboard)));
        }

        public int GetLeaderboardEntryCount(ulong hSteamLeaderboard)
        {
            return GetFunction<NativeGetLeaderboardEntryCountU>(Functions.GetLeaderboardEntryCount23)(ObjectAddress,
                hSteamLeaderboard);
        }

        public ELeaderboardSortMethod GetLeaderboardSortMethod(ulong hSteamLeaderboard)
        {
            return GetFunction<NativeGetLeaderboardSortMethodU>(Functions.GetLeaderboardSortMethod24)(ObjectAddress,
                hSteamLeaderboard);
        }

        public ELeaderboardDisplayType GetLeaderboardDisplayType(ulong hSteamLeaderboard)
        {
            return GetFunction<NativeGetLeaderboardDisplayTypeU>(Functions.GetLeaderboardDisplayType25)(ObjectAddress,
                hSteamLeaderboard);
        }

        public ulong DownloadLeaderboardEntries(ulong hSteamLeaderboard, ELeaderboardDataRequest eLeaderboardDataRequest,
            int nRangeStart, int nRangeEnd)
        {
            return
                GetFunction<NativeDownloadLeaderboardEntriesUeii>(Functions.DownloadLeaderboardEntries26)(
                    ObjectAddress, hSteamLeaderboard, eLeaderboardDataRequest, nRangeStart, nRangeEnd);
        }

        public ulong DownloadLeaderboardEntriesForUsers(ulong hSteamLeaderboard, ref CSteamId prgUsers, int cUsers)
        {
            ulong s0 = 0;
            var result =
                GetFunction<NativeDownloadLeaderboardEntriesForUsersUci>(Functions.DownloadLeaderboardEntriesForUsers27)
                    (ObjectAddress, hSteamLeaderboard, ref s0, cUsers);
            prgUsers = new CSteamId(s0);
            return result;
        }

        public bool GetDownloadedLeaderboardEntry(ulong hSteamLeaderboardEntries, int index,
            ref LeaderboardEntry002T pLeaderboardEntry, ref int pDetails, int cDetailsMax)
        {
            return
                GetFunction<NativeGetDownloadedLeaderboardEntryUilii>(Functions.GetDownloadedLeaderboardEntry28)(
                    ObjectAddress, hSteamLeaderboardEntries, index, ref pLeaderboardEntry, ref pDetails, cDetailsMax);
        }

        public ulong UploadLeaderboardScore(ulong hSteamLeaderboard,
            ELeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, int nScore, ref int pScoreDetails,
            int cScoreDetailsCount)
        {
            return GetFunction<NativeUploadLeaderboardScoreUeiii>(Functions.UploadLeaderboardScore29)(ObjectAddress,
                hSteamLeaderboard, eLeaderboardUploadScoreMethod, nScore, ref pScoreDetails, cScoreDetailsCount);
        }

        public ulong AttachLeaderboardUgc(ulong hSteamLeaderboard, ulong hUgc)
        {
            return GetFunction<NativeAttachLeaderboardUgcuu>(Functions.AttachLeaderboardUGC30)(ObjectAddress,
                hSteamLeaderboard, hUgc);
        }

        public ulong GetNumberOfCurrentPlayers()
        {
            return GetFunction<NativeGetNumberOfCurrentPlayers>(Functions.GetNumberOfCurrentPlayers31)(ObjectAddress);
        }

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeRequestCurrentStats(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetStatSf(IntPtr thisptr, string pchName, ref float pData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetStatSi(IntPtr thisptr, string pchName, ref int pData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetStatSf(IntPtr thisptr, string pchName, float fData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetStatSi(IntPtr thisptr, string pchName, int nData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeUpdateAvgRateStatSfd(
            IntPtr thisptr, string pchName, float flCountThisSession, double dSessionLength);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetAchievementSb(IntPtr thisptr, string pchName, ref bool pbAchieved);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetAchievementS(IntPtr thisptr, string pchName);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeClearAchievementS(IntPtr thisptr, string pchName);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetAchievementAndUnlockTimeSbu(
            IntPtr thisptr, string pchName, ref bool pbAchieved, ref uint prtTime);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeStoreStats(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetAchievementIconS(IntPtr thisptr, string pchName);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetAchievementDisplayAttributeSs(IntPtr thisptr, string pchName, string pchKey);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeIndicateAchievementProgressSuu(
            IntPtr thisptr, string pchName, uint nCurProgress, uint nMaxProgress);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeRequestUserStatsC(IntPtr thisptr, ulong steamIdUser);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetUserStatCsf(IntPtr thisptr, ulong steamIdUser, string pchName, ref float pData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetUserStatCsi(IntPtr thisptr, ulong steamIdUser, string pchName, ref int pData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetUserAchievementCsb(
            IntPtr thisptr, ulong steamIdUser, string pchName, ref bool pbAchieved);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetUserAchievementAndUnlockTimeCsbu(
            IntPtr thisptr, ulong steamIdUser, string pchName, ref bool pbAchieved, ref uint prtTime);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeResetAllStatsB(IntPtr thisptr, [MarshalAs(UnmanagedType.I1)] bool bAchievementsToo);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeFindOrCreateLeaderboardSee(
            IntPtr thisptr, string pchLeaderboardName, ELeaderboardSortMethod eLeaderboardSortMethod,
            ELeaderboardDisplayType eLeaderboardDisplayType);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeFindLeaderboardS(IntPtr thisptr, string pchLeaderboardName);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetLeaderboardNameU(IntPtr thisptr, ulong hSteamLeaderboard);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetLeaderboardEntryCountU(IntPtr thisptr, ulong hSteamLeaderboard);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ELeaderboardSortMethod NativeGetLeaderboardSortMethodU(IntPtr thisptr, ulong hSteamLeaderboard);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ELeaderboardDisplayType NativeGetLeaderboardDisplayTypeU(
            IntPtr thisptr, ulong hSteamLeaderboard);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeDownloadLeaderboardEntriesUeii(
            IntPtr thisptr, ulong hSteamLeaderboard, ELeaderboardDataRequest eLeaderboardDataRequest, int nRangeStart,
            int nRangeEnd);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeDownloadLeaderboardEntriesForUsersUci(
            IntPtr thisptr, ulong hSteamLeaderboard, ref ulong prgUsers, int cUsers);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetDownloadedLeaderboardEntryUilii(
            IntPtr thisptr, ulong hSteamLeaderboardEntries, int index, ref LeaderboardEntry002T pLeaderboardEntry,
            ref int pDetails, int cDetailsMax);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeUploadLeaderboardScoreUeiii(
            IntPtr thisptr, ulong hSteamLeaderboard, ELeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod,
            int nScore, ref int pScoreDetails, int cScoreDetailsCount);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeAttachLeaderboardUgcuu(IntPtr thisptr, ulong hSteamLeaderboard, ulong hUgc);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeGetNumberOfCurrentPlayers(IntPtr thisptr);
    };
}