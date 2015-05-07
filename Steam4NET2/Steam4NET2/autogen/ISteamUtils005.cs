// This file is automatically generated.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamUtils005VTable
    {
        public IntPtr GetSecondsSinceAppActive0;
        public IntPtr GetSecondsSinceComputerActive1;
        public IntPtr GetConnectedUniverse2;
        public IntPtr GetServerRealTime3;
        public IntPtr GetIPCountry4;
        public IntPtr GetImageSize5;
        public IntPtr GetImageRGBA6;
        public IntPtr GetCSERIPPort7;
        public IntPtr GetCurrentBatteryPower8;
        public IntPtr GetAppID9;
        public IntPtr SetOverlayNotificationPosition10;
        public IntPtr IsAPICallCompleted11;
        public IntPtr GetAPICallFailureReason12;
        public IntPtr GetAPICallResult13;
        public IntPtr RunFrame14;
        public IntPtr GetIPCCallCount15;
        public IntPtr SetWarningMessageHook16;
        public IntPtr IsOverlayEnabled17;
        public IntPtr BOverlayNeedsPresent18;
        public IntPtr CheckFileSignature19;
        public IntPtr ShowGamepadTextInput20;
        public IntPtr GetEnteredGamepadTextLength21;
        public IntPtr GetEnteredGamepadTextInput22;
        private IntPtr DTorISteamUtils00523;
    };

    [InteropHelp.InterfaceVersionAttribute("SteamUtils005")]
    public class SteamUtils005 : InteropHelp.NativeWrapper<SteamUtils005VTable>
    {
        public uint GetSecondsSinceAppActive()
        {
            return GetFunction<NativeGetSecondsSinceAppActive>(Functions.GetSecondsSinceAppActive0)(ObjectAddress);
        }

        public uint GetSecondsSinceComputerActive()
        {
            return
                GetFunction<NativeGetSecondsSinceComputerActive>(Functions.GetSecondsSinceComputerActive1)(ObjectAddress);
        }

        public EUniverse GetConnectedUniverse()
        {
            return GetFunction<NativeGetConnectedUniverse>(Functions.GetConnectedUniverse2)(ObjectAddress);
        }

        public uint GetServerRealTime()
        {
            return GetFunction<NativeGetServerRealTime>(Functions.GetServerRealTime3)(ObjectAddress);
        }

        public string GetIpCountry()
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(GetFunction<NativeGetIpCountry>(Functions.GetIPCountry4)(ObjectAddress)));
        }

        public bool GetImageSize(int iImage, ref uint pnWidth, ref uint pnHeight)
        {
            return GetFunction<NativeGetImageSizeIuu>(Functions.GetImageSize5)(ObjectAddress, iImage, ref pnWidth,
                ref pnHeight);
        }

        public bool GetImageRgba(int iImage, byte[] pubDest, int nDestBufferSize)
        {
            return GetFunction<NativeGetImageRgbaibi>(Functions.GetImageRGBA6)(ObjectAddress, iImage, pubDest,
                nDestBufferSize);
        }

        public bool GetCseripPort(ref uint unIp, ref ushort usPort)
        {
            return GetFunction<NativeGetCseripPortUu>(Functions.GetCSERIPPort7)(ObjectAddress, ref unIp, ref usPort);
        }

        public byte GetCurrentBatteryPower()
        {
            return GetFunction<NativeGetCurrentBatteryPower>(Functions.GetCurrentBatteryPower8)(ObjectAddress);
        }

        public uint GetAppId()
        {
            return GetFunction<NativeGetAppId>(Functions.GetAppID9)(ObjectAddress);
        }

        public void SetOverlayNotificationPosition(ENotificationPosition eNotificationPosition)
        {
            GetFunction<NativeSetOverlayNotificationPositionE>(Functions.SetOverlayNotificationPosition10)(
                ObjectAddress, eNotificationPosition);
        }

        public bool IsApiCallCompleted(ulong hSteamApiCall, ref bool pbFailed)
        {
            return GetFunction<NativeIsApiCallCompletedUb>(Functions.IsAPICallCompleted11)(ObjectAddress, hSteamApiCall,
                ref pbFailed);
        }

        public ESteamApiCallFailure GetApiCallFailureReason(ulong hSteamApiCall)
        {
            return GetFunction<NativeGetApiCallFailureReasonU>(Functions.GetAPICallFailureReason12)(ObjectAddress,
                hSteamApiCall);
        }

        public bool GetApiCallResult(ulong hSteamApiCall, byte[] pCallback, int iCallbackExpected, ref bool pbFailed)
        {
            return GetFunction<NativeGetApiCallResultUbiib>(Functions.GetAPICallResult13)(ObjectAddress, hSteamApiCall,
                pCallback, pCallback.Length, iCallbackExpected, ref pbFailed);
        }

        public void RunFrame()
        {
            GetFunction<NativeRunFrame>(Functions.RunFrame14)(ObjectAddress);
        }

        public uint GetIpcCallCount()
        {
            return GetFunction<NativeGetIpcCallCount>(Functions.GetIPCCallCount15)(ObjectAddress);
        }

        public void SetWarningMessageHook(ref IntPtr pFunction)
        {
            GetFunction<NativeSetWarningMessageHookI>(Functions.SetWarningMessageHook16)(ObjectAddress, ref pFunction);
        }

        public bool IsOverlayEnabled()
        {
            return GetFunction<NativeIsOverlayEnabled>(Functions.IsOverlayEnabled17)(ObjectAddress);
        }

        public bool BOverlayNeedsPresent()
        {
            return GetFunction<NativeBOverlayNeedsPresent>(Functions.BOverlayNeedsPresent18)(ObjectAddress);
        }

        public ulong CheckFileSignature(string szFileName)
        {
            return GetFunction<NativeCheckFileSignatureS>(Functions.CheckFileSignature19)(ObjectAddress, szFileName);
        }

        public bool ShowGamepadTextInput(EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eInputLineMode,
            string szText, uint uMaxLength)
        {
            return GetFunction<NativeShowGamepadTextInputEesu>(Functions.ShowGamepadTextInput20)(ObjectAddress,
                eInputMode, eInputLineMode, szText, uMaxLength);
        }

        public uint GetEnteredGamepadTextLength()
        {
            return GetFunction<NativeGetEnteredGamepadTextLength>(Functions.GetEnteredGamepadTextLength21)(ObjectAddress);
        }

        public bool GetEnteredGamepadTextInput(StringBuilder pchValue)
        {
            return GetFunction<NativeGetEnteredGamepadTextInputSu>(Functions.GetEnteredGamepadTextInput22)(
                ObjectAddress, pchValue, (uint)pchValue.Capacity);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetSecondsSinceAppActive(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetSecondsSinceComputerActive(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate EUniverse NativeGetConnectedUniverse(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetServerRealTime(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetIpCountry(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetImageSizeIuu(IntPtr thisptr, int iImage, ref uint pnWidth, ref uint pnHeight);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetImageRgbaibi(IntPtr thisptr, int iImage, byte[] pubDest, int nDestBufferSize);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetCseripPortUu(IntPtr thisptr, ref uint unIp, ref ushort usPort);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate byte NativeGetCurrentBatteryPower(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetAppId(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetOverlayNotificationPositionE(
            IntPtr thisptr, ENotificationPosition eNotificationPosition);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeIsApiCallCompletedUb(IntPtr thisptr, ulong hSteamApiCall, ref bool pbFailed);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ESteamApiCallFailure NativeGetApiCallFailureReasonU(IntPtr thisptr, ulong hSteamApiCall);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetApiCallResultUbiib(
            IntPtr thisptr, ulong hSteamApiCall, byte[] pCallback, int cubCallback, int iCallbackExpected,
            ref bool pbFailed);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeRunFrame(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetIpcCallCount(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetWarningMessageHookI(IntPtr thisptr, ref IntPtr pFunction);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeIsOverlayEnabled(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeBOverlayNeedsPresent(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeCheckFileSignatureS(IntPtr thisptr, string szFileName);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeShowGamepadTextInputEesu(
            IntPtr thisptr, EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eInputLineMode, string szText,
            uint uMaxLength);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate uint NativeGetEnteredGamepadTextLength(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetEnteredGamepadTextInputSu(
            IntPtr thisptr, StringBuilder pchValue, uint cchValueMax);
    };
}