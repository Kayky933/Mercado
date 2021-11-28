using Mercado.App.Domain.Models.Venda;
using Mercado.App.Infrastructure.Data.Interfaces.Repository;
using Mercado.App.Infrastructure.Data.ProdutoDatabase;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.App.Infrastructure.Data.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private readonly ProdutoDbContext _context;
        public VendaRepository(ProdutoDbContext context)
        {
            _context = context;
        }
        public void Create(VendaModel entity)
        {
            _context.Vendas.Add(entity);
            SaveChangesDb();
        }

        public void Delete(VendaModel entity)
        {
            _context.Remove(entity);
            SaveChangesDb();
        }

        public async Task<IEnumerable<object>> GetAll()
        {
            return await _context.Vendas.Select(x => new { x.Produto.Descricao, x.Quantidade, x.ValorPago }).ToListAsync();
        }

        public async Task<IEnumerable<VendaModel>> GetAllWithId()
        {
            return await _context.Vendas.ToListAsync();
        }

        public async Task<VendaModel> GetOneById(int id)
        {
            return await _context.Vendas.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void SaveChangesDb()
        {
            _context.SaveChanges();
        }

        public void Update(VendaModel entity)
        {
            _context.Vendas.Update(entity).State = EntityState.Modified;
            SaveChangesDb();
        }
    }
}
