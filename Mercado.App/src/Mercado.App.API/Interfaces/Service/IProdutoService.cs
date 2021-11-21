using Mercado.App.Domain.Models.Prateleira;
using Mercado.App.Domain.Models.Prateleira.PrateleiraViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.API.Interfaces.Service
{
    public interface IProdutoService : IBaseService<ProdutoModel>
    {
        Task<IEnumerable<object>> GettAllProductsBycategory(int id);
        Task<object> CreateProduct(ProdutoViewModel produto);
        Task<object> PutProduct(int id, ProdutoViewModel produto);
        Task<ProdutoModel> GetByDescriptionProduct(string description);
    }
}
