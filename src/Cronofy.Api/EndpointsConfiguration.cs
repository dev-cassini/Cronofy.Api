using Cronofy.Api.Endpoints.Commands.EnterpriseConnect.ServiceAccounts;

namespace Cronofy.Api;

public static class EndpointsConfiguration
{
    public static void RegisterEndpoints(this WebApplication webApplication)
    {
        webApplication.CreateServiceAccountEndpoint();
    }
}