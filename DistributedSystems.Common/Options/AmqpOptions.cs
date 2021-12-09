using System.ComponentModel.DataAnnotations;
using RabbitMQ.Client;

namespace DistributedSystems.Entities.Options;

public class AmqpOptions
{
    public string Host { get; set; } = "localhost";

    public int Port { get; set; } = AmqpTcpEndpoint.UseDefaultPort;

    [Required]
    public string Username { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    public TimeSpan HeartbeatTimeout { get; set; } = TimeSpan.FromSeconds(60);

    public string Exchange { get; set; } = null!;
    public string Queue { get; set; } = null!;
}