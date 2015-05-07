// This file is automatically generated.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamUser016VTable
    {
        public IntPtr GetHSteamUser0;
        public IntPtr BLoggedOn1;
        public IntPtr GetSteamID2;
        public IntPtr InitiateGameConnection3;
        public IntPtr TerminateGameConnection4;
        public IntPtr TrackAppUsageEvent5;
        public IntPtr GetUserDataFolder6;
        public IntPtr StartVoiceRecording7;
        public IntPtr StopVoiceRecording8;
        public IntPtr GetAvailableVoice9;
        public IntPtr GetVoice10;
        public IntPtr DecompressVoice11;
        public IntPtr GetVoiceOptimalSampleRate12;
        public IntPtr GetAuthSessionTicket13;
        public IntPtr BeginAuthSession14;
        public IntPtr EndAuthSession15;
        public IntPtr CancelAuthTicket16;
        public IntPtr UserHasLicenseForApp17;
        public IntPtr BIsBehindNAT18;
        public IntPtr AdvertiseGame19;
        public IntPtr RequestEncryptedAppTicket20;
        public IntPtr GetEncryptedAppTicket21;
        private IntPtr DTorISteamUser01622;
    };

    [InteropHelp.InterfaceVersionAttribute("SteamUser016")]
    public class SteamUser016 : InteropHelp.NativeWrapper<SteamUser016VTable>
    {
        public int GetHSteamUser()
        {
            return GetFunction<NativeGetHSteamUser>(Functions.GetHSteamUser0)(ObjectAddress);
        }

        public bool BLoggedOn()
        {
            return GetFunction<NativeBLoggedOn>(Functions.BLoggedOn1)(ObjectAddress);
        }

        public CSteamId GetSteamId()
        {
            ulong ret = 0;
            GetFunction<NativeGetSteamId>(Functions.GetSteamID2)(ObjectAddress, ref ret);
            return new CSteamId(ret);
        }

        public int InitiateGameConnection(byte[] pAuthBlob, CSteamId steamIdGameServer, uint unIpServer,
            ushort usPortServer, bool bSecure)
        {
            return GetFunction<NativeInitiateGameConnectionBicuub>(Functions.InitiateGameConnection3)(ObjectAddress,
                pAuthBlob, pAuthBlob.Length, steamIdGameServer.ConvertToUint64(), unIpServer, usPortServer, bSecure);
        }

        public void TerminateGameConnection(uint unIpServer, ushort usPortServer)
        {
            GetFunction<NativeTerminateGameConnectionUu>(Functions.TerminateGameConnection4)(ObjectAddress, unIpServer,
                usPortServer);
        }

        public void TrackAppUsageEvent(CGameId gameId, EAppUsageEvent eAppUsageEvent, string pchExtraInfo)
        {
            GetFunction<NativeTrackAppUsageEventCes>(Functions.TrackAppUsageEvent5)(ObjectAddress,
                gameId.ConvertToUint64(), eAppUsageEvent, pchExtraInfo);
        }

        public bool GetUserDataFolder(StringBuilder pchBuffer)
        {
            return GetFunction<NativeGetUserDataFolderSi>(Functions.GetUserDataFolder6)(ObjectAddress, pchBuffer,
                pchBuffer.Capacity);
        }

        public void StartVoiceRecording()
        {
            GetFunction<NativeStartVoiceRecording>(Functions.StartVoiceRecording7)(ObjectAddress);
        }

        public void StopVoiceRecording()
        {
            GetFunction<NativeStopVoiceRecording>(Functions.StopVoiceRecording8)(ObjectAddress);
        }

        public EVoiceResult GetAvailableVoice(ref uint pcbCompressed, ref uint pcbUncompressed,
            uint nUncompressedVoiceDesiredSampleRate)
        {
            return GetFunction<NativeGetAvailableVoiceUuu>(Functions.GetAvailableVoice9)(ObjectAddress,
                ref pcbCompressed, ref pcbUncompressed, nUncompressedVoiceDesiredSampleRate);
        }

        public EVoiceResult GetVoice(bool bWantCompressed, byte[] pDestBuffer, ref uint nBytesWritten,
            bool bWantUncompressed, byte[] pUncompressedDestBuffer, ref uint nUncompressBytesWritten,
            uint nUncompressedVoiceDesiredSampleRate)
        {
            return GetFunction<NativeGetVoiceBbuubbuuu>(Functions.GetVoice10)(ObjectAddress, bWantCompressed,
                pDestBuffer, (uint)pDestBuffer.Length, ref nBytesWritten, bWantUncompressed, pUncompressedDestBuffer,
                (uint)pUncompressedDestBuffer.Length, ref nUncompressBytesWritten, nUncompressedVoiceDesiredSampleRate);
        }

        public EVoiceResult DecompressVoice(byte[] pCompressed, byte[] pDestBuffer, ref uint nBytesWritten,
            uint nDesiredSampleRate)
        {
            return GetFunction<NativeDecompressVoiceBubuuu>(Functions.DecompressVoice11)(ObjectAddress, pCompressed,
                (uint)pCompressed.Length, pDestBuffer, (uint)pDestBuffer.Length, ref nBytesWritten, nDesiredSampleRate);
        }

        public uint GetVoiceOptimalSampleRate()
        {
            return GetFunction<NativeGetVoiceOptimalSampleRate>(Functions.GetVoiceOptimalSampleRate12)(ObjectAddress);
        }

        public uint GetAuthSessionTicket(byte[] pTicket, ref uint pcbTicket)
        {
            return GetFunction<NativeGetAuthSessionTicketBiu>(Functions.GetAuthSessionTicket13)(ObjectAddress, pTicket,
                pTicket.Length, ref pcbTicket);
        }

        public EBeginAuthSessionResult BeginAuthSession(byte[] pAuthTicket, CSteamId steamId)
        {
            return GetFunction<NativeBeginAuthSessionBic>(Functions.BeginAuthSession14)(ObjectAddress, pAuthTicket,
                pAuthTicket.Length, steamId.ConvertToUint64());
        }

        public void EndAuthSession(CSteamId steamId)
        {
            GetFunction<NativeEndAuthSessionC>(Functions.EndAuthSession15)(ObjectAddress, steamId.ConvertToUint64());
        }

        public void CancelAuthTicket(uint hAuthTicket)
        {
            GetFunction<NativeCancelAuthTicketU>(Functions.CancelAuthTicket16)(ObjectAddress, hAuthTicket);
        }

        public EUserHasLicenseForAppResult UserHasLicenseForApp(CSteamId steamId, uint appId)
        {
            return GetFunction<NativeUserHasLicenseForAppCu>(Functions.UserHasLicenseForApp17)(ObjectAddress,
                steamId.ConvertToUint64(), appId);
        }

        public bool BIsBehindNat()
        {
            return GetFunction<NativeBIsBehindNat>(Functions.BIsBehindNAT18)(ObjectAddress);
        }

        public void AdvertiseGame(CSteamId steamIdGameServer, uint unIpServer, ushort usPortServer)
        {
            GetFunction<NativeAdvertiseGameCuu>(Functions.AdvertiseGame19)(ObjectAddress,
                steamIdGameServer.ConvertToUint64(), unIpServer, usPortServer);
        }

        public ulong RequestEncryptedAppTicket(byte[] pDataToInclude)
        {
            return GetFunction<NativeRequestEncryptedAppTicketBi>(Functions.RequestEncryptedAppTicket20)(ObjectAddress,
                pDataToInclude, pDataToInclude.Length);
        }

        public bool GetEncryptedAppTicket(byte[] pTicket, ref uint pcbTicket)
        {
            return GetFunction<NativeGetEncryptedAppTicketBiu>(Functions.GetEncryptedAppTicket21)(ObjectAddress, pTicket,
                pTicket.Length, ref pcbTicket);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetHSteamUser(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBLoggedOn(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeGetSteamId(IntPtr thisptr, ref ulong retarg);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeInitiateGameConnectionBicuub(
            IntPtr thisptr, byte[] pAuthBlob, int cbMaxAuthBlob, ulong steamIdGameServer, uint unIpServer,
            ushort usPortServer, [MarshalAs(UnmanagedType.I1)] bool bSecure);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeTerminateGameConnectionUu(IntPtr thisptr, uint unIpServer, ushort usPortServer);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeTrackAppUsageEventCes(
            IntPtr thisptr, ulong gameId, EAppUsageEvent eAppUsageEvent, string pchExtraInfo);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetUserDataFolderSi(IntPtr thisptr, StringBuilder pchBuffer, int cubBuffer);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeStartVoiceRecording(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeStopVoiceRecording(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EVoiceResult NativeGetAvailableVoiceUuu(
            IntPtr thisptr, ref uint pcbCompressed, ref uint pcbUncompressed, uint nUncompressedVoiceDesiredSampleRate);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EVoiceResult NativeGetVoiceBbuubbuuu(
            IntPtr thisptr, [MarshalAs(UnmanagedType.I1)] bool bWantCompressed, byte[] pDestBuffer,
            uint cbDestBufferSize, ref uint nBytesWritten, [MarshalAs(UnmanagedType.I1)] bool bWantUncompressed,
            byte[] pUncompressedDestBuffer, uint cbUncompressedDestBufferSize, ref uint nUncompressBytesWritten,
            uint nUncompressedVoiceDesiredSampleRate);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EVoiceResult NativeDecompressVoiceBubuuu(
            IntPtr thisptr, byte[] pCompressed, uint cbCompressed, byte[] pDestBuffer, uint cbDestBufferSize,
            ref uint nBytesWritten, uint nDesiredSampleRate);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetVoiceOptimalSampleRate(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetAuthSessionTicketBiu(
            IntPtr thisptr, byte[] pTicket, int cbMaxTicket, ref uint pcbTicket);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EBeginAuthSessionResult NativeBeginAuthSessionBic(
            IntPtr thisptr, byte[] pAuthTicket, int cbAuthTicket, ulong steamId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeEndAuthSessionC(IntPtr thisptr, ulong steamId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeCancelAuthTicketU(IntPtr thisptr, uint hAuthTicket);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EUserHasLicenseForAppResult NativeUserHasLicenseForAppCu(
            IntPtr thisptr, ulong steamId, uint appId);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBIsBehindNat(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeAdvertiseGameCuu(
            IntPtr thisptr, ulong steamIdGameServer, uint unIpServer, ushort usPortServer);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeRequestEncryptedAppTicketBi(
            IntPtr thisptr, byte[] pDataToInclude, int cbDataToInclude);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetEncryptedAppTicketBiu(
            IntPtr thisptr, byte[] pTicket, int cbMaxTicket, ref uint pcbTicket);
    };
}