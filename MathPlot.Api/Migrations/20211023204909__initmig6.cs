using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MathPlot.Api.Migrations
{
    public partial class _initmig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f18ccc8e-1e9a-4d86-be1b-5c2c8a55f4cf"));

            migrationBuilder.AlterColumn<double>(
                name: "r",
                table: "MappingPlanks",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("affd2616-5558-4cd5-acf0-f18e50ef402c"), "deevzmak1234@mail.ru", "Максим", true, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("affd2616-5558-4cd5-acf0-f18e50ef402c"));

            migrationBuilder.AlterColumn<int>(
                name: "r",
                table: "MappingPlanks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("f18ccc8e-1e9a-4d86-be1b-5c2c8a55f4cf"), "deevzmak1234@mail.ru", "Максим", true, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }
    }
}
