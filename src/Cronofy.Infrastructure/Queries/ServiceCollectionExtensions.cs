using Cronofy.Application.Queries.ServiceAccount;
using Cronofy.Infrastructure.Queries.ServiceAccount;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Infrastructure.Queries;

internal static class ServiceCollectionExtensions
{
    internal static void AddQueries(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IGetServiceAccountQuery, GetServiceAccountQuery>();
    }
}