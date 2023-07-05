using Cronofy.Domain.HeartOfTheMatter.ServiceAccounts;
using Cronofy.Infrastructure.Messaging.MassTransit;
using Cronofy.Infrastructure.Messaging.MediatR;
using Cronofy.Infrastructure.Persistence.Write.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cronofy.Infrastructure.Persistence.Write;

public class CronofyWriteDbContext : DbContext
{
    private readonly IMediator _mediator;
    
    public DbSet<ServiceAccount> ServiceAccounts { get; set; } = null!;
    public DbSet<ServiceAccount> AuthorizedAccounts { get; set; } = null!;

    public CronofyWriteDbContext(
        DbContextOptions<CronofyWriteDbContext> options,
        IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ServiceAccountConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorizedAccountConfiguration());
        
        modelBuilder.ConfigureMassTransitEntityFrameworkOutbox();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync(this);
        return await base.SaveChangesAsync(cancellationToken);
    }
}