using Cronofy.Domain.Entities.ServiceAccounts;
using Cronofy.Domain.Repositories;
using Microsoft.AspNetCore.DataProtection;
using Moq;

namespace Cronofy.Domain.Tests.Entities.ServiceAccounts;

public class ServiceAccountBuilder
{
    private string _domain = Guid.NewGuid().ToString();
    private string _refreshToken = Guid.NewGuid().ToString();
    private Mock<IDataProtector> _dataProtector = new();
    
    public async Task<ServiceAccount> BuildAsync(CancellationToken cancellationToken = default)
    {
        var dataProtectionProvider = new Mock<IDataProtectionProvider>()
             .Setup(_dataProtector, _refreshToken);
        
        return await ServiceAccount.CreateAsync(
            Guid.NewGuid().ToString(),
            _domain,
            "test_access_token",
            _refreshToken,
            dataProtectionProvider.Object,
            Mock.Of<IServiceAccountRepository>(),
            cancellationToken);
    }

    public ServiceAccountBuilder WithDomain(string domain)
    {
        _domain = domain;
        return this;
    }
    
    public ServiceAccountBuilder WithRefreshToken(string refreshToken)
    {
        _refreshToken = refreshToken;
        return this;
    }

    public ServiceAccountBuilder WithDataProtector(Mock<IDataProtector> dataProtector)
    {
        _dataProtector = dataProtector;
        return this;
    }
}