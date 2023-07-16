using Cronofy.Domain.Entities.ServiceAccounts;
using Cronofy.Domain.Repositories;
using Microsoft.AspNetCore.DataProtection;
using Moq;

namespace Cronofy.Domain.Tests.Entities.ServiceAccounts;

public static class ServiceAccountBuilder
{
    public static async Task<ServiceAccount> BuildAsync(CancellationToken cancellationToken = default)
    {
        const string refreshToken = "test_refresh_token";
        var dataProtectionProvider = new Mock<IDataProtectionProvider>().Setup(refreshToken);
        
        return await ServiceAccount.CreateAsync(
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            "test_access_token",
            refreshToken,
            dataProtectionProvider.Object,
            Mock.Of<IServiceAccountRepository>(),
            cancellationToken);
    }
}