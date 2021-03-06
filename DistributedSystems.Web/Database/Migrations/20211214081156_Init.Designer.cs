// <auto-generated />
using System;
using System.Collections.Generic;
using DistributedSystems.Web.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DistributedSystems.Web.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211214081156_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DistributedSystems.Web.Database.Entities.GithubStat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("IsFromCache")
                        .HasColumnType("boolean");

                    b.Property<string>("Repository")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("DistributedSystems.Web.Database.Entities.GithubStat", b =>
                {
                    b.OwnsOne("DistributedSystems.Entities.Models.GithubRepo", "Statistics", b1 =>
                        {
                            b1.Property<Guid>("GithubStatId")
                                .HasColumnType("uuid");

                            b1.Property<bool>("AllowForking")
                                .HasColumnType("boolean");

                            b1.Property<bool>("Archived")
                                .HasColumnType("boolean");

                            b1.Property<string>("DefaultBranch")
                                .HasColumnType("text");

                            b1.Property<string>("Description")
                                .HasColumnType("text");

                            b1.Property<bool>("Disabled")
                                .HasColumnType("boolean");

                            b1.Property<bool>("Fork")
                                .HasColumnType("boolean");

                            b1.Property<int>("Forks")
                                .HasColumnType("integer");

                            b1.Property<string>("FullName")
                                .HasColumnType("text");

                            b1.Property<bool>("HasDownloads")
                                .HasColumnType("boolean");

                            b1.Property<bool>("HasIssues")
                                .HasColumnType("boolean");

                            b1.Property<bool>("HasPages")
                                .HasColumnType("boolean");

                            b1.Property<bool>("HasProjects")
                                .HasColumnType("boolean");

                            b1.Property<bool>("HasWiki")
                                .HasColumnType("boolean");

                            b1.Property<string>("Homepage")
                                .HasColumnType("text");

                            b1.Property<string>("HtmlUrl")
                                .HasColumnType("text");

                            b1.Property<long>("Id")
                                .HasColumnType("bigint");

                            b1.Property<bool>("IsTemplate")
                                .HasColumnType("boolean");

                            b1.Property<string>("Language")
                                .HasColumnType("text");

                            b1.Property<string>("MirrorUrl")
                                .HasColumnType("text");

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.Property<string>("NodeId")
                                .HasColumnType("text");

                            b1.Property<int>("OpenIssues")
                                .HasColumnType("integer");

                            b1.Property<bool>("Private")
                                .HasColumnType("boolean");

                            b1.Property<int>("Size")
                                .HasColumnType("integer");

                            b1.Property<ICollection<string>>("Topics")
                                .HasColumnType("jsonb");

                            b1.Property<string>("Visibility")
                                .HasColumnType("text");

                            b1.Property<int>("Watchers")
                                .HasColumnType("integer");

                            b1.HasKey("GithubStatId");

                            b1.ToTable("Stats");

                            b1.WithOwner()
                                .HasForeignKey("GithubStatId");

                            b1.OwnsOne("DistributedSystems.Entities.Models.GithubLicense", "License", b2 =>
                                {
                                    b2.Property<Guid>("GithubRepoGithubStatId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Key")
                                        .HasColumnType("text");

                                    b2.Property<string>("Name")
                                        .HasColumnType("text");

                                    b2.Property<string>("NodeId")
                                        .HasColumnType("text");

                                    b2.Property<string>("SpdxId")
                                        .HasColumnType("text");

                                    b2.Property<string>("Url")
                                        .HasColumnType("text");

                                    b2.HasKey("GithubRepoGithubStatId");

                                    b2.ToTable("Stats");

                                    b2.WithOwner()
                                        .HasForeignKey("GithubRepoGithubStatId");
                                });

                            b1.OwnsOne("DistributedSystems.Entities.Models.GithubUser", "Owner", b2 =>
                                {
                                    b2.Property<Guid>("GithubRepoGithubStatId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("AvatarUrl")
                                        .HasColumnType("text");

                                    b2.Property<string>("Bio")
                                        .HasColumnType("text");

                                    b2.Property<string>("Blog")
                                        .HasColumnType("text");

                                    b2.Property<string>("Company")
                                        .HasColumnType("text");

                                    b2.Property<DateTime>("CreatedAt")
                                        .HasColumnType("timestamp with time zone");

                                    b2.Property<string>("Email")
                                        .HasColumnType("text");

                                    b2.Property<int>("Followers")
                                        .HasColumnType("integer");

                                    b2.Property<int>("Following")
                                        .HasColumnType("integer");

                                    b2.Property<string>("HtmlUrl")
                                        .HasColumnType("text");

                                    b2.Property<long>("Id")
                                        .HasColumnType("bigint");

                                    b2.Property<string>("Location")
                                        .HasColumnType("text");

                                    b2.Property<string>("Login")
                                        .HasColumnType("text");

                                    b2.Property<string>("Name")
                                        .HasColumnType("text");

                                    b2.Property<string>("NodeId")
                                        .HasColumnType("text");

                                    b2.Property<int>("PublicGists")
                                        .HasColumnType("integer");

                                    b2.Property<int>("PublicRepos")
                                        .HasColumnType("integer");

                                    b2.Property<bool?>("SiteAdmin")
                                        .HasColumnType("boolean");

                                    b2.Property<string>("Type")
                                        .HasColumnType("text");

                                    b2.Property<DateTime>("UpdatedAt")
                                        .HasColumnType("timestamp with time zone");

                                    b2.HasKey("GithubRepoGithubStatId");

                                    b2.ToTable("Stats");

                                    b2.WithOwner()
                                        .HasForeignKey("GithubRepoGithubStatId");
                                });

                            b1.Navigation("License")
                                .IsRequired();

                            b1.Navigation("Owner")
                                .IsRequired();
                        });

                    b.Navigation("Statistics")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
