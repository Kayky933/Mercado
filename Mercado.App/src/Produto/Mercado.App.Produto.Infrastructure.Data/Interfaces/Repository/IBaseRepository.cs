using Mercado.App.Produto.Domain.Models.Prateleira;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllProducts();
        public Task<T> GetOneProductById(int id);
        public Task<IEnumerable<T>> GettAllProductBycategory(int id);
        public void CreateProduct(T produto);
        public void DeletProduct(ProdutoModel produto);
        public void PutProduct(T produto);
        public void SaveChangesDb();
    }
}
