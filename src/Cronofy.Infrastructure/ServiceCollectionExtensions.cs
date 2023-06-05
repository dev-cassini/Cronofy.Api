using Cronofy.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(
        this IServiceCollection serviceCollection, 
        IConfiguration configuration)
    {
        serviceCollection.AddPersistence(configuration);
    }
}