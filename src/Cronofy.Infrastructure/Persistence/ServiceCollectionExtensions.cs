using Cronofy.Domain.Repositories;
using Cronofy.Infrastructure.Persistence.Databases.Postgres;
using Cronofy.Infrastructure.Persistence.Read;
using Cronofy.Infrastructure.Persistence.Write;
using Cronofy.Infrastructure.Persistence.Write.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Infrastructure.Persistence;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPersistence(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddPostgresDatabase<CronofyReadDbContext>(configuration);
        serviceCollection.AddPostgresDatabase<CronofyWriteDbContext>(configuration);

        return serviceCollection;
    }

    internal static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IServiceAccountRepository, ServiceAccountRepository>();
        
        return serviceCollection;
    }
}