// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamFriends001VTable
    {
        public IntPtr GetPersonaName0;
        public IntPtr SetPersonaName1;
        public IntPtr GetPersonaState2;
        public IntPtr SetPersonaState3;
        public IntPtr AddFriend4;
        public IntPtr RemoveFriend5;
        public IntPtr HasFriend6;
        public IntPtr GetFriendRelationship7;
        public IntPtr GetFriendPersonaState8;
        public IntPtr Deprecated_GetFriendGamePlayed9;
        public IntPtr GetFriendPersonaName10;
        public IntPtr AddFriendByName11;
        public IntPtr GetFriendCount12;
        public IntPtr GetFriendByIndex13;
        public IntPtr SendMsgToFriend14;
        public IntPtr SetFriendRegValue15;
        public IntPtr GetFriendRegValue16;
        public IntPtr GetFriendPersonaNameHistory17;
        public IntPtr GetChatMessage18;
        public IntPtr SendMsgToFriend19;
        public IntPtr GetChatIDOfChatHistoryStart20;
        public IntPtr SetChatHistoryStart21;
        public IntPtr ClearChatHistory22;
        public IntPtr InviteFriendByEmail23;
        public IntPtr GetBlockedFriendCount24;
        public IntPtr GetFriendGamePlayed25;
        public IntPtr GetFriendGamePlayed226;
        private IntPtr DTorISteamFriends00127;
    };

    [InteropHelp.InterfaceVersionAttribute("SteamFriends001")]
    public class SteamFriends001 : InteropHelp.NativeWrapper<SteamFriends001VTable>
    {
        public string GetPersonaName()
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(GetFunction<NativeGetPersonaName>(Functions.GetPersonaName0)(ObjectAddress)));
        }

        public void SetPersonaName(string pchPersonaName)
        {
            GetFunction<NativeSetPersonaNameS>(Functions.SetPersonaName1)(ObjectAddress, pchPersonaName);
        }

        public EPersonaState GetPersonaState()
        {
            return GetFunction<NativeGetPersonaState>(Functions.GetPersonaState2)(ObjectAddress);
        }

        public void SetPersonaState(EPersonaState ePersonaState)
        {
            GetFunction<NativeSetPersonaStateE>(Functions.SetPersonaState3)(ObjectAddress, ePersonaState);
        }

        public bool AddFriend(CSteamId steamIdFriend)
        {
            return GetFunction<NativeAddFriendC>(Functions.AddFriend4)(ObjectAddress, steamIdFriend.ConvertToUint64());
        }

        public bool RemoveFriend(CSteamId steamIdFriend)
        {
            return GetFunction<NativeRemoveFriendC>(Functions.RemoveFriend5)(ObjectAddress,
                steamIdFriend.ConvertToUint64());
        }

        public bool HasFriend(CSteamId steamIdFriend)
        {
            return GetFunction<NativeHasFriendC>(Functions.HasFriend6)(ObjectAddress, steamIdFriend.ConvertToUint64());
        }

        public EFriendRelationship GetFriendRelationship(CSteamId steamIdFriend)
        {
            return GetFunction<NativeGetFriendRelationshipC>(Functions.GetFriendRelationship7)(ObjectAddress,
                steamIdFriend.ConvertToUint64());
        }

        public EPersonaState GetFriendPersonaState(CSteamId steamIdFriend)
        {
            return GetFunction<NativeGetFriendPersonaStateC>(Functions.GetFriendPersonaState8)(ObjectAddress,
                steamIdFriend.ConvertToUint64());
        }

        public bool Deprecated_GetFriendGamePlayed(CSteamId steamIdFriend, ref int pnGameId, ref uint punGameIp,
            ref ushort pusGamePort)
        {
            return
                GetFunction<NativeDeprecatedGetFriendGamePlayedCiuu>(Functions.Deprecated_GetFriendGamePlayed9)(
                    ObjectAddress, steamIdFriend.ConvertToUint64(), ref pnGameId, ref punGameIp, ref pusGamePort);
        }

        public string GetFriendPersonaName(CSteamId steamIdFriend)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(
                        GetFunction<NativeGetFriendPersonaNameC>(Functions.GetFriendPersonaName10)(ObjectAddress,
                            steamIdFriend.ConvertToUint64())));
        }

        public int AddFriendByName(string pchEmailOrAccountName)
        {
            return GetFunction<NativeAddFriendByNameS>(Functions.AddFriendByName11)(ObjectAddress, pchEmailOrAccountName);
        }

        public int GetFriendCount()
        {
            return GetFunction<NativeGetFriendCount>(Functions.GetFriendCount12)(ObjectAddress);
        }

        public CSteamId GetFriendByIndex(int iFriend)
        {
            ulong ret = 0;
            GetFunction<NativeGetFriendByIndexI>(Functions.GetFriendByIndex13)(ObjectAddress, ref ret, iFriend);
            return new CSteamId(ret);
        }

        public void SendMsgToFriend(CSteamId steamIdFriend, EChatEntryType eFriendMsgType, string pchMsgBody)
        {
            GetFunction<NativeSendMsgToFriendCes>(Functions.SendMsgToFriend14)(ObjectAddress,
                steamIdFriend.ConvertToUint64(), eFriendMsgType, pchMsgBody);
        }

        public void SetFriendRegValue(CSteamId steamIdFriend, string pchKey, string pchValue)
        {
            GetFunction<NativeSetFriendRegValueCss>(Functions.SetFriendRegValue15)(ObjectAddress,
                steamIdFriend.ConvertToUint64(), pchKey, pchValue);
        }

        public string GetFriendRegValue(CSteamId steamIdFriend, string pchKey)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(
                        GetFunction<NativeGetFriendRegValueCs>(Functions.GetFriendRegValue16)(ObjectAddress,
                            steamIdFriend.ConvertToUint64(), pchKey)));
        }

        public string GetFriendPersonaNameHistory(CSteamId steamIdFriend, int iPersonaName)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(
                        GetFunction<NativeGetFriendPersonaNameHistoryCi>(Functions.GetFriendPersonaNameHistory17)(
                            ObjectAddress, steamIdFriend.ConvertToUint64(), iPersonaName)));
        }

        public int GetChatMessage(CSteamId steamIdFriend, int iChatId, byte[] pvData, ref EChatEntryType peFriendMsgType)
        {
            return GetFunction<NativeGetChatMessageCibie>(Functions.GetChatMessage18)(ObjectAddress,
                steamIdFriend.ConvertToUint64(), iChatId, pvData, pvData.Length, ref peFriendMsgType);
        }

        public bool SendMsgToFriend(CSteamId steamIdFriend, EChatEntryType eFriendMsgType, byte[] pvMsgBody)
        {
            return GetFunction<NativeSendMsgToFriendCebi>(Functions.SendMsgToFriend19)(ObjectAddress,
                steamIdFriend.ConvertToUint64(), eFriendMsgType, pvMsgBody, pvMsgBody.Length);
        }

        public int GetChatIdOfChatHistoryStart(CSteamId steamIdFriend)
        {
            return
                GetFunction<NativeGetChatIdOfChatHistoryStartC>(Functions.GetChatIDOfChatHistoryStart20)(ObjectAddress,
                    steamIdFriend.ConvertToUint64());
        }

        public void SetChatHistoryStart(CSteamId steamIdFriend, int iChatId)
        {
            GetFunction<NativeSetChatHistoryStartCi>(Functions.SetChatHistoryStart21)(ObjectAddress,
                steamIdFriend.ConvertToUint64(), iChatId);
        }

        public void ClearChatHistory(CSteamId steamIdFriend)
        {
            GetFunction<NativeClearChatHistoryC>(Functions.ClearChatHistory22)(ObjectAddress,
                steamIdFriend.ConvertToUint64());
        }

        public int InviteFriendByEmail(string pchEmailOrAccountName)
        {
            return GetFunction<NativeInviteFriendByEmailS>(Functions.InviteFriendByEmail23)(ObjectAddress,
                pchEmailOrAccountName);
        }

        public uint GetBlockedFriendCount()
        {
            return GetFunction<NativeGetBlockedFriendCount>(Functions.GetBlockedFriendCount24)(ObjectAddress);
        }

        public bool GetFriendGamePlayed(CSteamId steamIdFriend, ref ulong pulGameId, ref uint punGameIp,
            ref ushort pusGamePort)
        {
            return GetFunction<NativeGetFriendGamePlayedCuuu>(Functions.GetFriendGamePlayed25)(ObjectAddress,
                steamIdFriend.ConvertToUint64(), ref pulGameId, ref punGameIp, ref pusGamePort);
        }

        public bool GetFriendGamePlayed2(CSteamId steamDiFriend, ref ulong pulGameId, ref uint punGameIp,
            ref ushort pusGamePort, ref ushort pusQueryPort)
        {
            return GetFunction<NativeGetFriendGamePlayed2Cuuuu>(Functions.GetFriendGamePlayed226)(ObjectAddress,
                steamDiFriend.ConvertToUint64(), ref pulGameId, ref punGameIp, ref pusGamePort, ref pusQueryPort);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetPersonaName(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetPersonaNameS(IntPtr thisptr, string pchPersonaName);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EPersonaState NativeGetPersonaState(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetPersonaStateE(IntPtr thisptr, EPersonaState ePersonaState);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeAddFriendC(IntPtr thisptr, ulong steamIdFriend);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeRemoveFriendC(IntPtr thisptr, ulong steamIdFriend);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeHasFriendC(IntPtr thisptr, ulong steamIdFriend);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EFriendRelationship NativeGetFriendRelationshipC(IntPtr thisptr, ulong steamIdFriend);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EPersonaState NativeGetFriendPersonaStateC(IntPtr thisptr, ulong steamIdFriend);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeDeprecatedGetFriendGamePlayedCiuu(
            IntPtr thisptr, ulong steamIdFriend, ref int pnGameId, ref uint punGameIp, ref ushort pusGamePort);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetFriendPersonaNameC(IntPtr thisptr, ulong steamIdFriend);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeAddFriendByNameS(IntPtr thisptr, string pchEmailOrAccountName);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetFriendCount(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeGetFriendByIndexI(IntPtr thisptr, ref ulong retarg, int iFriend);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSendMsgToFriendCes(
            IntPtr thisptr, ulong steamIdFriend, EChatEntryType eFriendMsgType, string pchMsgBody);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetFriendRegValueCss(
            IntPtr thisptr, ulong steamIdFriend, string pchKey, string pchValue);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetFriendRegValueCs(IntPtr thisptr, ulong steamIdFriend, string pchKey);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetFriendPersonaNameHistoryCi(
            IntPtr thisptr, ulong steamIdFriend, int iPersonaName);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetChatMessageCibie(
            IntPtr thisptr, ulong steamIdFriend, int iChatId, byte[] pvData, int cubData,
            ref EChatEntryType peFriendMsgType);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSendMsgToFriendCebi(
            IntPtr thisptr, ulong steamIdFriend, EChatEntryType eFriendMsgType, byte[] pvMsgBody, int cubMsgBody);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetChatIdOfChatHistoryStartC(IntPtr thisptr, ulong steamIdFriend);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetChatHistoryStartCi(IntPtr thisptr, ulong steamIdFriend, int iChatId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeClearChatHistoryC(IntPtr thisptr, ulong steamIdFriend);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeInviteFriendByEmailS(IntPtr thisptr, string pchEmailOrAccountName);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetBlockedFriendCount(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetFriendGamePlayedCuuu(
            IntPtr thisptr, ulong steamIdFriend, ref ulong pulGameId, ref uint punGameIp, ref ushort pusGamePort);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetFriendGamePlayed2Cuuuu(
            IntPtr thisptr, ulong steamDiFriend, ref ulong pulGameId, ref uint punGameIp, ref ushort pusGamePort,
            ref ushort pusQueryPort);
    };
}