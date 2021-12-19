namespace Mercado.App.Domain.Models.Venda.VendaViewModels
{
    public class VendaViewModel
    {
        public int Quantidade { get; set; }
        public int IdProduto { get; set; }
        private decimal ValorPago { get; set; }
        public decimal ValorPagoVenda()
        {
            decimal valor = this.ValorPago;
            return valor;
        }
    }
}
