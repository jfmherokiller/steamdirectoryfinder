// This file is automatically generated.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Steam2Bridge002VTable
    {
        public IntPtr SetSteam2Ticket0;
        public IntPtr SetAccountName1;
        public IntPtr SetPassword2;
        public IntPtr SetAccountCreationTime3;
        public IntPtr CreateProcess4;
        public IntPtr GetConnectedUniverse5;
        public IntPtr GetIPCountry6;
        public IntPtr GetNumLicenses7;
        public IntPtr GetLicensePackageID8;
        public IntPtr GetLicenseTimeCreated9;
        public IntPtr GetLicenseTimeNextProcess10;
        public IntPtr GetLicenseMinuteLimit11;
        public IntPtr GetLicenseMinutesUsed12;
        public IntPtr GetLicensePaymentMethod13;
        public IntPtr GetLicenseFlags14;
        public IntPtr GetLicensePurchaseCountryCode15;
        public IntPtr SetOfflineMode16;
        public IntPtr GetCurrentSessionToken17;
        public IntPtr SetCellID18;
        public IntPtr SetSteam2FullASTicket19;
        public IntPtr BUpdateAppOwnershipTicket20;
        public IntPtr GetAppOwnershipTicketLength21;
        public IntPtr GetAppOwnershipTicketData22;
        public IntPtr GetAppDecryptionKey23;
        public IntPtr GetPlatformName24;
        public IntPtr GetSteam2FullASTicket25;
        public IntPtr SetWinningPingTimeForCellID26;
        public IntPtr GetSteam2ID27;
        private IntPtr DTorISteam2Bridge00228;
    };

    [InteropHelp.InterfaceVersionAttribute("STEAM2BRIDGE_INTERFACE_VERSION002")]
    public class Steam2Bridge002 : InteropHelp.NativeWrapper<Steam2Bridge002VTable>
    {
        public void SetSteam2Ticket(byte[] pubTicket)
        {
            GetFunction<NativeSetSteam2TicketBi>(Functions.SetSteam2Ticket0)(ObjectAddress, pubTicket, pubTicket.Length);
        }

        public bool SetAccountName(string pchAccountName)
        {
            return GetFunction<NativeSetAccountNameS>(Functions.SetAccountName1)(ObjectAddress, pchAccountName);
        }

        public bool SetPassword(string pchPassword)
        {
            return GetFunction<NativeSetPasswordS>(Functions.SetPassword2)(ObjectAddress, pchPassword);
        }

        public bool SetAccountCreationTime(uint rt)
        {
            return GetFunction<NativeSetAccountCreationTimeU>(Functions.SetAccountCreationTime3)(ObjectAddress, rt);
        }

        public bool CreateProcess(byte[] lpVacBlob, string lpApplicationName, StringBuilder lpCommandLine,
            uint dwCreationFlags, byte[] lpEnvironment, StringBuilder lpCurrentDirectory, uint nGameId)
        {
            return GetFunction<NativeCreateProcessBussubsu>(Functions.CreateProcess4)(ObjectAddress, lpVacBlob,
                (uint)lpVacBlob.Length, lpApplicationName, lpCommandLine, dwCreationFlags, lpEnvironment,
                lpCurrentDirectory, nGameId);
        }

        public EUniverse GetConnectedUniverse()
        {
            return GetFunction<NativeGetConnectedUniverse>(Functions.GetConnectedUniverse5)(ObjectAddress);
        }

        public string GetIpCountry()
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(GetFunction<NativeGetIpCountry>(Functions.GetIPCountry6)(ObjectAddress)));
        }

        public uint GetNumLicenses()
        {
            return GetFunction<NativeGetNumLicenses>(Functions.GetNumLicenses7)(ObjectAddress);
        }

        public int GetLicensePackageId(uint nLicenseIndex)
        {
            return GetFunction<NativeGetLicensePackageIdu>(Functions.GetLicensePackageID8)(ObjectAddress, nLicenseIndex);
        }

        public uint GetLicenseTimeCreated(uint nLicenseIndex)
        {
            return GetFunction<NativeGetLicenseTimeCreatedU>(Functions.GetLicenseTimeCreated9)(ObjectAddress,
                nLicenseIndex);
        }

        public uint GetLicenseTimeNextProcess(uint nLicenseIndex)
        {
            return GetFunction<NativeGetLicenseTimeNextProcessU>(Functions.GetLicenseTimeNextProcess10)(ObjectAddress,
                nLicenseIndex);
        }

        public int GetLicenseMinuteLimit(uint nLicenseIndex)
        {
            return GetFunction<NativeGetLicenseMinuteLimitU>(Functions.GetLicenseMinuteLimit11)(ObjectAddress,
                nLicenseIndex);
        }

        public int GetLicenseMinutesUsed(uint nLicenseIndex)
        {
            return GetFunction<NativeGetLicenseMinutesUsedU>(Functions.GetLicenseMinutesUsed12)(ObjectAddress,
                nLicenseIndex);
        }

        public EPaymentMethod GetLicensePaymentMethod(uint nLicenseIndex)
        {
            return GetFunction<NativeGetLicensePaymentMethodU>(Functions.GetLicensePaymentMethod13)(ObjectAddress,
                nLicenseIndex);
        }

        public ELicenseFlags GetLicenseFlags(uint nLicenseIndex)
        {
            return GetFunction<NativeGetLicenseFlagsU>(Functions.GetLicenseFlags14)(ObjectAddress, nLicenseIndex);
        }

        public string GetLicensePurchaseCountryCode(uint nLicenseIndex)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(
                        GetFunction<NativeGetLicensePurchaseCountryCodeU>(Functions.GetLicensePurchaseCountryCode15)(
                            ObjectAddress, nLicenseIndex)));
        }

        public bool SetOfflineMode(bool bOffline)
        {
            return GetFunction<NativeSetOfflineModeB>(Functions.SetOfflineMode16)(ObjectAddress, bOffline);
        }

        public ulong GetCurrentSessionToken()
        {
            return GetFunction<NativeGetCurrentSessionToken>(Functions.GetCurrentSessionToken17)(ObjectAddress);
        }

        public void SetCellId(uint cellId)
        {
            GetFunction<NativeSetCellIdu>(Functions.SetCellID18)(ObjectAddress, cellId);
        }

        public void SetSteam2FullAsTicket(byte[] pubTicket)
        {
            GetFunction<NativeSetSteam2FullAsTicketBi>(Functions.SetSteam2FullASTicket19)(ObjectAddress, pubTicket,
                pubTicket.Length);
        }

        public bool BUpdateAppOwnershipTicket(uint nAppId, bool bOnlyUpdateIfStale)
        {
            return GetFunction<NativeBUpdateAppOwnershipTicketUb>(Functions.BUpdateAppOwnershipTicket20)(ObjectAddress,
                nAppId, bOnlyUpdateIfStale);
        }

        public uint GetAppOwnershipTicketLength(uint nAppId)
        {
            return
                GetFunction<NativeGetAppOwnershipTicketLengthU>(Functions.GetAppOwnershipTicketLength21)(ObjectAddress,
                    nAppId);
        }

        public uint GetAppOwnershipTicketData(uint nAppId, byte[] pvBuffer)
        {
            return GetFunction<NativeGetAppOwnershipTicketDataUbu>(Functions.GetAppOwnershipTicketData22)(
                ObjectAddress, nAppId, pvBuffer, (uint)pvBuffer.Length);
        }

        public bool GetAppDecryptionKey(uint nAppId, byte[] pvBuffer)
        {
            return GetFunction<NativeGetAppDecryptionKeyUbu>(Functions.GetAppDecryptionKey23)(ObjectAddress, nAppId,
                pvBuffer, (uint)pvBuffer.Length);
        }

        public string GetPlatformName(ref bool pbIs64Bit)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(
                        GetFunction<NativeGetPlatformNameB>(Functions.GetPlatformName24)(ObjectAddress, ref pbIs64Bit)));
        }

        public int GetSteam2FullAsTicket(byte[] pubTicket)
        {
            return GetFunction<NativeGetSteam2FullAsTicketBi>(Functions.GetSteam2FullASTicket25)(ObjectAddress,
                pubTicket, pubTicket.Length);
        }

        public void SetWinningPingTimeForCellId(uint uPing)
        {
            GetFunction<NativeSetWinningPingTimeForCellIdu>(Functions.SetWinningPingTimeForCellID26)(ObjectAddress,
                uPing);
        }

        public void GetSteam2Id(ref SteamGlobalUserId pUserId)
        {
            GetFunction<NativeGetSteam2Idt>(Functions.GetSteam2ID27)(ObjectAddress, ref pUserId);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetSteam2TicketBi(IntPtr thisptr, byte[] pubTicket, int cubTicket);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetAccountNameS(IntPtr thisptr, string pchAccountName);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetPasswordS(IntPtr thisptr, string pchPassword);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetAccountCreationTimeU(IntPtr thisptr, uint rt);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeCreateProcessBussubsu(
            IntPtr thisptr, byte[] lpVacBlob, uint cbBlobSize, string lpApplicationName, StringBuilder lpCommandLine,
            uint dwCreationFlags, byte[] lpEnvironment, StringBuilder lpCurrentDirectory, uint nGameId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EUniverse NativeGetConnectedUniverse(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIpCountry(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetNumLicenses(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetLicensePackageIdu(IntPtr thisptr, uint nLicenseIndex);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetLicenseTimeCreatedU(IntPtr thisptr, uint nLicenseIndex);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetLicenseTimeNextProcessU(IntPtr thisptr, uint nLicenseIndex);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetLicenseMinuteLimitU(IntPtr thisptr, uint nLicenseIndex);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetLicenseMinutesUsedU(IntPtr thisptr, uint nLicenseIndex);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EPaymentMethod NativeGetLicensePaymentMethodU(IntPtr thisptr, uint nLicenseIndex);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ELicenseFlags NativeGetLicenseFlagsU(IntPtr thisptr, uint nLicenseIndex);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetLicensePurchaseCountryCodeU(IntPtr thisptr, uint nLicenseIndex);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetOfflineModeB(IntPtr thisptr, [MarshalAs(UnmanagedType.I1)] bool bOffline);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeGetCurrentSessionToken(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetCellIdu(IntPtr thisptr, uint cellId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetSteam2FullAsTicketBi(IntPtr thisptr, byte[] pubTicket, int cubTicket);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBUpdateAppOwnershipTicketUb(
            IntPtr thisptr, uint nAppId, [MarshalAs(UnmanagedType.I1)] bool bOnlyUpdateIfStale);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetAppOwnershipTicketLengthU(IntPtr thisptr, uint nAppId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetAppOwnershipTicketDataUbu(
            IntPtr thisptr, uint nAppId, byte[] pvBuffer, uint cubBuffer);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetAppDecryptionKeyUbu(IntPtr thisptr, uint nAppId, byte[] pvBuffer, uint cubBuffer);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetPlatformNameB(IntPtr thisptr, ref bool pbIs64Bit);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetSteam2FullAsTicketBi(IntPtr thisptr, byte[] pubTicket, int cubTicket);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetWinningPingTimeForCellIdu(IntPtr thisptr, uint uPing);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeGetSteam2Idt(IntPtr thisptr, ref SteamGlobalUserId pUserId);
    };
}