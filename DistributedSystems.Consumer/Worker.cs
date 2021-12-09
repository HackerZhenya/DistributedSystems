using System.Reflection;
using System.Text;
using System.Text.Json;
using DistributedSystems.Consumer.Clients;
using DistributedSystems.Entities.Models;
using Microsoft.Net.Http.Headers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DistributedSystems.Consumer;

public class Worker : IHostedService
{
    private readonly ILogger<Worker> _logger;
    private readonly IModel _model;
    private readonly GithubClient _githubClient;
    private readonly ApiClient _apiClient;

    public Worker(IModel model, ILogger<Worker> logger, GithubClient githubClient, ApiClient apiClient)
    {
        _logger = logger;
        _githubClient = githubClient;
        _apiClient = apiClient;
        _model = model;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var consumer = new AsyncEventingBasicConsumer(_model);
        consumer.Received += async (sender, evt) =>
        {
            var request = JsonSerializer.Deserialize<StatsRequest>(Encoding.UTF8.GetString(evt.Body.ToArray()));
            var stats = await _githubClient.GetStatisticss(request, cancellationToken);

            var auth = evt.BasicProperties.Headers[HeaderNames.Authorization].ToString();
            var id = Guid.Parse(evt.BasicProperties.Headers["Id"].ToString());
            var resp = new StatsResponse
            {
                Repository = stats,
                IsFromCache = false
            };

            await _apiClient.SendStatistics(id, resp, auth);
        };

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) =>
        Task.CompletedTask;
}