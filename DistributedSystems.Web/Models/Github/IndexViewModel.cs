namespace DistributedSystems.Web.Models.Github;

public class IndexViewModel
{
    public ICollection<GithubShortStat> Stats { get; set; } = null!;
}