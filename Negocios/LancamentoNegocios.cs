using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class LancamentoNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public int TotalClientes()
        {
            acessoDados.LimparParametros();
            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT count(id_lancamento) FROM lancamento"));
        }

        public int Inserir(Lancamento lancamento, int IdCliente)
        {
            string queryInserir = "INSERT INTO lancamento " +
                "(" +
                "id_usuario," +
                "id_cliente," +
                "data_emissao," +
                "data_status," +
                "id_usuario_alteracao_status," +
                "tipo_operacao," +
                "status_lancamento, " +
                "id_loja "+
                ") values " +
                "(" +
                "@Usuario," +
                "@Cliente," +
                "@DataEmissao," +
                "@DataStatus," +
                "@UsuarioAlteracao," +
                "@TipoOperacao," +
                "@StatusLancamento, " +
                "@IdLoja "+
                ")";

            acessoDados.LimparParametros();
            var usuarioLogado = UsuarioLogado.Instancia;

            acessoDados.AdicionarParametros("@Usuario", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@Cliente", IdCliente);
            acessoDados.AdicionarParametros("@DataEmissao", DateTime.Now);
            acessoDados.AdicionarParametros("@DataStatus", DateTime.Now);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@TipoOperacao", lancamento.TipoOperacao);
            acessoDados.AdicionarParametros("@StatusLancamento", lancamento.StatusLancamento);
            acessoDados.AdicionarParametros("@IdLoja", 1);

            acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);

            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT MAX(id_lancamento) FROM lancamento"));
        }

        public int Alterar(Lancamento lancamento)
        {
            string queryAlterar = "UPDATE lancamento SET " +
                "data_status=@DataStatus," +
                "id_usuario_alteracao_status=@UsuarioAlteracao," +
                "tipo_operacao=@TipoOperacao," +
                "status_lancamento=@StatusLancamento" +
                " WHERE id_lancamento = @IdLancamento AND status_lancamento <> 'C'";

            var usuarioLogado = UsuarioLogado.Instancia;

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@DataStatus", DateTime.Now);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@TipoOperacao", lancamento.TipoOperacao);
            acessoDados.AdicionarParametros("@StatusLancamento", lancamento.StatusLancamento);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }

        public int AtualizarValorTotal(int IdLancamento, decimal Valor)
        {
            string queryAlterar = "UPDATE lancamento SET " +
                "valor_total=@Valor" +
                " WHERE id_lancamento = @IdLancamento AND status_lancamento <> 'C'";


            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdLancamento", IdLancamento);
            acessoDados.AdicionarParametros("@Valor", Valor);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }


        public int TruncarTabelaAux()
        {
            string queryAlterar = "truncate table temporariaAuxLancamento";
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }

        public int PopularTabelaAux()
        {
            string queryAlterar = "insert into temporariaAuxLancamento (id, quantidade, desconto)"+
                                    "("+
	                                    " select lancamento.id_lancamento, sum(lancamento_item.quantidade), SUM(lancamento_item.valor_desconto)"+
	                                    " from lancamento_item"+
	                                    " left join lancamento on lancamento.id_lancamento = lancamento_item.id_lancamento"+
	                                    " group by lancamento.id_lancamento"+
                                    ")";

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }



        public int ExcluirLancamento(int IdLancamento)
        {
            string queryApagar = "DELETE FROM lancamento " +
                "WHERE id_lancamento = @IdLancamento";

            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdLancamento", IdLancamento);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }
        public int Cancelar(Lancamento lancamento)
        {
            string queryApagar = "UPDATE lancamento SET " +
                "status_lancamento = 'C'," +
                "id_usuario_alteracao_status=@UsuarioAlteracao," +
                "data_status=@DataStatus, " +
                "WHERE id_lancamento = @IdLancamento AND status_lancamento <> 'C'";

            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@DataStatus", DateTime.Now);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }

        public LancamentoColecao ConsultarPorOperacao(string operacao)
        {
            LancamentoColecao lancamentoColecao = new LancamentoColecao();
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            ClienteNegocios clietneNegocios = new ClienteNegocios();

            string query = "SELECT * FROM lancamento WHERE tipo_operacao = @TipoOperacao";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@TipoOperacao", operacao);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Lancamento lancamento = new Lancamento();

                lancamento.IdLancamento = Convert.ToInt32(dataRow["id_lancamento"]);
                lancamento.Usuario = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario"]));
                lancamento.Cliente = clietneNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_cliente"]));
                lancamento.DataEmissao = Convert.ToDateTime(dataRow["data_emissao"]);
                lancamento.DataStatus = Convert.ToDateTime(dataRow["data_status"]);
                lancamento.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_alteracao_status"]));
                lancamento.ValorTotal = Convert.ToDecimal(dataRow["valor_total"]);
                lancamento.TipoOperacao = Convert.ToString(dataRow["tipo_operacao"]);
                lancamento.NumDocumento = Convert.ToString(dataRow["num_documento"]);
                lancamento.StatusLancamento = Convert.ToString(dataRow["status_lancamento"]);

                lancamentoColecao.Add(lancamento);
            }
            return lancamentoColecao;
        }
        public LancamentoColecao ConsultarPorStatus(string status)
        {
            LancamentoColecao lancamentoColecao = new LancamentoColecao();
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            ClienteNegocios clietneNegocios = new ClienteNegocios();

            string query = "SELECT * FROM lancamento WHERE status_lancamento = @StatusLancamento";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@StatusLancamento", status);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Lancamento lancamento = new Lancamento();

                lancamento.IdLancamento = Convert.ToInt32(dataRow["id_lancamento"]);
                lancamento.Usuario = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario"]));
                lancamento.Cliente = clietneNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_cliente"]));
                lancamento.DataEmissao = Convert.ToDateTime(dataRow["data_emissao"]);
                lancamento.DataStatus = Convert.ToDateTime(dataRow["data_status"]);
                lancamento.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_alteracao_status"]));
                lancamento.ValorTotal = Convert.ToDecimal(dataRow["valor_total"]);
                lancamento.TipoOperacao = Convert.ToString(dataRow["tipo_operacao"]);
                lancamento.NumDocumento = Convert.ToString(dataRow["num_documento"]);
                lancamento.StatusLancamento = Convert.ToString(dataRow["status_lancamento"]);

                lancamentoColecao.Add(lancamento);
            }
            return lancamentoColecao;
        }
        public LancamentoColecao ConsultarPorUsuario(int usuario)
        {
            LancamentoColecao lancamentoColecao = new LancamentoColecao();
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            ClienteNegocios clietneNegocios = new ClienteNegocios();

            string query = "SELECT * FROM lancamento WHERE id_usuario = @IdUsuario";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdUsuario", usuario);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Lancamento lancamento = new Lancamento();

                lancamento.IdLancamento = Convert.ToInt32(dataRow["id_lancamento"]);
                lancamento.Usuario = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario"]));
                lancamento.Cliente = clietneNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_cliente"]));
                lancamento.DataEmissao = Convert.ToDateTime(dataRow["data_emissao"]);
                lancamento.DataStatus = Convert.ToDateTime(dataRow["data_status"]);
                lancamento.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_alteracao_status"]));
                lancamento.ValorTotal = Convert.ToDecimal(dataRow["valor_total"]);
                lancamento.TipoOperacao = Convert.ToString(dataRow["tipo_operacao"]);
                lancamento.NumDocumento = Convert.ToString(dataRow["num_documento"]);
                lancamento.StatusLancamento = Convert.ToString(dataRow["status_lancamento"]);

                lancamentoColecao.Add(lancamento);
            }
            return lancamentoColecao;
        }
        public LancamentoColecao ConsultarPorCliente(int cliente)
        {
            LancamentoColecao lancamentoColecao = new LancamentoColecao();
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            ClienteNegocios clietneNegocios = new ClienteNegocios();

            string query = "SELECT * FROM lancamento WHERE id_cliente = @IdCliente";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdCliente", cliente);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Lancamento lancamento = new Lancamento();

                lancamento.IdLancamento = Convert.ToInt32(dataRow["id_lancamento"]);
                lancamento.Usuario = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario"]));
                lancamento.Cliente = clietneNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_cliente"]));
                lancamento.DataEmissao = Convert.ToDateTime(dataRow["data_emissao"]);
                lancamento.DataStatus = Convert.ToDateTime(dataRow["data_status"]);
                lancamento.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_alteracao_status"]));
                lancamento.ValorTotal = Convert.ToDecimal(dataRow["valor_total"]);
                lancamento.TipoOperacao = Convert.ToString(dataRow["tipo_operacao"]);
                lancamento.NumDocumento = Convert.ToString(dataRow["num_documento"]);
                lancamento.StatusLancamento = Convert.ToString(dataRow["status_lancamento"]);

                lancamentoColecao.Add(lancamento);
            }
            return lancamentoColecao;
        }
        public LancamentoColecao ConsultarPorPeriodo(DateTime DataInicio, DateTime DataFim)
        {
            LancamentoColecao lancamentoColecao = new LancamentoColecao();
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            ClienteNegocios clietneNegocios = new ClienteNegocios();

            string query = "SELECT * FROM lancamento WHERE data_status BETWEEN @DataInicio AND @DataFim";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@DataInicio", DataInicio);
            acessoDados.AdicionarParametros("@DataFim", DataFim);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Lancamento lancamento = new Lancamento();

                lancamento.IdLancamento = Convert.ToInt32(dataRow["id_lancamento"]);
                lancamento.Usuario = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario"]));
                lancamento.Cliente = clietneNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_cliente"]));
                lancamento.DataEmissao = Convert.ToDateTime(dataRow["data_emissao"]);
                lancamento.DataStatus = Convert.ToDateTime(dataRow["data_status"]);
                lancamento.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_alteracao_status"]));
                lancamento.ValorTotal = Convert.ToDecimal(dataRow["valor_total"]);
                lancamento.TipoOperacao = Convert.ToString(dataRow["tipo_operacao"]);
                lancamento.NumDocumento = Convert.ToString(dataRow["num_documento"]);
                lancamento.StatusLancamento = Convert.ToString(dataRow["status_lancamento"]);

                lancamentoColecao.Add(lancamento);
            }
            return lancamentoColecao;
        }
        public LancamentoColecao ConsultarTodos()
        {
            LancamentoColecao lancamentoColecao = new LancamentoColecao();
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            ClienteNegocios clietneNegocios = new ClienteNegocios();

            string query = "SELECT * FROM lancamento";

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Lancamento lancamento = new Lancamento();

                lancamento.IdLancamento = Convert.ToInt32(dataRow["id_lancamento"]);
                lancamento.Usuario = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario"]));
                lancamento.Cliente = clietneNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_cliente"]));
                lancamento.DataEmissao = Convert.ToDateTime(dataRow["data_emissao"]);
                lancamento.DataStatus = Convert.ToDateTime(dataRow["data_status"]);
                lancamento.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_alteracao_status"]));
                lancamento.ValorTotal = Convert.ToDecimal(dataRow["valor_total"]);
                lancamento.TipoOperacao = Convert.ToString(dataRow["tipo_operacao"]);
                lancamento.NumDocumento = Convert.ToString(dataRow["num_documento"]);
                lancamento.StatusLancamento = Convert.ToString(dataRow["status_lancamento"]);

                lancamentoColecao.Add(lancamento);
            }
            return lancamentoColecao;
        }

        public Lancamento ConsultarPorId(int IdLancamento)
        {
            string queryConsulta = "SELECT * FROM lancametno WHERE id_lancamento = @IdLancamento'";
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            ClienteNegocios clietneNegocios = new ClienteNegocios();

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdLancamento", IdLancamento);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            if (dataTable.Rows.Count > 0)
            {
                Lancamento lancamento = new Lancamento();

                lancamento.IdLancamento = Convert.ToInt32(dataTable.Rows[0]["id_lancamento"]);
                lancamento.Usuario = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataTable.Rows[0]["id_usuario"]));
                lancamento.Cliente = clietneNegocios.ConsultarPorId(Convert.ToInt32(dataTable.Rows[0]["id_cliente"]));
                lancamento.DataEmissao = Convert.ToDateTime(dataTable.Rows[0]["data_emissao"]);
                lancamento.DataStatus = Convert.ToDateTime(dataTable.Rows[0]["data_status"]);
                lancamento.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataTable.Rows[0]["id_usuario_alteracao_status"]));
                lancamento.ValorTotal = Convert.ToDecimal(dataTable.Rows[0]["valor_total"]);
                lancamento.TipoOperacao = Convert.ToString(dataTable.Rows[0]["tipo_operacao"]);
                lancamento.NumDocumento = Convert.ToString(dataTable.Rows[0]["num_documento"]);
                lancamento.StatusLancamento = Convert.ToString(dataTable.Rows[0]["status_lancamento"]);

                return lancamento;
            }
            else
            {
                return null;
            }
        }
    }
}
