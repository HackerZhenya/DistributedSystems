using System.Threading;
using System.Threading.Tasks;
using DistributedSystems.Web.Database.Interfaces;
using DistributedSystems.Web.Database.Models;
using DistributedSystems.Web.Handlers.Links.Dto;
using MediatR;

namespace DistributedSystems.Web.Handlers.Links.Commands.CreateLink
{
    public class CreateLinkRequestHandler : IRequestHandler<CreateLinkRequest, Entity>
    {
        private readonly IDbContext _dbContext;

        public CreateLinkRequestHandler(IDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Entity> Handle(CreateLinkRequest request, CancellationToken cancellationToken)
        {
            var link = new Link
            {
                Url = request.Url
            };

            _dbContext.Add(link);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Entity.From(link);
        }
    }
}