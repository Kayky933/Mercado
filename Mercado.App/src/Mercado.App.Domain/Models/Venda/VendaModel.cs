using Mercado.App.Domain.Models.Prateleira;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Mercado.App.Domain.Models.Venda
{
    [Table("VENDAS")]
    public class VendaModel
    {

        [Key]
        public int Id { get; set; }
        public int Quantidade { get; set; }
        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        [JsonIgnore]
        public ProdutoModel Produto { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorPago { get; set; }
    }
}
