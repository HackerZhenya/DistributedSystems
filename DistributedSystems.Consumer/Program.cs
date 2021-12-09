using DistributedSystems.Consumer;
using DistributedSystems.Consumer.Clients;
using DistributedSystems.Consumer.Extensions;
using DistributedSystems.Consumer.Options;
using DistributedSystems.Entities.Extensions;

await Host.CreateDefaultBuilder(args)
          .ConfigureServices(services =>
               {
                   services.AddRedis()
                           .AddAmqp()
                           .AddHostedService<Worker>();
                   services.AddHttpClient<GithubClient>();
                   services.AddHttpClient<ApiClient>();
                   services.AddOptions<ApiOptions>()
                           .BindConfiguration("Api");
               }
           )
          .Build()
          .RunAsync();