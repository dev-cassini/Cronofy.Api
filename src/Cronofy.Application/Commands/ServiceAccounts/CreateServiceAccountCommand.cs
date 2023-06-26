using Cronofy.Domain;
using MediatR;

namespace Cronofy.Application.Commands.ServiceAccounts;

public class CreateServiceAccountCommand : IRequest
{
    /// <inheritdoc cref="ServiceAccount.Id"/>
    public string Id { get; }
    
    /// <inheritdoc cref="ServiceAccount.Domain"/>
    public string Domain { get; }
    
    /// <inheritdoc cref="ServiceAccount.AccessToken"/>
    public string AccessToken { get; }
    
    /// <summary>
    /// Plaintext value of <see cref="ServiceAccount.ProtectedRefreshToken"/>.
    /// </summary>
    public string RefreshToken { get; }

    public CreateServiceAccountCommand(
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