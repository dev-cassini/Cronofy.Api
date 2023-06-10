using Cronofy.Infrastructure.Persistence.Read.Models;
using Cronofy.Infrastructure.Persistence.Read.Tables;
using Microsoft.EntityFrameworkCore;

namespace Cronofy.Infrastructure.Persistence.Read;

public class CronofyReadDbContext : DbContext
{
    private DbSet<ServiceAccountReadModel> ServiceAccounts { get; set; } = null!;
    public IQueryable<ServiceAccountReadModel> ServiceAccountsView => ServiceAccounts.AsNoTracking();

    public CronofyReadDbContext(DbContextOptions<CronofyReadDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ServiceAccountReadModelConfiguration());
    }
}