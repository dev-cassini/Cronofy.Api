using System.Net.Mail;
using Cronofy.Application.Queries.ServiceAccounts;
using Microsoft.Extensions.Options;

namespace Cronofy.Application.Clients;

using Application = Domain.Entities.Applications.Application;

public class EnterpriseConnectAccountClientFactory : IEnterpriseConnectAccountClientFactory
{
    private readonly Application _applicationConfiguration;
    private readonly IGetServiceAccountQuery _getServiceAccountQuery;

    public EnterpriseConnectAccountClientFactory(
        IGetServiceAccountQuery getServiceAccountQuery,
        IOptions<Application> applicationConfiguration)
    {
        _applicationConfiguration = applicationConfiguration.Value;
        _getServiceAccountQuery = getServiceAccountQuery;
    }

    public async Task<ICronofyEnterpriseConnectAccountClient> CreateAsync(string email)
    {
        var domain = new MailAddress(email).Host;
        var serviceAccount = await _getServiceAccountQuery.ExecuteAsync(domain);
        if (serviceAccount is null)
        {
            throw new ArgumentException("Domain {domain} is not associated with a service account.", domain);
        }

        return new CronofyEnterpriseConnectAccountClient(serviceAccount.AccessToken, _applicationConfiguration.SdkIdentifier);
    }
}