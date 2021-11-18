using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.App.Produto.Domain.Models.Prateleira
{
    [Table("CATEGORIA")]
    public class CategoriaModel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        [ScaffoldColumn(false)]
        public ICollection<ProdutoModel> Produtos { get; set; }
    }
}
