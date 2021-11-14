using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.App.Produto.Infrastructure.Data.Migrations
{
    public partial class MudancasNasTabelasCamposModificados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoProduto_PRODUTO_ProdutoId",
                table: "InfoProduto");

            migrationBuilder.DropTable(
                name: "CategoriaModelProdutoModel");

            migrationBuilder.DropTable(
                name: "ESTOQUE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InfoProduto",
                table: "InfoProduto");

            migrationBuilder.DropIndex(
                name: "IX_InfoProduto_ProdutoId",
                table: "InfoProduto");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InfoProduto");

            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "InfoProduto");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "InfoProduto");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "PRODUTO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Informacoes_ProdutoPrecoUnidade",
                table: "PRODUTO",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InfoProduto",
                table: "InfoProduto",
                column: "PrecoUnidade");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_CategoriaId",
                table: "PRODUTO",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_Informacoes_ProdutoPrecoUnidade",
                table: "PRODUTO",
                column: "Informacoes_ProdutoPrecoUnidade");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_CATEGORIA_CategoriaId",
                table: "PRODUTO",
                column: "CategoriaId",
                principalTable: "CATEGORIA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_InfoProduto_Informacoes_ProdutoPrecoUnidade",
                table: "PRODUTO",
                column: "Informacoes_ProdutoPrecoUnidade",
                principalTable: "InfoProduto",
                principalColumn: "PrecoUnidade",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_CATEGORIA_CategoriaId",
                table: "PRODUTO");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_InfoProduto_Informacoes_ProdutoPrecoUnidade",
                table: "PRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTO_CategoriaId",
                table: "PRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTO_Informacoes_ProdutoPrecoUnidade",
                table: "PRODUTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InfoProduto",
                table: "InfoProduto");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "PRODUTO");

            migrationBuilder.DropColumn(
                name: "Informacoes_ProdutoPrecoUnidade",
                table: "PRODUTO");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "InfoProduto",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdProduto",
                table: "InfoProduto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "InfoProduto",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InfoProduto",
                table: "InfoProduto",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CategoriaModelProdutoModel",
                columns: table => new
                {
                    CategoriasId = table.Column<int>(type: "int", nullable: false),
                    ProdutosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaModelProdutoModel", x => new { x.CategoriasId, x.ProdutosId });
                    table.ForeignKey(
                        name: "FK_CategoriaModelProdutoModel_CATEGORIA_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "CATEGORIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaModelProdutoModel_PRODUTO_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "PRODUTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ESTOQUE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfoProdutoId = table.Column<int>(type: "int", nullable: true),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTOQUE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ESTOQUE_InfoProduto_InfoProdutoId",
                        column: x => x.InfoProdutoId,
                        principalTable: "InfoProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ESTOQUE_PRODUTO_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "PRODUTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfoProduto_ProdutoId",
                table: "InfoProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaModelProdutoModel_ProdutosId",
                table: "CategoriaModelProdutoModel",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_ESTOQUE_InfoProdutoId",
                table: "ESTOQUE",
                column: "InfoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ESTOQUE_ProdutoId",
                table: "ESTOQUE",
                column: "ProdutoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoProduto_PRODUTO_ProdutoId",
                table: "InfoProduto",
                column: "ProdutoId",
                principalTable: "PRODUTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
