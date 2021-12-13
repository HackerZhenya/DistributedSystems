using System.Reflection;
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

    public Worker(IModel model,
                  ILogger<Worker> logger,
                  GithubClient githubClient,
                  ApiClient apiClient,
                  IOptions<AmqpOptions> options)
    {
        _logger = logger;
        _githubClient = githubClient;
        _apiClient = apiClient;
        _model = model;
        _options = options.Value;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _model.QueueDeclare(_options.Queue);
        _model.ExchangeDeclare(_options.Exchange, ExchangeType.Topic);
        _model.QueueBind(_options.Queue, _options.Exchange, nameof(StatsRequest));

        var consumer = new EventingBasicConsumer(_model);
        consumer.Received += async (sender, evt) =>
        {
            var request = JsonSerializer.Deserialize<StatsRequest>(Encoding.UTF8.GetString(evt.Body.ToArray()));
            var stats = await _githubClient.GetStatisticss(request, cancellationToken);
            var auth = Encoding.UTF8.GetString((byte[])evt.BasicProperties.Headers[HeaderNames.Authorization]);
            var id = Guid.Parse(Encoding.UTF8.GetString((byte[])evt.BasicProperties.Headers["Id"]));

            var resp = new StatsResponse
            {
                Repository = stats,
                IsFromCache = false
            };

            await _apiClient.SendStatistics(id, resp, auth);
        };

        _model.BasicConsume(_options.Queue, consumer: consumer, autoAck: true);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) =>
        Task.CompletedTask;
}