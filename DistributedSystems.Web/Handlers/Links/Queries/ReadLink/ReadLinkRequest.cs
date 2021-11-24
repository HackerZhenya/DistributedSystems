using System;
using DistributedSystems.Web.Database.Models;
using MediatR;

namespace DistributedSystems.Web.Handlers.Links.Queries.ReadLink
{
    public class ReadLinkRequest : IRequest<Link>
    {
        public Guid LinkId { get; set; }
    }
}