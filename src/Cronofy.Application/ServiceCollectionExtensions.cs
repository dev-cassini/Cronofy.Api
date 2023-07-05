using Cronofy.Application.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Application;

using Application = Domain.HeartOfTheMatter.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection serviceCollection, 
        Action<Application> configureApplication)
    {
        serviceCollection.AddCronofyClients(configureApplication);

        return serviceCollection;
    }
}