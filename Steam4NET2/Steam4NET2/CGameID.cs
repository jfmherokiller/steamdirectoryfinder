namespace Steam4Net
{
    public class CGameId
    {
        public enum EGameId
        {
            KeGameIdTypeApp = 0,
            KeGameIdTypeGameMod = 1,
            KeGameIdTypeShortcut = 2,
            KeGameIdTypeP2P = 3
        }

        private readonly InteropHelp.BitVector64 _gameid;

        public CGameId()
            : this((ulong)0)
        {
        }

        public CGameId(ulong id)
        {
            _gameid = new InteropHelp.BitVector64(id);
        }

        public CGameId(int nAppId)
            : this()
        {
        }

        public CGameId(GameIdT gid)
            : this()
        {
            AppId = gid.m_nAppID & 0xFFFFFF;
            AppType = (EGameId)gid.m_nType;
            ModId = gid.m_nModID;
        }

        public uint AppId
        {
            get { return (uint)_gameid[0, 0xFFFFFF]; }
            set { _gameid[0, 0xFFFFFF] = value; }
        }

        public EGameId AppType
        {
            get { return (EGameId)_gameid[24, 0xFF]; }
            set { _gameid[24, 0xFF] = (ulong)value; }
        }

        public uint ModId
        {
            get { return (uint)_gameid[32, 0xFFFFFFFF]; }
            set { _gameid[32, 0xFFFFFFFF] = value; }
        }

        public static implicit operator ulong(CGameId gid)
        {
            return gid._gameid.Data;
        }

        public static implicit operator CGameId(ulong id)
        {
            return new CGameId(id);
        }

        public static implicit operator CGameId(GameIdT gid)
        {
            return new CGameId(gid);
        }

        public ulong ConvertToUint64()
        {
            return _gameid.Data;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var gid = obj as CGameId;
            if ((object)gid == null)
                return false;

            return _gameid.Data == gid._gameid.Data;
        }

        public bool Equals(CGameId gid)
        {
            if ((object)gid == null)
                return false;

            return _gameid.Data == gid._gameid.Data;
        }

        public static bool operator ==(CGameId a, CGameId b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (((object)a == null) || ((object)b == null))
                return false;

            return a._gameid.Data == b._gameid.Data;
        }

        public static bool operator !=(CGameId a, CGameId b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return _gameid.GetHashCode();
        }
    }
}