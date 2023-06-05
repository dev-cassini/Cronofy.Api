using Cronofy.Infrastructure.Persistence.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cronofy.Infrastructure.Persistence;

public static class ServiceProviderExtensions
{
    public static void MigrateDatabase(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<CronofyWriteDbContext>();
        dbContext.Database.Migrate();
    }
}