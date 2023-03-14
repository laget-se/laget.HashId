using laget.HashId.Exceptions;
using laget.HashId.Util;
using Newtonsoft.Json;
using Xunit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace laget.HashId.Tests
{
    public class HashIdTest
    {
        private const string HashVersion0X = "0x";
        private const string Version0XSalt = "0xSalt";
        private const string HashVersion1X = "1x";
        private const string Version1XSalt = "1xSalt";
        private const string HashVersion2X = "2x";

        private readonly IHashIdFactory _hashIdFactory;

        public HashIdTest()
        {
            var options = new HashIdFactoryOptions
            {
                DefaultHashVersion = HashVersion0X,
                SaltVersions = new()
                {
                    { HashVersion0X, Version0XSalt },
                    { HashVersion1X, Version1XSalt }
                }
            };
            _hashIdFactory = new HashIdFactory(options);
            HashId.SetHashIdFactory(_hashIdFactory);
        }

        [Fact]
        public void ThrowsErrorOnUnknownHashVersion()
        {
            var hashId = HashId.FromString($"{HashVersion2X}bogusHash");
            Assert.Throws<HashIdInvalidVersionException>(() =>
            {
                var id = hashId.ToLong();
            });
        }

        [Fact]
        public void ThrowsErrorIfNotRegistered()
        {
            HashId.SetHashIdFactory(null);

            Assert.Throws<HashIdNotRegisteredException>(() => HashId.FromLong(1));

            HashId.SetHashIdFactory(_hashIdFactory);
        }

        [Fact]
        public void IsProperlySerializedWithNewtonsoft()
        {
            const long id = 1234;
            var dto = new Dto { Id = HashId.FromLong(id) };

            var expectedJson = $"{{\"Id\":\"{dto.Id.Hash}\"}}";
            var json = JsonConvert.SerializeObject(dto);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void IsProperlyDeserializedWithNewtonsoft()
        {
            const long id = 1234;
            var dto = new Dto { Id = HashId.FromLong(id) };
            var json = JsonConvert.SerializeObject(dto);

            var deserializedDto = JsonConvert.DeserializeObject<Dto>(json);

            Assert.Equal(dto.Id, deserializedDto.Id);
        }

        [Fact]
        public void NumericIdIsProperlyExtracedFromHashWithNewtonsoft()
        {
            const long id = 1234;
            var dto = new Dto { Id = HashId.FromLong(id) };
            var json = JsonConvert.SerializeObject(dto);

            var deserializedDto = JsonConvert.DeserializeObject<Dto>(json);
            var deserializedId = deserializedDto.Id.ToLong();

            Assert.Equal(id, deserializedId);
        }

        [Fact]
        public void NumericIdIntIsProperlyExtracedFromHashWithNewtonsoft()
        {
            const int id = 1234;
            var dto = new Dto { Id = HashId.FromInt(id) };
            var json = JsonConvert.SerializeObject(dto);

            var deserializedDto = JsonConvert.DeserializeObject<Dto>(json);
            var deserializedId = deserializedDto.Id.ToInt();

            Assert.Equal(id, deserializedId);
        }

        [Fact]
        public void IsProperlySerializedWithSystemText()
        {
            const long id = 1234;
            var dto = new Dto { Id = HashId.FromLong(id) };

            var expectedJson = $"{{\"Id\":\"{dto.Id.Hash}\"}}";
            var json = JsonSerializer.Serialize(dto);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void IsProperlyDeserializedWithSystemText()
        {
            const long id = 1234;
            var dto = new Dto { Id = HashId.FromLong(id) };
            var json = JsonSerializer.Serialize(dto);

            var deserializedDto = JsonSerializer.Deserialize<Dto>(json);

            Assert.Equal(dto.Id, deserializedDto.Id);
        }

        [Fact]
        public void NumericIdIsProperlyExtracedFromHashWithSystemText()
        {
            const long id = 1234;
            var dto = new Dto { Id = HashId.FromLong(id) };
            var json = JsonSerializer.Serialize(dto);

            var deserializedDto = JsonSerializer.Deserialize<Dto>(json);
            var deserializedId = deserializedDto.Id.ToLong();

            Assert.Equal(id, deserializedId);
        }

        [Fact]
        public void NumericIdIntIsProperlyExtracedFromHashWithSystemText()
        {
            const int id = 1234;
            var dto = new Dto { Id = HashId.FromInt(id) };
            var json = JsonSerializer.Serialize(dto);

            var deserializedDto = JsonSerializer.Deserialize<Dto>(json);
            var deserializedId = deserializedDto.Id.ToInt();

            Assert.Equal(id, deserializedId);
        }

        public class Dto
        {
            public HashId Id { get; set; }
        }
    }
}