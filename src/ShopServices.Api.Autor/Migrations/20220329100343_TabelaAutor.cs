using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShopServices.Api.Autor.Migrations
{
    public partial class TabelaAutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutorLivros",
                columns: table => new
                {
                    AutorLivroId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying", unicode: false, maxLength: 80, nullable: false),
                    Apelido = table.Column<string>(type: "character varying", unicode: false, maxLength: 50, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AutorLivroGuid = table.Column<string>(type: "character varying", unicode: false, maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLivros", x => x.AutorLivroId);
                });

            migrationBuilder.CreateTable(
                name: "GrauAcademicos",
                columns: table => new
                {
                    GrauAcademicoId = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "character varying", unicode: false, nullable: false),
                    CentroAcademico = table.Column<string>(type: "character varying", unicode: false, nullable: false),
                    DataNota = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AutorLivroId = table.Column<int>(type: "integer", nullable: false),
                    GrauAcademicoGuid = table.Column<string>(type: "character varying", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrauAcademicos", x => x.GrauAcademicoId);
                    table.ForeignKey(
                        name: "FK_GrauAcademicos_AutorLivros_GrauAcademicoId",
                        column: x => x.GrauAcademicoId,
                        principalTable: "AutorLivros",
                        principalColumn: "AutorLivroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AutorLivros",
                columns: new[] { "AutorLivroId", "Apelido", "AutorLivroGuid", "DataNascimento", "Nome" },
                values: new object[,]
                {
                    { 1, "Mara", "49f9e020-808d-4fd0-8ce8-2bd76a7ba199", new DateTime(2022, 3, 29, 6, 3, 43, 756, DateTimeKind.Utc).AddTicks(2967), "Maria" },
                    { 2, "Pedra", "c7606156-c165-4da5-9e7d-28af654bb97d", new DateTime(2022, 3, 29, 6, 3, 43, 756, DateTimeKind.Utc).AddTicks(2978), "Pedro" },
                    { 3, "Tonho", "368e956e-f665-4291-9a1a-53fc4cb4338a", new DateTime(2022, 3, 29, 6, 3, 43, 756, DateTimeKind.Utc).AddTicks(2978), "Antonio" },
                    { 4, "Cabeça", "8bf309ec-b958-4bcd-99f4-c7dd110c376d", new DateTime(2022, 3, 29, 6, 3, 43, 756, DateTimeKind.Utc).AddTicks(2979), "Marcio" },
                    { 5, "Ana", "de2eb41d-c9fd-4a5f-bbd9-57a8759d5cdb", new DateTime(2022, 3, 29, 6, 3, 43, 756, DateTimeKind.Utc).AddTicks(2980), "Ana" },
                    { 6, "Zé", "25142ffd-7ea7-4de0-afce-3ec447536c27", new DateTime(2022, 3, 29, 6, 3, 43, 756, DateTimeKind.Utc).AddTicks(2980), "José" },
                    { 7, "JÔ", "cd6087c4-48c8-4c25-a704-41af2e0271b3", new DateTime(2022, 3, 29, 6, 3, 43, 756, DateTimeKind.Utc).AddTicks(2981), "Joana" },
                    { 8, "Alex", "90bd9ee0-da94-48ef-8377-a3d9122868d3", new DateTime(2022, 3, 29, 6, 3, 43, 756, DateTimeKind.Utc).AddTicks(2982), "Alessandro" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrauAcademicos");

            migrationBuilder.DropTable(
                name: "AutorLivros");
        }
    }
}
