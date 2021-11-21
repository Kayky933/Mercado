using Mercado.App.Domain.Models.Prateleira;
using System.Threading.Tasks;

namespace Mercado.App.Infrastructure.Data.Interfaces.Repository
{
    public interface ICategoriaRepository : IBaseReposiroey<CategoriaModel>
    {
        Task<CategoriaModel> GetByDescriptionCategory(string description);
    }
}
