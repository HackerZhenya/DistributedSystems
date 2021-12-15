using DistributedSystems.Consumer.Options;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace DistributedSystems.Consumer.Extensions;

public static class RedisExtensions
{
    public static IServiceCollection AddRedis(this IServiceCollection services)
    {
        services.AddOptions<RedisOptions>()
                .BindConfiguration("Redis");
        services.AddSingleton<IConnectionMultiplexer>(ctx =>
            ConnectionMultiplexer.Connect(ctx.GetRequiredService<IOptions<RedisOptions>>().Value.ConnectionString));
        return services;
    }
}