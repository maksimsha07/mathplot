using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MathPlot.Api.Migrations
{
    public partial class _initmig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a2c4554a-cc1e-4e60-87d2-5bba3741ece7"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("53b52c4f-2192-419b-a62f-6738814760ad"), "deevzmak1234@mail.ru", "Максим", true, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("53b52c4f-2192-419b-a62f-6738814760ad"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("a2c4554a-cc1e-4e60-87d2-5bba3741ece7"), "deevzmak1234@mail.ru", "Максим", true, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }
    }
}
