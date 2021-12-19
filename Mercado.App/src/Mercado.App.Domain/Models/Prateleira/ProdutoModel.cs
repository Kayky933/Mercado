using Mercado.App.Domain.Models.Venda;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.App.Domain.Models.Prateleira
{
    [Table("PRODUTOS")]
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public CategoriaModel Categoria { get; set; }
        public double QuantidadeEstoque { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal PrecoUnidade { get; set; }
        public ICollection<VendaModel> Vendas { get; set; }
        public UnidadeMedidaEnum UnidadeMedida { get; set; }
    }
}
