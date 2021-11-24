using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DistributedSystems.Web.Controllers;

[Route("github")]
[ApiController]
public class GithubController : ControllerBase
{
    [HttpGet]
    [Route("{author:required}/{repository:required}/stats")]
    public Task<string> GetRepositoryStatisticsAsync(string author, string repository,
                                                     CancellationToken cancellationToken) =>
        Task.FromResult("pishov nahoy");
}