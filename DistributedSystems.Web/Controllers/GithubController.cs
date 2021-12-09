using System.Net.Mime;
using System.Text.Json;
using DistributedSystems.Entities.Extensions;
using DistributedSystems.Entities.Models;
using DistributedSystems.Entities.Options;
using DistributedSystems.Web.Database;
using DistributedSystems.Web.Database.Entities;
using DistributedSystems.Web.Database.Interfaces;
using DistributedSystems.Web.Extensions;
using DistributedSystems.Web.Models.Github;
using DistributedSystems.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using RabbitMQ.Client;

namespace DistributedSystems.Web.Controllers;

[Controller]
[Route("github")]
public class GithubController : Controller
{
    private readonly AppDbContext _dbContext;

    public GithubController(AppDbContext dbContext) =>
        _dbContext = dbContext;

    [HttpGet]
    public async Task<IActionResult> ListGithubStats(CancellationToken cancellationToken) =>
        View("Index", new IndexViewModel
        {
            Stats = await _dbContext.Stats
                                    .AsNoTracking()
                                    .OrderByDescending(x => x.UpdatedAt)
                                    .Select(x => new GithubShortStat
                                    {
                                        Id = x.Id,
                                        Group = x.Group,
                                        Repository = x.Repository,
                                        IsPending = x.Statistics == null,
                                        CreatedAt = x.CreatedAt,
                                        UpdatedAt = x.UpdatedAt
                                    })
                                    .ToListAsync(cancellationToken)
        });

    [HttpGet]
    [Route("create")]
    public IActionResult ShowRequestForm() =>
        View("Create");

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> DispatchRequest([FromForm] StatsRequest request,
                                                     [FromServices] IModel model,
                                                     [FromServices] InternalAuthService authService,
                                                     [FromServices] IOptions<AmqpOptions> options,
                                                     CancellationToken cancellationToken)
    {
        var stat = new GithubStat
        {
            Group = request.Group,
            Repository = request.Repository
        };

        _dbContext.Add(stat);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var props = model.CreateBasicProperties()
                         .Also(x => x.ContentType = MediaTypeNames.Application.Json)
                         .Also(x => x.Timestamp = new AmqpTimestamp(DateTime.UtcNow.ToUnixTimestamp()))
                         .Also(x => x.Headers = new Dictionary<string, object>
                         {
                             [nameof(IEntity.Id)] = stat.Id.ToString(),
                             [HeaderNames.Authorization] = authService.SecretKey
                         });

        model.BasicPublish(options.Value.Exchange, nameof(StatsRequest), props,
            JsonSerializer.SerializeToUtf8Bytes(request));

        return RedirectToAction(nameof(ShowStats), "Github", new
        {
            StatId = stat.Id
        });
    }

    [HttpPatch]
    [Route("{statId:guid:required}")]
    public async Task<IActionResult> UpdateStats([FromRoute] Guid statId,
                                                 [FromBody] StatsResponse response,
                                                 [FromServices] InternalAuthService authService,
                                                 CancellationToken cancellationToken)
    {
        if (!Request.Headers.ContainsKey(HeaderNames.Authorization) ||
            Request.Headers[HeaderNames.Authorization].ToString() != authService.SecretKey)
        {
            return Unauthorized();
        }

        var stat = await _dbContext.Stats
                                   .FirstOrDefaultAsync(x => x.Id == statId, cancellationToken);

        if (stat == null)
        {
            return NotFound();
        }

        stat.IsFromCache = response.IsFromCache;
        stat.Statistics = response.Repository;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpGet]
    [Route("{statId:guid:required}")]
    public async Task<IActionResult> ShowStats([FromRoute] Guid statId, CancellationToken cancellationToken) =>
        View("Show", new ShowViewModel
        {
            Stat = await _dbContext.Stats
                                   .Where(x => x.Id == statId)
                                   .FirstAsync(cancellationToken)
        });
}