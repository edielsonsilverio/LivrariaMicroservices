using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopServices.Api.Livro.Migrations
{
    public partial class ShopLivroInicialSqlServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bibliotecas",
                columns: table => new
                {
                    BibliotecaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AutorLivro = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliotecas", x => x.BibliotecaId);
                });

            migrationBuilder.InsertData(
                table: "Bibliotecas",
                columns: new[] { "BibliotecaId", "AutorLivro", "DataPublicacao", "Titulo" },
                values: new object[,]
                {
                    { new Guid("12324117-b504-4bfa-a2eb-4e584629f0d2"), new Guid("de2eb41d-c9fd-4a5f-bbd9-57a8759d5cdb"), new DateTime(2022, 3, 29, 10, 9, 16, 216, DateTimeKind.Utc).AddTicks(1650), "Titulo 05" },
                    { new Guid("17877ba0-6e53-4a66-ba94-8c86152b7d45"), new Guid("c7606156-c165-4da5-9e7d-28af654bb97d"), new DateTime(2022, 3, 29, 10, 9, 16, 216, DateTimeKind.Utc).AddTicks(1644), "Titulo 02" },
                    { new Guid("189dd0ad-606a-472c-b1f8-3e764a21d297"), new Guid("49f9e020-808d-4fd0-8ce8-2bd76a7ba199"), new DateTime(2022, 3, 29, 10, 9, 16, 216, DateTimeKind.Utc).AddTicks(1640), "Titulo 01" },
                    { new Guid("60f033ca-8718-4a60-98d2-45c2e4d68b56"), new Guid("cd6087c4-48c8-4c25-a704-41af2e0271b3"), new DateTime(2022, 3, 29, 10, 9, 16, 216, DateTimeKind.Utc).AddTicks(1654), "Titulo 07" },
                    { new Guid("6c02b533-1f7c-4e47-bcc8-a24bb5412c26"), new Guid("368e956e-f665-4291-9a1a-53fc4cb4338a"), new DateTime(2022, 3, 29, 10, 9, 16, 216, DateTimeKind.Utc).AddTicks(1647), "Titulo 03" },
                    { new Guid("6ebf97db-7b1c-4398-8fe4-4b16217db901"), new Guid("25142ffd-7ea7-4de0-afce-3ec447536c27"), new DateTime(2022, 3, 29, 10, 9, 16, 216, DateTimeKind.Utc).AddTicks(1652), "Titulo 06" },
                    { new Guid("bde285f7-17e0-4c77-a7ac-9e44839c6027"), new Guid("8bf309ec-b958-4bcd-99f4-c7dd110c376d"), new DateTime(2022, 3, 29, 10, 9, 16, 216, DateTimeKind.Utc).AddTicks(1649), "Titulo 04" },
                    { new Guid("db84bc00-0cb1-4bec-baed-17dcfec26f03"), new Guid("90bd9ee0-da94-48ef-8377-a3d9122868d3"), new DateTime(2022, 3, 29, 10, 9, 16, 216, DateTimeKind.Utc).AddTicks(1663), "Titulo 08" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bibliotecas");
        }
    }
}
