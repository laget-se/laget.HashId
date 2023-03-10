namespace laget.HashId.Exceptions
{
    public class HashIdInvalidVersionException : Exception
    {
        public HashIdInvalidVersionException(string version)
            : base($"No hasher available for hash of version {version}")
        {
        }
    }
}