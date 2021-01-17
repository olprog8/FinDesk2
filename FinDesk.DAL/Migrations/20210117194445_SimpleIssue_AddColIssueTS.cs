using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinDesk.DAL.Migrations
{
    public partial class SimpleIssue_AddColIssueTS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "IssueTS",
                table: "SimpleIssues",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueTS",
                table: "SimpleIssues");
        }
    }
}
