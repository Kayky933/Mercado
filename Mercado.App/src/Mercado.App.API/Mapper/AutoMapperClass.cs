using AutoMapper;
using Mercado.App.Domain.Models.Prateleira;
using Mercado.App.Domain.Models.Prateleira.PrateleiraViewModels;
using Mercado.App.Domain.Models.Venda;
using Mercado.App.Domain.Models.Venda.VendaViewModels;

namespace Mercado.App.API.Mapper
{
    public class AutoMapperClass : Profile
    {
        public AutoMapperClass()
        {
            CreateMap<ProdutoViewModel, ProdutoModel>();
            CreateMap<CategoriaViewModel, CategoriaModel>();
            CreateMap<VendaViewModel, VendaModel>();
        }
    }
}
