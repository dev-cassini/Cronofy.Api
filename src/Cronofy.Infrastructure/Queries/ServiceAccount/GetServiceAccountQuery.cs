using Cronofy.Application.Queries.ServiceAccount;
using Cronofy.Infrastructure.Persistence.Read;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace Cronofy.Infrastructure.Queries.ServiceAccount;

using ServiceAccount = Domain.ServiceAccount;

public class GetServiceAccountQuery : IGetServiceAccountQuery
{
    private readonly CronofyReadDbContext _dbContext;
    private readonly IDataProtector _dataProtector;

    public GetServiceAccountQuery(
        CronofyReadDbContext dbContext, 
        IDataProtectionProvider dataProtectionProvider)
    {
        _dbContext = dbContext;
        _dataProtector = dataProtectionProvider.CreateProtector(nameof(ServiceAccount.ProtectedRefreshToken));
    }
    
    public async Task<ServiceAccountDto?> ExecuteAsync(string domain)
    {
        return await _dbContext.ServiceAccountsView
            .Where(x => x.Domain.ToLower() == domain.ToLower())
            .Select(x => new ServiceAccountDto(
                x.Id,
                x.Domain,
                x.AccessToken,
                _dataProtector.Unprotect(x.ProtectedRefreshToken)))
            .SingleOrDefaultAsync();
    }
}