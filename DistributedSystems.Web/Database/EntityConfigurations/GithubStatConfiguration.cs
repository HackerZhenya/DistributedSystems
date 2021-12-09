using DistributedSystems.Web.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistributedSystems.Web.Database.EntityConfigurations;

public class GithubStatConfiguration : IEntityTypeConfiguration<GithubStat>
{
    public void Configure(EntityTypeBuilder<GithubStat> builder)
    {
        builder.OwnsOne(x => x.Statistics, b =>
        {
            b.OwnsOne(x => x.Owner);
            b.OwnsOne(x => x.License);

            b.Property(x => x.Topics)
             .HasColumnType("jsonb");
        });
    }
}