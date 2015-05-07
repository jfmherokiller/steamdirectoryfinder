// This file is automatically generated.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class ClientMasterServerUpdaterVTable
    {
        public IntPtr SetActive0;
        public IntPtr SetHeartbeatInterval1;
        public IntPtr HandleIncomingPacket2;
        public IntPtr GetNextOutgoingPacket3;
        public IntPtr SetBasicServerData4;
        public IntPtr ClearAllKeyValues5;
        public IntPtr SetKeyValue6;
        public IntPtr NotifyShutdown7;
        public IntPtr WasRestartRequested8;
        public IntPtr ForceHeartbeat9;
        public IntPtr AddMasterServer10;
        public IntPtr RemoveMasterServer11;
        public IntPtr GetNumMasterServers12;
        public IntPtr GetMasterServerAddress13;
        private IntPtr DTorIClientMasterServerUpdater14;
    };

    [InteropHelp.InterfaceVersionAttribute("CLIENTMASTERSERVERUPDATER_INTERFACE_VERSION001")]
    public class ClientMasterServerUpdater : InteropHelp.NativeWrapper<ClientMasterServerUpdaterVTable>
    {
        public void SetActive(bool bActive)
        {
            GetFunction<NativeSetActiveB>(Functions.SetActive0)(ObjectAddress, bActive);
        }

        public void SetHeartbeatInterval(int iHeartbeatInterval)
        {
            GetFunction<NativeSetHeartbeatIntervalI>(Functions.SetHeartbeatInterval1)(ObjectAddress, iHeartbeatInterval);
        }

        public bool HandleIncomingPacket(byte[] pData, uint srcIp, ushort srcPort)
        {
            return GetFunction<NativeHandleIncomingPacketBiuu>(Functions.HandleIncomingPacket2)(ObjectAddress, pData,
                pData.Length, srcIp, srcPort);
        }

        public int GetNextOutgoingPacket(byte[] pOut, ref uint pNetAdr, ref ushort pPort)
        {
            return GetFunction<NativeGetNextOutgoingPacketBiuu>(Functions.GetNextOutgoingPacket3)(ObjectAddress, pOut,
                pOut.Length, ref pNetAdr, ref pPort);
        }

        public void SetBasicServerData(ushort nProtocolVersion, bool bDedicatedServer, string pRegionName,
            string pProductName, ushort nMaxReportedClients, bool bPasswordProtected, string pGameDescription)
        {
            GetFunction<NativeSetBasicServerDataUbssubs>(Functions.SetBasicServerData4)(ObjectAddress, nProtocolVersion,
                bDedicatedServer, pRegionName, pProductName, nMaxReportedClients, bPasswordProtected, pGameDescription);
        }

        public void ClearAllKeyValues()
        {
            GetFunction<NativeClearAllKeyValues>(Functions.ClearAllKeyValues5)(ObjectAddress);
        }

        public void SetKeyValue(string pKey, string pValue)
        {
            GetFunction<NativeSetKeyValueSs>(Functions.SetKeyValue6)(ObjectAddress, pKey, pValue);
        }

        public void NotifyShutdown()
        {
            GetFunction<NativeNotifyShutdown>(Functions.NotifyShutdown7)(ObjectAddress);
        }

        public bool WasRestartRequested()
        {
            return GetFunction<NativeWasRestartRequested>(Functions.WasRestartRequested8)(ObjectAddress);
        }

        public void ForceHeartbeat()
        {
            GetFunction<NativeForceHeartbeat>(Functions.ForceHeartbeat9)(ObjectAddress);
        }

        public bool AddMasterServer(string pServerAddress)
        {
            return GetFunction<NativeAddMasterServerS>(Functions.AddMasterServer10)(ObjectAddress, pServerAddress);
        }

        public bool RemoveMasterServer(string pServerAddress)
        {
            return GetFunction<NativeRemoveMasterServerS>(Functions.RemoveMasterServer11)(ObjectAddress, pServerAddress);
        }

        public int GetNumMasterServers()
        {
            return GetFunction<NativeGetNumMasterServers>(Functions.GetNumMasterServers12)(ObjectAddress);
        }

        public int GetMasterServerAddress(int iServer, StringBuilder pOut, int outBufferSize)
        {
            return GetFunction<NativeGetMasterServerAddressIsi>(Functions.GetMasterServerAddress13)(ObjectAddress,
                iServer, pOut, outBufferSize);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetActiveB(IntPtr thisptr, [MarshalAs(UnmanagedType.I1)] bool bActive);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetHeartbeatIntervalI(IntPtr thisptr, int iHeartbeatInterval);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeHandleIncomingPacketBiuu(
            IntPtr thisptr, byte[] pData, int cbData, uint srcIp, ushort srcPort);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetNextOutgoingPacketBiuu(
            IntPtr thisptr, byte[] pOut, int cbMaxOut, ref uint pNetAdr, ref ushort pPort);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetBasicServerDataUbssubs(
            IntPtr thisptr, ushort nProtocolVersion, [MarshalAs(UnmanagedType.I1)] bool bDedicatedServer,
            string pRegionName, string pProductName, ushort nMaxReportedClients,
            [MarshalAs(UnmanagedType.I1)] bool bPasswordProtected, string pGameDescription);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeClearAllKeyValues(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetKeyValueSs(IntPtr thisptr, string pKey, string pValue);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeNotifyShutdown(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeWasRestartRequested(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeForceHeartbeat(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeAddMasterServerS(IntPtr thisptr, string pServerAddress);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeRemoveMasterServerS(IntPtr thisptr, string pServerAddress);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetNumMasterServers(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetMasterServerAddressIsi(
            IntPtr thisptr, int iServer, StringBuilder pOut, int outBufferSize);
    };
}