using Mercado.App.Domain.Models.Prateleira;
using Mercado.App.Domain.Models.Venda;
using Microsoft.EntityFrameworkCore;

namespace Mercado.App.Infrastructure.Data.ProdutoDatabase
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //restringe a deleção de categorias com proutos vinculados
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProdutoModel>()
                .HasOne(x => x.Categoria)
                .WithMany(x => x.Produtos)
                .HasForeignKey(c => c.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            //restringe as deleção de produtos com vendas vinculadas
            modelBuilder.Entity<VendaModel>()
                .HasOne(x => x.Produto)
                .WithMany(x => x.Vendas)
                .HasForeignKey(x => x.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<VendaModel> Vendas { get; set; }
    }
}
