using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository;
using Mercado.App.Produto.Infrastructure.Data.ProdutoDatabase;
using Microsoft.Data.SqlClient;
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

        #region Post, Put, Delet, Save
        public void Create(ProdutoModel entity)
        {
            _context.Produtos.Add(entity);
            SaveChangesDb();
        }
        public void Update(ProdutoModel entity)
        {
            _context.Produtos.Update(entity).State = EntityState.Modified;
            SaveChangesDb();
        }

        public void Delete(ProdutoModel entity)
        {
            _context.Produtos.Remove(entity);
            SaveChangesDb();
        }
        public void DeletAll()
        {
            string StringCommand = "TRUNCATE TABLE PRODUTO";
            var conn = new
                   SqlConnection("Server=(localdb)\\mssqllocaldb;Database=ProdutoDb2;Trusted_Connection=True;MultipleActiveResultSets=true");
            conn.Open();

            SqlCommand cmd = new SqlCommand(StringCommand, conn);
            cmd.ExecuteNonQuery();
        }

        public void SaveChangesDb()
        {
            _context.SaveChanges();
        }
        #endregion

        #region Gets
        public async Task<IEnumerable<object>> GetAll()
        {
            return await _context.Produtos.Select(x => new { x.Descricao, x.CategoriaId, x.PrecoUnidade, x.UnidadeMedida }).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetAllByCategory(int id)
        {
            var categorias = await _context.Produtos.Where(x => x.CategoriaId == id).Select(x => new { x.Descricao, x.CategoriaId, x.PrecoUnidade, x.UnidadeMedida }).ToListAsync();
            if (categorias == null)
                return null;
            return categorias;
        }

        public async Task<ProdutoModel> GetOneById(int id)
        {
            return await _context.Produtos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProdutoModel>> GetAllWithId()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<ProdutoModel> GetByDescriptionProduct(string description)
        {
            return await _context.Produtos.Where(x => x.Descricao.ToUpper().Trim() == description.ToUpper().Trim()).FirstOrDefaultAsync();
        }

        public async Task<bool> CategoryExists(int id)
        {
           var produtos = await _context.Produtos.AnyAsync(x => x.CategoriaId == id);
            if (!produtos)
                return false;
            return true;
        }
        #endregion
    }
}
