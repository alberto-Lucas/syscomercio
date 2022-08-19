using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Data;

namespace Negocios
{
    public class ProdutoFornecedorNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public int Inserir(ProdutoFornecedor produtoFornecedor)
        {
            string queryInserir = "INSERT INTO produto_fornecedor"+
                "(id_fornecedor, id_produto) VALUES " +
                "(@IdFornecedor, @IdProduto);";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdFornecedor", produtoFornecedor.Fornecedor.IdFornecedor);
            acessoDados.AdicionarParametros("@IdProduto", produtoFornecedor.Produto.IdProduto);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);
        }

        public int Apagar(int IdFornecedor, int IdProduto)
        {
            string queryApagar = "DELETE FROM produto_fornecedor WHERE id_fornecedor = @IdFornecedor AND id_produto = @IdProduto";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdFornecedor", IdFornecedor);
            acessoDados.AdicionarParametros("@IdPedidoItem", IdProduto);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }

        public ProdutoFornecedorColecao ConsultarTodosProdutosFornecedor(int IdFornecedor)
        {
            ProdutoFornecedorColecao produtoFornecedorColecao = new ProdutoFornecedorColecao();
            ProdutoNegocios produtoNegocios = new ProdutoNegocios();
            FornecedorNegocios fornecedorNegocios = new FornecedorNegocios();

            string queryConsulta = "SELECT * FROM produto_fornecedor WHERE id_fornecedor = @IdFornecedor ORDER BY id_produto";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdFornecdor", IdFornecedor);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                ProdutoFornecedor produtoFornecedor = new ProdutoFornecedor();
                produtoFornecedor.Fornecedor = fornecedorNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_fornecedor"]));
                produtoFornecedor.Produto = produtoNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_produto"]));


                produtoFornecedorColecao.Add(produtoFornecedor);
            }
            return produtoFornecedorColecao;
        }

        public ProdutoFornecedorColecao ConsultarTodosFornecedoresProduto(int IdProduto)
        {
            ProdutoFornecedorColecao produtoFornecedorColecao = new ProdutoFornecedorColecao();
            ProdutoNegocios produtoNegocios = new ProdutoNegocios();
            FornecedorNegocios fornecedorNegocios = new FornecedorNegocios();

            string queryConsulta = "SELECT * FROM produto_fornecedor WHERE id_produto = @IdProduto ORDER BY id_fornecedor";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdProduto", IdProduto);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                ProdutoFornecedor produtoFornecedor = new ProdutoFornecedor();
                produtoFornecedor.Fornecedor = fornecedorNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_fornecedor"]));
                produtoFornecedor.Produto = produtoNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_produto"]));


                produtoFornecedorColecao.Add(produtoFornecedor);
            }
            return produtoFornecedorColecao;
        }
    }
}
