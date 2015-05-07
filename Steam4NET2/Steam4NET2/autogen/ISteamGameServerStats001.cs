// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamGameServerStats001VTable
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
        private IntPtr DTorISteamGameServerStats00110;
    };

    [InteropHelp.InterfaceVersionAttribute("SteamGameServerStats001")]
    public class SteamGameServerStats001 : InteropHelp.NativeWrapper<SteamGameServerStats001VTable>
    {
        public ulong RequestUserStats(CSteamId steamIdUser)
        {
            return GetFunction<NativeRequestUserStatsC>(Functions.RequestUserStats0)(ObjectAddress,
                steamIdUser.ConvertToUint64());
        }

        public bool GetUserStat(CSteamId steamIdUser, string pchName, ref float pData)
        {
            return GetFunction<NativeGetUserStatCsf>(Functions.GetUserStat1)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchName, ref pData);
        }

        public bool GetUserStat(CSteamId steamIdUser, string pchName, ref int pData)
        {
            return GetFunction<NativeGetUserStatCsi>(Functions.GetUserStat2)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchName, ref pData);
        }

        public bool GetUserAchievement(CSteamId steamIdUser, string pchName, ref bool pbAchieved)
        {
            return GetFunction<NativeGetUserAchievementCsb>(Functions.GetUserAchievement3)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchName, ref pbAchieved);
        }

        public bool SetUserStat(CSteamId steamIdUser, string pchName, float fData)
        {
            return GetFunction<NativeSetUserStatCsf>(Functions.SetUserStat4)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchName, fData);
        }

        public bool SetUserStat(CSteamId steamIdUser, string pchName, int nData)
        {
            return GetFunction<NativeSetUserStatCsi>(Functions.SetUserStat5)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchName, nData);
        }

        public bool UpdateUserAvgRateStat(CSteamId steamIdUser, string pchName, float flCountThisSession,
            double dSessionLength)
        {
            return GetFunction<NativeUpdateUserAvgRateStatCsfd>(Functions.UpdateUserAvgRateStat6)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchName, flCountThisSession, dSessionLength);
        }

        public bool SetUserAchievement(CSteamId steamIdUser, string pchName)
        {
            return GetFunction<NativeSetUserAchievementCs>(Functions.SetUserAchievement7)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchName);
        }

        public bool ClearUserAchievement(CSteamId steamIdUser, string pchName)
        {
            return GetFunction<NativeClearUserAchievementCs>(Functions.ClearUserAchievement8)(ObjectAddress,
                steamIdUser.ConvertToUint64(), pchName);
        }

        public ulong StoreUserStats(CSteamId steamIdUser)
        {
            return GetFunction<NativeStoreUserStatsC>(Functions.StoreUserStats9)(ObjectAddress,
                steamIdUser.ConvertToUint64());
        }

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
        private delegate bool NativeSetUserStatCsf(IntPtr thisptr, ulong steamIdUser, string pchName, float fData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetUserStatCsi(IntPtr thisptr, ulong steamIdUser, string pchName, int nData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeUpdateUserAvgRateStatCsfd(
            IntPtr thisptr, ulong steamIdUser, string pchName, float flCountThisSession, double dSessionLength);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetUserAchievementCs(IntPtr thisptr, ulong steamIdUser, string pchName);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeClearUserAchievementCs(IntPtr thisptr, ulong steamIdUser, string pchName);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeStoreUserStatsC(IntPtr thisptr, ulong steamIdUser);
    };
}