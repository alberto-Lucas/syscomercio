using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Data;

namespace Negocios
{
    public class VendaItemNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public int Inserir(LancamentoItem vendaItem)
        {
            string queryInserir = "INSERT INTO venda_item "+
                "(id_venda, id_produto, preco_unitario, quantidade, valor_desconto ,total_venda) VALUES " +
                "(@IdVenda, @IdProduto, @PrecoUnitario, @Quantidade, @ValorDesconto ,@ValorTotal);";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdVenda", vendaItem.Lancamento.IdLancamento);
            acessoDados.AdicionarParametros("@IdProduto", vendaItem.Produto.IdProduto);
            acessoDados.AdicionarParametros("@PrecoUnitario", vendaItem.PrecoUnitario);
            acessoDados.AdicionarParametros("@Quantidade", vendaItem.Quantidade);
            acessoDados.AdicionarParametros("@ValorDesconto", vendaItem.ValorDesconto);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);
        }

        public int Alterar(LancamentoItem vendaItem)
        {
            string queryAlterar = "UPDATE veda_item SET "+
                "preco_unitario = @PrecoUnitario, " +
                "quantidade = @Quantidade, " +
                "valor_desconto = @ValorDesconto, "+
                "valor_total = @ValorTotal "+
                "WHERE id_venda = @IdVenda AND id_produto = @IdProduto";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdVenda", vendaItem.Lancamento.IdLancamento);
            acessoDados.AdicionarParametros("@IdProduto", vendaItem.Produto.IdProduto);
            acessoDados.AdicionarParametros("@PrecoUnitario", vendaItem.PrecoUnitario);
            acessoDados.AdicionarParametros("@Quantidade", vendaItem.Quantidade);
            acessoDados.AdicionarParametros("@ValorDesconto", vendaItem.ValorDesconto);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }

        public int Apagar(int IdVenda, int IdProduto)
        {
            string queryApagar = "DELETE FROM venda_item WHERE id_venda = @IdVenda AND id_produto= @IdProduto";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdVenda", IdVenda);
            acessoDados.AdicionarParametros("@IdProduto", IdProduto);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }

        public LancamentoItemColecao ConsultarTodosItensDaVenda(int IdVenda)
        {
            LancamentoItemColecao vendaItemColecao = new LancamentoItemColecao();
            ProdutoNegocios produtoNegocios = new ProdutoNegocios();
            VendaNegocios vendaNegocios = new VendaNegocios();

            string queryConsulta = "SELECT * FROM venda_item WHERE id_venda = @IdVenda ORDER BY id_produto";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdVenda", IdVenda);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                LancamentoItem vendaItem = new LancamentoItem();
                vendaItem.Lancamento = vendaNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_venda"]));
                vendaItem.Produto = produtoNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_produto"]));
                vendaItem.PrecoUnitario = Convert.ToDecimal(dataRow["preco_unitario"]);
                vendaItem.Quantidade = Convert.ToInt32(dataRow["quantidade"]);
                vendaItem.ValorDesconto= Convert.ToDecimal(dataRow["valor_desconto"]);

                vendaItemColecao.Add(vendaItem);
            }
            return vendaItemColecao;
        }

        public decimal ValorTotalItensDaVenda(int IdVenda)
        {
            string query = "SELECT SUM(valor_total) FROM venda_item WHERE id_venda = @IdVenda";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdVenda", IdVenda);

            return Convert.ToDecimal(acessoDados.ExecutarConsultaScalar(CommandType.Text, query));
        }
    }
}
