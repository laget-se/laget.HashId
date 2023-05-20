using laget.HashId.Tests.Abstractions;
using Xunit;

namespace laget.HashId.Tests
{
    public class ConversionTests : TestBase
    {
        [Fact]
        public void ShouldBeCastToInt()
        {
            const int hashId = 1;
            var hash = HashId.FromInt(hashId);
            var model = new IntModel { Value = (int)hash };

            Assert.Equal(1, hash.ToInt());
            Assert.Equal(1, (int)hash);
            Assert.Equal(1, model.Value);
        }

        [Fact]
        public void ShouldBeCastToLong()
        {
            const int hashId = 1;
            var hash = HashId.FromInt(hashId);
            var model = new LongModel { Value = (long)hash };

            Assert.Equal(1, hash.ToLong());
            Assert.Equal(1, (long)hash);
            Assert.Equal(1, model.Value);
        }

        [Fact]
        public void ShouldBeCastToString()
        {
            const int hashId = 1;
            var hash = HashId.FromInt(hashId);
            var model = new StringModel { Value = (string)hash };

            Assert.Equal("0xR4reL0zL3Xgq8", hash.ToString());
            Assert.Equal("0xR4reL0zL3Xgq8", (string)hash);
            Assert.Equal("0xR4reL0zL3Xgq8", model.Value);
        }

        internal class IntModel
        {
            public int Value { get; set; }
        }

        internal class LongModel
        {
            public long Value { get; set; }
        }

        internal class StringModel
        {
            public string Value { get; set; }
        }
    }
}
