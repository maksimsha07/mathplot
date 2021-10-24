using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MathPlot.Api.Migrations
{
    public partial class _initmig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("53b52c4f-2192-419b-a62f-6738814760ad"));

            migrationBuilder.CreateTable(
                name: "MappingPlanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    r = table.Column<int>(type: "integer", nullable: false),
                    lestlameri = table.Column<bool>(type: "boolean", nullable: false),
                    bifur = table.Column<bool>(type: "boolean", nullable: false),
                    pokazlapuniva = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MappingPlanks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("146b2c92-e2d1-4487-af79-ab9476731f5c"), "deevzmak1234@mail.ru", "Максим", true, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MappingPlanks");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("146b2c92-e2d1-4487-af79-ab9476731f5c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("53b52c4f-2192-419b-a62f-6738814760ad"), "deevzmak1234@mail.ru", "Максим", true, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }
    }
}
