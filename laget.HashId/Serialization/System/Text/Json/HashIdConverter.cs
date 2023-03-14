using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace laget.HashId.Serialization.System.Text.Json
{
    public class HashIdConverter : JsonConverter<HashId>
    {
        public override void Write(Utf8JsonWriter writer, HashId value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.Hash);

        public override HashId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException($"HashId deserializer encountered token {reader.TokenType}, expected String");

            var str = reader.GetString();
            if (str != null)
                return HashId.FromString(reader.GetString());

            throw new JsonException("Failed to read string from json, got null");
        }
    }
}