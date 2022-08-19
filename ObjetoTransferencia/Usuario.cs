using System;

namespace ObjetoTransferencia
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public GrupoUsuario GrupoUsuario { get; set; }
        public Usuario UsuarioCadastro { get; set; }
        public Usuario UsuarioAlteracao { get; set; }   
        public string Apagado { get; set; }
        public string Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
