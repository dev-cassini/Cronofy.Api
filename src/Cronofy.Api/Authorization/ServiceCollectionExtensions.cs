using Cronofy.Api.Authorization.Constants;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;

namespace Cronofy.Api.Authorization;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomAuthorization(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddAuthorizationBuilder()
            .AddServiceAccountWritePolicy();

        return serviceCollection;
    }

    private static AuthorizationBuilder AddServiceAccountWritePolicy(this AuthorizationBuilder authorizationBuilder)
    {
        return authorizationBuilder.AddPolicy(
            Policies.ServiceAccountWrite,
            policy => policy.RequireClaim(JwtClaimTypes.Scope, Scopes.ServiceAccountWrite));
    }
}