using Trinity.Infra.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Trinity.Infra.CrossCutting.Migrations
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider services)
        {
            var context = services.GetService<TrinityContext>();

            // NOTE: if you just want to ensure your DataBase reflects your 
            // DbContext, you can use: context.Database.EnsureCreated(), otherwise
            // you shall use the following to run migrations.
            context.Database.Migrate();
        }

        public static void InitializeHost(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
        }
    }

}
