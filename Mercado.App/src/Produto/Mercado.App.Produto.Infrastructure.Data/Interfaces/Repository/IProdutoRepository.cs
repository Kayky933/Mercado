using Mercado.App.Produto.Domain.Models.Prateleira;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository
{
    public interface IProdutoRepository : IBaseReposiroey<ProdutoModel>
    {
        Task<IEnumerable<object>> GetAllByCategory(int id);
        Task<bool> CategoryExists(int id);
        Task<ProdutoModel> GetByDescriptionProduct(string description);
    }
}
