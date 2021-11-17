namespace Mercado.App.Produto.Validation.Validation.ErrorMessages
{
    public class ProdutoErrorMessages : DefaultErrorMessages
    {
        public static string PrecoUnidadeVazio = "O campo Preço não pode ser nulo";
        public static string PrecoUnidadeInvalido = "O campo Preço esta em um formato inválido";

        public static string UnidadeMedidaVazia = "O campo Unidade de Medida não pode ser nulo";
        public static string UnidadeMedidaInvalida = "O campo Unidade de Medida esta em um formato inválido";

        public static string ProdutoExistente = "O Produto já existe no banco de dados!";
    }
}
