using System;
using System.ComponentModel.DataAnnotations.Schema;
using DistributedSystems.Web.Database.Interfaces;

namespace DistributedSystems.Web.Database.Models
{
    [Table("Links")]
    public class Link : IEntity
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
    }
}