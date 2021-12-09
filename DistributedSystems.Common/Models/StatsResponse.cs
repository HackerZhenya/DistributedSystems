namespace DistributedSystems.Entities.Models;

public class StatsResponse
{
    public bool IsFromCache { get; set; }
    public GithubRepo Repository { get; set; } = null!;
}