// This file is automatically generated.

using System;
using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class ClientConfigStoreVTable
    {
        public IntPtr IsSet0;
        public IntPtr GetBool1;
        public IntPtr GetInt2;
        public IntPtr GetUint643;
        public IntPtr GetFloat4;
        public IntPtr GetString5;
        public IntPtr GetBinary6;
        public IntPtr GetBinary7;
        public IntPtr GetBinaryWatermarked8;
        public IntPtr SetBool9;
        public IntPtr SetInt10;
        public IntPtr SetUint6411;
        public IntPtr SetFloat12;
        public IntPtr SetString13;
        public IntPtr SetBinary14;
        public IntPtr SetBinaryWatermarked15;
        public IntPtr RemoveKey16;
        public IntPtr GetKeySerialized17;
        public IntPtr FlushToDisk18;
        private IntPtr DTorIClientConfigStore19;
    };

    [InteropHelp.InterfaceVersionAttribute("CLIENTCONFIGSTORE_INTERFACE_VERSION001")]
    public class ClientConfigStore : InteropHelp.NativeWrapper<ClientConfigStoreVTable>
    {
        public bool IsSet(EConfigStore eConfigStore, string pszKeyNameIn)
        {
            return GetFunction<NativeIsSetEs>(Functions.IsSet0)(ObjectAddress, eConfigStore, pszKeyNameIn);
        }

        public bool GetBool(EConfigStore eConfigStore, string pszKeyNameIn, bool defaultValue)
        {
            return GetFunction<NativeGetBoolEsb>(Functions.GetBool1)(ObjectAddress, eConfigStore, pszKeyNameIn,
                defaultValue);
        }

        public int GetInt(EConfigStore eConfigStore, string pszKeyName, int defaultValue)
        {
            return GetFunction<NativeGetIntEsi>(Functions.GetInt2)(ObjectAddress, eConfigStore, pszKeyName, defaultValue);
        }

        public ulong GetUint64(EConfigStore eConfigStore, string pszKeyName, ulong defaultValue)
        {
            return GetFunction<NativeGetUint64Esu>(Functions.GetUint643)(ObjectAddress, eConfigStore, pszKeyName,
                defaultValue);
        }

        public float GetFloat(EConfigStore eConfigStore, string pszKeyName, float defaultValue)
        {
            return GetFunction<NativeGetFloatEsf>(Functions.GetFloat4)(ObjectAddress, eConfigStore, pszKeyName,
                defaultValue);
        }

        public string GetString(EConfigStore eConfigStore, string pszKeyName, string defaultValue)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(GetFunction<NativeGetStringEss>(Functions.GetString5)(ObjectAddress,
                        eConfigStore, pszKeyName, defaultValue)));
        }

        public uint GetBinary(EConfigStore eConfigStore, string pszKeyName, byte[] pubBuf)
        {
            return GetFunction<NativeGetBinaryEsbu>(Functions.GetBinary6)(ObjectAddress, eConfigStore, pszKeyName,
                pubBuf, (uint)pubBuf.Length);
        }

        public uint GetBinary(EConfigStore eConfigStore, string pszKeyName, ref CUtlBuffer pUtlBuf)
        {
            return GetFunction<NativeGetBinaryEsc>(Functions.GetBinary7)(ObjectAddress, eConfigStore, pszKeyName,
                ref pUtlBuf);
        }

        public uint GetBinaryWatermarked(EConfigStore eConfigStore, string pszKeyName, byte[] pubBuf)
        {
            return GetFunction<NativeGetBinaryWatermarkedEsbu>(Functions.GetBinaryWatermarked8)(ObjectAddress,
                eConfigStore, pszKeyName, pubBuf, (uint)pubBuf.Length);
        }

        public bool SetBool(EConfigStore eConfigStore, string pszKeyNameIn, bool value)
        {
            return GetFunction<NativeSetBoolEsb>(Functions.SetBool9)(ObjectAddress, eConfigStore, pszKeyNameIn, value);
        }

        public bool SetInt(EConfigStore eConfigStore, string pszKeyNameIn, int nValue)
        {
            return GetFunction<NativeSetIntEsi>(Functions.SetInt10)(ObjectAddress, eConfigStore, pszKeyNameIn, nValue);
        }

        public bool SetUint64(EConfigStore eConfigStore, string pszKeyNameIn, ulong unValue)
        {
            return GetFunction<NativeSetUint64Esu>(Functions.SetUint6411)(ObjectAddress, eConfigStore, pszKeyNameIn,
                unValue);
        }

        public bool SetFloat(EConfigStore eConfigStore, string pszKeyNameIn, float flValue)
        {
            return GetFunction<NativeSetFloatEsf>(Functions.SetFloat12)(ObjectAddress, eConfigStore, pszKeyNameIn,
                flValue);
        }

        public bool SetString(EConfigStore eConfigStore, string pszKeyNameIn, string pszValue)
        {
            return GetFunction<NativeSetStringEss>(Functions.SetString13)(ObjectAddress, eConfigStore, pszKeyNameIn,
                pszValue);
        }

        public bool SetBinary(EConfigStore eConfigStore, string pszKeyName, byte[] pubData)
        {
            return GetFunction<NativeSetBinaryEsbu>(Functions.SetBinary14)(ObjectAddress, eConfigStore, pszKeyName,
                pubData, (uint)pubData.Length);
        }

        public bool SetBinaryWatermarked(EConfigStore eConfigStore, string pszKeyName, byte[] pubData)
        {
            return GetFunction<NativeSetBinaryWatermarkedEsbu>(Functions.SetBinaryWatermarked15)(ObjectAddress,
                eConfigStore, pszKeyName, pubData, (uint)pubData.Length);
        }

        public bool RemoveKey(EConfigStore eConfigStore, string pszKeyName)
        {
            return GetFunction<NativeRemoveKeyEs>(Functions.RemoveKey16)(ObjectAddress, eConfigStore, pszKeyName);
        }

        public int GetKeySerialized(EConfigStore eConfigStore, string pszKeyNameIn, byte[] pchBuffer)
        {
            return GetFunction<NativeGetKeySerializedEsbi>(Functions.GetKeySerialized17)(ObjectAddress, eConfigStore,
                pszKeyNameIn, pchBuffer, pchBuffer.Length);
        }

        public bool FlushToDisk(bool bIsShuttingDown)
        {
            return GetFunction<NativeFlushToDiskB>(Functions.FlushToDisk18)(ObjectAddress, bIsShuttingDown);
        }

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeIsSetEs(IntPtr thisptr, EConfigStore eConfigStore, string pszKeyNameIn);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetBoolEsb(
            IntPtr thisptr, EConfigStore eConfigStore, string pszKeyNameIn,
            [MarshalAs(UnmanagedType.I1)] bool defaultValue);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetIntEsi(
            IntPtr thisptr, EConfigStore eConfigStore, string pszKeyName, int defaultValue);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeGetUint64Esu(
            IntPtr thisptr, EConfigStore eConfigStore, string pszKeyName, ulong defaultValue);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate float NativeGetFloatEsf(
            IntPtr thisptr, EConfigStore eConfigStore, string pszKeyName, float defaultValue);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetStringEss(
            IntPtr thisptr, EConfigStore eConfigStore, string pszKeyName, string defaultValue);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetBinaryEsbu(
            IntPtr thisptr, EConfigStore eConfigStore, string pszKeyName, byte[] pubBuf, uint cubBuf);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetBinaryEsc(
            IntPtr thisptr, EConfigStore eConfigStore, string pszKeyName, ref CUtlBuffer pUtlBuf);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetBinaryWatermarkedEsbu(
            IntPtr thisptr, EConfigStore eConfigStore, string pszKeyName, byte[] pubBuf, uint cubBuf);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetBoolEsb(
            IntPtr thisptr, EConfigStore eConfigStore, string pszKeyNameIn, [MarshalAs(UnmanagedType.I1)] bool value);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetIntEsi(IntPtr thisptr, EConfigStore eConfigStore, string pszKeyNameIn, int nValue
            );

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetUint64Esu(
            IntPtr thisptr, EConfigStore eConfigStore, string pszKeyNameIn, ulong unValue);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetFloatEsf(
            IntPtr thisptr, EConfigStore eConfigStore, string pszKeyNameIn, float flValue);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetStringEss(
            IntPtr thisptr, EConfigStore eConfigStore, string pszKeyNameIn, string pszValue);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetBinaryEsbu(
            IntPtr thisptr, EConfigStore eConfigStore, string pszKeyName, byte[] pubData, uint cubData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetBinaryWatermarkedEsbu(
            IntPtr thisptr, EConfigStore eConfigStore, string pszKeyName, byte[] pubData, uint cubData);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeRemoveKeyEs(IntPtr thisptr, EConfigStore eConfigStore, string pszKeyName);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetKeySerializedEsbi(
            IntPtr thisptr, EConfigStore eConfigStore, string pszKeyNameIn, byte[] pchBuffer, int cbBufferMax);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeFlushToDiskB(IntPtr thisptr, [MarshalAs(UnmanagedType.I1)] bool bIsShuttingDown);
    };
}