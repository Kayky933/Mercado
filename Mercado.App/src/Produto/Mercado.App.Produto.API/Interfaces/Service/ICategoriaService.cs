using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Domain.Models.ViewModels;
using System.Threading.Tasks;

namespace Mercado.App.Produto.API.Interfaces.Service
{
    public interface ICategoriaService : IBaseService<CategoriaModel>
    {
        Task<object> CreateCategory(CategoriaViewModel produto);
        Task<object> PutCategory(int id, CategoriaViewModel produto);
        Task<object> GetByDescriptionCategory(string description);
    }
}
