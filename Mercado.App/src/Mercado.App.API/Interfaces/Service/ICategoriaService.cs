using Mercado.App.Domain.Models.Prateleira;
using Mercado.App.Domain.Models.Prateleira.PrateleiraViewModels;
using System.Threading.Tasks;

namespace Mercado.App.API.Interfaces.Service
{
    public interface ICategoriaService : IBaseService<CategoriaModel>
    {
        Task<object> CreateCategory(CategoriaViewModel produto);
        Task<object> PutCategory(int id, CategoriaViewModel produto);
        Task<object> GetByDescriptionCategory(string description);
    }
}
