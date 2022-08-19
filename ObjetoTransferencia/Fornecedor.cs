using System;

namespace ObjetoTransferencia
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Observacao { get; set; }
        public Usuario UsuarioCadastro { get; set; }
        public Usuario UsuarioAlteracao { get; set; }   
        public string Apagado { get; set; }
        public string Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
