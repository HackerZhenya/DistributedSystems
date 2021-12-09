using DistributedSystems.Entities.Extensions;

namespace DistributedSystems.Web.Services;

public class InternalAuthService
{
    public string SecretKey { get; } = new byte[1024].Also(Random.Shared.NextBytes)
                                                     .Let(Convert.ToBase64String);
}