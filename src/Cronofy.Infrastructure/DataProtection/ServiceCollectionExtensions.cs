using Cronofy.Infrastructure.Persistence.Write;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Infrastructure.DataProtection;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddCustomDataProtection(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddDataProtection()
            .PersistKeysToDbContext<CronofyWriteDbContext>();

        return serviceCollection;
    }
}