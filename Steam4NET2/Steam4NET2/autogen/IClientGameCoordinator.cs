// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class ClientGameCoordinatorVTable
    {
        public IntPtr SendMessage0;
        public IntPtr IsMessageAvailable1;
        public IntPtr RetrieveMessage2;
        private IntPtr DTorIClientGameCoordinator3;
    };

    [InteropHelp.InterfaceVersionAttribute("CLIENTGAMECOORDINATOR_INTERFACE_VERSION001")]
    public class ClientGameCoordinator : InteropHelp.NativeWrapper<ClientGameCoordinatorVTable>
    {
        public EgcResults SendMessage(uint unAppId, uint unMsgType, byte[] pubData)
        {
            return GetFunction<NativeSendMessageUubu>(Functions.SendMessage0)(ObjectAddress, unAppId, unMsgType, pubData,
                (uint)pubData.Length);
        }

        public bool IsMessageAvailable(uint unAppId, ref uint pcubMsgSize)
        {
            return GetFunction<NativeIsMessageAvailableUu>(Functions.IsMessageAvailable1)(ObjectAddress, unAppId,
                ref pcubMsgSize);
        }

        public EgcResults RetrieveMessage(uint unAppId, ref uint punMsgType, byte[] pubDest, ref uint pcubMsgSize)
        {
            return GetFunction<NativeRetrieveMessageUubuu>(Functions.RetrieveMessage2)(ObjectAddress, unAppId,
                ref punMsgType, pubDest, (uint)pubDest.Length, ref pcubMsgSize);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EgcResults NativeSendMessageUubu(
            IntPtr thisptr, uint unAppId, uint unMsgType, byte[] pubData, uint cubData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeIsMessageAvailableUu(IntPtr thisptr, uint unAppId, ref uint pcubMsgSize);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EgcResults NativeRetrieveMessageUubuu(
            IntPtr thisptr, uint unAppId, ref uint punMsgType, byte[] pubDest, uint cubDest, ref uint pcubMsgSize);
    };
}