using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathPlot.Api.Migrations
{
    public partial class mianmigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("68b5a52e-ae0e-468a-9228-2e55a9b7ace7"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "ImagePath", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("68b5a52e-ae0e-468a-9228-2e55a9b7ace7"), "deevzmak1234@mail.ru", "Максим", true, null, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }
    }
}
