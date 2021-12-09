using System.Text.Json;
using DistributedSystems.Entities.Models;

namespace DistributedSystems.Consumer.Clients;

public class GithubClient
{
    private readonly HttpClient _client;

    public GithubClient(HttpClient client)
    {
        client.BaseAddress = new Uri("https://api.github/");
        _client = client;
    }

    public async Task<GithubRepo> GetStatisticss(StatsRequest request, CancellationToken cancellationToken)
    {
        var resp = await _client.GetAsync($"repos/{request.Group}/{request.Repository}", cancellationToken);
        var repo = JsonSerializer.Deserialize<GithubRepo>(await resp.Content.ReadAsStringAsync(cancellationToken));
        return repo;
    }
}