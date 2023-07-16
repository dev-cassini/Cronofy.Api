using Cronofy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cronofy.Infrastructure.Persistence.Write.Tables;

public class AuthorizedAccountConfiguration : IEntityTypeConfiguration<AuthorizedAccount>
{
    public void Configure(EntityTypeBuilder<AuthorizedAccount> builder)
    {
        builder.ToTable(nameof(CronofyWriteDbContext.AuthorizedAccounts));
        
        builder.HasKey(x => x.Sub);
        builder.Property(x => x.ProfileId);
        builder.Property(x => x.EmailAddress);
        builder.Property(x => x.AccessToken);
        builder.Property(x => x.RefreshToken);
        builder.Property(x => x.AccessTokenExpiryDateTimeUtc);
        builder.Property(x => x.ServiceAccountId);
        builder.HasOne(x => x.ServiceAccount);
    }
}