// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamGameStats001VTable
    {
        public IntPtr GetNewSession0;
        public IntPtr EndSession1;
        public IntPtr AddSessionAttributeInt2;
        public IntPtr AddSessionAttributeString3;
        public IntPtr AddSessionAttributeFloat4;
        public IntPtr AddNewRow5;
        public IntPtr CommitRow6;
        public IntPtr CommitOutstandingRows7;
        public IntPtr AddRowAttributeInt8;
        public IntPtr AddRowAtributeString9;
        public IntPtr AddRowAttributeFloat10;
        public IntPtr AddSessionAttributeInt6411;
        public IntPtr AddRowAttributeInt6412;
        private IntPtr DTorISteamGameStats00113;
    };

    [InteropHelp.InterfaceVersionAttribute("SteamGameStats001")]
    public class SteamGameStats001 : InteropHelp.NativeWrapper<SteamGameStats001VTable>
    {
        public ulong GetNewSession(sbyte nAccountType, ulong ulAccountId, int nAppId, uint rtTimeStarted)
        {
            return GetFunction<NativeGetNewSessionSuiu>(Functions.GetNewSession0)(ObjectAddress, nAccountType,
                ulAccountId, nAppId, rtTimeStarted);
        }

        public ulong EndSession(ulong ulSessionId, uint rtTimeEnded, int nReasonCode)
        {
            return GetFunction<NativeEndSessionUui>(Functions.EndSession1)(ObjectAddress, ulSessionId, rtTimeEnded,
                nReasonCode);
        }

        public EResult AddSessionAttributeInt(ulong ulSessionId, string pstrName, int nData)
        {
            return GetFunction<NativeAddSessionAttributeIntUsi>(Functions.AddSessionAttributeInt2)(ObjectAddress,
                ulSessionId, pstrName, nData);
        }

        public EResult AddSessionAttributeString(ulong ulSessionId, string pstrName, string pstrData)
        {
            return GetFunction<NativeAddSessionAttributeStringUss>(Functions.AddSessionAttributeString3)(ObjectAddress,
                ulSessionId, pstrName, pstrData);
        }

        public EResult AddSessionAttributeFloat(ulong ulSessionId, string pstrName, float fData)
        {
            return GetFunction<NativeAddSessionAttributeFloatUsf>(Functions.AddSessionAttributeFloat4)(ObjectAddress,
                ulSessionId, pstrName, fData);
        }

        public EResult AddNewRow(ref ulong pulRowId, ulong ulSessionId, string pstrTableName)
        {
            return GetFunction<NativeAddNewRowUus>(Functions.AddNewRow5)(ObjectAddress, ref pulRowId, ulSessionId,
                pstrTableName);
        }

        public EResult CommitRow(ulong ulRowId)
        {
            return GetFunction<NativeCommitRowU>(Functions.CommitRow6)(ObjectAddress, ulRowId);
        }

        public EResult CommitOutstandingRows(ulong ulSessionId)
        {
            return GetFunction<NativeCommitOutstandingRowsU>(Functions.CommitOutstandingRows7)(ObjectAddress,
                ulSessionId);
        }

        public EResult AddRowAttributeInt(ulong ulRowId, string pstrName, int nData)
        {
            return GetFunction<NativeAddRowAttributeIntUsi>(Functions.AddRowAttributeInt8)(ObjectAddress, ulRowId,
                pstrName, nData);
        }

        public EResult AddRowAtributeString(ulong ulRowId, string pstrName, string pstrData)
        {
            return GetFunction<NativeAddRowAtributeStringUss>(Functions.AddRowAtributeString9)(ObjectAddress, ulRowId,
                pstrName, pstrData);
        }

        public EResult AddRowAttributeFloat(ulong ulRowId, string pstrName, float fData)
        {
            return GetFunction<NativeAddRowAttributeFloatUsf>(Functions.AddRowAttributeFloat10)(ObjectAddress, ulRowId,
                pstrName, fData);
        }

        public EResult AddSessionAttributeInt64(ulong ulSessionId, string pstrName, long llData)
        {
            return GetFunction<NativeAddSessionAttributeInt64Usi>(Functions.AddSessionAttributeInt6411)(ObjectAddress,
                ulSessionId, pstrName, llData);
        }

        public EResult AddRowAttributeInt64(ulong ulRowId, string pstrName, long llData)
        {
            return GetFunction<NativeAddRowAttributeInt64Usi>(Functions.AddRowAttributeInt6412)(ObjectAddress, ulRowId,
                pstrName, llData);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeGetNewSessionSuiu(
            IntPtr thisptr, sbyte nAccountType, ulong ulAccountId, int nAppId, uint rtTimeStarted);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeEndSessionUui(IntPtr thisptr, ulong ulSessionId, uint rtTimeEnded, int nReasonCode);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EResult NativeAddSessionAttributeIntUsi(
            IntPtr thisptr, ulong ulSessionId, string pstrName, int nData);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EResult NativeAddSessionAttributeStringUss(
            IntPtr thisptr, ulong ulSessionId, string pstrName, string pstrData);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EResult NativeAddSessionAttributeFloatUsf(
            IntPtr thisptr, ulong ulSessionId, string pstrName, float fData);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EResult NativeAddNewRowUus(
            IntPtr thisptr, ref ulong pulRowId, ulong ulSessionId, string pstrTableName);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EResult NativeCommitRowU(IntPtr thisptr, ulong ulRowId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EResult NativeCommitOutstandingRowsU(IntPtr thisptr, ulong ulSessionId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EResult NativeAddRowAttributeIntUsi(IntPtr thisptr, ulong ulRowId, string pstrName, int nData);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EResult NativeAddRowAtributeStringUss(
            IntPtr thisptr, ulong ulRowId, string pstrName, string pstrData);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EResult NativeAddRowAttributeFloatUsf(
            IntPtr thisptr, ulong ulRowId, string pstrName, float fData);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EResult NativeAddSessionAttributeInt64Usi(
            IntPtr thisptr, ulong ulSessionId, string pstrName, long llData);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EResult NativeAddRowAttributeInt64Usi(
            IntPtr thisptr, ulong ulRowId, string pstrName, long llData);
    };
}