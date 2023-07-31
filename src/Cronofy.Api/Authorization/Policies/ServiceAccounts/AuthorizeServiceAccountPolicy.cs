using IdentityModel;
using Microsoft.AspNetCore.Authorization;

namespace Cronofy.Api.Authorization.Policies.ServiceAccounts;

using Scopes = Scopes.Scopes;

public static class AuthorizeServiceAccountPolicy
{
    public const string Name = "authorize-service-account-policy";

    public static AuthorizationPolicy AuthorizationPolicy => new AuthorizationPolicyBuilder()
        .RequireClaim(JwtClaimTypes.Scope, Scopes.ServiceAccount.Write)
        .Build();
}