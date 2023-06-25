namespace Cronofy.Domain.Repositories;

public interface IServiceAccountRepository
{
    Task AddAsync(ServiceAccount serviceAccount);
}