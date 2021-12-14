using FizzWare.NBuilder;
using Mercado.App.Domain.Models.Venda;

namespace Mercado.App.UnitTests.Builder
{
    public class VendaModelBuilder : BuilderBase<VendaModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<VendaModel>.CreateNew()
                .With(x => x.IdProduto = 1)
                .With(x => x.Quantidade = 10);
        }
    }
}
