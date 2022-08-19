using System;

namespace ObjetoTransferencia
{
    public class GrupoUsuario
    {
        public int IdGrupoUsuario { get; set; }
        public string Descricao { get; set; }
        public string AlterarLoja { get; set; }
        public string EmitirVenda { get; set; }
        public string CancelarVenda { get; set; }
        public string EmitirOarcamento { get; set; }
        public string CancelarOrcamento { get; set; }
        public string VisualizarCliente { get; set; }
        public string CadastrarCliente { get; set; }
        public string AlterarCliente { get; set; }
        public string ApagarCliente { get; set; }
        public string VisualizarProduto { get; set; }
        public string CadastrarProduto { get; set; }
        public string AlterarProduto { get; set; }
        public string ApagarProduto { get; set; }
        public string VisualizarFornecedor { get; set; }
        public string CadastrarFornecedor { get; set; }
        public string AlterarFornecedor { get; set; }
        public string ApagarFornecedor { get; set; }
        public string VisualizarUsuario { get; set; }
        public string CadastrarUsuario { get; set; }
        public string AlterarUsuario { get; set; }
        public string ApagarUsuario { get; set; }
        public string VisualizarGrupoUsuario { get; set; }
        public string CadastroGrupoUsuario { get; set; }
        public string AlterarGrupoUsuario { get; set; }
        public string ApagarGrupoUsuario { get; set; }
        public string RelCliente { get; set; }
        public string RelProduto { get; set; }
        public string RelOrcamento { get; set; }
        public string Relvenda { get; set; }
        public Usuario UsuarioCadastro { get; set; }
        public Usuario UsuarioAlteracao { get; set; }      
        public string Apagado { get; set; }
        public string Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
