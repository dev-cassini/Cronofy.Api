using Cronofy.Domain;
using Cronofy.Domain.Repositories;

namespace Cronofy.Infrastructure.Persistence.Write.Repositories;

public class ServiceAccountRepository : IServiceAccountRepository
{
    private readonly CronofyWriteDbContext _dbContext;

    public ServiceAccountRepository(CronofyWriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(ServiceAccount serviceAccount)
    {
        await _dbContext.ServiceAccounts.AddAsync(serviceAccount);
    }
}