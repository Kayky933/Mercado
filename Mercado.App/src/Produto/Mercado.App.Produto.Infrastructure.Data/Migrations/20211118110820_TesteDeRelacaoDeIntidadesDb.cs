using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.App.Produto.Infrastructure.Data.Migrations
{
    public partial class TesteDeRelacaoDeIntidadesDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_CATEGORIA_CategoriaId",
                table: "PRODUTO");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_CATEGORIA_CategoriaId",
                table: "PRODUTO",
                column: "CategoriaId",
                principalTable: "CATEGORIA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_CATEGORIA_CategoriaId",
                table: "PRODUTO");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_CATEGORIA_CategoriaId",
                table: "PRODUTO",
                column: "CategoriaId",
                principalTable: "CATEGORIA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
