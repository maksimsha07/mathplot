using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MathPlot.Api.Migrations
{
    public partial class _initmig13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2077a3e5-3101-48ce-93fb-81a6a5db398d"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "MappingSinus",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "path",
                table: "MappingSinus",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("0f2eb7e2-46a0-429c-97a2-94931e9a8b03"), "deevzmak1234@mail.ru", "Максим", true, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });

            migrationBuilder.CreateIndex(
                name: "IX_MappingSinus_UserId",
                table: "MappingSinus",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MappingSinus_Users_UserId",
                table: "MappingSinus",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MappingSinus_Users_UserId",
                table: "MappingSinus");

            migrationBuilder.DropIndex(
                name: "IX_MappingSinus_UserId",
                table: "MappingSinus");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0f2eb7e2-46a0-429c-97a2-94931e9a8b03"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MappingSinus");

            migrationBuilder.DropColumn(
                name: "path",
                table: "MappingSinus");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("2077a3e5-3101-48ce-93fb-81a6a5db398d"), "deevzmak1234@mail.ru", "Максим", true, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }
    }
}
