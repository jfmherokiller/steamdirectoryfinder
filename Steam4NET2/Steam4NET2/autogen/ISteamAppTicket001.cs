// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamAppTicket001VTable
    {
        public IntPtr GetAppOwnershipTicketData0;
        private IntPtr DTorISteamAppTicket0011;
    };

    [InteropHelp.InterfaceVersionAttribute("STEAMAPPTICKET_INTERFACE_VERSION001")]
    public class SteamAppTicket001 : InteropHelp.NativeWrapper<SteamAppTicket001VTable>
    {
        public uint GetAppOwnershipTicketData(uint nAppId, byte[] pvSignedTicket, ref uint piAppId, ref uint piSteamId,
            ref uint piSignature, ref uint pcbSignature)
        {
            return
                GetFunction<NativeGetAppOwnershipTicketDataUbuuuuu>(Functions.GetAppOwnershipTicketData0)(
                    ObjectAddress, nAppId, pvSignedTicket, (uint)pvSignedTicket.Length, ref piAppId, ref piSteamId,
                    ref piSignature, ref pcbSignature);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetAppOwnershipTicketDataUbuuuuu(
            IntPtr thisptr, uint nAppId, byte[] pvSignedTicket, uint cbSignedTicket, ref uint piAppId,
            ref uint piSteamId, ref uint piSignature, ref uint pcbSignature);
    };
}