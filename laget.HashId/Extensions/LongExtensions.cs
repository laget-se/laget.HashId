namespace laget.HashId.Extensions
{
    public static class LongExtensions
    {
        public static HashId ToHashId(this long id) => HashId.FromLong(id);

        public static HashId ToHashId(this long? id) => id.HasValue ? HashId.FromLong(id.Value) : null;
    }
}