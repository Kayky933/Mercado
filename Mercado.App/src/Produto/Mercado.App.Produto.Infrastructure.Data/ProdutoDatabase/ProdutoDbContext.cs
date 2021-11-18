using Mercado.App.Produto.Domain.Models.Prateleira;
using Microsoft.EntityFrameworkCore;

namespace Mercado.App.Produto.Infrastructure.Data.ProdutoDatabase
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProdutoModel>()
                .HasOne(x => x.Categoria)
                .WithMany(x => x.Produtos)
                .HasForeignKey(c => c.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
    }
}
