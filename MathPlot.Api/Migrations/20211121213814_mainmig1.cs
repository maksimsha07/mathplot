using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MathPlot.Api.Migrations
{
    public partial class mainmig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("892b8eaf-16bc-499d-957c-0d4fd9f6c31f"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "ImagePath", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("68b5a52e-ae0e-468a-9228-2e55a9b7ace7"), "deevzmak1234@mail.ru", "Максим", true, null, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("68b5a52e-ae0e-468a-9228-2e55a9b7ace7"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "ImagePath", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("892b8eaf-16bc-499d-957c-0d4fd9f6c31f"), "deevzmak1234@mail.ru", "Максим", true, null, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }
    }
}
