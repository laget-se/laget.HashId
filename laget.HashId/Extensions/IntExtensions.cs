namespace laget.HashId.Extensions
{
    public static class IntExtensions
    {
        public static HashId ToHashId(this int id) => HashId.FromLong(id);
    }
}