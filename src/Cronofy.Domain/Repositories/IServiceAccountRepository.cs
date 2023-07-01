namespace Cronofy.Domain.Repositories;

public interface IServiceAccountRepository
{
    Task AddAsync(ServiceAccount serviceAccount, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// If service account with the provided domain already exists then return true, else false.
    /// </summary>
    /// <param name="domain">Domain of service account to query for.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if service account exists, else false.</returns>
    Task<bool> AnyAsync(string domain, CancellationToken cancellationToken = default);
}