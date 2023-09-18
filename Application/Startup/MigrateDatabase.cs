using Microsoft.EntityFrameworkCore;

namespace DDDTemplate.Application.Startup
{    
    public static class MigrateDatabase
    {        
        public static void MigrateDbContext<TContext>(this WebApplication app, Action<TContext, IServiceProvider>? seeder)
            where TContext : DbContext
        {
            using var scope = app.Services.CreateScope();
            
            var services = scope.ServiceProvider;

            var logger = services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetRequiredService<TContext>();

            try
            {
                logger.LogInformation(
                    "Migrating database associated with context {DbContextName}",
                    typeof(TContext).Name);

                context.Database.Migrate();
                if (seeder is not null)
                {
                    seeder(context, services);
                }

                logger.LogInformation(
                    "Migrated database associated with context {DbContextName}",
                    typeof(TContext).Name);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An error occurred while migrating the database used on context {DbContextName}",
                    typeof(TContext).Name);
            }
        }
            }
}
