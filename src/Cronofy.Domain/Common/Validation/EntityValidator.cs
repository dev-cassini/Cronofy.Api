namespace Cronofy.Domain.Common.Validation;

public abstract class EntityValidator<T> where T : Entity
{
    protected abstract IEnumerable<IRule<T>> Rules { get; }

    /// <summary>
    /// Apply each rule, aggregate any exceptions and throw, else pass.
    /// </summary>
    /// <param name="entity">Entity to which the <see cref="Rules"/> apply.</param>
    /// <exception cref="AggregatedBrokenRuleException">One or more <see cref="Rules"/> failed.</exception>
    public async Task ValidateAsync(T entity)
    {
        var aggregateException = new AggregatedBrokenRuleException();
        foreach (var rule in Rules)
        {
            try
            {
                await rule.CheckAsync(entity);
            }
            catch (BrokenRuleException e)
            {
                aggregateException.AddException(e);
            }
        }

        if (aggregateException.Exceptions.Any())
        {
            throw aggregateException;
        }
    }
}