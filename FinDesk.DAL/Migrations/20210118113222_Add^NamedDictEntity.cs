using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinDesk.DAL.Migrations
{
    public partial class AddNamedDictEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ChangeDt",
                table: "IssueTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ChangeUser",
                table: "IssueTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descr01",
                table: "IssueTypes",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameRus",
                table: "IssueTypes",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangeDt",
                table: "IssueTypes");

            migrationBuilder.DropColumn(
                name: "ChangeUser",
                table: "IssueTypes");

            migrationBuilder.DropColumn(
                name: "Descr01",
                table: "IssueTypes");

            migrationBuilder.DropColumn(
                name: "NameRus",
                table: "IssueTypes");
        }
    }
}
