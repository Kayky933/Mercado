using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.App.Produto.Domain.Models.Prateleira
{
    public class CategoriaModel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<ProdutoModel> Produtos { get; set; } = default;
    }
}
