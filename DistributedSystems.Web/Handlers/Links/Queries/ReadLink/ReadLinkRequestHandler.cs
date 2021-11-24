using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DistributedSystems.Web.Database.Interfaces;
using DistributedSystems.Web.Database.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DistributedSystems.Web.Handlers.Links.Queries.ReadLink
{
    public class ReadLinkRequestHandler : IRequestHandler<ReadLinkRequest, Link>
    {
        private readonly IReadonlyDbContext _dbContext;

        public ReadLinkRequestHandler(IReadonlyDbContext dbContext) =>
            _dbContext = dbContext;

        public Task<Link> Handle(ReadLinkRequest request, CancellationToken cancellationToken) =>
            _dbContext.Links
                      .Where(x => x.Id == request.LinkId)
                      .FirstAsync(cancellationToken);
    }
}