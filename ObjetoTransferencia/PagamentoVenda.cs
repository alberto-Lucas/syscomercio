namespace ObjetoTransferencia
{
    public class PagamentoVenda
    {
        public Lancamento Lancamento { get; set; }
        public Pagamento Pagamento { get; set; }
        public int QuantidadeParcela { get; set; }
        public decimal ValorParela { get; set; }
    }
}
