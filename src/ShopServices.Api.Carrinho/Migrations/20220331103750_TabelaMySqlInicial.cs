using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopServices.Api.Carrinho.Migrations
{
    public partial class TabelaMySqlInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Carrinho",
                columns: table => new
                {
                    CarrinhoCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinho", x => x.CarrinhoCompraId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CarrinhoItem",
                columns: table => new
                {
                    CarrinhoItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ProdutoSelecionado = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarrinhoCompraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoItem", x => x.CarrinhoItemId);
                    table.ForeignKey(
                        name: "FK_CarrinhoItem_Carrinho_CarrinhoCompraId",
                        column: x => x.CarrinhoCompraId,
                        principalTable: "Carrinho",
                        principalColumn: "CarrinhoCompraId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItem_CarrinhoCompraId",
                table: "CarrinhoItem",
                column: "CarrinhoCompraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoItem");

            migrationBuilder.DropTable(
                name: "Carrinho");
        }
    }
}
