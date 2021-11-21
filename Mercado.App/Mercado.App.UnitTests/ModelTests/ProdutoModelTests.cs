using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Validation.Validation.ErrorMessages;
using Mercado.App.Produto.Validation.ValidationProject.ValidationModels;
using Mercado.App.UnitTests.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Mercado.App.UnitTests.ModelTests
{
    public class ProdutoModelTests
    {
        private readonly ProdutoModelBuilder _builder;
        private readonly ProdutoModelValidation _validator;
        public ProdutoModelTests()
        {
            var provider = new ServiceCollection().AddScoped<ProdutoModelValidation>().BuildServiceProvider();

            _builder = new ProdutoModelBuilder();
            _validator = provider.GetService<ProdutoModelValidation>();
        }

        [Fact(DisplayName = "A classe deve ser válida")]
        public async Task ClasseValida()
        {
            var instance = _builder.Build();
            var validationModel = await _validator.ValidateAsync(instance);

            Assert.True(validationModel.IsValid);
        }

        #region Descriao
        [Theory(DisplayName = "Descrições devem ser válidas")]
        [InlineData("Batata")]
        [InlineData("Morango")]
        [InlineData("Uva")]
        [InlineData("Limão")]
        [InlineData("Pera")]
        [InlineData("Melão")]
        public async Task DescricoesValidas(string description)
        {
            var instance = _builder.With(x => x.Descricao = description).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }
        [Theory(DisplayName = "Descrições não devem ser válidas!")]
        [InlineData("ab")]
        [InlineData("cd")]
        [InlineData("11")]
        [InlineData("aa")]
        [InlineData("33")]
        public async Task DescricoesInvalidas(string description)
        {
            var instance = _builder.With(x => x.Descricao = description).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(DefaultErrorMessages.DescricaoTamanhoMinimo));
        }
        [Fact(DisplayName = "Descrição tamanho máximo")]
        public async Task DescricaoTamanhoMaximo()
        {
            var descricaoTamanho = "A".PadLeft(101, 'A');
            var instance = _builder.With(x => x.Descricao = descricaoTamanho).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(DefaultErrorMessages.DescricaoTamanhoMaximo));
        }
        [Fact(DisplayName = "Descrição nula inválida!")]
        public async Task DescricaoNula()
        {
            var instance = _builder.With(x => x.Descricao = "").Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(DefaultErrorMessages.DescricaoVazia));
        }
        #endregion

        #region Categoria_Id
        [Theory(DisplayName = "Categorias_Id devem ser válidas!")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public async Task CategoriaIdValidas(int id)
        {
            var instance = _builder.With(x => x.CategoriaId = id).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }
        [Theory(DisplayName = "Categorias_Id não devem ser válidas!")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        [InlineData(-5)]
        public async Task CategoriaIdInvalidas(int id)
        {
            var instance = _builder.With(x => x.CategoriaId = id).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ProdutoErrorMessages.CategoriaInexixtente));
        }
        [Fact(DisplayName = "Categoria_Id vazia inválida!")]
        public async Task CategoriavaziaInvalida()
        {
            var instance = _builder.With(x => x.CategoriaId = Convert.ToInt32(null)).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ProdutoErrorMessages.CategoriaIvalida));
        }
        #endregion

        #region Preço
        [Theory(DisplayName = "Precos devem ser válidos!")]
        [InlineData("1.00")]
        [InlineData("2.50")]
        [InlineData("3.99")]
        [InlineData("4.11")]
        [InlineData("5.22")]
        [InlineData("6.27")]
        public async Task PrecosValidos(string preco)
        {
            var instance = _builder.With(x => x.PrecoUnidade = Convert.ToDecimal(preco)).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }

        [Theory(DisplayName = "Precos não devem ser válidos!")]
        [InlineData("0.00")]
        [InlineData("-1.00")]
        [InlineData("-2.00")]
        [InlineData("-3.00")]
        [InlineData("-4.00")]
        [InlineData("-5.00")]
        [InlineData("-6.00")]
        [InlineData("-7.00")]
        public async Task PrecosInvalidos(string preco)
        {
            var instance = _builder.With(x => x.PrecoUnidade = Convert.ToDecimal(preco)).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ProdutoErrorMessages.PrecoMinimo));
        }
        [Fact(DisplayName = "Preço Nulo deve ser inválido!")]
        public async Task PrecoNuloInvalido()
        {
            var instance = _builder.With(x => x.PrecoUnidade = Convert.ToDecimal(null)).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ProdutoErrorMessages.PrecoUnidadeVazio));
        }
        #endregion

        [Theory(DisplayName = "Unidades de medida devem ser válidas!")]
        [InlineData(UnidadeMedidaEnum.grama)]
        [InlineData(UnidadeMedidaEnum.caixa)]
        [InlineData(UnidadeMedidaEnum.kilograma)]
        [InlineData(UnidadeMedidaEnum.litro)]
        [InlineData(UnidadeMedidaEnum.mililitro)]
        [InlineData(UnidadeMedidaEnum.pacote)]
        [InlineData(UnidadeMedidaEnum.peca)]
        public async Task UnidadesMedidaValidas(UnidadeMedidaEnum unidadeMedida)
        {
            var instance = _builder.With(x => x.UnidadeMedida = unidadeMedida).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }
    }
}
