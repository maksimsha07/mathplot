using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MathPlot.Api.Migrations
{
    public partial class _initmig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("146b2c92-e2d1-4487-af79-ab9476731f5c"));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MappingPlanks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("f18ccc8e-1e9a-4d86-be1b-5c2c8a55f4cf"), "deevzmak1234@mail.ru", "Максим", true, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f18ccc8e-1e9a-4d86-be1b-5c2c8a55f4cf"));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MappingPlanks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("146b2c92-e2d1-4487-af79-ab9476731f5c"), "deevzmak1234@mail.ru", "Максим", true, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }
    }
}
