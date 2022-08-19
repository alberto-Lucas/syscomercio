
namespace ObjetoTransferencia
{
    public class LancamentoItem
    {
        public Lancamento Lancamento { get; set; }
        public Produto Produto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorDesconto { get; set; }
        public int ordemItem { get; set; }
        public decimal totalBruto { get { return PrecoUnitario * Quantidade; } }
        public decimal total { get { return PrecoUnitario * Quantidade - ValorDesconto; } }
    }
}
