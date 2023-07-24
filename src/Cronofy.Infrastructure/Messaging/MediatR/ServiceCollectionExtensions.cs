using Cronofy.Application;
using Cronofy.Infrastructure.Messaging.MediatR.PipelineBehaviours;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Infrastructure.Messaging.MediatR;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddMediatR(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblyContaining<ApplicationMarker>();
            configuration.AddOpenBehavior(typeof(TransactionPipelineBehaviour<,>));
        });
        
        return serviceCollection;
    }
}