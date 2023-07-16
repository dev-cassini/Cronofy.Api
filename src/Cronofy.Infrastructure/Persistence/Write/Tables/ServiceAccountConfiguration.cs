using Cronofy.Domain.Entities.ServiceAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cronofy.Infrastructure.Persistence.Write.Tables;

public class ServiceAccountConfiguration : IEntityTypeConfiguration<ServiceAccount>
{
    public void Configure(EntityTypeBuilder<ServiceAccount> builder)
    {
        builder.ToTable(nameof(CronofyWriteDbContext.ServiceAccounts));
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Domain);
        builder.Property(x => x.AccessToken);
        builder.Property(x => x.ProtectedRefreshToken);
        builder.Ignore(x => x.DomainEvents);
    }
}