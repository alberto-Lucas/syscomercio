using System;

namespace ObjetoTransferencia
{
    public class Lancamento
    {
        public int IdLancamento { get; set; }
        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataStatus { get; set; }
        public Usuario UsuarioAlteracao { get; set; }
        public decimal ValorTotal { get; set; }
        public string TipoOperacao { get; set; }
        public string NumDocumento { get; set; }
        public string StatusLancamento { get; set; }

    }
}
