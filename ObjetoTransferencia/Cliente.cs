using System;

namespace ObjetoTransferencia
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string TipoPessoa { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string ApelidoNomeFantasia { get; set; }
        public string CpfCnpj { get; set; }
        public string RgIe { get; set; }
        public DateTime DataNascimentoRegistro { get; set; }
        public string Observacao { get; set; }
        public Usuario UsuarioCadastro { get; set; }
        public Usuario UsuarioAlteracao { get; set; }   
        public string Apagado { get; set; }
        public string Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
