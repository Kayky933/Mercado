using FluentValidation;
using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository;
using Mercado.App.Produto.Validation.Validation.ErrorMessages;

namespace Mercado.App.Produto.Validation.Validation.ValidationModels
{
    public class CategoriaModelValidation : AbstractValidator<CategoriaModel>
    {
        public CategoriaModelValidation(ICategoriaRepository repository)
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage(CategoriaErrorMessages.DescricaoVazia)
               .MinimumLength(3).WithMessage(CategoriaErrorMessages.DescricaoTamanhoMaximo)
                .MaximumLength(100).WithMessage(CategoriaErrorMessages.DescricaoTamanhoMinimo);
        }
    }
}
