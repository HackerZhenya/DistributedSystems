using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RabbitMQ.Client;

namespace DistributedSystems.Web.Handlers.Github.Commands.LoadRepositoryStats;

public class LoadRepositoryStatsRequestHandler : IRequestHandler<LoadRepositoryStatsRequest>
{
    private readonly IModel _model;

    public LoadRepositoryStatsRequestHandler(IModel model) =>
        _model = model;

    public Task<Unit> Handle(LoadRepositoryStatsRequest request, CancellationToken cancellationToken)
    {
        _model.BasicPublish("exchange", "route", null, JsonSerializer.SerializeToUtf8Bytes(request));
        return Unit.Task;
    }
}