using System.Text.Json;
using DistributedSystems.Entities.Models;

namespace DistributedSystems.Consumer.Clients;

public class GithubClient
{
    private readonly HttpClient _client;

    public GithubClient(HttpClient client)
    {
        client.BaseAddress = new Uri("https://api.github.com/");
        client.DefaultRequestHeaders.Add("User-Agent", "PostmanRuntime/7.28.4");
        _client = client;
    }

    public async Task<GithubRepo> GetStatisticss(StatsRequest request, CancellationToken cancellationToken)
    {
        var resp = await _client.GetAsync($"repos/{request.Group}/{request.Repository}", cancellationToken);
        var content = await resp.Content.ReadAsStringAsync(cancellationToken);
        var repo = JsonSerializer.Deserialize<GithubRepo>(content);
        return repo;
    }
}