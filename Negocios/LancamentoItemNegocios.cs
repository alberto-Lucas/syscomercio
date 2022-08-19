using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class LancamentoItemNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public int Inserir(LancamentoItem lancamentoItem, int IdProduto, int IdLancamento)
        {
            string queryInserir = "INSERT INTO lancamento_item " +
                "(" +
                "id_produto," +
                "id_lancamento," +
                "preco_unitario," +
                "quantidade," +
                "valor_desconto, "+
                "ordem_item  " +
                ") values " +
                "(" +
                "@Produto," +
                "@IdLancamento," +
                "@PrecoUnitario," +
                "@Quantidade," +
                "@ValorDesconto, " +
                "@OrdemItem" +
                ")";

            acessoDados.LimparParametros();
            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.AdicionarParametros("@IdLancamento", IdLancamento);
            acessoDados.AdicionarParametros("@Produto", IdProduto);
            acessoDados.AdicionarParametros("@PrecoUnitario", lancamentoItem.PrecoUnitario);
            acessoDados.AdicionarParametros("@Quantidade", lancamentoItem.Quantidade);
            acessoDados.AdicionarParametros("@ValorDesconto", lancamentoItem.ValorDesconto);
            acessoDados.AdicionarParametros("@OrdemItem", lancamentoItem.ordemItem);

            acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);

            return 1;
        }

        public int AtualizarItem(int IdLancamento, int IdProduto, int Quantidade, decimal ValorDesconto)
        {
            string queryAlterar = 
                "update lancamento_item "+
                "set "+
                    "quantidade = "+
	                    "(select quantidade "+
		                    "from lancamento_item "+
		                    "where id_lancamento = @IdLancamento and id_produto = @IdProduto"+
	                    ") + @Quantidade, "+
	                "valor_desconto = "+
	                    "(select valor_desconto "+
		                    "from lancamento_item "+
		                    "where id_lancamento = @IdLancamento and id_produto = @IdProduto "+
	                    ") + @ValorDesconto "+
                "where id_lancamento = @IdLancamento and id_produto = @IdProduto";

            var usuarioLogado = UsuarioLogado.Instancia;

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdLancamento", IdLancamento);
            acessoDados.AdicionarParametros("@IdProduto", IdProduto);
            acessoDados.AdicionarParametros("@Quantidade", Quantidade);
            acessoDados.AdicionarParametros("@ValorDesconto", ValorDesconto);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }
        public int AlterarItem(int IdLancamento, int IdProduto, int Quantidade, decimal ValorDesconto)
        {
            string queryAlterar =
                "update lancamento_item " +
                "set " +
                    "quantidade = @Quantidade, " +
                    "valor_desconto = @ValorDesconto " +
                "where id_lancamento = @IdLancamento and id_produto = @IdProduto";

            var usuarioLogado = UsuarioLogado.Instancia;

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdLancamento", IdLancamento);
            acessoDados.AdicionarParametros("@IdProduto", IdProduto);
            acessoDados.AdicionarParametros("@Quantidade", Quantidade);
            acessoDados.AdicionarParametros("@ValorDesconto", ValorDesconto);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }

        public int ExcluirItem(int IdLancamento, int IdProduto)
        {
            string queryApagar = "DELETE FROM lancamento_item " +
                "WHERE id_lancamento = @IdLancamento AND id_produto = @Produto";

            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdLancamento", IdLancamento);
            acessoDados.AdicionarParametros("@Produto", IdProduto);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }
        public int ExcluirLancamento(int IdLancamento)
        {
            string queryApagar = "DELETE FROM lancamento_item " +
                "WHERE id_lancamento = @IdLancamento";

            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdLancamento", IdLancamento);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }

        public LancamentoItemColecao ConsultarPorLancamento(int lancamento)
        {
            LancamentoItemColecao lancamentoItemColecao = new LancamentoItemColecao();
            //ProdutoNegocios produtoNegocios = new ProdutoNegocios();

            string query = "SELECT * FROM lancamento_item WHERE id_lancamento = @IdLancamento ORDER BY ordem_item";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdLancamento", lancamento);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                LancamentoItem lancamentoItem = new LancamentoItem();
                LancamentoNegocios lancamentoNegocios = new LancamentoNegocios();
                ProdutoNegocios produtoNegocios = new ProdutoNegocios();

                //lancamentoItem.Lancamento = lancamentoNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_lancamento"]));
                lancamentoItem.Produto = produtoNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_produto"]));
                lancamentoItem.PrecoUnitario = Convert.ToDecimal(dataRow["preco_unitario"]);
                lancamentoItem.Quantidade = Convert.ToInt32(dataRow["quantidade"]);
                lancamentoItem.ValorDesconto = Convert.ToDecimal(dataRow["valor_desconto"]);
                lancamentoItem.ordemItem = Convert.ToInt32(dataRow["ordem_item"]);
                lancamentoItemColecao.Add(lancamentoItem);
            }
            return lancamentoItemColecao;
        }

        public LancamentoItemColecao ConsultarPorProduto(int produto)
        {
            LancamentoItemColecao lancamentoItemColecao = new LancamentoItemColecao();
            //ProdutoNegocios produtoNegocios = new ProdutoNegocios();

            string query = "SELECT * FROM lancamento_item WHERE id_produto = @IdProduto";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdProduto", produto);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                LancamentoItem lancamentoItem = new LancamentoItem();
                LancamentoNegocios lancamentoNegocios = new LancamentoNegocios();
                ProdutoNegocios produtoNegocios = new ProdutoNegocios();

                lancamentoItem.Lancamento = lancamentoNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_lancamento"]));
                lancamentoItem.Produto = produtoNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_produto"]));
                lancamentoItem.PrecoUnitario = Convert.ToDecimal(dataRow["preco_unitario"]);
                lancamentoItem.Quantidade = Convert.ToInt32(dataRow["quantidade"]);
                lancamentoItem.ValorDesconto = Convert.ToDecimal(dataRow["valor_desconto"]);
                lancamentoItem.ordemItem = Convert.ToInt32(dataRow["ordem_item"]);
                lancamentoItemColecao.Add(lancamentoItem);
            }
            return lancamentoItemColecao;
        }
        public decimal ValorTotalBruto(int IdLancamento)
        {
            string query = "SELECT SUM((preco_unitario * quantidade)) FROM lancamento_item WHERE id_lancamento = @IdLancamento";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdLancamento", IdLancamento);

            return Convert.ToDecimal(acessoDados.ExecutarConsultaScalar(CommandType.Text, query));
        }
        public decimal QuantidadeItens(int IdLancamento)
        {
            string query = "SELECT COUNT(quantidade) FROM lancamento_item WHERE id_lancamento = @IdLancamento";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdLancamento", IdLancamento);

            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(CommandType.Text, query));
        }
        public decimal ValorTotalDesc(int IdLancamento)
        {
            string query = "SELECT SUM(valor_desconto) FROM lancamento_item WHERE id_lancamento = @IdLancamento";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdLancamento", IdLancamento);

            return Convert.ToDecimal(acessoDados.ExecutarConsultaScalar(CommandType.Text, query));
        }

        public int maxItem(int IdLancamento)
        {
            string query = "SELECT MAX(ordem_item) FROM lancamento_item WHERE id_lancamento = @IdLancamento";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdLancamento", IdLancamento);

            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(CommandType.Text, query));
        }
    }
}
