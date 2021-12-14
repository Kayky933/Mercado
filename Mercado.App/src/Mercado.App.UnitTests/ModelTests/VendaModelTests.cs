using Mercado.App.UnitTests.Builder;
using Mercado.App.Validation.ValidationProject.ErrorMessages;
using Mercado.App.Validation.ValidationProject.ValidationModels;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace Mercado.App.UnitTests.ModelTests
{
    public class VendaModelTests
    {
        private readonly VendaModelValidation _validator;
        private readonly VendaModelBuilder _builder;
        public VendaModelTests()
        {
            var provider = new ServiceCollection().AddScoped<VendaModelValidation>().BuildServiceProvider();
            _builder = new VendaModelBuilder();
            _validator = provider.GetService<VendaModelValidation>();
        }

        [Fact(DisplayName = "A classe deve ser válida")]
        public async Task ClasseValida()
        {
            var instance = _builder.Build();
            var validationModel = await _validator.ValidateAsync(instance);

            Assert.True(validationModel.IsValid);
        }

        [Theory(DisplayName = "A quantidade deve ser válida")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public async Task QuantidadeValida(int quantidade)
        {
            var instance = _builder.With(x => x.Quantidade = quantidade).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }

        [Theory(DisplayName = "A quantidade deve ser invalida")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        [InlineData(-5)]
        public async Task QuantidadeInvalida(int quantidade)
        {
            var instance = _builder.With(x => x.Quantidade = quantidade).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(VendaErrorMessages.QuantidadeMinima));
        }

        [Theory(DisplayName = "A Id_Produto deve ser invalida")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        [InlineData(-5)]
        public async Task IdProdutoInvalida(int id)
        {
            var instance = _builder.With(x => x.Quantidade = id).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
        }

        [Theory(DisplayName = "A quantidade deve ser válida")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public async Task IdProdutoValida(int id)
        {
            var instance = _builder.With(x => x.Quantidade = id).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }
    }
}
