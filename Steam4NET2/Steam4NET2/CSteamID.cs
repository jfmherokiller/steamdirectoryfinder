using System;

namespace Steam4Net
{
    public class CSteamId
    {
        private readonly InteropHelp.BitVector64 _steamid;

        public CSteamId()
            : this(0)
        {
        }

        public CSteamId(uint unAccountId, EUniverse eUniverse, EAccountType eAccountType)
            : this()
        {
            Set(unAccountId, eUniverse, eAccountType);
        }

        public CSteamId(uint unAccountId, uint unInstance, EUniverse eUniverse, EAccountType eAccountType)
            : this()
        {
            InstancedSet(unAccountId, unInstance, eUniverse, eAccountType);
        }

        public CSteamId(ulong id)
        {
            _steamid = new InteropHelp.BitVector64(id);
        }

        public CSteamId(SteamIdT sid)
            : this(
                sid.low32Bits, sid.high32Bits & 0xFFFFF, (EUniverse)(sid.high32Bits >> 24),
                (EAccountType)((sid.high32Bits >> 20) & 0xF))
        {
        }

        public uint AccountId
        {
            get { return (uint)_steamid[0, 0xFFFFFFFF]; }
            set { _steamid[0, 0xFFFFFFFF] = value; }
        }

        public uint AccountInstance
        {
            get { return (uint)_steamid[32, 0xFFFFF]; }
            set { _steamid[32, 0xFFFFF] = value; }
        }

        public EAccountType AccountType
        {
            get { return (EAccountType)_steamid[52, 0xF]; }
            set { _steamid[52, 0xF] = (ulong)value; }
        }

        public EUniverse AccountUniverse
        {
            get { return (EUniverse)_steamid[56, 0xFF]; }
            set { _steamid[56, 0xFF] = (ulong)value; }
        }

        public static implicit operator ulong(CSteamId sid)
        {
            return sid._steamid.Data;
        }

        public static implicit operator CSteamId(ulong id)
        {
            return new CSteamId(id);
        }

        public static implicit operator CSteamId(SteamIdT sid)
        {
            return new CSteamId(sid);
        }

        public void Set(uint unAccountId, EUniverse eUniverse, EAccountType eAccountType)
        {
            AccountId = unAccountId;
            AccountUniverse = eUniverse;
            AccountType = eAccountType;

            if (eAccountType == EAccountType.KeAccountTypeClan)
            {
                AccountInstance = 0;
            }
            else
            {
                AccountInstance = 1;
            }
        }

        public void InstancedSet(uint unAccountId, uint unInstance, EUniverse eUniverse, EAccountType eAccountType)
        {
            AccountId = unAccountId;
            AccountUniverse = eUniverse;
            AccountType = eAccountType;
            AccountInstance = unInstance;
        }

        public void SetFromUint64(ulong ulSteamId)
        {
            _steamid.Data = ulSteamId;
        }

        public ulong ConvertToUint64()
        {
            return _steamid.Data;
        }

        public bool BBlankAnonAccount()
        {
            return AccountId == 0 && BAnonAccount() && AccountInstance == 0;
        }

        public bool BGameServerAccount()
        {
            return AccountType == EAccountType.KeAccountTypeGameServer ||
                   AccountType == EAccountType.KeAccountTypeAnonGameServer;
        }

        public bool BContentServerAccount()
        {
            return AccountType == EAccountType.KeAccountTypeContentServer;
        }

        public bool BClanAccount()
        {
            return AccountType == EAccountType.KeAccountTypeClan;
        }

        public bool BChatAccount()
        {
            return AccountType == EAccountType.KeAccountTypeChat;
        }

        public bool IsLobby()
        {
            return (AccountType == EAccountType.KeAccountTypeChat) && ((AccountInstance & (0x000FFFFF + 1) >> 2) != 0);
        }

        public bool BAnonAccount()
        {
            return AccountType == EAccountType.KeAccountTypeAnonUser ||
                   AccountType == EAccountType.KeAccountTypeAnonGameServer;
        }

        public bool BAnonUserAccount()
        {
            return AccountType == EAccountType.KeAccountTypeAnonUser;
        }

        public bool IsValid()
        {
            if (AccountType <= EAccountType.KeAccountTypeInvalid || AccountType >= EAccountType.KeAccountTypeMax)
                return false;

            if (AccountUniverse <= EUniverse.KeUniverseInvalid || AccountUniverse >= EUniverse.KeUniverseMax)
                return false;

            if (AccountType == EAccountType.KeAccountTypeIndividual)
            {
                if (AccountId == 0 || AccountInstance != 1)
                    return false;
            }

            if (AccountType == EAccountType.KeAccountTypeClan)
            {
                if (AccountId == 0 || AccountInstance != 0)
                    return false;
            }

            return true;
        }

        public string Render()
        {
            switch (AccountType)
            {
                case EAccountType.KeAccountTypeInvalid:
                case EAccountType.KeAccountTypeIndividual:
                    if (AccountUniverse <= EUniverse.KeUniversePublic)
                        return string.Format("STEAM_0:{0}:{1}", AccountId & 1, AccountId >> 1);
                    return string.Format("STEAM_{2}:{0}:{1}", AccountId & 1, AccountId >> 1, (int)AccountUniverse);

                default:
                    return Convert.ToString(this);
            }
        }

        public override string ToString()
        {
            return Render();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var sid = obj as CSteamId;
            if ((object)sid == null)
                return false;

            return _steamid.Data == sid._steamid.Data;
        }

        public bool Equals(CSteamId sid)
        {
            if ((object)sid == null)
                return false;

            return _steamid.Data == sid._steamid.Data;
        }

        public static bool operator ==(CSteamId a, CSteamId b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (((object)a == null) || ((object)b == null))
                return false;

            return a._steamid.Data == b._steamid.Data;
        }

        public static bool operator !=(CSteamId a, CSteamId b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return _steamid.Data.GetHashCode();
        }
    }
}