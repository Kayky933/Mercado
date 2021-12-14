using FluentValidation;
using Mercado.App.Domain.Models.Venda;
using Mercado.App.Validation.ValidationProject.ErrorMessages;

namespace Mercado.App.Validation.ValidationProject.ValidationModels
{
    public class VendaModelValidation : AbstractValidator<VendaModel>
    {
        public VendaModelValidation()
        {

            RuleFor(x => x.Quantidade).NotEmpty().WithMessage(VendaErrorMessages.QuantidadeNula)
                .GreaterThanOrEqualTo(1).WithMessage(VendaErrorMessages.QuantidadeMinima);

            RuleFor(x => x.IdProduto).NotEmpty().WithMessage(VendaErrorMessages.ProdutoIdNulo)
            .GreaterThanOrEqualTo(1).WithMessage(VendaErrorMessages.IdProdutoMinimo);
        }
    }
}
