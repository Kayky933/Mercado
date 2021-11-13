using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.App.Produto.Infrastructure.Data.Migrations
{
    public partial class AlterandoChavePrimariainfoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_InfoProduto_Informacoes_ProdutoPrecoUnidade",
                table: "PRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTO_Informacoes_ProdutoPrecoUnidade",
                table: "PRODUTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InfoProduto",
                table: "InfoProduto");

            migrationBuilder.DropColumn(
                name: "Informacoes_ProdutoPrecoUnidade",
                table: "PRODUTO");

            migrationBuilder.AddColumn<int>(
                name: "Informacoes_ProdutoId",
                table: "PRODUTO",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoUnidade",
                table: "InfoProduto",
                type: "decimal(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "InfoProduto",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InfoProduto",
                table: "InfoProduto",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_Informacoes_ProdutoId",
                table: "PRODUTO",
                column: "Informacoes_ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_InfoProduto_Informacoes_ProdutoId",
                table: "PRODUTO",
                column: "Informacoes_ProdutoId",
                principalTable: "InfoProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_InfoProduto_Informacoes_ProdutoId",
                table: "PRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTO_Informacoes_ProdutoId",
                table: "PRODUTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InfoProduto",
                table: "InfoProduto");

            migrationBuilder.DropColumn(
                name: "Informacoes_ProdutoId",
                table: "PRODUTO");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InfoProduto");

            migrationBuilder.AddColumn<decimal>(
                name: "Informacoes_ProdutoPrecoUnidade",
                table: "PRODUTO",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoUnidade",
                table: "InfoProduto",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InfoProduto",
                table: "InfoProduto",
                column: "PrecoUnidade");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_Informacoes_ProdutoPrecoUnidade",
                table: "PRODUTO",
                column: "Informacoes_ProdutoPrecoUnidade");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_InfoProduto_Informacoes_ProdutoPrecoUnidade",
                table: "PRODUTO",
                column: "Informacoes_ProdutoPrecoUnidade",
                principalTable: "InfoProduto",
                principalColumn: "PrecoUnidade",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
