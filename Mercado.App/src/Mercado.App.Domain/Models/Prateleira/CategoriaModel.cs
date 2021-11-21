using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.App.Domain.Models.Prateleira
{
    [Table("CATEGORIAS")]
    public class CategoriaModel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<ProdutoModel> Produtos { get; set; }
    }
}
