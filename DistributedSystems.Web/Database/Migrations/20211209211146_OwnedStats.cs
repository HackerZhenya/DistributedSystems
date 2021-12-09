using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistributedSystems.Web.Database.Migrations
{
    public partial class OwnedStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFromCache",
                table: "Stats",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Statistics_AllowForking",
                table: "Stats",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Statistics_Archived",
                table: "Stats",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_DefaultBranch",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Description",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Statistics_Disabled",
                table: "Stats",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Statistics_Fork",
                table: "Stats",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Statistics_Forks",
                table: "Stats",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_FullName",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Statistics_HasDownloads",
                table: "Stats",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Statistics_HasIssues",
                table: "Stats",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Statistics_HasPages",
                table: "Stats",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Statistics_HasProjects",
                table: "Stats",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Statistics_HasWiki",
                table: "Stats",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Homepage",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_HtmlUrl",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Statistics_Id",
                table: "Stats",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Statistics_IsTemplate",
                table: "Stats",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Language",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_License_Key",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_License_Name",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_License_NodeId",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_License_SpdxId",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_License_Url",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_MirrorUrl",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Name",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_NodeId",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Statistics_OpenIssues",
                table: "Stats",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Owner_AvatarUrl",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Owner_Bio",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Owner_Blog",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Owner_Company",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Statistics_Owner_CreatedAt",
                table: "Stats",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Owner_Email",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Statistics_Owner_Followers",
                table: "Stats",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Statistics_Owner_Following",
                table: "Stats",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Owner_HtmlUrl",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Statistics_Owner_Id",
                table: "Stats",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Owner_Location",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Owner_Login",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Owner_Name",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Owner_NodeId",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Statistics_Owner_PublicGists",
                table: "Stats",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Statistics_Owner_PublicRepos",
                table: "Stats",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Owner_SiteAdmin",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Owner_Type",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Statistics_Owner_UpdatedAt",
                table: "Stats",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Statistics_Private",
                table: "Stats",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Statistics_Size",
                table: "Stats",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<ICollection<string>>(
                name: "Statistics_Topics",
                table: "Stats",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statistics_Visibility",
                table: "Stats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Statistics_Watchers",
                table: "Stats",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFromCache",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_AllowForking",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Archived",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_DefaultBranch",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Description",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Disabled",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Fork",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Forks",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_FullName",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_HasDownloads",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_HasIssues",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_HasPages",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_HasProjects",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_HasWiki",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Homepage",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_HtmlUrl",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Id",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_IsTemplate",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Language",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_License_Key",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_License_Name",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_License_NodeId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_License_SpdxId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_License_Url",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_MirrorUrl",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Name",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_NodeId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_OpenIssues",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_AvatarUrl",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_Bio",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_Blog",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_Company",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_CreatedAt",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_Email",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_Followers",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_Following",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_HtmlUrl",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_Id",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_Location",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_Login",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_Name",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_NodeId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_PublicGists",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_PublicRepos",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_SiteAdmin",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_Type",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Owner_UpdatedAt",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Private",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Size",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Topics",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Visibility",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Statistics_Watchers",
                table: "Stats");
        }
    }
}
