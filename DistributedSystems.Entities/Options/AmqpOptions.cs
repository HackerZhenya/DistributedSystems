namespace DistributedSystems.Entities.Options;

public class AmqpOptions
{
    public string Host { get; set; }
    public int? Port { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }

    public TimeSpan HeartbeatTimeout { get; set; }

    public string Exchange { get; set; }
}