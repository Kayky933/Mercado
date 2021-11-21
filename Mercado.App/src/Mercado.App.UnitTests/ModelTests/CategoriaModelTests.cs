using Mercado.App.UnitTests.Builder;
using Mercado.App.Validation.Validation.ErrorMessages;
using Mercado.App.Validation.ValidationProject.ValidationModels;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace Mercado.App.UnitTests.ModelTests
{
    public class CategoriaModelTests
    {
        private readonly CategoriaModelValidation _validator;
        private readonly CategoriaModelBuilder _builder;
        public CategoriaModelTests()
        {
            var provider = new ServiceCollection().AddScoped<CategoriaModelValidation>().BuildServiceProvider();
            _builder = new CategoriaModelBuilder();
            _validator = provider.GetService<CategoriaModelValidation>();
        }
        [Fact(DisplayName = "A classe deve ser válida")]
        public async Task ClasseValida()
        {
            var instance = _builder.Build();
            var validationModel = await _validator.ValidateAsync(instance);

            Assert.True(validationModel.IsValid);
        }

        [Theory(DisplayName = "Descrições devem ser válidas")]
        [InlineData("Enlatados")]
        [InlineData("Massas")]
        [InlineData("Carnes")]
        [InlineData("Frutas")]
        [InlineData("Destilados")]
        [InlineData("Fermentados")]
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

    }
}
