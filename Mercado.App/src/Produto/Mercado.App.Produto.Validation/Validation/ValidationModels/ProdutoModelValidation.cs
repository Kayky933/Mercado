using FluentValidation;
using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Validation.Validation.ErrorMessages;

namespace Mercado.App.Produto.Validation.Validation.ValidationModels
{
    public class ProdutoModelValidation : AbstractValidator<ProdutoModel>
    {
        public ProdutoModelValidation()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage(ProdutoErrorMessages.DescricaoVazia)
                .MinimumLength(3).WithMessage(ProdutoErrorMessages.DescricaoTamanhoMinimo)
                .MaximumLength(100).WithMessage(ProdutoErrorMessages.DescricaoTamanhoMaximo);
        }
    }
}
