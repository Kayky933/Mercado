using Mercado.App.Produto.Domain.Models.Prateleira;

namespace Mercado.App.Produto.Domain.Models.Prateleira.PrateleiraViewModels
{
    public class ProdutoViewModel
    {
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public decimal PrecoUnidade { get; set; }
        public UnidadeMedidaEnum UnidadeMedida { get; set; }
    }
}
