using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.App.Infrastructure.Data.Migrations
{
    public partial class ImplementacaoQuantidadeEstoqueProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "QuantidadeEstoque",
                table: "PRODUTOS",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeEstoque",
                table: "PRODUTOS");
        }
    }
}
