using AutoMapper;
using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Domain.Models.ViewModels;

namespace Mercado.App.Produto.API.Mapper
{
    public class AutoMapperClass : Profile
    {
        public AutoMapperClass()
        {
            CreateMap<ProdutoViewModel, ProdutoModel>();
        }
    }
}
