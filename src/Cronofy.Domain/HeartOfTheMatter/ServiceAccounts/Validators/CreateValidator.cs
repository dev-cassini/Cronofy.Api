using Cronofy.Domain.Common.Validation;
using Cronofy.Domain.HeartOfTheMatter.ServiceAccounts.Rules;
using Cronofy.Domain.Repositories;

namespace Cronofy.Domain.HeartOfTheMatter.ServiceAccounts.Validators;

/// <summary>
/// Validator to be applied on creation of a <see cref="ServiceAccount"/>.
/// </summary>
public class CreateValidator : EntityValidator<ServiceAccount>
{
    private readonly IServiceAccountRepository _serviceAccountRepository;

    protected override IEnumerable<IRule<ServiceAccount>> Rules => new List<IRule<ServiceAccount>>
    {
        new DomainIsUnique(_serviceAccountRepository)
    };

    public CreateValidator(IServiceAccountRepository serviceAccountRepository)
    {
        _serviceAccountRepository = serviceAccountRepository;
    }
}