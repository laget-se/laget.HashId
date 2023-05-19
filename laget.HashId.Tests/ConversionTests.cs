using laget.HashId.Tests.Abstractions;
using Xunit;

namespace laget.HashId.Tests
{
    public class ConversionTests : TestBase
    {
        [Fact]
        public void ShouldBeConvertedToInt()
        {
            const int hashId = 1;
            var hash = HashId.FromInt(hashId);

            Assert.Equal(1, hash.ToInt());
        }

        [Fact]
        public void ShouldBeConvertedToLong()
        {
            const int hashId = 1;
            var hash = HashId.FromInt(hashId);

            Assert.Equal(1, hash.ToLong());
        }
    }
}
