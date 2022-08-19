using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Data;

namespace Negocios
{
    public class GrupoUsuarioLogadoNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public GrupoUsuarioLogado ConsultarPorId(int IdGrupoUsuarioLogado)
        {
            string queryConsulta = "SELECT * FROM grupo_usuario WHERE id_grupo_usuario = @IdGrupoUsuario";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdGrupoUsuario", IdGrupoUsuarioLogado);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            if (dataTable.Rows.Count > 0)
            {
                GrupoUsuarioLogado grupoUsuarioLogado = new GrupoUsuarioLogado();

                grupoUsuarioLogado.IdGrupoUsuario = Convert.ToInt32(dataTable.Rows[0]["id_grupo "]);
                grupoUsuarioLogado.Descricao = Convert.ToString(dataTable.Rows[0]["nome "]);
                grupoUsuarioLogado.AlterarLoja = Convert.ToString(dataTable.Rows[0]["alterar_loja "]);
                grupoUsuarioLogado.EmitirVenda = Convert.ToString(dataTable.Rows[0]["emitir_nfe"]);
                grupoUsuarioLogado.CancelarVenda = Convert.ToString(dataTable.Rows[0]["cancelar_nfe"]);
                grupoUsuarioLogado.EmitirOarcamento = Convert.ToString(dataTable.Rows[0]["emitir_orcamento"]);
                grupoUsuarioLogado.CancelarOrcamento = Convert.ToString(dataTable.Rows[0]["cancelar_orcamento"]);
                grupoUsuarioLogado.VisualizarCliente = Convert.ToString(dataTable.Rows[0]["visualizar_cliente"]);
                grupoUsuarioLogado.CadastrarCliente = Convert.ToString(dataTable.Rows[0]["cadastrar_cliente"]);
                grupoUsuarioLogado.AlterarCliente = Convert.ToString(dataTable.Rows[0]["alterar_cliente"]);
                grupoUsuarioLogado.ApagarCliente = Convert.ToString(dataTable.Rows[0]["apagar_clinte "]);
                grupoUsuarioLogado.VisualizarProduto = Convert.ToString(dataTable.Rows[0]["visualizar_produto"]);
                grupoUsuarioLogado.CadastrarProduto = Convert.ToString(dataTable.Rows[0]["cadastrar_produto"]);
                grupoUsuarioLogado.AlterarProduto = Convert.ToString(dataTable.Rows[0]["alterar_produto"]);
                grupoUsuarioLogado.ApagarProduto = Convert.ToString(dataTable.Rows[0]["apagar_produto"]);
                grupoUsuarioLogado.VisualizarFornecedor = Convert.ToString(dataTable.Rows[0]["visualizar_fornecedor"]);
                grupoUsuarioLogado.CadastrarFornecedor = Convert.ToString(dataTable.Rows[0]["cadastrar_fornecedor"]);
                grupoUsuarioLogado.AlterarFornecedor = Convert.ToString(dataTable.Rows[0]["alterar_fornecedor"]);
                grupoUsuarioLogado.ApagarFornecedor = Convert.ToString(dataTable.Rows[0]["apagar_fornecedor"]);
                grupoUsuarioLogado.VisualizarUsuario = Convert.ToString(dataTable.Rows[0]["visualizar_usuario"]);
                grupoUsuarioLogado.CadastrarUsuario = Convert.ToString(dataTable.Rows[0]["cadastrar_usuario"]);
                grupoUsuarioLogado.AlterarUsuario = Convert.ToString(dataTable.Rows[0]["alterar_usuario"]);
                grupoUsuarioLogado.ApagarUsuario = Convert.ToString(dataTable.Rows[0]["apagar_usuario"]);
                grupoUsuarioLogado.VisualizarGrupoUsuario = Convert.ToString(dataTable.Rows[0]["visualizar_grupo_usuario"]);
                grupoUsuarioLogado.CadastroGrupoUsuario = Convert.ToString(dataTable.Rows[0]["cadastrar_grupo_usuario"]);
                grupoUsuarioLogado.AlterarGrupoUsuario = Convert.ToString(dataTable.Rows[0]["alterar_grupo_usuario"]);
                grupoUsuarioLogado.ApagarGrupoUsuario = Convert.ToString(dataTable.Rows[0]["apagar_grupo_usuario"]);
                grupoUsuarioLogado.RelCliente = Convert.ToString(dataTable.Rows[0]["rel_cliente"]);
                grupoUsuarioLogado.RelProduto = Convert.ToString(dataTable.Rows[0]["rel_produto"]);
                grupoUsuarioLogado.RelOrcamento = Convert.ToString(dataTable.Rows[0]["rel_orcamento"]);
                grupoUsuarioLogado.Relvenda = Convert.ToString(dataTable.Rows[0]["rel_venda"]);
                grupoUsuarioLogado.UsuarioCadastro.IdUsuario = Convert.ToInt32(dataTable.Rows[0]["id_usuario_cadastro"]);
                grupoUsuarioLogado.UsuarioAlteracao.IdUsuario = Convert.ToInt32(dataTable.Rows[0]["id_usuario_alteracao"]);
                grupoUsuarioLogado.Apagado = Convert.ToString(dataTable.Rows[0]["apagado"]);
                grupoUsuarioLogado.Ativo = Convert.ToString(dataTable.Rows[0]["ativo"]);
                grupoUsuarioLogado.DataCadastro = Convert.ToDateTime(dataTable.Rows[0]["data_cadastro"]);
                grupoUsuarioLogado.DataAlteracao = Convert.ToDateTime(dataTable.Rows[0]["data_alteracao"]);

                return grupoUsuarioLogado;
            }
            else
            {
                return null;
            }
        }
    }
}
