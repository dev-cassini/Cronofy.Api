using Microsoft.AspNetCore.DataProtection;

namespace Cronofy.Domain;

public class ServiceAccount
{
    public string Id { get; } = null!;
    public string Domain { get; } = null!;
    public string AccessToken { get; } = null!;
    public string ProtectedRefreshToken { get; } = null!;


    public ServiceAccount(
        string id,
        string domain,
        string accessToken, 
        string refreshToken,
        IDataProtectionProvider dataProtectionProvider)
    {
        Id = id;
        Domain = domain;
        AccessToken = accessToken;
        
        var protector = dataProtectionProvider.CreateProtector(nameof(ProtectedRefreshToken));
        ProtectedRefreshToken = protector.Protect(refreshToken);
    }
    
    #region EF Constructor
    // ReSharper disable once UnusedMember.Local
    private ServiceAccount() { }
    #endregion
}