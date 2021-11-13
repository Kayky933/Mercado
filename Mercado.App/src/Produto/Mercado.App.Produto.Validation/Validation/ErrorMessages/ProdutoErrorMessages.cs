namespace Mercado.App.Produto.Validation.Validation.ErrorMessages
{
    public static class ProdutoErrorMessages
    {
        public static string DescricaoVazia = "O campo Descrição não pode ser nulo";
        public static string DescricaoTamanhoMaximo = "O campo Descrição tem tamanho máximo de 300 caracteres";
        public static string DescricaoTamanhoMinimo = "O campo Descrição tem tamanho mínimo de 3 caracteres";

        public static string CategoriaVazia = "O campo Categoria não pode ser nulo";
        public static string CategoriaTipoInvalido = "O campo Categoria não foi encontrato nos tipos existentes";

        public static string EstoqueVazia = "O campo Estoque não pode ser nulo";
        public static string EstoqueTipoInvalido = "O campo Estoque não foi encontrato nos tipos existentes";
    }
}
