using Cronofy.Api.Endpoints.Commands.EnterpriseConnect.ServiceAccounts;

namespace Cronofy.Api.Endpoints;

public static class Configuration
{
    public static void RegisterEndpoints(this WebApplication webApplication)
    {
        webApplication.CreateServiceAccountEndpoint();
    }
}