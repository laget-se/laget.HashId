namespace laget.HashId.Extensions
{
    public static class StringExtensions
    {
        public static HashId ToHashId(this string @string) => !string.IsNullOrWhiteSpace(@string) ? HashId.FromString(@string) : null;
    }
}
