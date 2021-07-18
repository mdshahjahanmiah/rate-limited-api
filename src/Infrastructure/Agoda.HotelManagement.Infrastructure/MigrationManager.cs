using Agoda.HotelManagement.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Agoda.HotelManagement.Infrastructure
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using var appContext = scope.ServiceProvider.GetRequiredService<HotelManagementDbContext>();
                appContext.Database.Migrate();
            }
            return host;
        }
    }
}
