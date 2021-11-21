using AutoMapper;
using Mercado.App.Domain.Models.Prateleira;
using Mercado.App.Domain.Models.Prateleira.PrateleiraViewModels;

namespace Mercado.App.API.Mapper
{
    public class AutoMapperClass : Profile
    {
        public AutoMapperClass()
        {
            CreateMap<ProdutoViewModel, ProdutoModel>();
            CreateMap<CategoriaViewModel, CategoriaModel>();
        }
    }
}
