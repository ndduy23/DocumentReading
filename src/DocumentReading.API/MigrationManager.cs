using DocumentReading.Data;
using Microsoft.EntityFrameworkCore;

namespace DocumentReading.API
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using( var context = scope.ServiceProvider.GetRequiredService<DocumentReading.Data.AppDbContext>())
                {
                    context.Database.Migrate();
                    new DataSeeder().SeedAsync(context).Wait();
                }
            }
            return app;
        }
    }
}
