using System.Diagnostics;
using DistributedSystems.Entities.Options;
using DistributedSystems.Web.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace DistributedSystems.Web.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication RunMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<AppDbContext>>();

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
                migrations.Select(x => $"Migrate: {x}")
                          .Append($"Database migrated successfully in {sw.ElapsedMilliseconds} ms")));
        }
        else
        {
            logger.LogInformation("Nothing to migrate");
        }

        return app;
    }

    public static WebApplication DeclareExchanges(this WebApplication app)
    {
        var model = app.Services.GetRequiredService<IModel>();
        var options = app.Services.GetRequiredService<IOptions<AmqpOptions>>().Value;

        model.ExchangeDeclare(options.Exchange, ExchangeType.Topic);

        return app;
    }
}