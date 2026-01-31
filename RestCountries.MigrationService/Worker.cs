using Microsoft.EntityFrameworkCore;
using RestCountries.Data;

namespace RestCountries.MigrationService;

public class Worker(
    ILogger<Worker> logger, 
    IServiceProvider serviceProvider,
    IHostApplicationLifetime hostApplicationLifetime) 
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CountriesDbContext>();

                logger.LogInformation("Applying migrations...");
                // Automatically applies any pending migrations to the database
                await dbContext.Database.MigrateAsync(stoppingToken);
                logger.LogInformation("Migrations applied successfully.");
            }

            // Stop the service (because it's strictly for migrations)
            hostApplicationLifetime.StopApplication();
        }
    }
}
