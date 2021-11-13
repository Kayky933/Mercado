using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.Produto.API.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllProducts();
        public Task<T> GetOneProductById(int id);
        public Task<IEnumerable<T>> GettAllProductBycategory(int id);
        public Task<ValidationResult> CreateProduct(T produto);
        public Task<ValidationResult> DeletProduct(int id);
        public Task<ValidationResult> PutProduct(int id, T produto);
    }
}
