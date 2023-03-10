using Autofac;
using laget.HashId.Exceptions;
using laget.HashId.Util;
using Microsoft.Extensions.Configuration;

namespace laget.HashId.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterHashId(this ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.RegisterBuildCallback(c =>
            {
                var configuration = c.Resolve<IConfiguration>();
                var options = configuration.GetSection("HashIds").Get<HashIdFactoryOptions>();
                if (options == null)
                    throw new HashIdMissingConfigurationException();

                HashId.SetHashIdFactory(new HashIdFactory(options));
            });
        }
    }
}