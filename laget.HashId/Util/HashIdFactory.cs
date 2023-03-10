using HashidsNet;
using laget.HashId.Exceptions;

namespace laget.HashId.Util
{
    public interface IHashIdFactory
    {
        string GetHash(long id);
        long GetId(string hash);
    }

    public class HashIdFactory : IHashIdFactory
    {
        private const int HashLength = 13;

        private readonly Dictionary<string, Hashids> _hashers = new();
        private readonly string _defaultHashVersion;

        public HashIdFactory(HashIdFactoryOptions options)
        {
            _defaultHashVersion = options.DefaultHashVersion;
            foreach (var saltVersions in options.SaltVersions)
            {
                _hashers.Add(saltVersions.Key, new Hashids(saltVersions.Value, HashLength));
            }
        }

        public string GetHash(long id)
        {
            if (!_hashers.TryGetValue(_defaultHashVersion, out var hasher))
                throw new HashIdInvalidVersionException(_defaultHashVersion);

            return $"{_defaultHashVersion}{hasher.EncodeLong(id)}";
        }

        public long GetId(string hash)
        {
            var versionString = hash.Substring(0, 2);
            if (!_hashers.TryGetValue(versionString, out var hasher))
                throw new HashIdInvalidVersionException(versionString);

            var hashString = hash.Substring(2);
            return hasher.DecodeSingleLong(hashString);
        }
    }
}