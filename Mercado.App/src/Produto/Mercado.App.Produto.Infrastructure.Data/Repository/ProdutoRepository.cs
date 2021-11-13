using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository;
using Mercado.App.Produto.Infrastructure.Data.ProdutoDatabase;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.App.Produto.Infrastructure.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoDbContext _context;
        public ProdutoRepository(ProdutoDbContext context)
        {
            _context = context;
        }
        public void CreateProduct(ProdutoModel produto)
        {
            _context.AddAsync(produto);
            SaveChangesDb();
        }

        public void DeletProduct(ProdutoModel produto)
        {
            _context.Produtos.Remove(produto);
            SaveChangesDb();
        }

        public async Task<IEnumerable<ProdutoModel>> GetAllProducts()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<ProdutoModel> GetOneProductById(int id)
        {
            return await _context.Produtos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProdutoModel>> GettAllProductBycategory(int id)
        {
            return await _context.Produtos.Where(x => x.CategoriaId == id).ToListAsync();
        }

        public void PutProduct(ProdutoModel produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            SaveChangesDb();
        }
        public void SaveChangesDb()
        {
            _context.SaveChangesAsync();
        }

    }
}
