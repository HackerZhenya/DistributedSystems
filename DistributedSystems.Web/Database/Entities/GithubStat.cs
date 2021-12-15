using DistributedSystems.Entities.Models;
using DistributedSystems.Web.Database.Interfaces;

namespace DistributedSystems.Web.Database.Entities;

public class GithubStat : IEntity, IHasTimestamps
{
    public Guid Id { get; set; }

    public string Group { get; set; } = null!;
    public string Repository { get; set; } = null!;

    public bool? IsFromCache { get; set; }
    public GithubRepo? Statistics { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}