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

            RuleFor(x => x.PrecoUnidade).NotEmpty().WithMessage(ProdutoErrorMessages.PrecoUnidadeVazio)
                .Must(x => x.GetType() == typeof(decimal)).WithMessage(ProdutoErrorMessages.PrecoUnidadeInvalido);

            RuleFor(x => x.UnidadeMedida).NotEmpty().WithMessage(ProdutoErrorMessages.UnidadeMedidaVazia)
                .Must(x => x.GetType() == typeof(UnidadeMedidaEnum)).WithMessage(ProdutoErrorMessages.UnidadeMedidaInvalida);
        }
    }
}
