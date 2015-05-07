using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct GameIdT
    {
        [FieldOffset(0)]
        // /!\ C# doesn't support bit fields, use this field like this: m_nAppID & 0xFFFFFF
        public uint m_nAppID; // : 24

        [FieldOffset(3)]
        public uint m_nType; // : 8

        [FieldOffset(4)]
        public uint m_nModID; // : 32
    }
}