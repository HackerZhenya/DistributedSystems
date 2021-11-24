using System;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using DistributedSystems.Web.Database.Models;
using DistributedSystems.Web.Handlers.Links.Commands.CreateLink;
using DistributedSystems.Web.Handlers.Links.Dto;
using DistributedSystems.Web.Handlers.Links.Queries.ReadLink;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DistributedSystems.Web.Controllers
{
    [Route("/links")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json), Produces(MediaTypeNames.Application.Json)]
    public class LinksController : Controller
    {
        private readonly IMediator _mediator;

        public LinksController(IMediator mediator) =>
            _mediator = mediator;

        [HttpPost]
        public Task<Entity> CreateLink([FromBody] CreateLinkRequest request, CancellationToken cancellationToken) =>
            _mediator.Send(request, cancellationToken);

        [HttpGet]
        [Route("{linkId:guid}")]
        public Task<Link> ReadLink([FromRoute] Guid linkId, CancellationToken cancellationToken) =>
            _mediator.Send(new ReadLinkRequest
            {
                LinkId = linkId
            }, cancellationToken);
    }
}