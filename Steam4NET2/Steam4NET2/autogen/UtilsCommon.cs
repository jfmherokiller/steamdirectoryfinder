// This file is automatically generated.

using System.Runtime.InteropServices;

namespace Steam4Net
{
    public enum ESteamApiCallFailure
    {
        KeSteamApiCallFailureNone = -1,
        KeSteamApiCallFailureSteamGone = 0,
        KeSteamApiCallFailureNetworkFailure = 1,
        KeSteamApiCallFailureInvalidHandle = 2,
        KeSteamApiCallFailureMismatchedCallback = 3
    };

    public enum EConfigStore
    {
        KeConfigStoreInvalid = 0,
        KeConfigStoreInstall = 1,
        KeConfigStoreUserRoaming = 2,
        KeConfigStoreUserLocal = 3,
        KeConfigStoreMax = 4
    };

    public enum ECheckFileSignature
    {
        KeCheckFileSignatureInvalidSignature = 0,
        KeCheckFileSignatureValidSignature = 1,
        KeCheckFileSignatureFileNotFound = 2,
        KeCheckFileSignatureNoSignaturesFoundForThisApp = 3,
        KeCheckFileSignatureNoSignaturesFoundForThisFile = 4
    };

    public enum ESpewGroup
    {
        KeSpewGroupConsole = 0,
        KeSpewGroupPublish = 1,
        KeSpewGroupBootstrap = 2,
        KeSpewGroupStartup = 3,
        KeSpewGroupService = 4,
        KeSpewGroupFileop = 5,
        KeSpewGroupSystem = 6,
        KeSpewGroupSmtp = 7,
        KeSpewGroupAccount = 8,
        KeSpewGroupJob = 9,
        KeSpewGroupCrypto = 10,
        KeSpewGroupNetwork = 11,
        KeSpewGroupVac = 12,
        KeSpewGroupClient = 13,
        KeSpewGroupContent = 14,
        KeSpewGroupCloud = 15,
        KeSpewGroupLogon = 16,
        KeSpewGroupClping = 17,
        KeSpewGroupThreads = 18,
        KeSpewGroupBsnova = 19,
        KeSpewGroupTest = 20,
        KeSpewGroupFiletx = 21,
        KeSpewGroupStats = 22,
        KeSpewGroupSrvping = 23,
        KeSpewGroupFriends = 24,
        KeSpewGroupChat = 25,
        KeSpewGroupGuestpass = 26,
        KeSpewGroupLicense = 27,
        KeSpewGroupP2P = 28,
        KeSpewGroupDatacoll = 29,
        KeSpewGroupDrm = 30,
        KeSpewGroupSvcm = 31,
        KeSpewGroupHttpclient = 32,
        KeSpewGroupHttpserver = 33
    };

    public enum EuiMode
    {
        KEuiModeNormal = 0,
        KEuiModeTenFoot = 1
    };

    public enum EGamepadTextInputMode
    {
    };

    public enum EGamepadTextInputLineMode
    {
    };

    public enum EWindowType
    {
    };

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    [InteropHelp.CallbackIdentityAttribute(701)]
    public struct IpCountryT
    {
        public const int KiCallback = 701;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    [InteropHelp.CallbackIdentityAttribute(702)]
    public struct LowBatteryPowerT
    {
        public const int KiCallback = 702;
        public byte m_nMinutesBatteryLeft;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    [InteropHelp.CallbackIdentityAttribute(703)]
    public struct SteamApiCallCompletedT
    {
        public const int KiCallback = 703;
        public ulong m_hAsyncCall;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    [InteropHelp.CallbackIdentityAttribute(704)]
    public struct SteamShutdownT
    {
        public const int KiCallback = 704;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    [InteropHelp.CallbackIdentityAttribute(705)]
    public struct CheckFileSignatureT
    {
        public const int KiCallback = 705;
        public ECheckFileSignature m_eCheckFileSignature;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    [InteropHelp.CallbackIdentityAttribute(711)]
    public struct SteamConfigStoreChangedT
    {
        public const int KiCallback = 711;
        public EConfigStore m_eConfigStore;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string m_szRootOfChanges;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    [InteropHelp.CallbackIdentityAttribute(1603)]
    public struct CellIdChangedT
    {
        public const int KiCallback = 1603;
        public uint m_nCellID;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct CUtlBuffer
    {
        public int m_iPadding;
    };
}