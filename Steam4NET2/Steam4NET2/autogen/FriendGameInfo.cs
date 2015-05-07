// This file is automatically generated.

using System.Runtime.InteropServices;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct FriendGameInfoT
    {
        public GameIdT m_gameID;
        public uint m_unGameIP;
        public ushort m_usGamePort;
        public ushort m_usQueryPort;
        public SteamIdT m_steamIDLobby;
    };
}