using Cronofy.Domain;
using Cronofy.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cronofy.Infrastructure.Persistence.Write.Repositories;

public class ServiceAccountRepository : IServiceAccountRepository
{
    private readonly CronofyWriteDbContext _dbContext;

    public ServiceAccountRepository(CronofyWriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(ServiceAccount serviceAccount, CancellationToken cancellationToken = default)
    {
        await _dbContext.ServiceAccounts.AddAsync(serviceAccount, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(string domain, CancellationToken cancellationToken = default)
    {
        var serviceAccount = await _dbContext.ServiceAccounts
            .SingleOrDefaultAsync(x => x.Domain.Trim().ToLower() == x.Domain, cancellationToken);
        
        return serviceAccount is not null;
    }
}