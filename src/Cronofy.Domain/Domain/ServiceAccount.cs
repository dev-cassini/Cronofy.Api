namespace Cronofy.Domain;

public class ServiceAccount
{
    public string Id { get; } = null!;
    public string Domain { get; } = null!;
    public string AccessToken { get; } = null!;
    public string RefreshToken { get; } = null!;


    public ServiceAccount(
        string id,
        string domain,
        string accessToken, 
        string refreshToken)
    {
        Id = id;
        Domain = domain;
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
    
    #region EF Constructor
    // ReSharper disable once UnusedMember.Local
    private ServiceAccount() { }
    #endregion
}