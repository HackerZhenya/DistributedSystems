using MediatR;

namespace DistributedSystems.Web.Handlers.Github.Commands.LoadRepositoryStats;

public class LoadRepositoryStatsRequest : IRequest
{
    public string Author { get; set; }
    public string Repository { get; set; }
}