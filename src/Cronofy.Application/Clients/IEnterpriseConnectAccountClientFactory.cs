namespace Cronofy.Application.Clients;

public interface IEnterpriseConnectAccountClientFactory
{
    Task<ICronofyEnterpriseConnectAccountClient> CreateAsync(string email);
}