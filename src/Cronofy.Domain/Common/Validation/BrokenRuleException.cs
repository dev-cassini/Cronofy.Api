namespace Cronofy.Domain.Common.Validation;

/// <summary>
/// Abstraction of an exception thrown when a specific business rule check fails.
/// </summary>
public abstract class BrokenRuleException : Exception
{
    public abstract BrokenRuleSummary BrokenRuleSummary { get; }

    public override string ToString()
    {
        return $"{BrokenRuleSummary.Key}: {BrokenRuleSummary.Reason}";
    }
}