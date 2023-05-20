namespace laget.HashId.Extensions
{
    public static class StringExtensions
    {
        public static HashId ToHashId(this string id) => HashId.FromString(id);
    }
}
