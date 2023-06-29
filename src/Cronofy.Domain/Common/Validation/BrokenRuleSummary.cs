namespace Cronofy.Domain.Common.Validation;

/// <summary>
/// Summary of a <see cref="IRule{T}"/> check that failed.
/// </summary>
public class BrokenRuleSummary
{
    /// <summary>
    /// Descriptor of the broken <see cref="IRule{T}"/>.
    /// </summary>
    public string Key { get; }
    
    /// <summary>
    /// Why the <see cref="IRule{T}"/> failed.
    /// </summary>
    public string Reason { get; }

    public BrokenRuleSummary(string key, string reason)
    {
        Key = key;
        Reason = reason;
    }
}