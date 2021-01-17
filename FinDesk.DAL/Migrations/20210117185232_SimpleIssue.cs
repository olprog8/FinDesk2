using Microsoft.EntityFrameworkCore.Migrations;

namespace FinDesk.DAL.Migrations
{
    public partial class SimpleIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SimpleIssues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(nullable: true),
                    IssueType = table.Column<string>(nullable: true),
                    LongDescr = table.Column<string>(nullable: true),
                    SolveDescr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimpleIssues", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimpleIssues");
        }
    }
}
