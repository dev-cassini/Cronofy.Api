using System.Security.Claims;
using Cronofy.Api.Authorization.Policies.ServiceAccounts;
using Cronofy.Api.Authorization.Scopes;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Api.Tests.Authorization.Policies.ServiceAccounts;

[TestFixture]
public class AuthorizeServiceAccountPolicyTests
{
    [Test]
    public async Task ClaimsPrincipalWithNoScopes_FailsAuthorization()
    {
        // Arrange
        var authorizationService = BuildAuthorizationService();
        var claimsPrincipal = new ClaimsPrincipal();
        
        // Act
        var authorize = await authorizationService.AuthorizeAsync(claimsPrincipal, AuthorizeServiceAccountPolicy.Name);
        
        // Assert
        Assert.That(authorize.Succeeded, Is.False);
    }
    
    [Test]
    public async Task ClaimsPrincipalWithServiceAccountWriteScope_PassesAuthorization()
    {
        // Arrange
        var authorizationService = BuildAuthorizationService();
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new[]
            { new Claim(JwtClaimTypes.Scope, Scopes.ServiceAccount.Write) }));
        
        // Act
        var authorize = await authorizationService.AuthorizeAsync(claimsPrincipal, AuthorizeServiceAccountPolicy.Name);
        
        // Assert
        Assert.That(authorize.Succeeded, Is.True);
    }

    private static IAuthorizationService BuildAuthorizationService()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging();
        serviceCollection.AddAuthorization(options => options.AddPolicy(AuthorizeServiceAccountPolicy.Name, AuthorizeServiceAccountPolicy.AuthorizationPolicy));

        return serviceCollection
            .BuildServiceProvider()
            .GetRequiredService<IAuthorizationService>();
    }
}