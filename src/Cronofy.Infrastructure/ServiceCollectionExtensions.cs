using Cronofy.Infrastructure.DataProtection;
using Cronofy.Infrastructure.Messaging.MassTransit;
using Cronofy.Infrastructure.Messaging.MediatR;
using Cronofy.Infrastructure.Persistence;
using Cronofy.Infrastructure.Persistence.Write;
using Cronofy.Infrastructure.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(
        this IServiceCollection serviceCollection, 
        IConfiguration configuration)
    {
        serviceCollection
            .AddPersistence(configuration)
            .AddRepositories()
            .AddQueries()
            .AddMediatR()
            .AddMassTransit<CronofyWriteDbContext>(configuration)
            .AddCustomDataProtection();
    }
}