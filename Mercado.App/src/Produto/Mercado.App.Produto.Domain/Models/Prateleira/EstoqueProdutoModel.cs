using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.App.Produto.Domain.Models.Prateleira
{
    public class EstoqueProdutoModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PRODUTO")]
        public int ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; }     
        public EstoqueProdutoModel InfoProduto { get; set; }
    }
}
