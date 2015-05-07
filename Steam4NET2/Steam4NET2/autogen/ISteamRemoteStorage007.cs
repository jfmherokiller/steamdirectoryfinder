// This file is automatically generated.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamRemoteStorage007VTable
    {
        public IntPtr FileWrite0;
        public IntPtr FileRead1;
        public IntPtr FileForget2;
        public IntPtr FileDelete3;
        public IntPtr FileShare4;
        public IntPtr SetSyncPlatforms5;
        public IntPtr FileExists6;
        public IntPtr FilePersisted7;
        public IntPtr GetFileSize8;
        public IntPtr GetFileTimestamp9;
        public IntPtr GetSyncPlatforms10;
        public IntPtr GetFileCount11;
        public IntPtr GetFileNameAndSize12;
        public IntPtr GetQuota13;
        public IntPtr IsCloudEnabledForAccount14;
        public IntPtr IsCloudEnabledForApp15;
        public IntPtr SetCloudEnabledForApp16;
        public IntPtr UGCDownload17;
        public IntPtr GetUGCDownloadProgress18;
        public IntPtr GetUGCDetails19;
        public IntPtr UGCRead20;
        public IntPtr GetCachedUGCCount21;
        public IntPtr GetCachedUGCHandle22;
        public IntPtr PublishWorkshopFile23;
        public IntPtr CreatePublishedFileUpdateRequest24;
        public IntPtr UpdatePublishedFileFile25;
        public IntPtr UpdatePublishedFilePreviewFile26;
        public IntPtr UpdatePublishedFileTitle27;
        public IntPtr UpdatePublishedFileDescription28;
        public IntPtr UpdatePublishedFileVisibility29;
        public IntPtr UpdatePublishedFileTags30;
        public IntPtr CommitPublishedFileUpdate31;
        public IntPtr GetPublishedFileDetails32;
        public IntPtr DeletePublishedFile33;
        public IntPtr EnumerateUserPublishedFiles34;
        public IntPtr SubscribePublishedFile35;
        public IntPtr EnumerateUserSubscribedFiles36;
        public IntPtr UnsubscribePublishedFile37;
        public IntPtr UpdatePublishedFileSetChangeDescription38;
        public IntPtr GetPublishedItemVoteDetails39;
        public IntPtr UpdateUserPublishedItemVote40;
        public IntPtr GetUserPublishedItemVoteDetails41;
        public IntPtr EnumerateUserSharedWorkshopFiles42;
        public IntPtr PublishVideo43;
        public IntPtr SetUserPublishedFileAction44;
        public IntPtr EnumeratePublishedFilesByUserAction45;
        public IntPtr EnumeratePublishedWorkshopFiles46;
        private IntPtr DTorISteamRemoteStorage00747;
    };

    [InteropHelp.InterfaceVersionAttribute("STEAMREMOTESTORAGE_INTERFACE_VERSION007")]
    public class SteamRemoteStorage007 : InteropHelp.NativeWrapper<SteamRemoteStorage007VTable>
    {
        public bool FileWrite(string pchFile, byte[] pvData)
        {
            return GetFunction<NativeFileWriteSbi>(Functions.FileWrite0)(ObjectAddress, pchFile, pvData, pvData.Length);
        }

        public int FileRead(string pchFile, byte[] pvData)
        {
            return GetFunction<NativeFileReadSbi>(Functions.FileRead1)(ObjectAddress, pchFile, pvData, pvData.Length);
        }

        public bool FileForget(string pchFile)
        {
            return GetFunction<NativeFileForgetS>(Functions.FileForget2)(ObjectAddress, pchFile);
        }

        public bool FileDelete(string pchFile)
        {
            return GetFunction<NativeFileDeleteS>(Functions.FileDelete3)(ObjectAddress, pchFile);
        }

        public ulong FileShare(string pchFile)
        {
            return GetFunction<NativeFileShareS>(Functions.FileShare4)(ObjectAddress, pchFile);
        }

        public bool SetSyncPlatforms(string pchFile, ERemoteStoragePlatform eRemoteStoragePlatform)
        {
            return GetFunction<NativeSetSyncPlatformsSe>(Functions.SetSyncPlatforms5)(ObjectAddress, pchFile,
                eRemoteStoragePlatform);
        }

        public bool FileExists(string pchFile)
        {
            return GetFunction<NativeFileExistsS>(Functions.FileExists6)(ObjectAddress, pchFile);
        }

        public bool FilePersisted(string pchFile)
        {
            return GetFunction<NativeFilePersistedS>(Functions.FilePersisted7)(ObjectAddress, pchFile);
        }

        public int GetFileSize(string pchFile)
        {
            return GetFunction<NativeGetFileSizeS>(Functions.GetFileSize8)(ObjectAddress, pchFile);
        }

        public long GetFileTimestamp(string pchFile)
        {
            return GetFunction<NativeGetFileTimestampS>(Functions.GetFileTimestamp9)(ObjectAddress, pchFile);
        }

        public ERemoteStoragePlatform GetSyncPlatforms(string pchFile)
        {
            return GetFunction<NativeGetSyncPlatformsS>(Functions.GetSyncPlatforms10)(ObjectAddress, pchFile);
        }

        public int GetFileCount()
        {
            return GetFunction<NativeGetFileCount>(Functions.GetFileCount11)(ObjectAddress);
        }

        public string GetFileNameAndSize(int iFile, ref int pnFileSizeInBytes)
        {
            return
                InteropHelp.DecodeAnsiReturn(
                    Marshal.PtrToStringAnsi(
                        GetFunction<NativeGetFileNameAndSizeIi>(Functions.GetFileNameAndSize12)(ObjectAddress, iFile,
                            ref pnFileSizeInBytes)));
        }

        public bool GetQuota(ref int pnTotalBytes, ref int puAvailableBytes)
        {
            return GetFunction<NativeGetQuotaIi>(Functions.GetQuota13)(ObjectAddress, ref pnTotalBytes,
                ref puAvailableBytes);
        }

        public bool IsCloudEnabledForAccount()
        {
            return GetFunction<NativeIsCloudEnabledForAccount>(Functions.IsCloudEnabledForAccount14)(ObjectAddress);
        }

        public bool IsCloudEnabledForApp()
        {
            return GetFunction<NativeIsCloudEnabledForApp>(Functions.IsCloudEnabledForApp15)(ObjectAddress);
        }

        public void SetCloudEnabledForApp(bool bEnabled)
        {
            GetFunction<NativeSetCloudEnabledForAppB>(Functions.SetCloudEnabledForApp16)(ObjectAddress, bEnabled);
        }

        public ulong UgcDownload(ulong hContent)
        {
            return GetFunction<NativeUgcDownloadU>(Functions.UGCDownload17)(ObjectAddress, hContent);
        }

        public bool GetUgcDownloadProgress(ulong hContent, ref uint puDownloadedBytes, ref uint puTotalBytes)
        {
            return GetFunction<NativeGetUgcDownloadProgressUuu>(Functions.GetUGCDownloadProgress18)(ObjectAddress,
                hContent, ref puDownloadedBytes, ref puTotalBytes);
        }

        public bool GetUgcDetails(ulong hContent, ref uint pnAppId, StringBuilder ppchName, ref int pnFileSizeInBytes,
            ref CSteamId pSteamIdOwner)
        {
            ulong s0 = 0;
            var result = GetFunction<NativeGetUgcDetailsUusic>(Functions.GetUGCDetails19)(ObjectAddress, hContent,
                ref pnAppId, ppchName, ref pnFileSizeInBytes, ref s0);
            pSteamIdOwner = new CSteamId(s0);
            return result;
        }

        public int UgcRead(ulong hContent, byte[] pvData)
        {
            return GetFunction<NativeUgcReadUbi>(Functions.UGCRead20)(ObjectAddress, hContent, pvData, pvData.Length);
        }

        public int GetCachedUgcCount()
        {
            return GetFunction<NativeGetCachedUgcCount>(Functions.GetCachedUGCCount21)(ObjectAddress);
        }

        public ulong GetCachedUgcHandle(int iCachedContent)
        {
            return GetFunction<NativeGetCachedUgcHandleI>(Functions.GetCachedUGCHandle22)(ObjectAddress, iCachedContent);
        }

        public ulong PublishWorkshopFile(string pchFile, string pchPreviewFile, uint nConsumerAppId, string pchTitle,
            string pchDescription, ERemoteStoragePublishedFileVisibility eVisibility, ref SteamParamStringArrayT pTags,
            EWorkshopFileType eWorkshopFileType)
        {
            return GetFunction<NativePublishWorkshopFileSsussese>(Functions.PublishWorkshopFile23)(ObjectAddress,
                pchFile, pchPreviewFile, nConsumerAppId, pchTitle, pchDescription, eVisibility, ref pTags,
                eWorkshopFileType);
        }

        public ulong CreatePublishedFileUpdateRequest(ulong unPublishedFileId)
        {
            return
                GetFunction<NativeCreatePublishedFileUpdateRequestU>(Functions.CreatePublishedFileUpdateRequest24)(
                    ObjectAddress, unPublishedFileId);
        }

        public bool UpdatePublishedFileFile(ulong hUpdateRequest, string pchFile)
        {
            return GetFunction<NativeUpdatePublishedFileFileUs>(Functions.UpdatePublishedFileFile25)(ObjectAddress,
                hUpdateRequest, pchFile);
        }

        public bool UpdatePublishedFilePreviewFile(ulong hUpdateRequest, string pchPreviewFile)
        {
            return
                GetFunction<NativeUpdatePublishedFilePreviewFileUs>(Functions.UpdatePublishedFilePreviewFile26)(
                    ObjectAddress, hUpdateRequest, pchPreviewFile);
        }

        public bool UpdatePublishedFileTitle(ulong hUpdateRequest, string pchTitle)
        {
            return GetFunction<NativeUpdatePublishedFileTitleUs>(Functions.UpdatePublishedFileTitle27)(ObjectAddress,
                hUpdateRequest, pchTitle);
        }

        public bool UpdatePublishedFileDescription(ulong hUpdateRequest, string pchDescription)
        {
            return
                GetFunction<NativeUpdatePublishedFileDescriptionUs>(Functions.UpdatePublishedFileDescription28)(
                    ObjectAddress, hUpdateRequest, pchDescription);
        }

        public bool UpdatePublishedFileVisibility(ulong hUpdateRequest,
            ERemoteStoragePublishedFileVisibility eVisibility)
        {
            return
                GetFunction<NativeUpdatePublishedFileVisibilityUe>(Functions.UpdatePublishedFileVisibility29)(
                    ObjectAddress, hUpdateRequest, eVisibility);
        }

        public bool UpdatePublishedFileTags(ulong hUpdateRequest, ref SteamParamStringArrayT pTags)
        {
            return GetFunction<NativeUpdatePublishedFileTagsUs>(Functions.UpdatePublishedFileTags30)(ObjectAddress,
                hUpdateRequest, ref pTags);
        }

        public ulong CommitPublishedFileUpdate(ulong hUpdateRequest)
        {
            return GetFunction<NativeCommitPublishedFileUpdateU>(Functions.CommitPublishedFileUpdate31)(ObjectAddress,
                hUpdateRequest);
        }

        public ulong GetPublishedFileDetails(ulong unPublishedFileId)
        {
            return GetFunction<NativeGetPublishedFileDetailsU>(Functions.GetPublishedFileDetails32)(ObjectAddress,
                unPublishedFileId);
        }

        public ulong DeletePublishedFile(ulong unPublishedFileId)
        {
            return GetFunction<NativeDeletePublishedFileU>(Functions.DeletePublishedFile33)(ObjectAddress,
                unPublishedFileId);
        }

        public ulong EnumerateUserPublishedFiles(uint uStartIndex)
        {
            return
                GetFunction<NativeEnumerateUserPublishedFilesU>(Functions.EnumerateUserPublishedFiles34)(ObjectAddress,
                    uStartIndex);
        }

        public ulong SubscribePublishedFile(ulong unPublishedFileId)
        {
            return GetFunction<NativeSubscribePublishedFileU>(Functions.SubscribePublishedFile35)(ObjectAddress,
                unPublishedFileId);
        }

        public ulong EnumerateUserSubscribedFiles(uint uStartIndex)
        {
            return
                GetFunction<NativeEnumerateUserSubscribedFilesU>(Functions.EnumerateUserSubscribedFiles36)(
                    ObjectAddress, uStartIndex);
        }

        public ulong UnsubscribePublishedFile(ulong unPublishedFileId)
        {
            return GetFunction<NativeUnsubscribePublishedFileU>(Functions.UnsubscribePublishedFile37)(ObjectAddress,
                unPublishedFileId);
        }

        public bool UpdatePublishedFileSetChangeDescription(ulong hUpdateRequest, string cszDescription)
        {
            return
                GetFunction<NativeUpdatePublishedFileSetChangeDescriptionUs>(
                    Functions.UpdatePublishedFileSetChangeDescription38)(ObjectAddress, hUpdateRequest, cszDescription);
        }

        public ulong GetPublishedItemVoteDetails(ulong unPublishedFileId)
        {
            return
                GetFunction<NativeGetPublishedItemVoteDetailsU>(Functions.GetPublishedItemVoteDetails39)(ObjectAddress,
                    unPublishedFileId);
        }

        public ulong UpdateUserPublishedItemVote(ulong unPublishedFileId, bool bVoteUp)
        {
            return
                GetFunction<NativeUpdateUserPublishedItemVoteUb>(Functions.UpdateUserPublishedItemVote40)(
                    ObjectAddress, unPublishedFileId, bVoteUp);
        }

        public ulong GetUserPublishedItemVoteDetails(ulong unPublishedFileId)
        {
            return
                GetFunction<NativeGetUserPublishedItemVoteDetailsU>(Functions.GetUserPublishedItemVoteDetails41)(
                    ObjectAddress, unPublishedFileId);
        }

        public ulong EnumerateUserSharedWorkshopFiles(uint nAppId, CSteamId creatorSteamId, uint uStartIndex,
            ref SteamParamStringArrayT pRequiredTags, ref SteamParamStringArrayT pExcludedTags)
        {
            return
                GetFunction<NativeEnumerateUserSharedWorkshopFilesUcuss>(Functions.EnumerateUserSharedWorkshopFiles42)(
                    ObjectAddress, nAppId, creatorSteamId.ConvertToUint64(), uStartIndex, ref pRequiredTags,
                    ref pExcludedTags);
        }

        public ulong PublishVideo(EWorkshopVideoProvider eVideoProvider, string cszVideoAccountName,
            string cszVideoIdentifier, string cszFileName, uint nConsumerAppId, string cszTitle, string cszDescription,
            ERemoteStoragePublishedFileVisibility eVisibility, ref SteamParamStringArrayT pTags)
        {
            return GetFunction<NativePublishVideoEsssusses>(Functions.PublishVideo43)(ObjectAddress, eVideoProvider,
                cszVideoAccountName, cszVideoIdentifier, cszFileName, nConsumerAppId, cszTitle, cszDescription,
                eVisibility, ref pTags);
        }

        public ulong SetUserPublishedFileAction(ulong unPublishedFileId, EWorkshopFileAction eAction)
        {
            return GetFunction<NativeSetUserPublishedFileActionUe>(Functions.SetUserPublishedFileAction44)(
                ObjectAddress, unPublishedFileId, eAction);
        }

        public ulong EnumeratePublishedFilesByUserAction(EWorkshopFileAction eAction, uint uStartIndex)
        {
            return
                GetFunction<NativeEnumeratePublishedFilesByUserActionEu>(Functions.EnumeratePublishedFilesByUserAction45)
                    (ObjectAddress, eAction, uStartIndex);
        }

        public ulong EnumeratePublishedWorkshopFiles(EWorkshopEnumerationType eType, uint uStartIndex, uint cDays,
            uint cCount, ref SteamParamStringArrayT pTags, ref SteamParamStringArrayT pUserTags)
        {
            return
                GetFunction<NativeEnumeratePublishedWorkshopFilesEuuuss>(Functions.EnumeratePublishedWorkshopFiles46)(
                    ObjectAddress, eType, uStartIndex, cDays, cCount, ref pTags, ref pUserTags);
        }

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeFileWriteSbi(IntPtr thisptr, string pchFile, byte[] pvData, int cubData);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeFileReadSbi(IntPtr thisptr, string pchFile, byte[] pvData, int cubDataToRead);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeFileForgetS(IntPtr thisptr, string pchFile);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeFileDeleteS(IntPtr thisptr, string pchFile);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeFileShareS(IntPtr thisptr, string pchFile);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetSyncPlatformsSe(
            IntPtr thisptr, string pchFile, ERemoteStoragePlatform eRemoteStoragePlatform);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeFileExistsS(IntPtr thisptr, string pchFile);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeFilePersistedS(IntPtr thisptr, string pchFile);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetFileSizeS(IntPtr thisptr, string pchFile);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate long NativeGetFileTimestampS(IntPtr thisptr, string pchFile);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ERemoteStoragePlatform NativeGetSyncPlatformsS(IntPtr thisptr, string pchFile);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetFileCount(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetFileNameAndSizeIi(IntPtr thisptr, int iFile, ref int pnFileSizeInBytes);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetQuotaIi(IntPtr thisptr, ref int pnTotalBytes, ref int puAvailableBytes);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeIsCloudEnabledForAccount(IntPtr thisptr);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeIsCloudEnabledForApp(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetCloudEnabledForAppB(IntPtr thisptr, [MarshalAs(UnmanagedType.I1)] bool bEnabled);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeUgcDownloadU(IntPtr thisptr, ulong hContent);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetUgcDownloadProgressUuu(
            IntPtr thisptr, ulong hContent, ref uint puDownloadedBytes, ref uint puTotalBytes);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetUgcDetailsUusic(
            IntPtr thisptr, ulong hContent, ref uint pnAppId, StringBuilder ppchName, ref int pnFileSizeInBytes,
            ref ulong pSteamIdOwner);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeUgcReadUbi(IntPtr thisptr, ulong hContent, byte[] pvData, int cubDataToRead);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetCachedUgcCount(IntPtr thisptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeGetCachedUgcHandleI(IntPtr thisptr, int iCachedContent);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativePublishWorkshopFileSsussese(
            IntPtr thisptr, string pchFile, string pchPreviewFile, uint nConsumerAppId, string pchTitle,
            string pchDescription, ERemoteStoragePublishedFileVisibility eVisibility, ref SteamParamStringArrayT pTags,
            EWorkshopFileType eWorkshopFileType);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeCreatePublishedFileUpdateRequestU(IntPtr thisptr, ulong unPublishedFileId);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeUpdatePublishedFileFileUs(IntPtr thisptr, ulong hUpdateRequest, string pchFile);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeUpdatePublishedFilePreviewFileUs(
            IntPtr thisptr, ulong hUpdateRequest, string pchPreviewFile);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeUpdatePublishedFileTitleUs(IntPtr thisptr, ulong hUpdateRequest, string pchTitle);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeUpdatePublishedFileDescriptionUs(
            IntPtr thisptr, ulong hUpdateRequest, string pchDescription);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeUpdatePublishedFileVisibilityUe(
            IntPtr thisptr, ulong hUpdateRequest, ERemoteStoragePublishedFileVisibility eVisibility);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeUpdatePublishedFileTagsUs(
            IntPtr thisptr, ulong hUpdateRequest, ref SteamParamStringArrayT pTags);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeCommitPublishedFileUpdateU(IntPtr thisptr, ulong hUpdateRequest);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeGetPublishedFileDetailsU(IntPtr thisptr, ulong unPublishedFileId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeDeletePublishedFileU(IntPtr thisptr, ulong unPublishedFileId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeEnumerateUserPublishedFilesU(IntPtr thisptr, uint uStartIndex);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeSubscribePublishedFileU(IntPtr thisptr, ulong unPublishedFileId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeEnumerateUserSubscribedFilesU(IntPtr thisptr, uint uStartIndex);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeUnsubscribePublishedFileU(IntPtr thisptr, ulong unPublishedFileId);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeUpdatePublishedFileSetChangeDescriptionUs(
            IntPtr thisptr, ulong hUpdateRequest, string cszDescription);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeGetPublishedItemVoteDetailsU(IntPtr thisptr, ulong unPublishedFileId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeUpdateUserPublishedItemVoteUb(
            IntPtr thisptr, ulong unPublishedFileId, [MarshalAs(UnmanagedType.I1)] bool bVoteUp);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeGetUserPublishedItemVoteDetailsU(IntPtr thisptr, ulong unPublishedFileId);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeEnumerateUserSharedWorkshopFilesUcuss(
            IntPtr thisptr, uint nAppId, ulong creatorSteamId, uint uStartIndex,
            ref SteamParamStringArrayT pRequiredTags, ref SteamParamStringArrayT pExcludedTags);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativePublishVideoEsssusses(
            IntPtr thisptr, EWorkshopVideoProvider eVideoProvider, string cszVideoAccountName, string cszVideoIdentifier,
            string cszFileName, uint nConsumerAppId, string cszTitle, string cszDescription,
            ERemoteStoragePublishedFileVisibility eVisibility, ref SteamParamStringArrayT pTags);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeSetUserPublishedFileActionUe(
            IntPtr thisptr, ulong unPublishedFileId, EWorkshopFileAction eAction);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeEnumeratePublishedFilesByUserActionEu(
            IntPtr thisptr, EWorkshopFileAction eAction, uint uStartIndex);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ulong NativeEnumeratePublishedWorkshopFilesEuuuss(
            IntPtr thisptr, EWorkshopEnumerationType eType, uint uStartIndex, uint cDays, uint cCount,
            ref SteamParamStringArrayT pTags, ref SteamParamStringArrayT pUserTags);
    };
}