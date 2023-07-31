using Cronofy.Api.Authorization.Policies.ServiceAccounts;
using Microsoft.AspNetCore.Authorization;

namespace Cronofy.Api.Authorization;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomAuthorization(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddAuthorizationBuilder()
            .AddServiceAccountPolicies();

        return serviceCollection;
    }

    private static AuthorizationBuilder AddServiceAccountPolicies(this AuthorizationBuilder authorizationBuilder)
    {
        return authorizationBuilder.AddPolicy(AuthorizeServiceAccountPolicy.Name, AuthorizeServiceAccountPolicy.AuthorizationPolicy);
    }
}