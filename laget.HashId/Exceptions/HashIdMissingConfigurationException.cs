namespace laget.HashId.Exceptions
{
    public class HashIdMissingConfigurationException : Exception
    {
        public HashIdMissingConfigurationException()
            : base("Failed to load configuration for HashIds\n Make sure your config contains a section named 'HashIds' that contains all necessary configuration for using hashed ids")
        {
        }
    }
}