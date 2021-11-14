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
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }   
    }
}
