using Cronofy.Infrastructure.Persistence.Databases.Postgres;
using Cronofy.Infrastructure.Persistence.Read;
using Cronofy.Infrastructure.Persistence.Write;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Infrastructure.Persistence;

internal static class ServiceCollectionExtensions
{
    internal static void AddPersistence(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddPostgresDatabase<CronofyReadDbContext>(configuration);
        serviceCollection.AddPostgresDatabase<CronofyWriteDbContext>(configuration);
    }
}