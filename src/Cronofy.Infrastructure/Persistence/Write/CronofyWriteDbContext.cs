using Cronofy.Domain;
using Cronofy.Infrastructure.Persistence.Write.Tables;
using Microsoft.EntityFrameworkCore;

namespace Cronofy.Infrastructure.Persistence.Write;

public class CronofyWriteDbContext : DbContext
{
    public DbSet<ServiceAccount> ServiceAccounts { get; set; } = null!;
    public DbSet<ServiceAccount> AuthorizedAccounts { get; set; } = null!;

    public CronofyWriteDbContext(DbContextOptions<CronofyWriteDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ServiceAccountConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorizedAccountConfiguration());
    }
}