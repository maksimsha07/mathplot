using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MathPlot.Api.Migrations
{
    public partial class _initmig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d9fb4a4b-0f1e-4939-8cb5-a95b8cc63cfc"));

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("a2c4554a-cc1e-4e60-87d2-5bba3741ece7"), "deevzmak1234@mail.ru", "Максим", true, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a2c4554a-cc1e-4e60-87d2-5bba3741ece7"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "FirstName", "Genre", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("d9fb4a4b-0f1e-4939-8cb5-a95b8cc63cfc"), new DateTime(2001, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "deevzmak1234@mail.ru", "Максим", true, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }
    }
}
