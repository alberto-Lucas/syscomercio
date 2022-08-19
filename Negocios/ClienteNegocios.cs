using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Data;

namespace Negocios
{
    public class ClienteNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();
        
        public int TotalClientes()
        {
            acessoDados.LimparParametros();
            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT count(id_cliente) FROM cliente"));
        }

        public int Inserir(Cliente cliente)
        {
            string queryInserir = "INSERT INTO cliente "+
                "("+
                "tipo_pessoa,"+
                "nome_razaosocial,"+
                "apelido_nomefantasia,"+
                "cpf_cnpj,"+
                "rg_ie,"+
                "dnasc_dreg,"+
                "observacao,"+
                "id_usuario_cadastro,"+
                "id_usuario_alteracao," +
                "apagado,"+
                "ativo,"+
                "data_cadastro,"+
                "data_alteracao" +
                ") values " +
                "("+
                "@TipoPessoa," +
                "@NomeRazaoSocial," +
                "@ApelidoNomeFantasia," +
                "@CpfCnpj," +
                "@RgIe," +
                "@DataNascimentoRegistro," +
                "@Observacao," +
                "@UsuarioCadastro," +
                "@UsuarioAlteracao," +
                "'N'," +
                "@Ativo," +
                "@DataCadastro," +
                "@DataAlteracao" +
                ")";

            acessoDados.LimparParametros();
            var usuarioLogado = UsuarioLogado.Instancia;

            acessoDados.AdicionarParametros("@TipoPessoa", cliente.TipoPessoa);
            acessoDados.AdicionarParametros("@NomeRazaoSocial", cliente.NomeRazaoSocial.Trim());
            acessoDados.AdicionarParametros("@ApelidoNomeFantasia", cliente.ApelidoNomeFantasia.Trim());
            acessoDados.AdicionarParametros("@CpfCnpj", cliente.CpfCnpj.Trim());
            acessoDados.AdicionarParametros("@RgIe", cliente.RgIe.Trim());
            acessoDados.AdicionarParametros("@DataNascimentoRegistro", cliente.DataNascimentoRegistro);
            acessoDados.AdicionarParametros("@Observacao", cliente.Observacao);
            acessoDados.AdicionarParametros("@UsuarioCadastro", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@Ativo", cliente.Ativo);
            acessoDados.AdicionarParametros("@DataCadastro", DateTime.Now);
            acessoDados.AdicionarParametros("@DataAlteracao", DateTime.Now);


            acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);

            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT MAX(id_cliente) FROM cliente"));
        }

