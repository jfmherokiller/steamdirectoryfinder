// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamContentServer002VTable
    {
        public IntPtr LogOn0;
        public IntPtr LogOff1;
        public IntPtr BLoggedOn2;
        public IntPtr SendClientContentAuthRequest3;
        public IntPtr BCheckTicket4;
        private IntPtr DTorISteamContentServer0025;
    };

    [InteropHelp.InterfaceVersionAttribute("SteamContentServer002")]
    public class SteamContentServer002 : InteropHelp.NativeWrapper<SteamContentServer002VTable>
    {
        public bool LogOn(uint uContentServerId)
        {
            return GetFunction<NativeLogOnU>(Functions.LogOn0)(ObjectAddress, uContentServerId);
        }

        public bool LogOff()
        {
            return GetFunction<NativeLogOff>(Functions.LogOff1)(ObjectAddress);
        }

        public bool BLoggedOn()
        {
            return GetFunction<NativeBLoggedOn>(Functions.BLoggedOn2)(ObjectAddress);
        }

        public void SendClientContentAuthRequest(CSteamId steamId, uint uContentId, ulong ulSessionToken,
            bool bTokenPresent)
        {
            GetFunction<NativeSendClientContentAuthRequestCuub>(Functions.SendClientContentAuthRequest3)(ObjectAddress,
                steamId.ConvertToUint64(), uContentId, ulSessionToken, bTokenPresent);
        }

        public bool BCheckTicket(CSteamId steamId, uint uContentId, byte[] pvTicketData)
        {
            return GetFunction<NativeBCheckTicketCubu>(Functions.BCheckTicket4)(ObjectAddress, steamId.ConvertToUint64(),
                uContentId, pvTicketData, (uint)pvTicketData.Length);
        }

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeLogOnU(IntPtr thisptr, uint uContentServerId);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeLogOff(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBLoggedOn(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSendClientContentAuthRequestCuub(
            IntPtr thisptr, ulong steamId, uint uContentId, ulong ulSessionToken,
            [MarshalAs(UnmanagedType.I1)] bool bTokenPresent);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBCheckTicketCubu(
            IntPtr thisptr, ulong steamId, uint uContentId, byte[] pvTicketData, uint cubTicketLength);
    };
}