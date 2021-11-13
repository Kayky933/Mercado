using Mercado.App.Produto.Domain.Models.Prateleira;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.App.Produto.Infrastructure.Data.ProdutoDatabase
{
    public class ProdutoDbContext:DbContext
    {
        public ProdutoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<EstoqueProdutoModel> Estoque { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoDbContext).Assembly);
        }
    }
}
