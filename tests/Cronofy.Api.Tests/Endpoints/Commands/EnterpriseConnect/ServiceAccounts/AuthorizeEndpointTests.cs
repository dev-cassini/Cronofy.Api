using System.Reflection;
using Cronofy.Api.Authorization;
using Cronofy.Api.Authorization.Policies.ServiceAccounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Api.Tests.Endpoints.Commands.EnterpriseConnect.ServiceAccounts;

[TestFixture]
public class AuthorizeEndpointTests
{
    [Test]
    public void AuthorizeServiceAccountPolicyIsAppliedToEndpoint()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddControllers().AddApplicationPart(Assembly.GetAssembly(typeof(Program))!);
        serviceCollection.AddLogging();
        serviceCollection.AddCustomAuthorization();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var apiDescriptionGroupCollectionProvider = serviceProvider.GetRequiredService<IApiDescriptionGroupCollectionProvider>();
        var apiDescription = apiDescriptionGroupCollectionProvider
            .ApiDescriptionGroups
            .Items.Single()
            .Items.Single(x => x.HttpMethod == HttpMethods.Post && x.RelativePath == "");

        var authorizeAttribute = apiDescription.ActionDescriptor.EndpointMetadata.OfType<AuthorizeAttribute>().Single();
        
        Assert.That(authorizeAttribute.Policy, Is.EqualTo(AuthorizeServiceAccountPolicy.Name));
    }
}