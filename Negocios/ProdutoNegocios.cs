using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Data;

namespace Negocios
{
    public class ProdutoNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public int TotalProdutos()
        {

            //Limpa qualquer sujeira do objeto que armazena as variáveis.
            acessoDados.LimparParametros();
            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT COUNT(id_produto) FROM produto"));
        }

        public int Inserir(Produto produto)
        {
            string queryInserir = "INSERT INTO produto "+
                "(" +
                "descricao     ," +
                "codigo_barras         ," +
                "preco_compra          ," +
                "preco_venda           ," +
                "margem_lucro          ," +
                "unidade               ," +
                "ncm                   ," +
                "estoque               ," +
                "observacao            ," +
                "id_usuario_cadastro   ," +
                "id_usuario_alteracao  ," +
                "apagado               ," +
                "ativo                 ," +
                "data_cadastro         ," +
                "data_alteracao         " +
                ") values (" +
                "@Descricao          ," +
                "@CodigoBarras       ," +
                "@PrecoCompra        ," +
                "@PrecoVenda         ," +
                "@MargemLucro        ," +
                "@Unidade            ," +
                "@Ncm                ," +
                "@Estoque            ," +
                "@Observacao         ," +
                "@UsuarioCadastro    ," +
                "@UsuarioAlteracao   ," +
                "'N'           ," +
                "@Ativo              ," +
                "@DataCadastro       ," +
                "@DataAlteracao       " +
                ")";

            acessoDados.LimparParametros();
            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.AdicionarParametros("@Descricao          ", produto.Descricao);
            acessoDados.AdicionarParametros("@CodigoBarras       ", produto.CodigoBarras);
            acessoDados.AdicionarParametros("@PrecoCompra        ", produto.PrecoCompra);
            acessoDados.AdicionarParametros("@PrecoVenda         ", produto.PrecoVenda);
            acessoDados.AdicionarParametros("@MargemLucro        ", produto.MargemLucro);
            acessoDados.AdicionarParametros("@Unidade            ", produto.Unidade);
            acessoDados.AdicionarParametros("@Ncm                ", produto.Ncm);
            acessoDados.AdicionarParametros("@Estoque            ", produto.Estoque);
            acessoDados.AdicionarParametros("@Observacao         ", produto.Observacao);
            acessoDados.AdicionarParametros("@UsuarioCadastro    ", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@UsuarioAlteracao   ", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@Ativo              ", produto.Ativo);
            acessoDados.AdicionarParametros("@DataCadastro       ", DateTime.Now);
            acessoDados.AdicionarParametros("@DataAlteracao      ", DateTime.Now);

            acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);

            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(CommandType.Text, "SELECT MAX(id_produto) FROM produto"));
        }

        public int Alterar(Produto produto)
        {
            string queryInserir = "UPDATE produto SET "+
                "descricao=@Descricao," +
                "codigo_barras=@CodigoBarras," +
                "preco_compra=@PrecoCompra," +
                "preco_venda=@PrecoVenda," +
                "margem_lucro=@MargemLucro," +
                "unidade=@Unidade," +
                "ncm=@Ncm," +
                "estoque=@Estoque," +
                "observacao=@Observacao," +
                "id_usuario_alteracao=@UsuarioAlteracao," +
                "ativo=@Ativo," +
                "data_alteracao=@DataAlteracao " +
                "WHERE id_produto= @IdProduto";

            acessoDados.LimparParametros();
            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.AdicionarParametros("@IdProduto", produto.IdProduto);
            acessoDados.AdicionarParametros("@Descricao", produto.Descricao);
            acessoDados.AdicionarParametros("@CodigoBarras", produto.CodigoBarras);
            acessoDados.AdicionarParametros("@PrecoCompra", produto.PrecoCompra);
            acessoDados.AdicionarParametros("@PrecoVenda", produto.PrecoVenda);
            acessoDados.AdicionarParametros("@MargemLucro", produto.MargemLucro);
            acessoDados.AdicionarParametros("@Unidade", produto.Unidade);
            acessoDados.AdicionarParametros("@Ncm", produto.Ncm);
            acessoDados.AdicionarParametros("@Estoque", produto.Estoque);
            acessoDados.AdicionarParametros("@Observacao", produto.Observacao);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@Ativo", produto.Ativo);
            acessoDados.AdicionarParametros("@DataAlteracao", DateTime.Now);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);
        }

        public int Apagar(Produto produto)
        {
            string queryInserir = "UPDATE produto SET " +
                "apagado = 'S'," +
                "ativo =  'N'," +
                "id_usuario_alteracao  =@UsuarioAlteracao," +
                "data_alteracao = @DataAlteracao " +
                "WHERE id_produto = @IdProduto";

            acessoDados.LimparParametros();
            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.AdicionarParametros("@IdProduto          ", produto.IdProduto);
            acessoDados.AdicionarParametros("@UsuarioAlteracao   ", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@DataAlteracao      ", DateTime.Now);
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);
        }

        public ProdutoColecao ConsultarTodos()
        {
            ProdutoColecao produtoColecao = new ProdutoColecao();
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            string queryConsulta = "SELECT * FROM produto WHERE apagado <>'S' ORDER BY descricao";

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Produto produto = new Produto();
                produto.IdProduto = Convert.ToInt32(dataRow["id_produto"]);
                if (!(dataRow["descricao"] is DBNull)) produto.Descricao = Convert.ToString(dataRow["descricao"]); else produto.Descricao = "";
                if (!(dataRow["codigo_barras"] is DBNull)) produto.CodigoBarras = Convert.ToString(dataRow["codigo_barras"]); else produto.CodigoBarras = "";
                if (!(dataRow["preco_compra"] is DBNull)) produto.PrecoCompra = Convert.ToDecimal(dataRow["preco_compra"]); else produto.PrecoCompra = 0;
                if (!(dataRow["preco_venda"] is DBNull)) produto.PrecoVenda = Convert.ToDecimal(dataRow["preco_venda"]); else produto.PrecoVenda = 0;
                if (!(dataRow["margem_lucro"] is DBNull)) produto.MargemLucro = Convert.ToDecimal(dataRow["margem_lucro"]); else produto.MargemLucro = 0;
                if (!(dataRow["unidade"] is DBNull)) produto.Unidade = Convert.ToString(dataRow["unidade"]); else produto.Unidade = "";
                if (!(dataRow["ncm"] is DBNull)) produto.Ncm = Convert.ToString(dataRow["ncm"]); else produto.Ncm = "";
                if (!(dataRow["estoque"] is DBNull)) produto.Estoque = Convert.ToInt32(dataRow["estoque"]); else produto.Estoque = 0;
                if (!(dataRow["observacao"] is DBNull)) produto.Observacao = Convert.ToString(dataRow["observacao"]); else produto.Observacao = "";
                produto.UsuarioCadastro = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_cadastro"]));
                produto.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_alteracao"]));
                if (!(dataRow["ativo"] is DBNull)) produto.Ativo = Convert.ToString(dataRow["ativo"]); else produto.Ativo = "";
                if (!(dataRow["data_cadastro"] is DBNull)) produto.DataCadastro = Convert.ToDateTime(dataRow["data_cadastro"]);
                if (!(dataRow["data_alteracao"] is DBNull)) produto.DataAlteracao = Convert.ToDateTime(dataRow["data_alteracao"]);

                produtoColecao.Add(produto);
            }
            return produtoColecao;
        }

        public Produto ConsultarPorId(int IdProduto)
        {
            string queryConsulta = "SELECT * FROM produto WHERE id_produto = @IdProduto AND apagado <>'S' ORDER BY descricao";

            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdProduto", IdProduto);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);
            if (dataTable.Rows.Count > 0)
            {
                Produto produto = new Produto();
                produto.IdProduto = Convert.ToInt32(dataTable.Rows[0]["id_produto"]);
                if (!(dataTable.Rows[0]["descricao"] is DBNull)) produto.Descricao = Convert.ToString(dataTable.Rows[0]["descricao"]); else produto.Descricao = "";
                if (!(dataTable.Rows[0]["codigo_barras"] is DBNull)) produto.CodigoBarras = Convert.ToString(dataTable.Rows[0]["codigo_barras"]); else produto.CodigoBarras = "";
                if (!(dataTable.Rows[0]["preco_compra"] is DBNull)) produto.PrecoCompra = Convert.ToDecimal(dataTable.Rows[0]["preco_compra"]); else produto.PrecoCompra = 0;
                if (!(dataTable.Rows[0]["preco_venda"] is DBNull)) produto.PrecoVenda = Convert.ToDecimal(dataTable.Rows[0]["preco_venda"]); else produto.PrecoVenda = 0;
                if (!(dataTable.Rows[0]["margem_lucro"] is DBNull)) produto.MargemLucro = Convert.ToDecimal(dataTable.Rows[0]["margem_lucro"]); else produto.MargemLucro = 0;
                if (!(dataTable.Rows[0]["unidade"] is DBNull)) produto.Unidade = Convert.ToString(dataTable.Rows[0]["unidade"]); else produto.Unidade = "";
                if (!(dataTable.Rows[0]["ncm"] is DBNull)) produto.Ncm = Convert.ToString(dataTable.Rows[0]["ncm"]); else produto.Ncm = "";
                if (!(dataTable.Rows[0]["estoque"] is DBNull)) produto.Estoque = Convert.ToInt32(dataTable.Rows[0]["estoque"]); else produto.Estoque = 0;
                if (!(dataTable.Rows[0]["observacao"] is DBNull)) produto.Observacao = Convert.ToString(dataTable.Rows[0]["observacao"]); else produto.Observacao = "";
                if (!(dataTable.Rows[0]["id_usuario_cadastro"] is DBNull)) produto.UsuarioCadastro = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataTable.Rows[0]["id_usuario_cadastro"]));
                if (!(dataTable.Rows[0]["id_usuario_alteracao"] is DBNull)) produto.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataTable.Rows[0]["id_usuario_alteracao"]));
                if (!(dataTable.Rows[0]["ativo"] is DBNull)) produto.Ativo = Convert.ToString(dataTable.Rows[0]["ativo"]); else produto.Ativo = "";
                if (!(dataTable.Rows[0]["data_cadastro"] is DBNull)) produto.DataCadastro = Convert.ToDateTime(dataTable.Rows[0]["data_cadastro"]);
                if (!(dataTable.Rows[0]["data_alteracao"] is DBNull)) produto.DataAlteracao = Convert.ToDateTime(dataTable.Rows[0]["data_alteracao"]);

                return produto;
            }
            else
            {
                return null;
            }
        }


        public ProdutoColecao ConsultarPorBarras(string CodigoBarras)
        {
            ProdutoColecao produtoColecao = new ProdutoColecao();
            string queryConsulta = "SELECT * FROM produto WHERE codigo_barras = @CodigoBarras AND apagado <>'S' ORDER BY descricao";
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@CodigoBarras", CodigoBarras);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Produto produto = new Produto();
                produto.IdProduto = Convert.ToInt32(dataRow["id_produto"]);
                if (!(dataRow["descricao"] is DBNull)) produto.Descricao = Convert.ToString(dataRow["descricao"]); else produto.Descricao = "";
                if (!(dataRow["codigo_barras"] is DBNull)) produto.CodigoBarras = Convert.ToString(dataRow["codigo_barras"]); else produto.CodigoBarras = "";
                if (!(dataRow["preco_compra"] is DBNull)) produto.PrecoCompra = Convert.ToDecimal(dataRow["preco_compra"]); else produto.PrecoCompra = 0;
                if (!(dataRow["preco_venda"] is DBNull)) produto.PrecoVenda = Convert.ToDecimal(dataRow["preco_venda"]); else produto.PrecoVenda = 0;
                if (!(dataRow["margem_lucro"] is DBNull)) produto.MargemLucro = Convert.ToDecimal(dataRow["margem_lucro"]); else produto.MargemLucro = 0;
                if (!(dataRow["unidade"] is DBNull)) produto.Unidade = Convert.ToString(dataRow["unidade"]); else produto.Unidade = "";
                if (!(dataRow["ncm"] is DBNull)) produto.Ncm = Convert.ToString(dataRow["ncm"]); else produto.Ncm = "";
                if (!(dataRow["estoque"] is DBNull)) produto.Estoque = Convert.ToInt32(dataRow["estoque"]); else produto.Estoque = 0;
                if (!(dataRow["observacao"] is DBNull)) produto.Observacao = Convert.ToString(dataRow["observacao"]); else produto.Observacao = "";
                if (!(dataRow["id_usuario_cadastro"] is DBNull)) produto.UsuarioCadastro = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_cadastro"])); else produto.UsuarioCadastro.IdUsuario = 0;
                if (!(dataRow["id_usuario_alteracao"] is DBNull)) produto.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_alteracao"])); else produto.UsuarioAlteracao.IdUsuario = 0;
                if (!(dataRow["ativo"] is DBNull)) produto.Ativo = Convert.ToString(dataRow["ativo"]); else produto.Ativo = "";
                if (!(dataRow["data_cadastro"] is DBNull)) produto.DataCadastro = Convert.ToDateTime(dataRow["data_cadastro"]);
                if (!(dataRow["data_alteracao"] is DBNull)) produto.DataAlteracao = Convert.ToDateTime(dataRow["data_alteracao"]);

                produtoColecao.Add(produto);
            }
            return produtoColecao;
        }




        public ProdutoColecao ConsultarPorDescricao(string Descricao)
        {
            ProdutoColecao produtoColecao = new ProdutoColecao();
            string queryConsulta = "SELECT * FROM produto WHERE descricao LIKE '%' + @Descricao + '%' AND apagado <>'S' ORDER BY descricao";
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@Descricao", Descricao);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Produto produto = new Produto();
                produto.IdProduto = Convert.ToInt32(dataRow["id_produto"]);
                if (!(dataRow["descricao"] is DBNull)) produto.Descricao = Convert.ToString(dataRow["descricao"]); else produto.Descricao = "";
                if (!(dataRow["codigo_barras"] is DBNull)) produto.CodigoBarras = Convert.ToString(dataRow["codigo_barras"]); else produto.CodigoBarras = "";
                if (!(dataRow["preco_compra"] is DBNull)) produto.PrecoCompra = Convert.ToDecimal(dataRow["preco_compra"]); else produto.PrecoCompra = 0;
                if (!(dataRow["preco_venda"] is DBNull)) produto.PrecoVenda = Convert.ToDecimal(dataRow["preco_venda"]); else produto.PrecoVenda = 0;
                if (!(dataRow["margem_lucro"] is DBNull)) produto.MargemLucro = Convert.ToDecimal(dataRow["margem_lucro"]); else produto.MargemLucro = 0;
                if (!(dataRow["unidade"] is DBNull)) produto.Unidade = Convert.ToString(dataRow["unidade"]); else produto.Unidade = "";
                if (!(dataRow["ncm"] is DBNull)) produto.Ncm = Convert.ToString(dataRow["ncm"]); else produto.Ncm = "";
                if (!(dataRow["estoque"] is DBNull)) produto.Estoque = Convert.ToInt32(dataRow["estoque"]); else produto.Estoque = 0;
                if (!(dataRow["observacao"] is DBNull)) produto.Observacao = Convert.ToString(dataRow["observacao"]); else produto.Observacao = "";
                if (!(dataRow["id_usuario_cadastro"] is DBNull)) produto.UsuarioCadastro = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_cadastro"])); else produto.UsuarioCadastro.IdUsuario = 0;
                if (!(dataRow["id_usuario_alteracao"] is DBNull)) produto.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_alteracao"])); else produto.UsuarioAlteracao.IdUsuario = 0;
                if (!(dataRow["ativo"] is DBNull)) produto.Ativo = Convert.ToString(dataRow["ativo"]); else produto.Ativo = "";
                if (!(dataRow["data_cadastro"] is DBNull)) produto.DataCadastro = Convert.ToDateTime(dataRow["data_cadastro"]);
                if (!(dataRow["data_alteracao"] is DBNull)) produto.DataAlteracao = Convert.ToDateTime(dataRow["data_alteracao"]);

                produtoColecao.Add(produto);
            }
            return produtoColecao;
        }
    }
}
