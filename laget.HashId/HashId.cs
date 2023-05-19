using laget.HashId.Exceptions;
using laget.HashId.Util;

namespace laget.HashId
{
    [Newtonsoft.Json.JsonConverter(typeof(Serialization.Newtonsoft.Json.HashIdConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(Serialization.System.Text.Json.HashIdConverter))]
    public class HashId
    {
        #region HashIdFactory
        private static IHashIdFactory _hashIdFactory;
        public static void SetHashIdFactory(IHashIdFactory factory) => _hashIdFactory = factory;

        private static IHashIdFactory HashIdFactory
        {
            get
            {
                if (_hashIdFactory == null)
                    throw new HashIdNotRegisteredException();
                return _hashIdFactory;
            }
        }
        #endregion

        public string Hash { get; }

        private HashId(string hash)
        {
            Hash = hash;
        }

        public long ToLong() => HashIdFactory.GetId(Hash);
        public int ToInt() => (int)HashIdFactory.GetId(Hash);
        public static HashId FromLong(long id) => new HashId(HashIdFactory.GetHash(id));
        public static HashId FromInt(int id) => new HashId(HashIdFactory.GetHash(id));
        public static HashId FromString(string hash) => new HashId(hash);


        #region Overrides & Operators
        public override bool Equals(object obj)
        {
            if (!(obj is HashId))
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            var rhs = (HashId)obj;

            return Hash.Equals(rhs.Hash);
        }

        public override int GetHashCode() => Hash.GetHashCode();

        public override string ToString() => Hash;

        public static bool operator ==(HashId lhs, HashId rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return ReferenceEquals(rhs, null);
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(HashId lhs, HashId rhs)
        {
            return !(lhs == rhs);
        }
        #endregion
    }
}