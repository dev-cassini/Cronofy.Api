using Cronofy.Domain.Entities.ServiceAccounts;
using Cronofy.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;

namespace Cronofy.Application.Commands.ServiceAccounts;

using Application = Domain.Entities.Applications.Application;

public class AuthorizeServiceAccountCommandHandler : IRequestHandler<AuthorizeServiceAccountCommand, Unit>
{
    private readonly IDataProtectionProvider _dataProtectionProvider;
    private readonly IServiceAccountRepository _serviceAccountRepository;
    private readonly Application _applicationConfiguration;

    public AuthorizeServiceAccountCommandHandler(
        IOptions<Application> applicationConfiguration,
        IDataProtectionProvider dataProtectionProvider,
        IServiceAccountRepository serviceAccountRepository)
    {
        _dataProtectionProvider = dataProtectionProvider;
        _serviceAccountRepository = serviceAccountRepository;
        _applicationConfiguration = applicationConfiguration.Value;
    }
    
    public async Task<Unit> Handle(AuthorizeServiceAccountCommand request, CancellationToken cancellationToken)
    {
        var cronofyOAuthClient = new CronofyOAuthClient(
            _applicationConfiguration.ClientId,
            _applicationConfiguration.ClientSecret,
            _applicationConfiguration.SdkIdentifier);

        var oauthToken = cronofyOAuthClient.GetTokenFromCode(request.Code, "https://auth0react.vercel.app/cronofy");
        var serviceAccount = await ServiceAccount.CreateAsync(
            oauthToken.Sub, 
            Guid.NewGuid().ToString(), 
            oauthToken.AccessToken, 
            oauthToken.RefreshToken,
            _dataProtectionProvider,
            _serviceAccountRepository,
            cancellationToken);

        await _serviceAccountRepository.AddAsync(serviceAccount, cancellationToken);
        await _serviceAccountRepository.SaveChangesAsync(cancellationToken);

        return new Unit();
    }
}