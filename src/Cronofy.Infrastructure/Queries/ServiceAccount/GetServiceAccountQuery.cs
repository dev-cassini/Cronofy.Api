using Cronofy.Application.Queries.ServiceAccount;
using Cronofy.Infrastructure.Persistence.Read;
using Microsoft.EntityFrameworkCore;

namespace Cronofy.Infrastructure.Queries.ServiceAccount;

public class GetServiceAccountQuery : IGetServiceAccountQuery
{
    private readonly CronofyReadDbContext _dbContext;

    public GetServiceAccountQuery(CronofyReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ServiceAccountDto?> ExecuteAsync(string domain)
    {
        return await _dbContext.ServiceAccountsView
            .Where(x => x.Domain.ToLower() == domain.ToLower())
            .Select(x => new ServiceAccountDto(
                x.Id,
                x.Domain,
                x.AccessToken,
                x.RefreshToken))
            .SingleOrDefaultAsync();
    }
}