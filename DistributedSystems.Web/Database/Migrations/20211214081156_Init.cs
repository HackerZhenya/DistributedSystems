using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistributedSystems.Web.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Group = table.Column<string>(type: "text", nullable: false),
                    Repository = table.Column<string>(type: "text", nullable: false),
                    IsFromCache = table.Column<bool>(type: "boolean", nullable: true),
                    Statistics_Id = table.Column<long>(type: "bigint", nullable: false),
                    Statistics_Owner_Id = table.Column<long>(type: "bigint", nullable: false),
                    Statistics_Owner_Login = table.Column<string>(type: "text", nullable: true),
                    Statistics_Owner_NodeId = table.Column<string>(type: "text", nullable: true),
                    Statistics_Owner_AvatarUrl = table.Column<string>(type: "text", nullable: true),
                    Statistics_Owner_HtmlUrl = table.Column<string>(type: "text", nullable: true),
                    Statistics_Owner_Type = table.Column<string>(type: "text", nullable: true),
                    Statistics_Owner_SiteAdmin = table.Column<bool>(type: "boolean", nullable: true),
                    Statistics_Owner_Name = table.Column<string>(type: "text", nullable: true),
                    Statistics_Owner_Company = table.Column<string>(type: "text", nullable: true),
                    Statistics_Owner_Blog = table.Column<string>(type: "text", nullable: true),
                    Statistics_Owner_Location = table.Column<string>(type: "text", nullable: true),
                    Statistics_Owner_Email = table.Column<string>(type: "text", nullable: true),
                    Statistics_Owner_Bio = table.Column<string>(type: "text", nullable: true),
                    Statistics_Owner_PublicRepos = table.Column<int>(type: "integer", nullable: false),
                    Statistics_Owner_PublicGists = table.Column<int>(type: "integer", nullable: false),
                    Statistics_Owner_Followers = table.Column<int>(type: "integer", nullable: false),
                    Statistics_Owner_Following = table.Column<int>(type: "integer", nullable: false),
                    Statistics_Owner_CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Statistics_Owner_UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Statistics_License_Key = table.Column<string>(type: "text", nullable: true),
                    Statistics_License_Name = table.Column<string>(type: "text", nullable: true),
                    Statistics_License_NodeId = table.Column<string>(type: "text", nullable: true),
                    Statistics_License_SpdxId = table.Column<string>(type: "text", nullable: true),
                    Statistics_License_Url = table.Column<string>(type: "text", nullable: true),
                    Statistics_NodeId = table.Column<string>(type: "text", nullable: true),
                    Statistics_Name = table.Column<string>(type: "text", nullable: true),
                    Statistics_FullName = table.Column<string>(type: "text", nullable: true),
                    Statistics_Private = table.Column<bool>(type: "boolean", nullable: false),
                    Statistics_HtmlUrl = table.Column<string>(type: "text", nullable: true),
                    Statistics_Description = table.Column<string>(type: "text", nullable: true),
                    Statistics_Fork = table.Column<bool>(type: "boolean", nullable: false),
                    Statistics_Homepage = table.Column<string>(type: "text", nullable: true),
                    Statistics_Size = table.Column<int>(type: "integer", nullable: false),
                    Statistics_Language = table.Column<string>(type: "text", nullable: true),
                    Statistics_HasIssues = table.Column<bool>(type: "boolean", nullable: false),
                    Statistics_HasProjects = table.Column<bool>(type: "boolean", nullable: false),
                    Statistics_HasDownloads = table.Column<bool>(type: "boolean", nullable: false),
                    Statistics_HasWiki = table.Column<bool>(type: "boolean", nullable: false),
                    Statistics_HasPages = table.Column<bool>(type: "boolean", nullable: false),
                    Statistics_MirrorUrl = table.Column<string>(type: "text", nullable: true),
                    Statistics_Archived = table.Column<bool>(type: "boolean", nullable: false),
                    Statistics_Disabled = table.Column<bool>(type: "boolean", nullable: false),
                    Statistics_AllowForking = table.Column<bool>(type: "boolean", nullable: false),
                    Statistics_IsTemplate = table.Column<bool>(type: "boolean", nullable: false),
                    Statistics_Topics = table.Column<ICollection<string>>(type: "jsonb", nullable: true),
                    Statistics_Visibility = table.Column<string>(type: "text", nullable: true),
                    Statistics_Forks = table.Column<int>(type: "integer", nullable: false),
                    Statistics_OpenIssues = table.Column<int>(type: "integer", nullable: false),
                    Statistics_Watchers = table.Column<int>(type: "integer", nullable: false),
                    Statistics_DefaultBranch = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stats");
        }
    }
}
