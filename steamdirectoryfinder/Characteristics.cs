using System;

namespace steamdirectoryfinder
{
    [Flags]
    public enum Characteristics : ushort
    {
        ImageFileRelocsStripped = (ushort)1,
        ImageFileExecutableImage = (ushort)2,
        ImageFileLineNumsStripped = (ushort)4,
        ImageFileLocalSymsStripped = (ushort)8,
        ImageFileAggresiveWsTrim = (ushort)16,
        ImageFileLargeAddressAware = (ushort)32,
        ImageFileBytesReversedLo = (ushort)128,
        ImageFile32BitMachine = (ushort)256,
        ImageFileDebugStripped = (ushort)512,
        ImageFileRemovableRunFromSwap = (ushort)1024,
        ImageFileNetRunFromSwap = (ushort)2048,
        ImageFileSystem = (ushort)4096,
        ImageFileDll = (ushort)8192,
        ImageFileUpSystemOnly = (ushort)16384,
        ImageFileBytesReversedHi = (ushort)32768,
    }
}