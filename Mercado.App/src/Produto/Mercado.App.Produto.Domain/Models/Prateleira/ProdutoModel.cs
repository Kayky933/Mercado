using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.App.Produto.Domain.Models.Prateleira
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<CategoriaModel> Categorias { get; set; } = default;
        public EstoqueProdutoModel Estoque { get; set; } = default;
    }
}
