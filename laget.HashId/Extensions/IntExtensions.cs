namespace laget.HashId.Extensions
{
    public static class IntExtensions
    {
        public static HashId ToHashId(this int id) => HashId.FromInt(id);

        public static HashId ToHashId(this int? id) => id.HasValue ? HashId.FromInt(id.Value) : null;
    }
}