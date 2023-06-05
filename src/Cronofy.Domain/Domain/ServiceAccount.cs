namespace Cronofy.Domain;

public class ServiceAccount
{
    public string Id { get; }
    public string Domain { get; }
    public string AccessToken { get; }
    public string RefreshToken { get; }


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
}