using Mercado.App.Produto.Domain.Models.Prateleira;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository
{
    public interface IProdutoRepository : IBaseReposiroey<ProdutoModel>
    {
        Task<ProdutoModel> GetOneById(int id);
        Task<IEnumerable<ProdutoModel>> GetOneByCategoey(int id);
    }
}
