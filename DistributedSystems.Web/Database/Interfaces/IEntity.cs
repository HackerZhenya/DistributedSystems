using System;

namespace DistributedSystems.Web.Database.Interfaces
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}