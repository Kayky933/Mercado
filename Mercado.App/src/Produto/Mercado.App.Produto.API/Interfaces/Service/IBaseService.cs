using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.Produto.API.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<object>> GetAllProducts();
        Task<T> GetOneProductById(int id);
        Task<IEnumerable<object>> GettAllProductBycategory(int id);
        Task<IEnumerable<T>> GetAllProductsWithId();
        Task<bool> DeletProduct(int id);

    }
}
