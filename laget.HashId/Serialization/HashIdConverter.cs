using Newtonsoft.Json;

namespace laget.HashId.Serialization
{
    public class HashIdConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is not HashId hashId)
            {
                serializer.Serialize(writer, null);
                return;
            }

            serializer.Serialize(writer, hashId.Hash);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
                throw new JsonException("");

            if (reader.Value is not string hash)
                throw new JsonException("");

            return HashId.FromString(hash);
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(HashId);
    }
}