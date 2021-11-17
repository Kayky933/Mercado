using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Domain.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.Produto.API.Interfaces.Service
{
    public interface IProdutoService : IBaseService<ProdutoModel>
    {
        Task<IEnumerable<object>> GettAllProductsBycategory(int id);
        Task<object> CreateProduct(ProdutoViewModel produto);
        Task<object> PutProduct(int id, ProdutoViewModel produto);
        Task<ProdutoModel> GetByDescriptionProduct(string description);
    }
}
