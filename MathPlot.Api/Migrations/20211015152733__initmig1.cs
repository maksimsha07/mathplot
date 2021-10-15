using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MathPlot.Api.Migrations
{
    public partial class _initmig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "FirstName", "Genre", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("d9fb4a4b-0f1e-4939-8cb5-a95b8cc63cfc"), new DateTime(2001, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "deevzmak1234@mail.ru", "Максим", true, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d9fb4a4b-0f1e-4939-8cb5-a95b8cc63cfc"));
        }
    }
}
