using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.App.Produto.Infrastructure.Data.Migrations
{
    public partial class IniciandoImplementacaoDeVendasFaseTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_CATEGORIA_CategoriaId",
                table: "PRODUTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUTO",
                table: "PRODUTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CATEGORIA",
                table: "CATEGORIA");

            migrationBuilder.RenameTable(
                name: "PRODUTO",
                newName: "PRODUTOS");

            migrationBuilder.RenameTable(
                name: "CATEGORIA",
                newName: "CATEGORIAS");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUTO_CategoriaId",
                table: "PRODUTOS",
                newName: "IX_PRODUTOS_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUTOS",
                table: "PRODUTOS",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CATEGORIAS",
                table: "CATEGORIAS",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "VENDAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VENDAS_PRODUTOS_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "PRODUTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_IdProduto",
                table: "VENDAS",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTOS_CATEGORIAS_CategoriaId",
                table: "PRODUTOS",
                column: "CategoriaId",
                principalTable: "CATEGORIAS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTOS_CATEGORIAS_CategoriaId",
                table: "PRODUTOS");

            migrationBuilder.DropTable(
                name: "VENDAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUTOS",
                table: "PRODUTOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CATEGORIAS",
                table: "CATEGORIAS");

            migrationBuilder.RenameTable(
                name: "PRODUTOS",
                newName: "PRODUTO");

            migrationBuilder.RenameTable(
                name: "CATEGORIAS",
                newName: "CATEGORIA");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUTOS_CategoriaId",
                table: "PRODUTO",
                newName: "IX_PRODUTO_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUTO",
                table: "PRODUTO",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CATEGORIA",
                table: "CATEGORIA",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_CATEGORIA_CategoriaId",
                table: "PRODUTO",
                column: "CategoriaId",
                principalTable: "CATEGORIA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
