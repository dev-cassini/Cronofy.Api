using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Domain;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDataProtection();

        return serviceCollection;
    }
}