namespace Cronofy.Domain.Common.Validation;

/// <summary>
/// A collection of <see cref="BrokenRuleException"/> thrown when the exceptions of multiple
/// rule checks applicable to an entity need to be aggregated.
/// </summary>
public class AggregatedBrokenRuleException : Exception
{
    private readonly List<BrokenRuleException> _exceptions = new();
    public IReadOnlyList<BrokenRuleException> Exceptions => _exceptions;

    public void AddException(BrokenRuleException exception)
    {
        _exceptions.Add(exception);
    }

    public override string Message => "The following rules failed validation: \r\n    - " +
                                      $"{string.Join("\r\n    - ", _exceptions)}";
}