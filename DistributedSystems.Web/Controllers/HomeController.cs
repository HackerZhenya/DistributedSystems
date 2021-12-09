using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DistributedSystems.Web.Models;

namespace DistributedSystems.Web.Controllers;

[Controller]
[Route("/")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index() =>
        RedirectToAction(nameof(GithubController.ListGithubStats), "Github");

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
}
