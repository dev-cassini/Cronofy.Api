using Cronofy.Domain.Common;
using Cronofy.Domain.Events;
using Cronofy.Domain.Entities.ServiceAccounts.Validators;
using Cronofy.Domain.Repositories;
using Microsoft.AspNetCore.DataProtection;

namespace Cronofy.Domain.Entities.ServiceAccounts;

public class ServiceAccount : Entity
{
    public string Id { get; } = null!;
    public string Domain { get; } = null!;
    public string AccessToken { get; } = null!;
    public string ProtectedRefreshToken { get; } = null!;
    
    private ServiceAccount(
        string id,
        string domain,
        string accessToken, 
        string refreshToken,
        IDataProtectionProvider dataProtectionProvider)
    {
        Id = id;
        Domain = domain.Trim().ToLower();
        AccessToken = accessToken;

        var protector = dataProtectionProvider.CreateProtector(nameof(ProtectedRefreshToken));
        ProtectedRefreshToken = protector.Protect(refreshToken);
        
        AddDomainEvent(new ServiceAccountCreated(Id));
    }

    public static async Task<ServiceAccount> CreateAsync(
        string id,
        string domain,
        string accessToken, 
        string refreshToken,
        IDataProtectionProvider dataProtectionProvider,
        IServiceAccountRepository serviceAccountRepository,
        CancellationToken cancellationToken)
    {
        var serviceAccount = new ServiceAccount(
            id,
            domain,
            accessToken,
            refreshToken,
            dataProtectionProvider);

        await new CreateValidator(serviceAccountRepository).ValidateAsync(serviceAccount, cancellationToken);
        return serviceAccount;
    }

    #region EF Constructor
    // ReSharper disable once UnusedMember.Local
    private ServiceAccount() { }
    #endregion
}