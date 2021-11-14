using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.Produto.API.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllProducts();
        public Task<T> GetOneProductById(int id);
        public Task<IEnumerable<object>> GettAllProductBycategory(int id);       
        public Task<bool> DeletProduct(int id);
        public Task<object> PutProduct(int id, T produto);
    }
}
