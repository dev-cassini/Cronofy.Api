using Cronofy.Api.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Api.Tests.Endpoints;

[TestFixture]
public class AuthorizationPolicyTests
{
    [Test]
    public async Task AllEndpointsAuthorizationPoliciesAreRegistered()
    {
        var serviceProvider = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(collection =>
                {
                    collection.AddLogging();
                    collection.AddCustomAuthorization();
                });
            }).Services;

        var authorizationPolicyCollectionProvider = serviceProvider.GetRequiredService<IAuthorizationPolicyProvider>();
        var actionDescriptorCollectionProvider = serviceProvider.GetRequiredService<IActionDescriptorCollectionProvider>();

        var test = serviceProvider.GetRequiredService<IEnumerable<IEndpointDescriptionMetadata>>();
        var endpoints = actionDescriptorCollectionProvider.ActionDescriptors.Items;
        foreach (var endpoint in endpoints)
        {
            var authorizeAttribute = endpoint.EndpointMetadata.OfType<AuthorizeAttribute>().SingleOrDefault();
            if (authorizeAttribute?.Policy is not null)
            {
                var policy = await authorizationPolicyCollectionProvider.GetPolicyAsync(authorizeAttribute.Policy);
                Assert.That(policy, Is.Not.Null, $"Policy {authorizeAttribute.Policy} assigned to endpoint {endpoint.DisplayName} but not registered at startup.");
            }
        }
    }
}