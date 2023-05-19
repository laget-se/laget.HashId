using laget.HashId.Util;
using System.Collections.Generic;

namespace laget.HashId.Tests.Abstractions
{
    public abstract class TestBase
    {
        protected const string HashVersion0X = "0x";
        protected const string Version0XSalt = "0xSalt";
        protected const string HashVersion1X = "1x";
        protected const string Version1XSalt = "1xSalt";
        protected const string HashVersion2X = "2x";

        protected readonly IHashIdFactory HashIdFactory;

        protected TestBase()
        {
            var options = new HashIdFactoryOptions
            {
                DefaultHashVersion = HashVersion0X,
                SaltVersions = new Dictionary<string, string>
                {
                    { HashVersion0X, Version0XSalt },
                    { HashVersion1X, Version1XSalt }
                }
            };
            HashIdFactory = new HashIdFactory(options);
            HashId.SetHashIdFactory(HashIdFactory);
        }
    }
}
