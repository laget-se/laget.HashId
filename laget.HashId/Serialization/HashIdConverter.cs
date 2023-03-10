using Newtonsoft.Json;
using System;

namespace laget.HashId.Serialization
{
    public class HashIdConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is HashId hashId)
            {
                serializer.Serialize(writer, hashId.Hash);
                return;
            }

            serializer.Serialize(writer, null);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
                throw new JsonException("");

            if (reader.Value is string hash)
                return HashId.FromString(hash);

            throw new JsonException("");
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(HashId);
    }
}