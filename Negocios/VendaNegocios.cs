using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Data;

namespace Negocios
{
    public class VendaNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public int TotalVendas()
        {
            acessoDados.LimparParametros();
            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT COUNT(id_venda) FROM venda"));
        }

        public int Inserir(Lancamento venda)
        {
            string query = "INSERT INTO venda "+
                "(id_usuario, id_cliente, data_hora) VALUES " +
                "(@IdUsuario, @IdCliente, @DataHora)";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdUsuario", venda.Usuario.IdUsuario);
            acessoDados.AdicionarParametros("@IdCliente", venda.Cliente.IdCliente);
            acessoDados.AdicionarParametros("@DataHora", venda.DataEmissao);

            acessoDados.ExecutarManipulacao(CommandType.Text, query);

            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT MAX(id_venda) FROM venda"));
        }

        public int Alterar(Lancamento venda)
        {
            string query = "UPDATE pedido SET "+
                "id_usuario = @IdUsuario, " +
                "id_cliente = @IdCliente, " +
                "data_hora = @DataHora " +
                "WHERE id_venda = @IdVenda";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdVenda", venda.IdLancamento);
            acessoDados.AdicionarParametros("@IdUsuario", venda.Usuario.IdUsuario);
            acessoDados.AdicionarParametros("@IdCliente", venda.Cliente.IdCliente);
            acessoDados.AdicionarParametros("@DataHora", venda.DataEmissao);

            return acessoDados.ExecutarManipulacao(CommandType.Text, query);
        }

        public int Apagar(int IdVenda)
        {
            string query = "DELETE FROM venda WHERE id_venda = @IdVenda";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdVenda", IdVenda);

            return acessoDados.ExecutarManipulacao(CommandType.Text, query);
        }

        public LancamentoColecao ConsultarTodos()
        {
            LancamentoColecao vendaColecao = new LancamentoColecao();
            ClienteNegocios clienteNegocios = new ClienteNegocios();
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();

            string query = "SELECT * FROM venda";

            DataTable dataTable = acessoDados.ExecutarConsulta(
                CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Lancamento venda = new Lancamento();
                
                venda.IdLancamento = Convert.ToInt32(dataRow["id_venda"]);
                if (!(dataRow["id_usuario"] is DBNull))
                    venda.Usuario = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario"]));
                if (!(dataRow["id_cliente"] is DBNull))
                    venda.Cliente = clienteNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_cliente"]));
                venda.DataEmissao = Convert.ToDateTime(dataRow["data_hora"]);
                

                vendaColecao.Add(venda);
            }
            return vendaColecao;
        }

        public Lancamento ConsultarPorId(int IdVenda)
        {
            ClienteNegocios clienteNegocios = new ClienteNegocios();
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();

            string query = "SELECT * FROM venda WHERE id_venda = @IdVenda";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdVenda", IdVenda);

            DataTable dataTable = acessoDados.ExecutarConsulta(
                CommandType.Text, query);

            if (dataTable.Rows.Count > 0)
            {
                Lancamento venda = new Lancamento();
                venda.IdLancamento = Convert.ToInt32(dataTable.Rows[0]["id_venda"]);
                if (!(dataTable.Rows[0]["id_usuario"] is DBNull))
                    venda.Usuario = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataTable.Rows[0]["id_usuario"]));
                if (!(dataTable.Rows[0]["id_cliente"] is DBNull))
                    venda.Cliente = clienteNegocios.ConsultarPorId(Convert.ToInt32(dataTable.Rows[0]["id_cliente"]));
                venda.DataEmissao = Convert.ToDateTime(dataTable.Rows[0]["data_hora"]);
                

                return venda;
            }
            else
            {
                return null;
            }
        }
    }
}
