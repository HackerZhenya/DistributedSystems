using DistributedSystems.Entities.Options;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace DistributedSystems.Consumer.Extensions;

public static class AmqpExtensions
{
    public static IServiceCollection AddAmqp(this IServiceCollection services)
    {
        services.AddOptions<AmqpOptions>()
                .BindConfiguration("RabbitMQ");

        services.AddSingleton<IConnectionFactory>(x =>
        {
            var options = x.GetRequiredService<IOptions<AmqpOptions>>()
                           .Value;
            return new ConnectionFactory
            {
                HostName = options.Host,
                UserName = options.Username,
                Password = options.Password,
                Port = options.Port ?? AmqpTcpEndpoint.UseDefaultPort,
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