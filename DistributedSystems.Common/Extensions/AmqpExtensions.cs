using DistributedSystems.Entities.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace DistributedSystems.Entities.Extensions;

public static class AmqpExtensions
{
    public static IServiceCollection AddAmqp(this IServiceCollection services, string configurationSection = "RabbitMQ")
    {
        services.AddOptions<AmqpOptions>()
                .BindConfiguration(configurationSection)
                .ValidateDataAnnotations();

        services.AddSingleton<IConnectionFactory>(x =>
        {
            var options = x.GetRequiredService<IOptions<AmqpOptions>>()
                           .Value;

            return new ConnectionFactory
            {
                HostName = options.Host,
                UserName = options.Username,
                Password = options.Password,
                Port = options.Port,
                RequestedHeartbeat = options.HeartbeatTimeout
            };
        });

        services.AddSingleton<IConnection>(x => x.GetRequiredService<IConnectionFactory>()
                                                 .CreateConnection());

        services.AddSingleton<IModel>(x => x.GetRequiredService<IConnection>()
                                            .CreateModel());

        return services;
    }
}