using Cronofy.Domain.Common.Validation;
using Cronofy.Domain.Entities.ServiceAccounts.Rules;
using Cronofy.Domain.Repositories;

namespace Cronofy.Domain.Entities.ServiceAccounts.Validators;

/// <summary>
/// Validator to be applied on creation of a <see cref="ServiceAccount"/>.
/// </summary>
internal class CreateValidator : EntityValidator<ServiceAccount>
{
    private readonly IServiceAccountRepository _serviceAccountRepository;

    internal override IEnumerable<IRule<ServiceAccount>> Rules => new List<IRule<ServiceAccount>>
    {
        new DomainIsUnique(_serviceAccountRepository)
    };

    internal CreateValidator(IServiceAccountRepository serviceAccountRepository)
    {
        _serviceAccountRepository = serviceAccountRepository;
    }
}