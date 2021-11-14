using Mercado.App.Produto.Domain.Models.Prateleira;
using Microsoft.EntityFrameworkCore;

namespace Mercado.App.Produto.Infrastructure.Data.ProdutoDatabase
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoDbContext).Assembly);
        }
    }
}
