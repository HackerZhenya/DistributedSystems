using System.Reflection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DistributedSystems.Consumer;

public class Worker : IHostedService
{
    private readonly ILogger<Worker> _logger;
    private readonly IModel _model;

    public Worker(IModel model, ILogger<Worker> logger)
    {
        _logger = logger;
        _model = model;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var consumer = new AsyncEventingBasicConsumer(_model);
        consumer.Received += (sender, evt) =>
        {
            _logger.LogInformation("Console.Log");
            return Task.CompletedTask;
        };

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) =>
        Task.CompletedTask;
}