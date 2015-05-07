// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamMatchmaking002VTable
    {
        public IntPtr GetFavoriteGameCount0;
        public IntPtr GetFavoriteGame1;
        public IntPtr AddFavoriteGame2;
        public IntPtr RemoveFavoriteGame3;
        public IntPtr RequestLobbyList4;
        public IntPtr GetLobbyByIndex5;
        public IntPtr CreateLobby6;
        public IntPtr JoinLobby7;
        public IntPtr LeaveLobby8;
        public IntPtr InviteUserToLobby9;
        public IntPtr GetNumLobbyMembers10;
        public IntPtr GetLobbyMemberByIndex11;
        public IntPtr GetLobbyData12;
        public IntPtr SetLobbyData13;
        public IntPtr GetLobbyMemberData14;
        public IntPtr SetLobbyMemberData15;
        public IntPtr SendLobbyChatMsg16;
        public IntPtr GetLobbyChatEntry17;
        public IntPtr RequestLobbyData18;
        public IntPtr SetLobbyGameServer19;
        private IntPtr DTorISteamMatchmaking00220;
    };

    [InteropHelp.InterfaceVersionAttribute("SteamMatchMaking002")]
    public class SteamMatchmaking002 : InteropHelp.NativeWrapper<SteamMatchmaking002VTable>
    {
        public int GetFavoriteGameCount()
        {
            return GetFunction<NativeGetFavoriteGameCount>(Functions.GetFavoriteGameCount0)(ObjectAddress);
        }

        public bool GetFavoriteGame(int iGame, ref uint pnAppId, ref uint pnIp, ref ushort pnConnPort,
            ref ushort pnQueryPort, ref uint punFlags, ref uint pRTime32LastPlayedOnServer)
        {
            return GetFunction<NativeGetFavoriteGameIuuuuuu>(Functions.GetFavoriteGame1)(ObjectAddress, iGame,
                ref pnAppId, ref pnIp, ref pnConnPort, ref pnQueryPort, ref punFlags, ref pRTime32LastPlayedOnServer);
        }

        public int AddFavoriteGame(uint nAppId, uint nIp, ushort nConnPort, ushort nQueryPort, uint unFlags,
            uint rTime32LastPlayedOnServer)
        {
            return GetFunction<NativeAddFavoriteGameUuuuuu>(Functions.AddFavoriteGame2)(ObjectAddress, nAppId, nIp,
                nConnPort, nQueryPort, unFlags, rTime32LastPlayedOnServer);
        }

        public bool RemoveFavoriteGame(uint nAppId, uint nIp, ushort nConnPort, ushort nQueryPort, uint unFlags)
        {
            return GetFunction<NativeRemoveFavoriteGameUuuuu>(Functions.RemoveFavoriteGame3)(ObjectAddress, nAppId, nIp,
                nConnPort, nQueryPort, unFlags);
        }

        public void RequestLobbyList()
        {
            GetFunction<NativeRequestLobbyList>(Functions.RequestLobbyList4)(ObjectAddress);
        }

        public CSteamId GetLobbyByIndex(int iLobby)
        {
            ulong ret = 0;
            GetFunction<NativeGetLobbyByIndexI>(Functions.GetLobbyByIndex5)(ObjectAddress, ref ret, iLobby);
            return new CSteamId(ret);
        }

        public void CreateLobby(bool bPrivate)
        {
            GetFunction<NativeCreateLobbyB>(Functions.CreateLobby6)(ObjectAddress, bPrivate);
        }

        public void JoinLobby(CSteamId steamIdLobby)
        {
            GetFunction<NativeJoinLobbyC>(Functions.JoinLobby7)(ObjectAddress, steamIdLobby.ConvertToUint64());
        }

        public void LeaveLobby(CSteamId steamIdLobby)
        {
            GetFunction<NativeLeaveLobbyC>(Functions.LeaveLobby8)(ObjectAddress, steamIdLobby.ConvertToUint64());
        }

        public bool InviteUserToLobby(CSteamId steamIdLobby, CSteamId steamIdInvitee)
        {
            return GetFunction<NativeInviteUserToLobbyCc>(Functions.InviteUserToLobby9)(ObjectAddress,
                steamIdLobby.ConvertToUint64(), steamIdInvitee.ConvertToUint64());
        }

        public int GetNumLobbyMembers(CSteamId steamIdLobby)
        {
            return GetFunction<NativeGetNumLobbyMembersC>(Functions.GetNumLobbyMembers10)(ObjectAddress,
                steamIdLobby.ConvertToUint64());
        }

        public CSteamId GetLobbyMemberByIndex(CSteamId steamIdLobby, int iMember)
        {
            ulong ret = 0;
            GetFunction<NativeGetLobbyMemberByIndexCi>(Functions.GetLobbyMemberByIndex11)(ObjectAddress, ref ret,
                steamIdLobby.ConvertToUint64(), iMember);
            return new CSteamId(ret);
        }

        public string GetLobbyData(CSteamId steamIdLobby, string pchKey)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(GetFunction<NativeGetLobbyDataCs>(Functions.GetLobbyData12)(ObjectAddress,
                        steamIdLobby.ConvertToUint64(), pchKey)));
        }

        public void SetLobbyData(CSteamId steamIdLobby, string pchKey, string pchValue)
        {
            GetFunction<NativeSetLobbyDataCss>(Functions.SetLobbyData13)(ObjectAddress, steamIdLobby.ConvertToUint64(),
                pchKey, pchValue);
        }

        public string GetLobbyMemberData(CSteamId steamIdLobby, CSteamId steamIdUser, string pchKey)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(
                        GetFunction<NativeGetLobbyMemberDataCcs>(Functions.GetLobbyMemberData14)(ObjectAddress,
                            steamIdLobby.ConvertToUint64(), steamIdUser.ConvertToUint64(), pchKey)));
        }

        public void SetLobbyMemberData(CSteamId steamIdLobby, string pchKey, string pchValue)
        {
            GetFunction<NativeSetLobbyMemberDataCss>(Functions.SetLobbyMemberData15)(ObjectAddress,
                steamIdLobby.ConvertToUint64(), pchKey, pchValue);
        }

        public bool SendLobbyChatMsg(CSteamId steamIdLobby, byte[] pvMsgBody)
        {
            return GetFunction<NativeSendLobbyChatMsgCbi>(Functions.SendLobbyChatMsg16)(ObjectAddress,
                steamIdLobby.ConvertToUint64(), pvMsgBody, pvMsgBody.Length);
        }

        public int GetLobbyChatEntry(CSteamId steamIdLobby, int iChatId, ref CSteamId pSteamIdUser, byte[] pvData,
            ref EChatEntryType peChatEntryType)
        {
            ulong s0 = 0;
            var result = GetFunction<NativeGetLobbyChatEntryCicbie>(Functions.GetLobbyChatEntry17)(ObjectAddress,
                steamIdLobby.ConvertToUint64(), iChatId, ref s0, pvData, pvData.Length, ref peChatEntryType);
            pSteamIdUser = new CSteamId(s0);
            return result;
        }

        public bool RequestLobbyData(CSteamId steamIdLobby)
        {
            return GetFunction<NativeRequestLobbyDataC>(Functions.RequestLobbyData18)(ObjectAddress,
                steamIdLobby.ConvertToUint64());
        }

        public void SetLobbyGameServer(CSteamId steamIdLobby, uint unGameServerIp, ushort unGameServerPort,
            CSteamId steamIdGameServer)
        {
            GetFunction<NativeSetLobbyGameServerCuuc>(Functions.SetLobbyGameServer19)(ObjectAddress,
                steamIdLobby.ConvertToUint64(), unGameServerIp, unGameServerPort, steamIdGameServer.ConvertToUint64());
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetFavoriteGameCount(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetFavoriteGameIuuuuuu(
            IntPtr thisptr, int iGame, ref uint pnAppId, ref uint pnIp, ref ushort pnConnPort, ref ushort pnQueryPort,
            ref uint punFlags, ref uint pRTime32LastPlayedOnServer);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeAddFavoriteGameUuuuuu(
            IntPtr thisptr, uint nAppId, uint nIp, ushort nConnPort, ushort nQueryPort, uint unFlags,
            uint rTime32LastPlayedOnServer);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeRemoveFavoriteGameUuuuu(
            IntPtr thisptr, uint nAppId, uint nIp, ushort nConnPort, ushort nQueryPort, uint unFlags);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeRequestLobbyList(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeGetLobbyByIndexI(IntPtr thisptr, ref ulong retarg, int iLobby);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeCreateLobbyB(IntPtr thisptr, [MarshalAs(UnmanagedType.I1)] bool bPrivate);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeJoinLobbyC(IntPtr thisptr, ulong steamIdLobby);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeLeaveLobbyC(IntPtr thisptr, ulong steamIdLobby);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeInviteUserToLobbyCc(IntPtr thisptr, ulong steamIdLobby, ulong steamIdInvitee);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetNumLobbyMembersC(IntPtr thisptr, ulong steamIdLobby);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeGetLobbyMemberByIndexCi(
            IntPtr thisptr, ref ulong retarg, ulong steamIdLobby, int iMember);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetLobbyDataCs(IntPtr thisptr, ulong steamIdLobby, string pchKey);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetLobbyDataCss(IntPtr thisptr, ulong steamIdLobby, string pchKey, string pchValue);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetLobbyMemberDataCcs(
            IntPtr thisptr, ulong steamIdLobby, ulong steamIdUser, string pchKey);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetLobbyMemberDataCss(
            IntPtr thisptr, ulong steamIdLobby, string pchKey, string pchValue);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSendLobbyChatMsgCbi(
            IntPtr thisptr, ulong steamIdLobby, byte[] pvMsgBody, int cubMsgBody);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetLobbyChatEntryCicbie(
            IntPtr thisptr, ulong steamIdLobby, int iChatId, ref ulong pSteamIdUser, byte[] pvData, int cubData,
            ref EChatEntryType peChatEntryType);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeRequestLobbyDataC(IntPtr thisptr, ulong steamIdLobby);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetLobbyGameServerCuuc(
            IntPtr thisptr, ulong steamIdLobby, uint unGameServerIp, ushort unGameServerPort, ulong steamIdGameServer);
    };
}