using Cronofy.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Infrastructure.Messaging.MediatR;

internal static class ServiceCollectionExtensions
{
    internal static void AddMediatR(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblyContaining<ApplicationMarker>();
        });
    }
}