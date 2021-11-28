using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.App.Infrastructure.Data.Migrations
{
    public partial class mudandoCampoDeValorVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorPago",
                table: "VENDAS",
                type: "decimal(12,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorPago",
                table: "VENDAS");
        }
    }
}
