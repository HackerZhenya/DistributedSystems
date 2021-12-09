using DistributedSystems.Consumer;
using DistributedSystems.Consumer.Extensions;
using DistributedSystems.Entities.Extensions;

await Host.CreateDefaultBuilder(args)
          .ConfigureServices(services =>
              services.AddRedis()
                      .AddAmqp()
                      .AddHostedService<Worker>())
          .Build()
          .RunAsync();