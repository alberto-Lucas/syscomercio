using System;

namespace ObjetoTransferencia
{
    public class Loja
    {
        public int IdLoja { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantatasia { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public DateTime DataRegistro { get; set; }
        public Usuario UsuarioAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
