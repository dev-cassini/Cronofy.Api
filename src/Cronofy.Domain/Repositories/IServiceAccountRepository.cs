namespace Cronofy.Domain.Repositories;

public interface IServiceAccountRepository
{
    Task AddAsync(ServiceAccount serviceAccount, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}