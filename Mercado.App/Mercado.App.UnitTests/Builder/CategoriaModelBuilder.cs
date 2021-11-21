using FizzWare.NBuilder;
using Mercado.App.Produto.Domain.Models.Prateleira;

namespace Mercado.App.UnitTests.Builder
{
    public class CategoriaModelBuilder : BuilderBase<CategoriaModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<CategoriaModel>.CreateNew()
                .With(x => x.Descricao = "Enlatado");
        }
    }
}
