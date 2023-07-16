using Cronofy.Domain.Common.Validation;
using Cronofy.Domain.Repositories;

namespace Cronofy.Domain.Entities.ServiceAccounts.Rules;

public class DomainIsUnique : IRule<ServiceAccount>
{
    private readonly IServiceAccountRepository _serviceAccountRepository;

    public DomainIsUnique(IServiceAccountRepository serviceAccountRepository)
    {
        _serviceAccountRepository = serviceAccountRepository;
    }

    /// <summary>
    /// If domain is unique i.e. service account with domain does not already exist then pass,
    /// else fail and throw.
    /// </summary>
    /// <param name="serviceAccount">Service account to which the check is applied.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <exception cref="NotImplementedException"></exception>
    public async Task CheckAsync(ServiceAccount serviceAccount, CancellationToken cancellationToken)
    {
        var serviceAccountExists = await _serviceAccountRepository.AnyAsync(serviceAccount.Domain, cancellationToken);
        if (serviceAccountExists)
        {
            throw new DomainIsNotUniqueException();
        }
    }
}

public class DomainIsNotUniqueException : BrokenRuleException
{
    public const string Key = "DomainIsNotUnique";
    public override BrokenRuleSummary BrokenRuleSummary { get; }

    public DomainIsNotUniqueException()
    {
        BrokenRuleSummary = new BrokenRuleSummary(
            Key,
            "A service account with the provided domain already exists.");
    }
}