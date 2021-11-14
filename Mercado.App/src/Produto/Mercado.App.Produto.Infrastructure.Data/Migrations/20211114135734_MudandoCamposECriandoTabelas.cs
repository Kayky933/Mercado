using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.App.Produto.Infrastructure.Data.Migrations
{
    public partial class MudandoCamposECriandoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_InfoProduto_Informacoes_ProdutoId",
                table: "PRODUTO");

            migrationBuilder.DropTable(
                name: "InfoProduto");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTO_Informacoes_ProdutoId",
                table: "PRODUTO");

            migrationBuilder.DropColumn(
                name: "Informacoes_ProdutoId",
                table: "PRODUTO");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoUnidade",
                table: "PRODUTO",
                type: "decimal(12,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UnidadeMedida",
                table: "PRODUTO",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoUnidade",
                table: "PRODUTO");

            migrationBuilder.DropColumn(
                name: "UnidadeMedida",
                table: "PRODUTO");

            migrationBuilder.AddColumn<int>(
                name: "Informacoes_ProdutoId",
                table: "PRODUTO",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InfoProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecoUnidade = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    UnidadeMedida = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoProduto", x => x.Id);
                });

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
    }
}
