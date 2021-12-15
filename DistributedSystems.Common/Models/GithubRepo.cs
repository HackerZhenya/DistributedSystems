using System.Text.Json.Serialization;

namespace DistributedSystems.Entities.Models;

public class GithubRepo
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("owner")]
    public GithubUser? Owner { get; set; } = null!;

    [JsonPropertyName("license")]
    public GithubLicense? License { get; set; } = null!;

    [JsonPropertyName("node_id")]
    public string? NodeId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("full_name")]
    public string? FullName { get; set; }

    [JsonPropertyName("private")]
    public bool Private { get; set; }

    [JsonPropertyName("html_url")]
    public string? HtmlUrl { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("fork")]
    public bool Fork { get; set; }

    [JsonPropertyName("homepage")]
    public string? Homepage { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("has_issues")]
    public bool HasIssues { get; set; }

    [JsonPropertyName("has_projects")]
    public bool HasProjects { get; set; }

    [JsonPropertyName("has_downloads")]
    public bool HasDownloads { get; set; }

    [JsonPropertyName("has_wiki")]
    public bool HasWiki { get; set; }

    [JsonPropertyName("has_pages")]
    public bool HasPages { get; set; }

    [JsonPropertyName("mirror_url")]
    public string? MirrorUrl { get; set; }

    [JsonPropertyName("archived")]
    public bool Archived { get; set; }

    [JsonPropertyName("disabled")]
    public bool Disabled { get; set; }

    [JsonPropertyName("allow_forking")]
    public bool AllowForking { get; set; }

    [JsonPropertyName("is_template")]
    public bool IsTemplate { get; set; }

    [JsonPropertyName("topics")]
    public ICollection<string>? Topics { get; set; }

    [JsonPropertyName("visibility")]
    public string? Visibility { get; set; }

    [JsonPropertyName("forks")]
    public int Forks { get; set; }

    [JsonPropertyName("open_issues")]
    public int OpenIssues { get; set; }

    [JsonPropertyName("watchers")]
    public int Watchers { get; set; }

    [JsonPropertyName("default_branch")]
    public string? DefaultBranch { get; set; }
}