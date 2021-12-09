namespace DistributedSystems.Entities.Models;

public class ResponseWrapper
{
    public bool IsFromCache { get; set; }
    public GithubRepo Repo { get; set; }
}