using Microsoft.EntityFrameworkCore.Migrations;

namespace FinDesk.DAL.Migrations
{
    public partial class SimpleIssue_AddColCategoryIssueStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "SimpleIssues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssueStatus",
                table: "SimpleIssues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "SimpleIssues");

            migrationBuilder.DropColumn(
                name: "IssueStatus",
                table: "SimpleIssues");
        }
    }
}
