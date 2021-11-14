using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Domain.Models.ViewModels;
using System.Threading.Tasks;

namespace Mercado.App.Produto.API.Interfaces.Service
{
    public interface IProdutoService : IBaseService<ProdutoModel>
    {
        public Task<object> CreateProduct(ProdutoViewModel produto);
    }
}
