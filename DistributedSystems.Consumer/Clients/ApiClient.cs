using System.Text.Json;
using DistributedSystems.Consumer.Options;
using DistributedSystems.Entities.Models;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

namespace DistributedSystems.Consumer.Clients;

public class ApiClient
{
    private readonly HttpClient _client;

    public ApiClient(HttpClient client, IOptions<ApiOptions> options)
    {
        client.BaseAddress = options.Value.Url;
        _client = client;
    }

    public async Task SendStatistics(Guid statId, StatsResponse response, string auth)
    {
        var req = new StringContent(JsonSerializer.Serialize(response));
        req.Headers.Add(HeaderNames.Authorization, auth);
        await _client.PatchAsync($"github/{statId}", req);
    }
}