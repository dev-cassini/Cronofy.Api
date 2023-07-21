using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Infrastructure.Messaging.MassTransit;

internal static class ServiceCollectionExtensions
{
    internal static void AddMassTransit<TDbContext>(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
        where TDbContext : DbContext
    {
        serviceCollection.AddMassTransit(configurator =>
        {
            configurator.AddDelayedMessageScheduler();
            configurator.UsingRabbitMq((context, factoryConfigurator) =>
            {
                var rabbitMqConnectionString = configuration.GetConnectionString("RabbitMq")!;
                factoryConfigurator.Host(rabbitMqConnectionString);
                factoryConfigurator.UseDelayedMessageScheduler();
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