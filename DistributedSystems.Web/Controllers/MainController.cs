using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DistributedSystems.Web.Controllers
{
    [Route("/")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json), Produces(MediaTypeNames.Application.Json)]
    public class MainController : Controller
    {
        [HttpGet]
        public Task<object> Home(CancellationToken cancellationToken) =>
            Task.FromResult<object>(new
            {
                Hello = "World"
            });
    }
}