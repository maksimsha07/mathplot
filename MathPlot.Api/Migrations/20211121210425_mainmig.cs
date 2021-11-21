using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MathPlot.Api.Migrations
{
    public partial class mainmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e100543-6395-4ce4-bb72-7d42f4a5be43"));

            migrationBuilder.DropColumn(
                name: "lestlameri",
                table: "MappingSinus");

            migrationBuilder.DropColumn(
                name: "lestlameri",
                table: "MappingPlanks");

            migrationBuilder.CreateTable(
                name: "mappingGausses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    r = table.Column<double>(type: "double precision", nullable: false),
                    bifur = table.Column<bool>(type: "boolean", nullable: false),
                    pokazlapuniva = table.Column<bool>(type: "boolean", nullable: false),
                    path = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mappingGausses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mappingGausses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mappingLogistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    r = table.Column<double>(type: "double precision", nullable: false),
                    bifur = table.Column<bool>(type: "boolean", nullable: false),
                    pokazlapuniva = table.Column<bool>(type: "boolean", nullable: false),
                    path = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mappingLogistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mappingLogistics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mappingTwos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    r = table.Column<double>(type: "double precision", nullable: false),
                    bifur = table.Column<bool>(type: "boolean", nullable: false),
                    pokazlapuniva = table.Column<bool>(type: "boolean", nullable: false),
                    path = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mappingTwos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mappingTwos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "ImagePath", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("892b8eaf-16bc-499d-957c-0d4fd9f6c31f"), "deevzmak1234@mail.ru", "Максим", true, null, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });

            migrationBuilder.CreateIndex(
                name: "IX_mappingGausses_UserId",
                table: "mappingGausses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_mappingLogistics_UserId",
                table: "mappingLogistics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_mappingTwos_UserId",
                table: "mappingTwos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mappingGausses");

            migrationBuilder.DropTable(
                name: "mappingLogistics");

            migrationBuilder.DropTable(
                name: "mappingTwos");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("892b8eaf-16bc-499d-957c-0d4fd9f6c31f"));

            migrationBuilder.AddColumn<bool>(
                name: "lestlameri",
                table: "MappingSinus",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "lestlameri",
                table: "MappingPlanks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Genre", "ImagePath", "LastName", "Login", "Password", "Phone" },
                values: new object[] { new Guid("9e100543-6395-4ce4-bb72-7d42f4a5be43"), "deevzmak1234@mail.ru", "Максим", true, null, "Чешихин", "Maksim", "qwertyuiop123", 89094352590L });
        }
    }
}
