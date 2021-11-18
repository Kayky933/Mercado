using Mercado.App.Produto.Domain.Models.Prateleira;
using System.Threading.Tasks;

namespace Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository
{
    public interface ICategoriaRepository : IBaseReposiroey<CategoriaModel>
    {
        Task<CategoriaModel> GetByDescriptionCategory(string description);
    }
}
