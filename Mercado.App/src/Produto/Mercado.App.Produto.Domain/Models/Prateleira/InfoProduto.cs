﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.App.Produto.Domain.Models.Prateleira
{
    public class InfoProduto
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal PrecoUnidade { get; set; }
        public UnidadeMedidaEnum UnidadeMedida { get; set; }

    }
}
