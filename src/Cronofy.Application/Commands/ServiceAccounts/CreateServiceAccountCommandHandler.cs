using Cronofy.Domain;
using Cronofy.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.DataProtection;

namespace Cronofy.Application.Commands.ServiceAccounts;

public class CreateServiceAccountCommandHandler : IRequestHandler<CreateServiceAccountCommand>
{
    private readonly IServiceAccountRepository _serviceAccountRepository;
    private readonly IDataProtectionProvider _dataProtectionProvider;

    public CreateServiceAccountCommandHandler(
        IServiceAccountRepository serviceAccountRepository,
        IDataProtectionProvider dataProtectionProvider)
    {
        _serviceAccountRepository = serviceAccountRepository;
        _dataProtectionProvider = dataProtectionProvider;
    }
    
    public async Task Handle(CreateServiceAccountCommand request, CancellationToken cancellationToken)
    {
        var serviceAccount = new ServiceAccount(
            request.Id, 
            request.Domain, 
            request.AccessToken, 
            request.RefreshToken,
            _dataProtectionProvider);

        await _serviceAccountRepository.AddAsync(serviceAccount, cancellationToken);
        await _serviceAccountRepository.SaveChangesAsync(cancellationToken);
    }
}