using System;
using DistributedSystems.Web.Database.Interfaces;

namespace DistributedSystems.Web.Handlers.Links.Dto
{
    public class Entity
    {
        public Guid Id { get; private init; }

        public static Entity From(IEntity entity) =>
            new()
            {
                Id = entity.Id
            };
    }
}