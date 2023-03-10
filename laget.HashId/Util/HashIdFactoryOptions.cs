namespace laget.HashId.Util
{
    public class HashIdFactoryOptions
    {
        public string DefaultHashVersion { get; set; } = "a0";
        public Dictionary<string, string> SaltVersions { get; set; }
    }
}