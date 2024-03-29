using Cronofy.Application.Queries.ServiceAccounts;
using Cronofy.Infrastructure.Queries.ServiceAccounts;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Infrastructure.Queries;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddQueries(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IGetServiceAccountQuery, GetServiceAccountQuery>();
        
        return serviceCollection;
    }
}