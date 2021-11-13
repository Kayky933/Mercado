﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.App.Produto.Domain.Models.Prateleira
{
    [Table("PRODUTO")]
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public CategoriaModel Categoria { get; set; } = default;
        public InfoProduto Informacoes_Produto { get; set; } = default;
    }
}
