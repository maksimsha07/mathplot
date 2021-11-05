using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MathPlot.Api.Migrations
{
    public partial class _initmig12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2e7a4b19-eba9-4601-acc2-0dc502e9da12"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "MappingPlanks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "path",
                table: "MappingPlanks",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("2077a3e5-3101-48ce-93fb-81a6a5db398d"), "deevzmak1234@mail.ru", "Максим", true, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });

            migrationBuilder.CreateIndex(
                name: "IX_MappingPlanks_UserId",
                table: "MappingPlanks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MappingPlanks_Users_UserId",
                table: "MappingPlanks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MappingPlanks_Users_UserId",
                table: "MappingPlanks");

            migrationBuilder.DropIndex(
                name: "IX_MappingPlanks_UserId",
                table: "MappingPlanks");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2077a3e5-3101-48ce-93fb-81a6a5db398d"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MappingPlanks");

            migrationBuilder.DropColumn(
                name: "path",
                table: "MappingPlanks");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("2e7a4b19-eba9-4601-acc2-0dc502e9da12"), "deevzmak1234@mail.ru", "Максим", true, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }
    }
}
