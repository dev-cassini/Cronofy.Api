using Cronofy.Domain.Common.Validation;
using Cronofy.Domain.Repositories;

namespace Cronofy.Domain.Rules;

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
    /// <exception cref="NotImplementedException"></exception>
    public async Task CheckAsync(ServiceAccount serviceAccount)
    {
        var serviceAccountExists = await _serviceAccountRepository.AnyAsync(serviceAccount.Domain);
        if (!serviceAccountExists)
        {
            throw new DomainIsNotUnique();
        }
    }
}

public class DomainIsNotUnique : BrokenRuleException
{
    public const string Key = "DomainIsNotUnique";
    public override BrokenRuleSummary BrokenRuleSummary { get; }

    public DomainIsNotUnique()
    {
        BrokenRuleSummary = new BrokenRuleSummary(
            Key,
            "A service account with the provided domain already exists.");
    }
}