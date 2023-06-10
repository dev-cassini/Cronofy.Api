using Cronofy.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cronofy.Application.Clients;

using Application = Domain.Application;

internal static class ServiceCollectionExtensions
{
    internal static void AddCronofyClients(
        this IServiceCollection serviceCollection,
        Action<Application> configureApplication)
    {
        serviceCollection.Configure(configureApplication);
        serviceCollection.AddScoped<ICronofyOAuthClient, CronofyOAuthClient>(provider =>
        {
            var application = provider.GetRequiredService<IOptions<Application>>().Value;
            
            return new CronofyOAuthClient(
                application.ClientId,
                application.ClientSecret,
                application.DataCenter.ToSdkIdentifier());
        });
    }
}