namespace Mercado.App.Validation.Validation.ErrorMessages
{
    public class ProdutoErrorMessages : DefaultErrorMessages
    {
        public static string PrecoUnidadeVazio = "O campo Preço não pode ser nulo";
        public static string PrecoUnidadeInvalido = "O campo Preço esta em um formato inválido";
        public static string PrecoMinimo = "O Campo Preco deve ter no mínimo R$0,99 de valor";

        public static string UnidadeMedidaVazia = "O campo Unidade de Medida não pode ser nulo";
        public static string UnidadeMedidaInvalida = "O campo Unidade de Medida esta em um formato inválido";

        public static string CategoriaIvalida = "A Categoria selecionada não é válida!";
        public static string CategoriaInexixtente = "A Categoria selecionada não existe!";

        public static string ProdutoExistente = "O Produto já existe no banco de dados!";
    }
}
