using DistributedSystems.Consumer;
using DistributedSystems.Consumer.Extensions;

await Host.CreateDefaultBuilder(args)
          .ConfigureServices(services =>
               services.AddRedis()
                       .AddAmqp()
                       .AddHostedService<Worker>())
          .Build()
          .RunAsync();