using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class EnderecoExternoNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();
        #region Clientes
        public int InserirEnderecoCliente(int IdCliente, int IdEndereco)
        {
            string queryInserir = "INSERT INTO endereco_cliente " +
                "(" +
                "id_endereco," +
                "id_cliente" +
                ") values " +
                "(" +
                "@IdEndereco," +
                "@IdCliente" +
                ")";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdEndereco", IdEndereco);
            acessoDados.AdicionarParametros("@IdCliente", IdCliente);
            acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);

            return 1;
        }
        public int ApagarEnderecoCliente(int IdEndereco, int IdCliente)
        {
            string queryApagar = "delete from endereco_cliente WHERE id_endereco = @IdEndereco AND id_cliente = @IdCliente";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdEndereco", IdEndereco);
            acessoDados.AdicionarParametros("@IdCliente", IdCliente);
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }

        public EnderecoClienteColecao ConsultarPorCliente(int IdCliente)
        {
            string queryConsulta = "SELECT * FROM endereco_cliente WHERE id_cliente = @IdCliente";
            ClienteNegocios clienteNegocios = new ClienteNegocios();
            EnderecoNegocios enderecoNegocios = new EnderecoNegocios();
            EnderecoClienteColecao enderecoClienteColecao = new EnderecoClienteColecao();
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdCliente", IdCliente);
            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {

                EnderecoCliente enderecoCliente = new EnderecoCliente();
                enderecoCliente.Endereco = enderecoNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_endereco"]));
                enderecoCliente.Cliente = clienteNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_cliente"]));
                enderecoClienteColecao.Add(enderecoCliente);
            }
            return enderecoClienteColecao;
        }
        #endregion

        #region Usuario
        public int InserirEnderecoUsuario(int IdUsuario, int IdEndereco)
        {
            string queryInserir = "INSERT INTO endereco_usuario " +
                "(" +
                "id_endereco," +
                "id_usuario" +
                ") values " +
                "(" +
                "@IdEndereco," +
                "@IdUsuario" +
                ")";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdEndereco", IdEndereco);
            acessoDados.AdicionarParametros("@IdUsuario", IdUsuario);
            acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);
            return 1;
        }
        public int ApagarEnderecoUsuario(int IdEndereco, int IdUsuario)
        {
            string queryApagar = "delete from endereco_usuario WHERE id_enedereco = @IdEndereco AND id_usuario = @IdUsuario";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdEndereco", IdEndereco);
            acessoDados.AdicionarParametros("@IdUsuario", IdUsuario);
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }
        public EnderecoUsuarioColecao ConsultarPorUsuario(int IdUsuario)
        {
            string queryConsulta = "SELECT * FROM endereco_usuario WHERE id_usuario = @IdUsuario";
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            EnderecoNegocios enderecoNegocios = new EnderecoNegocios();
            EnderecoUsuarioColecao enderecoUsuarioColecao = new EnderecoUsuarioColecao();
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdUsuario", IdUsuario);
            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {

                EnderecoUsuario enderecoUsuario = new EnderecoUsuario();
                enderecoUsuario.Endereco = enderecoNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_endereco"]));
                enderecoUsuario.Usuario = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario"]));
                enderecoUsuarioColecao.Add(enderecoUsuario);
            }
            return enderecoUsuarioColecao;
        }
        #endregion

        #region Loja
        public int InserirEnderecoLoja(int IdLoja, int IdEndereco)
        {
            string queryInserir = "INSERT INTO endereco_loja " +
                "(" +
                "id_endereco," +
                "id_loja" +
                ") values " +
                "(" +
                "@IdContato," +
                "@IdEndereco" +
                ")";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdEndereco", IdEndereco);
            acessoDados.AdicionarParametros("@IdLoja", IdLoja);
            acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);
            return 1;
        }
        public int ApagarEnderecoLoja(int IdEndereco, int IdLoja)
        {
            string queryApagar = "delete from endereco_loja WHERE id_endereco = @IdEndereco AND id_loja = @IdLoja";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdEndereco", IdEndereco);
            acessoDados.AdicionarParametros("@IdLoja", IdLoja);
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }
        public EnderecoLojaColecao ConsultarPorLoja(int IdLoja)
        {
            string queryConsulta = "SELECT * FROM endreco_loja WHERE id_loja = @IdLoja";
            LojaNegocios lojaNegocios = new LojaNegocios();
            EnderecoNegocios enderecoNegocios = new EnderecoNegocios();
            EnderecoLojaColecao enderecoLojaColecao = new EnderecoLojaColecao();
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdLoja", IdLoja);
            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);
            foreach (DataRow dataRow in dataTable.Rows)
            {

                EnderecoLoja enderecoLoja = new EnderecoLoja();
                enderecoLoja.Endereco = enderecoNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_endereco"]));
                enderecoLoja.Loja = lojaNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_loja"]));
                enderecoLojaColecao.Add(enderecoLoja);
            }
            return enderecoLojaColecao;
        }
        #endregion

        #region Fornecedor

        public int InserirEnderecoFornecedor(int IdFornecedor, int IdEndereco)
        {
            string queryInserir = "INSERT INTO endereco_fornecedor " +
                "(" +
                "id_endereco," +
                "id_fornecedor" +
                ") values " +
                "(" +
                "@IdEndereco," +
                "@IdFornecedor" +
                ")";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdEndereco", IdEndereco);
            acessoDados.AdicionarParametros("@IdFornecedor", IdFornecedor);
            acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);
            return 1;
        }

        public int ApagarEnderecoFornecedor(int IdEndereco, int IdFornecedor)
        {
            string queryApagar = "delete from endereco_fornecedor WHERE id_endereco = @IdEndereco AND id_fornecedor = @IdFornecedor";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdEndereco", IdEndereco);
            acessoDados.AdicionarParametros("@IdFornecedor", IdFornecedor);
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }

        public EnderecoFornecedorColecao ConsultarPorFornecedor(int IdFornecedor)
        {
            string queryConsulta = "SELECT * FROM endereco_fornecedor WHERE id_fornecedor = @IdFornecedor";
            FornecedorNegocios usuarioNegocios = new FornecedorNegocios();
            EnderecoNegocios enderecoNegocios = new EnderecoNegocios();
            EnderecoFornecedorColecao enderecoFornecedorColecao = new EnderecoFornecedorColecao();
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdUsuario", IdFornecedor);
            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {

                EnderecoFornecedor enderecoFornecedor = new EnderecoFornecedor();
                enderecoFornecedor.Endereco = enderecoNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_endereco"]));
                enderecoFornecedor.Fornecedor = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_fornecedor"]));
                enderecoFornecedorColecao.Add(enderecoFornecedor);
            }
            return enderecoFornecedorColecao;
        }
        #endregion
    }
}

