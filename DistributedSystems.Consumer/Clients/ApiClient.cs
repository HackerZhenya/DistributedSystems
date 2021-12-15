using System.Net.Http.Headers;
using System.Net.Http.Json;
using DistributedSystems.Consumer.Options;
using DistributedSystems.Entities.Models;
using Microsoft.Extensions.Options;

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
        var req = JsonContent.Create(response);
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Secret", auth);
        var resp = await _client.PatchAsync($"github/{statId}", req);
    }
}