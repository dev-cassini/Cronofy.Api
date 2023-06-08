namespace Cronofy.Domain;

public class AuthorizedAccount
{
    public string Sub { get; } = null!;
    public string ProfileId { get; } = null!;
    public string EmailAddress { get; } = null!;
    public string AccessToken { get; } = null!;
    public string RefreshToken { get; } = null!;
    public DateTimeOffset AccessTokenExpiryDateTimeUtc { get; }
    public string ServiceAccountId { get; } = null!;
    public ServiceAccount ServiceAccount { get; } = null!;

    public AuthorizedAccount(
        string sub, 
        string profileId, 
        string emailAddress, 
        string accessToken, 
        string refreshToken,
        DateTimeOffset accessTokenExpiryDateTimeUtc,
        ServiceAccount serviceAccount)
    {
        Sub = sub;
        ProfileId = profileId;
        EmailAddress = emailAddress;
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        AccessTokenExpiryDateTimeUtc = accessTokenExpiryDateTimeUtc;
        ServiceAccountId = serviceAccount.Id;
        ServiceAccount = serviceAccount;
    }
    
    #region EF Constructor
    // ReSharper disable once UnusedMember.Local
    private AuthorizedAccount() { }
    #endregion
}