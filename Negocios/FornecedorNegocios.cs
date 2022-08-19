using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Data;

namespace Negocios
{
    public class FornecedorNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public int TotalFornecedores()
        {
            acessoDados.LimparParametros();
            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT count(id_fornecedor) FROM fornecedor"));
        }

        public int Inserir(Fornecedor fornecedor)
        {
            string queryInserir = "INSERT INTO fornecedor " +
                "(" +
                "razao_social," +
                "nome_fantasia," +
                "cnpj," +
                "inscr_estadual," +
                "data_registro," +
                "observacao," +
                "id_usuario_cadastro," +
                "id_usuario_alteracao," +
                "apagado," +
                "ativo," +
                "data_cadastro," +
                "data_alteracao " +
                ") values " +
                "(" +
                "@RazaoSocial," +
                "@NomeFantasia," +
                "@Cnpj," +
                "@Ie," +
                "@DataRegistro," +
                "@Observacao," +
                "@UsuarioCadastro," +
                "@UsuarioAlteracao," +
                "@Apagado," +
                "@Ativo," +
                "@DataCadastro," +
                "@DataAlteracao" +
                ")";

            acessoDados.LimparParametros();
            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.AdicionarParametros("@RazaoSocial", fornecedor.RazaoSocial);
            acessoDados.AdicionarParametros("@NomeFantasia", fornecedor.NomeFantasia);
            acessoDados.AdicionarParametros("@Cnpj", fornecedor.Cnpj);
            acessoDados.AdicionarParametros("@Ie", fornecedor.InscricaoEstadual);
            acessoDados.AdicionarParametros("@DataRegistro", fornecedor.DataRegistro);
            acessoDados.AdicionarParametros("@Observacao", fornecedor.Observacao);
            acessoDados.AdicionarParametros("@UsuarioCadastro", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@Apagado", "N");
            acessoDados.AdicionarParametros("@Ativo", fornecedor.Ativo);
            acessoDados.AdicionarParametros("@DataCadastro", DateTime.Now);
            acessoDados.AdicionarParametros("@DataAlteracao", DateTime.Now);


            acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);

            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT MAX(id_fornecedor) FROM fornecedor"));
        }

        public int AtualizarAlteracao(int idFornecedor)
        {
            string queryAlterar = "UPDATE fornecedor SET " +
                "id_usuario_alteracao=@UsuarioAlteracao," +
                "data_alteracao =@DataAlteracao " +
                "WHERE id_fornecedor = @IdFornecedor";

            acessoDados.LimparParametros();
            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.AdicionarParametros("@IdFornecedor", idFornecedor);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@DataAlteracao", DateTime.Now);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }
        public int Alterar(Fornecedor fornecedor)
        {
            string queryAlterar = "UPDATE fornecedor SET " +
                "razao_social=@RazaoSocial," +
                "nome_fantasia=@NomeFantasia," +
                "cnpj=@Cnpj," +
                "inscr_estadual=@Ie," +
                "data_registro=@DataRegistro," +
                "observacao=@Observacao," +
                "id_usuario_alteracao=@UsuarioAlteracao," +
                "ativo=@Ativo," +
                "data_alteracao =@DataAlteracao " +
                "WHERE id_fornecedor = @IdFornecedor";

            acessoDados.LimparParametros();
            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.AdicionarParametros("@IdFornecedor", fornecedor.IdFornecedor);
            acessoDados.AdicionarParametros("@RazaoSocial", fornecedor.RazaoSocial);
            acessoDados.AdicionarParametros("@NomeFantasia", fornecedor.NomeFantasia);
            acessoDados.AdicionarParametros("@Cnpj", fornecedor.Cnpj);
            acessoDados.AdicionarParametros("@Ie", fornecedor.InscricaoEstadual);
            acessoDados.AdicionarParametros("@DataRegistro", fornecedor.DataRegistro);
            acessoDados.AdicionarParametros("@Observacao", fornecedor.Observacao);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@Ativo", fornecedor.Ativo);
            acessoDados.AdicionarParametros("@DataAlteracao", DateTime.Now);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }

        public int Apagar(Fornecedor fornecedor)
        {
            string queryApagar = "UPDATE fornecedor SET " +
                "apagado = 'S'," +
                "ativo =  'N'," +
                "data_alteracao = @DataAlteracao," +
                "id_usuario_alteracao=@UsuarioAlteracao " +
                "WHERE id_fornecedor = @IdFornecedor";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdFornecedor", fornecedor.IdFornecedor);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", fornecedor.UsuarioAlteracao.IdUsuario);
            acessoDados.AdicionarParametros("@DataAlteracao", fornecedor.DataAlteracao);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }

