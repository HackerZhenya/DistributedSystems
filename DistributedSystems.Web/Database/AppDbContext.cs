using System.Reflection;
using DistributedSystems.Web.Database.Entities;
using DistributedSystems.Web.Extensions;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace DistributedSystems.Web.Database;

public class AppDbContext : DbContext
{
    public DbSet<GithubStat> Stats { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) =>
        this.UseTimestamps();

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly())
                    .UseUtcDateTimeConverter();
}