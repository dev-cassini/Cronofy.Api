using Cronofy.Domain.Common.Validation;
using Cronofy.Domain.Repositories;
using Cronofy.Domain.Rules;

namespace Cronofy.Domain.Validators;

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