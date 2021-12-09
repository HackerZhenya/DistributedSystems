using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace DistributedSystems.Consumer.Extensions;

public static class RedisExtensions
{
    public static IServiceCollection AddRedis(this IServiceCollection services)
    {
        services.AddOptions<ConfigurationOptions>()
                .BindConfiguration("Redis");
        services.AddSingleton(ctx =>
            ConnectionMultiplexer.Connect(ctx.GetRequiredService<IOptions<ConfigurationOptions>>().Value));
        services.AddTransient<IDatabase>(ctx => ctx.GetRequiredService<ConnectionMultiplexer>().GetDatabase());
        return services;
    }
}