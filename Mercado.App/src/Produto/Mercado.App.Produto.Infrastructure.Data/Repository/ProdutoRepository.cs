using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository;
using Mercado.App.Produto.Infrastructure.Data.ProdutoDatabase;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.App.entity.Infrastructure.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoDbContext _context;
        public ProdutoRepository(ProdutoDbContext context)
        {
            _context = context;
        }

        public void Create(ProdutoModel entity)
        {
            _context.Produtos.Add(entity);
            SaveChangesDb();
        }

        public void Delete(ProdutoModel entity)
        {
            _context.Produtos.Remove(entity);
            SaveChangesDb();
        }
        public void Update(ProdutoModel entity)
        {
            _context.Update(entity).State = EntityState.Modified;
            SaveChangesDb();
        }

        public async Task<IEnumerable<ProdutoModel>> GetAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<IEnumerable<ProdutoModel>> GetOneByCategoey(int id)
        {
            return await _context.Produtos.Where(x => x.CategoriaId == id).ToListAsync();
        }

        public async Task<ProdutoModel> GetOneById(int id)
        {
            return await _context.Produtos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void SaveChangesDb()
        {
            _context.SaveChanges();
        }

    }
}
