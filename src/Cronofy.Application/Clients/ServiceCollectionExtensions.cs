using Cronofy.Domain.Entities.Applications.Validators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cronofy.Application.Clients;

using Application = Domain.Entities.Applications.Application;

internal static class ServiceCollectionExtensions
{
    internal static void AddCronofyClients(
        this IServiceCollection serviceCollection,
        Action<Application> configureApplication)
    {
        serviceCollection.AddSingleton<IValidateOptions<Application>, ApplicationValidator>();
        serviceCollection
            .AddOptions<Application>()
            .Configure(configureApplication)
            .ValidateOnStart();
        
        serviceCollection.AddScoped<ICronofyOAuthClient, CronofyOAuthClient>(provider =>
        {
            var application = provider.GetRequiredService<IOptions<Application>>().Value;
            
            return new CronofyOAuthClient(
                application.ClientId,
                application.ClientSecret,
                application.SdkIdentifier);
        });

        serviceCollection.AddScoped<IEnterpriseConnectAccountClientFactory, EnterpriseConnectAccountClientFactory>();
    }
}