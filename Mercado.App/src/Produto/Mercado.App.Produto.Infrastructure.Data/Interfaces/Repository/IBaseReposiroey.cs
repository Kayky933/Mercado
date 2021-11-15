using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository
{
    public interface IBaseReposiroey<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChangesDb();
        Task<IEnumerable<T>> GetAllProdWithId();
        Task<IEnumerable<object>> GetAll();
    }
}
