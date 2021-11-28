using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.App.Infrastructure.Data.Migrations
{
    public partial class TesteDeMudancaDeCamposVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VENDAS_PRODUTOS_IdProduto",
                table: "VENDAS");

            migrationBuilder.AddForeignKey(
                name: "FK_VENDAS_PRODUTOS_IdProduto",
                table: "VENDAS",
                column: "IdProduto",
                principalTable: "PRODUTOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VENDAS_PRODUTOS_IdProduto",
                table: "VENDAS");

            migrationBuilder.AddForeignKey(
                name: "FK_VENDAS_PRODUTOS_IdProduto",
                table: "VENDAS",
                column: "IdProduto",
                principalTable: "PRODUTOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