        public FornecedorColecao ConsultarPorNome(string nome)
        {
            FornecedorColecao fornecedorColecao = new FornecedorColecao();
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            string query = "SELECT * FROM fornecedor WHERE razao_social LIKE '%' + @RazaoSocial + '%' AND apagado <>'S'";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@RazaoSocial", nome.Trim());

            DataTable dataTable = acessoDados.ExecutarConsulta(
                CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Fornecedor fornecedor = new Fornecedor();

                fornecedor.IdFornecedor = Convert.ToInt32(dataRow["id_fornecedor"]);


                if (!(dataRow["razao_social"] is DBNull))
                    fornecedor.RazaoSocial = Convert.ToString(dataRow["razao_social"]);
                else
                    fornecedor.RazaoSocial = "";

                if (!(dataRow["nome_fantasia"] is DBNull))
                    fornecedor.NomeFantasia = Convert.ToString(dataRow["nome_fantasia"]);
                else
                    fornecedor.NomeFantasia = "";

                if (!(dataRow["cnpj"] is DBNull))
                    fornecedor.Cnpj = Convert.ToString(dataRow["cnpj"]);
                else
                    fornecedor.Cnpj = "";

                if (!(dataRow["inscr_estadual"] is DBNull))
                    fornecedor.InscricaoEstadual = Convert.ToString(dataRow["inscr_estadual"]);
                else
                    fornecedor.InscricaoEstadual = "";

                if (!(dataRow["data_registro"] is DBNull))
                    fornecedor.DataRegistro = Convert.ToDateTime(dataRow["data_registro"]);

                if (!(dataRow["observacao"] is DBNull))
                    fornecedor.Observacao = Convert.ToString(dataRow["observacao"]);
                else
                    fornecedor.Observacao = "";

                fornecedor.UsuarioCadastro = usuarioNegocios.ConsultarPorId(Convert.ToInt32(
                    dataRow["id_usuario_cadastro"]));


                fornecedor.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(
                    dataRow["id_usuario_alteracao"]));


                if (!(dataRow["ativo"] is DBNull))
                    fornecedor.Ativo = Convert.ToString(dataRow["ativo"]);
                else
                    fornecedor.Ativo = "";

                if (!(dataRow["data_cadastro"] is DBNull))
                    fornecedor.DataCadastro = Convert.ToDateTime(dataRow["data_cadastro"]);

                if (!(dataRow["data_alteracao"] is DBNull))
                    fornecedor.DataAlteracao = Convert.ToDateTime(dataRow["data_alteracao"]);



                fornecedorColecao.Add(fornecedor);
            }
            return fornecedorColecao;
        }

        public Fornecedor ConsultarPorId(int IdFornecedor)
        {
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            string queryConsulta = "SELECT * FROM fornecedor WHERE id_fornecedor = @IdFornecedor AND apagado <>'S'";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdFornecedor", IdFornecedor);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            if (dataTable.Rows.Count > 0)
            {
                Fornecedor fornecedor = new Fornecedor();

                fornecedor.IdFornecedor = Convert.ToInt32(dataTable.Rows[0]["id_fornecedor"]);
                fornecedor.RazaoSocial = Convert.ToString(dataTable.Rows[0]["razao_social"]);
                fornecedor.NomeFantasia = Convert.ToString(dataTable.Rows[0]["nome_fantasia"]);
                fornecedor.Cnpj = Convert.ToString(dataTable.Rows[0]["cnpj"]);
                fornecedor.InscricaoEstadual = Convert.ToString(dataTable.Rows[0]["inscr_estadual"]);
                fornecedor.DataRegistro = Convert.ToDateTime(dataTable.Rows[0]["data_registro"]);
                fornecedor.Observacao = Convert.ToString(dataTable.Rows[0]["observacao"]);
                fornecedor.UsuarioCadastro = usuarioNegocios.ConsultarPorId(Convert.ToInt32(
                    dataTable.Rows[0]["id_usuario_cadastro"]));
                fornecedor.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(
                    dataTable.Rows[0]["id_usuario_alteracao"]));
                fornecedor.Apagado = Convert.ToString(dataTable.Rows[0]["apagado"]);
                fornecedor.Ativo = Convert.ToString(dataTable.Rows[0]["ativo"]);
                fornecedor.DataCadastro = Convert.ToDateTime(dataTable.Rows[0]["data_cadastro"]);
                fornecedor.DataAlteracao = Convert.ToDateTime(dataTable.Rows[0]["data_alteracao"]);

                return fornecedor;
            }
            else
            {
                return null;
            }
        }
        
    }
}
