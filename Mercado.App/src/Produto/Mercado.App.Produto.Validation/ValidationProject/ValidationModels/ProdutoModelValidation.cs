using FluentValidation;
using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Validation.Validation.ErrorMessages;

namespace Mercado.App.Produto.Validation.ValidationProject.ValidationModels
{
    public class ProdutoModelValidation : AbstractValidator<ProdutoModel>
    {
        public ProdutoModelValidation()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage(DefaultErrorMessages.DescricaoVazia)
                .MinimumLength(3).WithMessage(DefaultErrorMessages.DescricaoTamanhoMinimo)
                .MaximumLength(100).WithMessage(DefaultErrorMessages.DescricaoTamanhoMaximo);

            RuleFor(x => x.CategoriaId).NotEmpty().WithMessage(ProdutoErrorMessages.CategoriaIvalida)
                .GreaterThanOrEqualTo(1).WithMessage(ProdutoErrorMessages.CategoriaInexixtente);

            RuleFor(x => x.PrecoUnidade).NotEmpty().WithMessage(ProdutoErrorMessages.PrecoUnidadeVazio)
                .GreaterThanOrEqualTo(0.99M).WithMessage(ProdutoErrorMessages.PrecoMinimo)
                .Must(x => x.GetType() == typeof(decimal)).WithMessage(ProdutoErrorMessages.PrecoUnidadeInvalido);

            RuleFor(x => x.UnidadeMedida).NotEmpty().WithMessage(ProdutoErrorMessages.UnidadeMedidaVazia)
                .Must(x => x.GetType() == typeof(UnidadeMedidaEnum)).WithMessage(ProdutoErrorMessages.UnidadeMedidaInvalida);
        }
    }
}
