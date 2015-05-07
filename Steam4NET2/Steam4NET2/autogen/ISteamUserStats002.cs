// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamUserStats002VTable
    {
        public IntPtr GetNumStats0;
        public IntPtr GetStatName1;
        public IntPtr GetStatType2;
        public IntPtr GetNumAchievements3;
        public IntPtr GetAchievementName4;
        public IntPtr RequestCurrentStats5;
        public IntPtr GetStat6;
        public IntPtr GetStat7;
        public IntPtr SetStat8;
        public IntPtr SetStat9;
        public IntPtr UpdateAvgRateStat10;
        public IntPtr GetAchievement11;
        public IntPtr SetAchievement12;
        public IntPtr ClearAchievement13;
        public IntPtr StoreStats14;
        public IntPtr GetAchievementIcon15;
        public IntPtr GetAchievementDisplayAttribute16;
        public IntPtr IndicateAchievementProgress17;
        private IntPtr DTorISteamUserStats00218;
    };

    [InteropHelp.InterfaceVersionAttribute("STEAMUSERSTATS_INTERFACE_VERSION002")]
    public class SteamUserStats002 : InteropHelp.NativeWrapper<SteamUserStats002VTable>
    {
        public uint GetNumStats(CGameId nGameId)
        {
            return GetFunction<NativeGetNumStatsC>(Functions.GetNumStats0)(ObjectAddress, nGameId.ConvertToUint64());
        }

        public string GetStatName(CGameId nGameId, uint iStat)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(GetFunction<NativeGetStatNameCu>(Functions.GetStatName1)(ObjectAddress,
                        nGameId.ConvertToUint64(), iStat)));
        }

        public ESteamUserStatType GetStatType(CGameId nGameId, string pchName)
        {
            return GetFunction<NativeGetStatTypeCs>(Functions.GetStatType2)(ObjectAddress, nGameId.ConvertToUint64(),
                pchName);
        }

        public uint GetNumAchievements(CGameId nGameId)
        {
            return GetFunction<NativeGetNumAchievementsC>(Functions.GetNumAchievements3)(ObjectAddress,
                nGameId.ConvertToUint64());
        }

        public string GetAchievementName(CGameId nGameId, uint iAchievement)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(
                        GetFunction<NativeGetAchievementNameCu>(Functions.GetAchievementName4)(ObjectAddress,
                            nGameId.ConvertToUint64(), iAchievement)));
        }

        public bool RequestCurrentStats(CGameId nGameId)
        {
            return GetFunction<NativeRequestCurrentStatsC>(Functions.RequestCurrentStats5)(ObjectAddress,
                nGameId.ConvertToUint64());
        }

        public bool GetStat(CGameId nGameId, string pchName, ref float pData)
        {
            return GetFunction<NativeGetStatCsf>(Functions.GetStat6)(ObjectAddress, nGameId.ConvertToUint64(), pchName,
                ref pData);
        }

        public bool GetStat(CGameId nGameId, string pchName, ref int pData)
        {
            return GetFunction<NativeGetStatCsi>(Functions.GetStat7)(ObjectAddress, nGameId.ConvertToUint64(), pchName,
                ref pData);
        }

        public bool SetStat(CGameId nGameId, string pchName, float fData)
        {
            return GetFunction<NativeSetStatCsf>(Functions.SetStat8)(ObjectAddress, nGameId.ConvertToUint64(), pchName,
                fData);
        }

        public bool SetStat(CGameId nGameId, string pchName, int nData)
        {
            return GetFunction<NativeSetStatCsi>(Functions.SetStat9)(ObjectAddress, nGameId.ConvertToUint64(), pchName,
                nData);
        }

        public bool UpdateAvgRateStat(CGameId nGameId, string pchName, uint nCountThisSession, double dSessionLength)
        {
            return GetFunction<NativeUpdateAvgRateStatCsud>(Functions.UpdateAvgRateStat10)(ObjectAddress,
                nGameId.ConvertToUint64(), pchName, nCountThisSession, dSessionLength);
        }

        public bool GetAchievement(CGameId nGameId, string pchName, ref bool pbAchieved)
        {
            return GetFunction<NativeGetAchievementCsb>(Functions.GetAchievement11)(ObjectAddress,
                nGameId.ConvertToUint64(), pchName, ref pbAchieved);
        }

        public bool SetAchievement(CGameId nGameId, string pchName)
        {
            return GetFunction<NativeSetAchievementCs>(Functions.SetAchievement12)(ObjectAddress,
                nGameId.ConvertToUint64(), pchName);
        }

        public bool ClearAchievement(CGameId nGameId, string pchName)
        {
            return GetFunction<NativeClearAchievementCs>(Functions.ClearAchievement13)(ObjectAddress,
                nGameId.ConvertToUint64(), pchName);
        }

        public bool StoreStats(CGameId nGameId)
        {
            return GetFunction<NativeStoreStatsC>(Functions.StoreStats14)(ObjectAddress, nGameId.ConvertToUint64());
        }

        public int GetAchievementIcon(CGameId nGameId, string pchName)
        {
            return GetFunction<NativeGetAchievementIconCs>(Functions.GetAchievementIcon15)(ObjectAddress,
                nGameId.ConvertToUint64(), pchName);
        }

        public string GetAchievementDisplayAttribute(CGameId nGameId, string pchName, string pchKey)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(
                        GetFunction<NativeGetAchievementDisplayAttributeCss>(Functions.GetAchievementDisplayAttribute16)
                            (ObjectAddress, nGameId.ConvertToUint64(), pchName, pchKey)));
        }

        public bool IndicateAchievementProgress(CGameId nGameId, string pchName, uint nCurProgress, uint nMaxProgress)
        {
            return
                GetFunction<NativeIndicateAchievementProgressCsuu>(Functions.IndicateAchievementProgress17)(
                    ObjectAddress, nGameId.ConvertToUint64(), pchName, nCurProgress, nMaxProgress);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetNumStatsC(IntPtr thisptr, ulong nGameId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetStatNameCu(IntPtr thisptr, ulong nGameId, uint iStat);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ESteamUserStatType NativeGetStatTypeCs(IntPtr thisptr, ulong nGameId, string pchName);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetNumAchievementsC(IntPtr thisptr, ulong nGameId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetAchievementNameCu(IntPtr thisptr, ulong nGameId, uint iAchievement);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeRequestCurrentStatsC(IntPtr thisptr, ulong nGameId);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetStatCsf(IntPtr thisptr, ulong nGameId, string pchName, ref float pData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetStatCsi(IntPtr thisptr, ulong nGameId, string pchName, ref int pData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetStatCsf(IntPtr thisptr, ulong nGameId, string pchName, float fData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetStatCsi(IntPtr thisptr, ulong nGameId, string pchName, int nData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeUpdateAvgRateStatCsud(
            IntPtr thisptr, ulong nGameId, string pchName, uint nCountThisSession, double dSessionLength);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetAchievementCsb(IntPtr thisptr, ulong nGameId, string pchName, ref bool pbAchieved
            );

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetAchievementCs(IntPtr thisptr, ulong nGameId, string pchName);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeClearAchievementCs(IntPtr thisptr, ulong nGameId, string pchName);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeStoreStatsC(IntPtr thisptr, ulong nGameId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetAchievementIconCs(IntPtr thisptr, ulong nGameId, string pchName);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetAchievementDisplayAttributeCss(
            IntPtr thisptr, ulong nGameId, string pchName, string pchKey);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeIndicateAchievementProgressCsuu(
            IntPtr thisptr, ulong nGameId, string pchName, uint nCurProgress, uint nMaxProgress);
    };
}