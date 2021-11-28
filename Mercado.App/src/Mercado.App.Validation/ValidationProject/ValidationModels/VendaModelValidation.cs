using FluentValidation;
using Mercado.App.Domain.Models.Venda;

namespace Mercado.App.Validation.ValidationProject.ValidationModels
{
    public class VendaModelValidation : AbstractValidator<VendaModel>
    {
        public VendaModelValidation()
        {

            RuleFor(x => x.Quantidade).NotEmpty().WithMessage("z")
                .GreaterThanOrEqualTo(1).WithMessage("a");

        }
    }
}
