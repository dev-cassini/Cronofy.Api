using Cronofy.Domain.Common;
using Cronofy.Infrastructure.Persistence.Write;
using MediatR;

namespace Cronofy.Infrastructure.Messaging.MediatR;

internal static class MediatorExtensions
{
    internal static async Task DispatchDomainEventsAsync(
        this IMediator mediator, 
        CronofyWriteDbContext dbContext)
    {
        var entityEntries = dbContext.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents.Any()).ToList();

        foreach (var entityEntry in entityEntries)
        {
            foreach (var domainEvent in entityEntry.Entity.DomainEvents)
            {
                await mediator.Publish(domainEvent);
            }
            
            entityEntry.Entity.ClearDomainEvents();
        }
    }
}