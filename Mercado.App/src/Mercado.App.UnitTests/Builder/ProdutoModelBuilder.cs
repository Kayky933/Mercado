using FizzWare.NBuilder;
using Mercado.App.Domain.Models.Prateleira;

namespace Mercado.App.UnitTests.Builder
{
    public class ProdutoModelBuilder : BuilderBase<ProdutoModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<ProdutoModel>.CreateNew()
                .With(x => x.Descricao = "ABC")
                .With(x => x.CategoriaId = 5)
                .With(x => x.PrecoUnidade = 1.99M)
                .With(x => x.UnidadeMedida = UnidadeMedidaEnum.grama);
        }
    }
}
