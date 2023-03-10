using laget.HashId.Exceptions;
using laget.HashId.Serialization;
using laget.HashId.Util;
using Newtonsoft.Json;

namespace laget.HashId
{
    [JsonConverter(typeof(HashIdConverter))]
    public class HashId
    {
        #region HashIdFactory
        private static IHashIdFactory? _hashIdFactory;
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
        public static HashId FromLong(long id) => new(HashIdFactory.GetHash(id));
        public static HashId FromInt(int id) => new(HashIdFactory.GetHash(id));
        public static HashId FromString(string hash) => new(hash);


        #region Overrides & Operators
        public override bool Equals(object? obj) => obj is HashId other && Hash.Equals(other.Hash);

        public override int GetHashCode() => Hash.GetHashCode();

        public override string ToString() => Hash;

        public static bool operator ==(HashId left, HashId right) => left.Equals(right);

        public static bool operator !=(HashId left, HashId right) => !(left == right);
        #endregion
    }
}