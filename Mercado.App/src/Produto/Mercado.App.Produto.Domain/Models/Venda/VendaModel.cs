using Mercado.App.Produto.Domain.Models.Prateleira;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.App.Produto.Domain.Models.Venda
{
    [Table("VENDAS")]
    public class VendaModel
    {

        [Key]
        public int Id { get; set; }
        public int Quantidade { get; set; }
        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public ProdutoModel Produto { get; set; }
        public decimal Valor()
        {
            var valor = 0m;
            return valor += Produto.PrecoUnidade * Quantidade;
        }
    }
}
