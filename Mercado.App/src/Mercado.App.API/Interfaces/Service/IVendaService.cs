using Mercado.App.Domain.Models.Venda;
using Mercado.App.Domain.Models.Venda.VendaViewModels;
using System.Threading.Tasks;

namespace Mercado.App.API.Interfaces.Service
{
    public interface IVendaService : IBaseService<VendaModel>
    {
        Task<object> CreateVenda(VendaViewModel venda);
        Task<object> PutVenda(int id, VendaViewModel venda);
    }
}
