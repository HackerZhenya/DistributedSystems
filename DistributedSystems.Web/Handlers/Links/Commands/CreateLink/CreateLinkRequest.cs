using DistributedSystems.Web.Handlers.Links.Dto;
using MediatR;

namespace DistributedSystems.Web.Handlers.Links.Commands.CreateLink
{
    public class CreateLinkRequest : IRequest<Entity>
    {
        public string Url { get; set; }
    }
}