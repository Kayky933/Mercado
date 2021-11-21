using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.App.Infrastructure.Data.Migrations
{
    public partial class ModificacoesTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaModelProdutoModel_Categorias_CategoriasId",
                table: "CategoriaModelProdutoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaModelProdutoModel_Produtos_ProdutosId",
                table: "CategoriaModelProdutoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Estoque_InfoProdutoId",
                table: "Estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Produtos_ProdutoId",
                table: "Estoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estoque",
                table: "Estoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "Estoque",
                newName: "ESTOQUE");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "PRODUTO");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "CATEGORIA");

            migrationBuilder.RenameIndex(
                name: "IX_Estoque_ProdutoId",
                table: "ESTOQUE",
                newName: "IX_ESTOQUE_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Estoque_InfoProdutoId",
                table: "ESTOQUE",
                newName: "IX_ESTOQUE_InfoProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESTOQUE",
                table: "ESTOQUE",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUTO",
                table: "PRODUTO",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CATEGORIA",
                table: "CATEGORIA",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "InfoProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: true),
                    PrecoUnidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnidadeMedida = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoProduto_PRODUTO_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "PRODUTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfoProduto_ProdutoId",
                table: "InfoProduto",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaModelProdutoModel_CATEGORIA_CategoriasId",
                table: "CategoriaModelProdutoModel",
                column: "CategoriasId",
                principalTable: "CATEGORIA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaModelProdutoModel_PRODUTO_ProdutosId",
                table: "CategoriaModelProdutoModel",
                column: "ProdutosId",
                principalTable: "PRODUTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESTOQUE_InfoProduto_InfoProdutoId",
                table: "ESTOQUE",
                column: "InfoProdutoId",
                principalTable: "InfoProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ESTOQUE_PRODUTO_ProdutoId",
                table: "ESTOQUE",
                column: "ProdutoId",
                principalTable: "PRODUTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaModelProdutoModel_CATEGORIA_CategoriasId",
                table: "CategoriaModelProdutoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaModelProdutoModel_PRODUTO_ProdutosId",
                table: "CategoriaModelProdutoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ESTOQUE_InfoProduto_InfoProdutoId",
                table: "ESTOQUE");

            migrationBuilder.DropForeignKey(
                name: "FK_ESTOQUE_PRODUTO_ProdutoId",
                table: "ESTOQUE");

            migrationBuilder.DropTable(
                name: "InfoProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESTOQUE",
                table: "ESTOQUE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUTO",
                table: "PRODUTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CATEGORIA",
                table: "CATEGORIA");

            migrationBuilder.RenameTable(
                name: "ESTOQUE",
                newName: "Estoque");

            migrationBuilder.RenameTable(
                name: "PRODUTO",
                newName: "Produtos");

            migrationBuilder.RenameTable(
                name: "CATEGORIA",
                newName: "Categorias");

            migrationBuilder.RenameIndex(
                name: "IX_ESTOQUE_ProdutoId",
                table: "Estoque",
                newName: "IX_Estoque_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_ESTOQUE_InfoProdutoId",
                table: "Estoque",
                newName: "IX_Estoque_InfoProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estoque",
                table: "Estoque",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaModelProdutoModel_Categorias_CategoriasId",
                table: "CategoriaModelProdutoModel",
                column: "CategoriasId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaModelProdutoModel_Produtos_ProdutosId",
                table: "CategoriaModelProdutoModel",
                column: "ProdutosId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Estoque_InfoProdutoId",
                table: "Estoque",
                column: "InfoProdutoId",
                principalTable: "Estoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Produtos_ProdutoId",
                table: "Estoque",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
