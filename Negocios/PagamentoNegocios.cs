using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class PagamentoNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public int Inserir(Pagamento pagamento)
        {
            string query = "INSERT INTO pagamento " +
                "(descricao) VALUES " +
                "(@Descricao)";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@Descricao", pagamento.Descricao);

            acessoDados.ExecutarManipulacao(CommandType.Text, query);

            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT MAX(id_pagamento) FROM pagamento"));
        }

        public int Alterar(Pagamento pagamento)
        {
            string query = "UPDATE pagamento SET " +
                "descricao = @Descricao " +
                "WHERE id_pagamento = @IdPagamento";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdPagamento", pagamento.IdPagamento);
            acessoDados.AdicionarParametros("@descricao", pagamento.Descricao);

            return acessoDados.ExecutarManipulacao(CommandType.Text, query);
        }

        public int Apagar(int IdPagamento)
        {
            string query = "DELETE FROM pagamento WHERE id_pagamento = @IdPagamento";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdPagamento", IdPagamento);

            return acessoDados.ExecutarManipulacao(CommandType.Text, query);
        }

        public PagamentoColecao ConsultarTodos()
        {
            PagamentoColecao pagamentoColecao = new PagamentoColecao();

            string query = "SELECT * FROM pagamento";

            DataTable dataTable = acessoDados.ExecutarConsulta(
                CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Pagamento pagamento = new Pagamento();

                pagamento.IdPagamento = Convert.ToInt32(dataRow["id_pagamento"]);
                if (!(dataRow["descricao"] is DBNull))pagamento.Descricao = Convert.ToString(dataRow["descricao"]);

                pagamentoColecao.Add(pagamento);
            }
            return pagamentoColecao;
        }

        public Pagamento ConsultarPorId(int IdPagamento)
        {
            string query = "SELECT * FROM pagamento WHERE id_pagamento = @IdPagamento";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdPagamento", IdPagamento);

            DataTable dataTable = acessoDados.ExecutarConsulta(
                CommandType.Text, query);

            if (dataTable.Rows.Count > 0)
            {
                Pagamento pagamento = new Pagamento();

                pagamento.IdPagamento = Convert.ToInt32(dataTable.Rows[0]["id_pagamento"]);
                if (!(dataTable.Rows[0]["descricao"] is DBNull)) pagamento.Descricao = Convert.ToString(dataTable.Rows[0]["descricao"]);

                return pagamento;
            }
            else
            {
                return null;
            }
        }
    }
}