        public int AltualizarAlteracao(int idCliente)
        {
            string queryAlterar = "UPDATE cliente SET " +
                "id_usuario_alteracao = @UsuarioAlteracao," +
                "data_alteracao = @DataAlteracao " +
                "WHERE id_cliente = @IdCliente";

            var usuarioLogado = UsuarioLogado.Instancia;

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdCliente", idCliente);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@DataAlteracao", DateTime.Now);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }
        public int Alterar(Cliente cliente)
        {
            string queryAlterar = "UPDATE cliente SET "+
                "tipo_pessoa = @TipoPessoa,"+
                "nome_razaosocial = @NomeRazaoSocial,"+
                "apelido_nomefantasia = @ApelidoNomeFantasia,"+
                "cpf_cnpj = @CpfCnpj,"+
                "rg_ie = @RgIe,"+
                "dnasc_dreg = @DataNascimentoRegistro,"+
                "observacao = @Observacao,"+
                "id_usuario_alteracao = @UsuarioAlteracao,"+
                "ativo = @Ativo,"+
                "data_alteracao = @DataAlteracao "+
                "WHERE id_cliente = @IdCliente";

            var usuarioLogado = UsuarioLogado.Instancia;

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdCliente", cliente.IdCliente);
            acessoDados.AdicionarParametros("@TipoPessoa", cliente.TipoPessoa);
            acessoDados.AdicionarParametros("@NomeRazaoSocial", cliente.NomeRazaoSocial.Trim());
            acessoDados.AdicionarParametros("@ApelidoNomeFantasia", cliente.ApelidoNomeFantasia.Trim());
            acessoDados.AdicionarParametros("@CpfCnpj", cliente.CpfCnpj.Trim());
            acessoDados.AdicionarParametros("@RgIe", cliente.RgIe.Trim());
            acessoDados.AdicionarParametros("@DataNascimentoRegistro", cliente.DataNascimentoRegistro);
            acessoDados.AdicionarParametros("@Observacao", cliente.Observacao);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@Ativo", cliente.Ativo);
            acessoDados.AdicionarParametros("@DataAlteracao", DateTime.Now);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }

        public int Apagar(Cliente cliente)
        {
            string queryApagar = "UPDATE cliente SET " +
                "apagado = 'S'," +
                "ativo =  'N'," +
                "id_usuario_alteracao  =@UsuarioAlteracao," +
                "data_alteracao = @DataAlteracao " +
                "WHERE id_cliente = @IdCliente";

            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdCliente", cliente.IdCliente);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@DataAlteracao", DateTime.Now);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }

        public ClienteColecao ConsultarPorNome(string nome)
        {
            ClienteColecao clienteColecao = new ClienteColecao();
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            string query = "SELECT * FROM cliente WHERE nome_razaosocial LIKE '%' + @NomeRazaoSocial + '%' AND apagado <>'S' ORDER BY nome_razaosocial";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@NomeRazaoSocial", nome.Trim());

            DataTable dataTable = acessoDados.ExecutarConsulta(
                CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Cliente cliente = new Cliente();

                cliente.IdCliente = Convert.ToInt32(dataRow["id_cliente"]);


                if (!(dataRow["tipo_pessoa"] is DBNull))
                    cliente.TipoPessoa = Convert.ToString(dataRow["tipo_pessoa"]);
                else
                    cliente.TipoPessoa = "";

                if (!(dataRow["nome_razaosocial"] is DBNull))
                    cliente.NomeRazaoSocial = Convert.ToString(dataRow["nome_razaosocial"]);
                else
                    cliente.NomeRazaoSocial = "";

                if (!(dataRow["apelido_nomefantasia"] is DBNull))
                    cliente.ApelidoNomeFantasia= Convert.ToString(dataRow["apelido_nomefantasia"]);
                else
                    cliente.ApelidoNomeFantasia = "";

                if (!(dataRow["cpf_cnpj"] is DBNull))
                    cliente.CpfCnpj= Convert.ToString(dataRow["cpf_cnpj"]);
                else
                    cliente.CpfCnpj = "";

                if (!(dataRow["rg_ie"] is DBNull))
                    cliente.RgIe = Convert.ToString(dataRow["rg_ie"]);
                else
                    cliente.RgIe = "";

                if (!(dataRow["dnasc_dreg"] is DBNull))
                    cliente.DataNascimentoRegistro = Convert.ToDateTime(dataRow["dnasc_dreg"]);

                if (!(dataRow["observacao"] is DBNull))
                    cliente.Observacao = Convert.ToString(dataRow["observacao"]);
                else
                    cliente.Observacao = "";

                cliente.UsuarioCadastro = usuarioNegocios.ConsultarPorId(Convert.ToInt32(
                    dataRow["id_usuario_cadastro"]));


                cliente.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(
                    dataRow["id_usuario_alteracao"]));


                if (!(dataRow["apagado"] is DBNull))
                    cliente.Apagado = Convert.ToString(dataRow["apagado"]);
                else
                    cliente.Apagado = "";

                if (!(dataRow["ativo"] is DBNull))
                    cliente.Ativo = Convert.ToString(dataRow["ativo"]);
                else
                    cliente.Ativo = "";

                if (!(dataRow["data_cadastro"] is DBNull))
                    cliente.DataCadastro = Convert.ToDateTime(dataRow["data_cadastro"]);

                if (!(dataRow["data_alteracao"] is DBNull))
                    cliente.DataAlteracao = Convert.ToDateTime(dataRow["data_alteracao"]);



                clienteColecao.Add(cliente);
            }
            return clienteColecao;
        }
        public ClienteColecao ConsultarTodos()
        {
            ClienteColecao clienteColecao = new ClienteColecao();
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();

            string queryConsulta = "SELECT * FROM cliente WHERE apagado <> 'S' ORDER BY nome_razaosocial";

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.IdCliente = Convert.ToInt32(dataRow["id_cliente"]);
                if (!(dataRow["tipo_pessoa"] is DBNull))
                    cliente.TipoPessoa = Convert.ToString(dataRow["tipo_pessoa"]);
                if (!(dataRow["nome_razaosocial"] is DBNull))
                    cliente.NomeRazaoSocial = Convert.ToString(dataRow["nome_razaosocial"]);
                if (!(dataRow["apelido_nomefantasia"] is DBNull))
                    cliente.ApelidoNomeFantasia = Convert.ToString(dataRow["apelido_nomefantasia"]);
                if (!(dataRow["cpf_cnpj"] is DBNull))
                    cliente.CpfCnpj = Convert.ToString(dataRow["cpf_cnpj"]);
                if (!(dataRow["rg_ie"] is DBNull))
                    cliente.RgIe = Convert.ToString(dataRow["rg_ie"]);
                if (!(dataRow["dnasc_dreg"] is DBNull))
                    cliente.DataNascimentoRegistro = Convert.ToDateTime(dataRow["dnasc_dreg"]);
                if (!(dataRow["observacao"] is DBNull))
                    cliente.Observacao = Convert.ToString(dataRow["observacao"]);
                cliente.UsuarioCadastro = usuarioNegocios.ConsultarPorId(Convert.ToInt32(
                    dataRow["id_usuario_cadastro"]));
                cliente.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(
                    dataRow["id_usuario_alteracao"]));
                if (!(dataRow["apagado"] is DBNull))
                    cliente.Apagado = Convert.ToString(dataRow["apagado"]);
                if (!(dataRow["ativo"] is DBNull))
                    cliente.Ativo = Convert.ToString(dataRow["ativo"]);
                if (!(dataRow["data_cadastro"] is DBNull))
                    cliente.DataCadastro = Convert.ToDateTime(dataRow["data_cadastro"]);
                if (!(dataRow["data_alteracao"] is DBNull))
                    cliente.DataAlteracao = Convert.ToDateTime(dataRow["data_alteracao"]);

                clienteColecao.Add(cliente);
            }
            return clienteColecao;
        }

        public Cliente ConsultarPorId(int IdCliente)
        {
            string queryConsulta = "SELECT * FROM cliente WHERE id_cliente = @IdCliente  AND apagado <>'S'";
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdCliente", IdCliente);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            if (dataTable.Rows.Count > 0)
            {
                Cliente cliente = new Cliente();
                cliente.IdCliente = Convert.ToInt32(dataTable.Rows[0]["id_cliente"]);

                cliente.IdCliente = Convert.ToInt32(dataTable.Rows[0]["id_cliente"]);
                cliente.TipoPessoa = Convert.ToString(dataTable.Rows[0]["tipo_pessoa"]);
                cliente.NomeRazaoSocial = Convert.ToString(dataTable.Rows[0]["nome_razaosocial"]);
                cliente.ApelidoNomeFantasia = Convert.ToString(dataTable.Rows[0]["apelido_nomefantasia"]);
                cliente.CpfCnpj = Convert.ToString(dataTable.Rows[0]["cpf_cnpj"]);
                cliente.RgIe = Convert.ToString(dataTable.Rows[0]["rg_ie"]);
                cliente.DataNascimentoRegistro = Convert.ToDateTime(dataTable.Rows[0]["dnasc_dreg"]);
                cliente.Observacao = Convert.ToString(dataTable.Rows[0]["observacao"]);

               cliente.UsuarioCadastro = usuarioNegocios.ConsultarPorId(Convert.ToInt32(
                    dataTable.Rows[0]["id_usuario_cadastro"]));

                cliente.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(
                    dataTable.Rows[0]["id_usuario_alteracao"]));

                cliente.Apagado = Convert.ToString(dataTable.Rows[0]["apagado"]);
                cliente.Ativo = Convert.ToString(dataTable.Rows[0]["ativo"]);
                cliente.DataCadastro = Convert.ToDateTime(dataTable.Rows[0]["data_cadastro"]);
                cliente.DataAlteracao = Convert.ToDateTime(dataTable.Rows[0]["data_alteracao"]);

                return cliente;
            }
            else
            {
                return null;
            }
        }
    }
}
