using Cronofy.Domain;
using Cronofy.Infrastructure.Persistence.Read.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cronofy.Infrastructure.Persistence.Read.Tables;

public class ServiceAccountReadModelConfiguration : IEntityTypeConfiguration<ServiceAccountReadModel>
{
    public void Configure(EntityTypeBuilder<ServiceAccountReadModel> builder)
    {
        builder.ToTable(nameof(ServiceAccount));
        builder.HasKey(x => x.Id);
    }
}