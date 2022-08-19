using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class PagamentoVendaNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public int rollBack(int idLancamento)
        {
            string query = "DELETE FROM pagamento_venda WHERE id_lancamento = @Lancamento";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@Lancamento", idLancamento);
            acessoDados.ExecutarManipulacao(CommandType.Text, query);

            return 1;
        }

        public int Inserir(int idLancamento, int idPagamento, int qtdParcela, double valorParcela)
        {
            string query = "DELETE FROM pagamento_venda WHERE id_lancamento = @Lancamento;"+
                "INSERT INTO pagamento_venda " +
                "(id_lancamento, id_pagamento, quantidade_parcela, valor_parcela) VALUES " +
                "(@Lancamento, @Pagamento, @QuantidadeParcela, @ValorParela)";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@Lancamento", idLancamento);
            acessoDados.AdicionarParametros("@Pagamento", idPagamento);
            acessoDados.AdicionarParametros("@QuantidadeParcela", qtdParcela);
            acessoDados.AdicionarParametros("@ValorParela", valorParcela);
            acessoDados.ExecutarManipulacao(CommandType.Text, query);

            return 1;
        }

        public PagamentoVendaColecao ConsultarTodos()
        {
            PagamentoVendaColecao pagamentoVendaColecao = new PagamentoVendaColecao();
            PagamentoNegocios pagamentoNegocios = new PagamentoNegocios();

            string query = "SELECT * FROM pagamento_venda";

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                PagamentoVenda pagamentoVenda = new PagamentoVenda();

                pagamentoVenda.Lancamento.IdLancamento = Convert.ToInt32(dataRow["id_lancamento"]);
                pagamentoVenda.Pagamento.IdPagamento = Convert.ToInt32(dataRow["id_pagamento"]);
                pagamentoVenda.QuantidadeParcela = Convert.ToInt32(dataRow["quantidade_parcela"]);
                pagamentoVenda.ValorParela = Convert.ToDecimal(dataRow["valor_parcela"]);


                pagamentoVendaColecao.Add(pagamentoVenda);
            }
            return pagamentoVendaColecao;
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
