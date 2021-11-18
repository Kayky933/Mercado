using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.Produto.API.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<object>> GetAll();
        Task<T> GetOneById(int id);
        Task<IEnumerable<T>> GetAllWithId();
        Task<object> Delet(int id);

        public void DeletAll();

    }
}
