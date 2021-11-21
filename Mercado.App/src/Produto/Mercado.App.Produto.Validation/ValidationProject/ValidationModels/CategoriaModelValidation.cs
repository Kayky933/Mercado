using FluentValidation;
using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Validation.Validation.ErrorMessages;

namespace Mercado.App.Produto.Validation.ValidationProject.ValidationModels
{
    public class CategoriaModelValidation : AbstractValidator<CategoriaModel>
    {
        public CategoriaModelValidation()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage(DefaultErrorMessages.DescricaoVazia)
               .MinimumLength(3).WithMessage(DefaultErrorMessages.DescricaoTamanhoMinimo)
                .MaximumLength(100).WithMessage(DefaultErrorMessages.DescricaoTamanhoMaximo);
        }
    }
}
