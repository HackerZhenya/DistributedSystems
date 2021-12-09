namespace DistributedSystems.Web.Models.Github;

public class GithubShortStat
{
    public Guid Id { get; set; }

    public string Group { get; set; } = null!;
    public string Repository { get; set; } = null!;

    public bool IsPending { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}