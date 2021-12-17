using System.Text;
using System.Text.Json;
using DistributedSystems.Consumer.Clients;
using DistributedSystems.Entities.Models;
using DistributedSystems.Entities.Options;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StackExchange.Redis;

namespace DistributedSystems.Consumer;

public class Worker : IHostedService
{
    private readonly ILogger<Worker> _logger;
    private readonly IModel _model;
    private readonly GithubClient _githubClient;
    private readonly ApiClient _apiClient;
    private readonly AmqpOptions _options;
    private readonly IConnectionMultiplexer _redis;

    public Worker(IModel model,
                  ILogger<Worker> logger,
                  GithubClient githubClient,
                  ApiClient apiClient,
                  IOptions<AmqpOptions> options,
                  IConnectionMultiplexer redis)
    {
        _logger = logger;
        _githubClient = githubClient;
        _apiClient = apiClient;
        _redis = redis;
        _model = model;
        _options = options.Value;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _model.QueueDeclare(_options.Queue, exclusive: false);
        _model.QueueBind(_options.Queue, _options.Exchange, nameof(StatsRequest));

        var consumer = new EventingBasicConsumer(_model);
        consumer.Received += async (sender, evt) =>
        {
            var request = JsonSerializer.Deserialize<StatsRequest>(Encoding.UTF8.GetString(evt.Body.ToArray()));
            var auth = Encoding.UTF8.GetString((byte[])evt.BasicProperties.Headers[HeaderNames.Authorization]);
            var id = Guid.Parse(Encoding.UTF8.GetString((byte[])evt.BasicProperties.Headers["Id"]));

            var db = _redis.GetDatabase();
            var cached = db.StringGet($"{request.Group}{request.Repository}");
            var resp = new StatsResponse();

            if (cached.HasValue)
            {
                var stats = JsonSerializer.Deserialize<GithubRepo>(cached);
                resp.Repository = stats;
                resp.IsFromCache = true;
            }
            else
            {
                var stats = await _githubClient.GetStatisticss(request, cancellationToken);
                db.StringSet($"{request.Group}{request.Repository}", JsonSerializer.Serialize(stats));
                resp.Repository = stats;
            }

            await _apiClient.SendStatistics(id, resp, auth);
        };

        _model.BasicConsume(_options.Queue, consumer: consumer, autoAck: true);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) =>
        Task.CompletedTask;
}