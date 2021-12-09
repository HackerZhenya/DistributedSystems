namespace DistributedSystems.Consumer.Clients;

public class GithubClient
{
    private readonly HttpClient _client;

    public GithubClient(HttpClient client)
    {
        client.BaseAddress = new Uri("api.github");
        _client = client;
    }

    public async Task GetStatisticss()
    {
        
    }
}