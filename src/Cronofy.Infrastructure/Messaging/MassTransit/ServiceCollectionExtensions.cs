using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Infrastructure.Messaging.MassTransit;

internal static class ServiceCollectionExtensions
{
    internal static void AddMassTransit<TDbContext>(this IServiceCollection serviceCollection)
        where TDbContext : DbContext
    {
        serviceCollection.AddMassTransit(configurator =>
        {
            configurator.UsingRabbitMq((context, factoryConfigurator) =>
            {
                factoryConfigurator.Host("localhost", "/", hostConfigurator =>
                {
                    hostConfigurator.Username("guest");
                    hostConfigurator.Password("guest");
                });
                factoryConfigurator.ConfigureEndpoints(context);
            });
            
            configurator.AddEntityFrameworkOutbox<TDbContext>(outboxConfigurator =>
            {
                outboxConfigurator.UsePostgres();
                outboxConfigurator.UseBusOutbox();
            });
        });
    }

    internal static void ConfigureMassTransitEntityFrameworkOutbox(this ModelBuilder modelBuilder)
    {
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
    }
}