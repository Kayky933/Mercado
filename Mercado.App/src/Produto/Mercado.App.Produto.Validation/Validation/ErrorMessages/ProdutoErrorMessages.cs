namespace Mercado.App.Produto.Validation.Validation.ErrorMessages
{
    public static class ProdutoErrorMessages
    {
        public static string DescricaoVazia = "O campo Descrição não pode ser nulo";
        public static string DescricaoTamanhoMaximo = "O campo Descrição tem tamanho máximo de 300 caracteres";
        public static string DescricaoTamanhoMinimo = "O campo Descrição tem tamanho mínimo de 3 caracteres";

        public static string PrecoUnidadeVazio = "O campo Preço não pode ser nulo";
        public static string PrecoUnidadeInvalido = "O campo Preço esta em um formato inválido";

        public static string UnidadeMedidaVazia = "O campo Unidade de Medida não pode ser nulo";
        public static string UnidadeMedidaInvalida = "O campo Unidade de Medida esta em um formato inválido";
    }
}
