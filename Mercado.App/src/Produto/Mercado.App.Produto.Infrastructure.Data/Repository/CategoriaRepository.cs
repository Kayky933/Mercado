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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ProdutoDbContext _context;
        public CategoriaRepository(ProdutoDbContext context)
        {
            _context = context;
        }

        #region Post, Put, Delet, Save
        public void Create(CategoriaModel entity)
        {
            _context.Categorias.Add(entity);
            SaveChangesDb();
        }
        public void Update(CategoriaModel entity)
        {
            _context.Categorias.Update(entity).State = EntityState.Modified;
            SaveChangesDb();
        }

        public void Delete(CategoriaModel entity)
        {
            _context.Categorias.Remove(entity);
            SaveChangesDb();
        }
        public void DeletAll()
        {
            string StringCommand = "TRUNCATE TABLE CATEGORIA";
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
            return await _context.Categorias.Select(x => new { x.Descricao }).ToListAsync();
        }

        public async Task<IEnumerable<CategoriaModel>> GetAllWithId()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<CategoriaModel> GetOneById(int id)
        {
            return await _context.Categorias.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<CategoriaModel> GetByDescriptionCategory(string description)
        {
            return await _context.Categorias.Where(x => x.Descricao.ToUpper().Trim() == description.ToUpper().Trim()).FirstOrDefaultAsync();
        }
        #endregion
    }
}
