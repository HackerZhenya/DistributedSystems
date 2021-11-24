using System.Reflection;
using DistributedSystems.Web.Database.Interfaces;
using DistributedSystems.Web.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DistributedSystems.Web.Database
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public DbSet<Link> Links { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}