using Mercado.App.Produto.Domain.Models.Prateleira;

namespace Mercado.App.Produto.Domain.Models.ViewModels
{
    public class ProdutoViewModel
    {
        public string Descricao { get; set; }
        public int Categorias { get; set; } = default;
        public InfoProduto InfoProduto { get; set; } = default;
    }
}
