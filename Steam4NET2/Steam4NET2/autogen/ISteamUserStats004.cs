// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamUserStats004VTable
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
        public IntPtr StoreStats9;
        public IntPtr GetAchievementIcon10;
        public IntPtr GetAchievementDisplayAttribute11;
        public IntPtr IndicateAchievementProgress12;
        public IntPtr RequestUserStats13;
        public IntPtr GetUserStat14;
        public IntPtr GetUserStat15;
        public IntPtr GetUserAchievement16;
        public IntPtr ResetAllStats17;
        private IntPtr DTorISteamUserStats00418;
    };

    [InteropHelp.InterfaceVersionAttribute("STEAMUSERSTATS_INTERFACE_VERSION004")]
    public class SteamUserStats004 : InteropHelp.NativeWrapper<SteamUserStats004VTable>
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

        public bool UpdateAvgRateStat(string pchName, float arg1, double dSessionLength)
        {
            return GetFunction<NativeUpdateAvgRateStatSfd>(Functions.UpdateAvgRateStat5)(ObjectAddress, pchName, arg1,
                dSessionLength);
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

        public bool StoreStats()
        {
            return GetFunction<NativeStoreStats>(Functions.StoreStats9)(ObjectAddress);
        }

        public int GetAchievementIcon(string pchName)
        {
            return GetFunction<NativeGetAchievementIconS>(Functions.GetAchievementIcon10)(ObjectAddress, pchName);
        }

        public string GetAchievementDisplayAttribute(string pchName, string pchKey)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(
                        GetFunction<NativeGetAchievementDisplayAttributeSs>(Functions.GetAchievementDisplayAttribute11)(
                            ObjectAddress, pchName, pchKey)));
        }

        public bool IndicateAchievementProgress(string pchName, uint nCurProgress, uint nMaxProgress)
        {
            return
                GetFunction<NativeIndicateAchievementProgressSuu>(Functions.IndicateAchievementProgress12)(
                    ObjectAddress, pchName, nCurProgress, nMaxProgress);
        }

        public ulong RequestUserStats(CSteamId steamIdUser)
        {
            return GetFunction<NativeRequestUserStatsC>(Functions.RequestUserStats13)(ObjectAddress,
                steamIdUser.ConvertToUint64());
        }

        public bool GetUserStat(CSteamId steamIdUser, string pchName, ref float pData)
        {
            return GetFunction<NativeGetUserStatCsf>(Functions.GetUserStat14)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchName, ref pData);
        }

        public bool GetUserStat(CSteamId steamIdUser, string pchName, ref int pData)
        {
            return GetFunction<NativeGetUserStatCsi>(Functions.GetUserStat15)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchName, ref pData);
        }

        public bool GetUserAchievement(CSteamId steamIdUser, string pchName, ref bool pbAchieved)
        {
            return GetFunction<NativeGetUserAchievementCsb>(Functions.GetUserAchievement16)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchName, ref pbAchieved);
        }

        public bool ResetAllStats(bool bAchievementsToo)
        {
            return GetFunction<NativeResetAllStatsB>(Functions.ResetAllStats17)(ObjectAddress, bAchievementsToo);
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
            IntPtr thisptr, string pchName, float arg1, double dSessionLength);

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
        private delegate bool NativeResetAllStatsB(IntPtr thisptr, [MarshalAs(UnmanagedType.I1)] bool bAchievementsToo);
    };
}