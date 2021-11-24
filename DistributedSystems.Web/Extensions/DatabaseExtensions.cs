using System;
using System.Diagnostics;
using System.Linq;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DistributedSystems.Web.Extensions
{
    public static class DatabaseExtensions
    {
        public static ContainerBuilder RunMigrations<TContext>(this ContainerBuilder builder)
            where TContext : DbContext =>
            builder.RegisterBuildCallback(scope =>
            {
                var context = scope.Resolve<TContext>();
                var logger = scope.Resolve<ILogger<TContext>>();

                var migrations = context.Database
                                        .GetPendingMigrations()
                                        .ToList();

                if (migrations.Any())
                {
                    var sw = new Stopwatch();

                    sw.Start();
                    context.Database.Migrate();
                    sw.Stop();

                    logger.LogInformation(string.Join(Environment.NewLine,
                        migrations.Select(x => $"migrate: {x}")
                                  .Append($"Database migrated successfully in {sw.ElapsedMilliseconds} ms")));
                }
                else
                {
                    logger.LogInformation("Nothing to migrate");
                }
            });
    }
}