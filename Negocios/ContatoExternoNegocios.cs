using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class ContatoExternoNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();
        #region Inserir

        public int InserirContatoUsuario(int IdUsuario, int IdContato)
        {
            string queryInserir = "INSERT INTO contato_usuario " +
                "(" +
                "id_contato," +
                "id_usuario" +
                ") values " +
                "(" +
                "@IdContato," +
                "@IdUsuario" +
                ")";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdContato", IdContato);
            acessoDados.AdicionarParametros("@IdUsuario    ", IdUsuario);
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);
        }
        public int InserirContatoLoja(int IdLoja, int IdContato)
        {
            string queryInserir = "INSERT INTO contato_loja " +
                "(" +
                "id_contato," +
                "id_loja" +
                ") values " +
                "(" +
                "@IdContato," +
                "@IdLoja" +
                ")";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdContato", IdContato);
            acessoDados.AdicionarParametros("@IdLoja", IdLoja);
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);
        }
        public int InserirContatoFornecedor(int IdFornecedor, int IdContato)
        {
            string queryInserir = "INSERT INTO contato_fornecedor " +
                "(" +
                "id_contato," +
                "id_fornecedor" +
                ") values " +
                "(" +
                "@IdContato," +
                "@IdFornecedor" +
                ")";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdContato", IdContato);
            acessoDados.AdicionarParametros("@IdFornecedor", IdFornecedor);
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);
        }

        public int InserirContatoCliente(int IdCliente, int IdContato)
        {
            string queryInserir = "INSERT INTO contato_cliente " +
                "(" +
                "id_contato," +
                "id_cliente" +
                ") values " +
                "(" +
                "@IdContato," +
                "@IdCliente" +
                ")";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdContato", IdContato);
            acessoDados.AdicionarParametros("@IdCliente", IdCliente);
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);
        }
        #endregion

        #region Apagar
        public int ApagarContatoUsuario(int IdContato, int IdUsuario)
        {
            string queryApagar = "delete from contato_usuario WHERE id_contato = @IdContato AND id_usuario = @IdUsuario";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdContato", IdContato);
            acessoDados.AdicionarParametros("@IdUsuario", IdUsuario);
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }
        public int ApagarContatoLoja(int IdContato, int IdLoja)
        {
            string queryApagar = "delete from contato_loja WHERE id_contato = @IdContato AND id_loja = @IdLoja";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdContato", IdContato);
            acessoDados.AdicionarParametros("@IdLoja", IdLoja);
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }
        public int ApagarContatoFornecedor(int IdContato, int IdFornecedor)
        {
            string queryApagar = "delete from contato_fornecedor WHERE id_contato = @IdContato AND id_fornecedor = @IdFornecedor";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdContato", IdContato);
            acessoDados.AdicionarParametros("@IdFornecedor", IdFornecedor);
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }
        public int ApagarContatoCliente(int IdContato, int IdCliente)
        {
            string queryApagar = "delete from contato_cliente WHERE id_contato = @IdContato AND id_cliente = @IdCliente";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdContato", IdContato);
            acessoDados.AdicionarParametros("@IdCliente", IdCliente);
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }
#endregion

        #region Consultar
        public ContatoLojaColecao ConsultarPorLoja(int IdLoja)
        {
            string queryConsulta = "SELECT * FROM contato_loja WHERE id_loja = @IdLoja";
            LojaNegocios lojaNegocios = new LojaNegocios();
            ContatoNegocios contatoNegocios = new ContatoNegocios();
            ContatoLojaColecao contatoLojaColecao = new ContatoLojaColecao();
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdLoja", IdLoja);
            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                ContatoLoja contatoLoja = new ContatoLoja();
                contatoLoja.Contato = contatoNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_contato"]));
                contatoLoja.Loja = lojaNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_loja"]));
                contatoLojaColecao.Add(contatoLoja);
            }
            return contatoLojaColecao;
        }
        public ContatoUsuarioColecao ConsultarPorUsuario(int IdUsuario)
        {
            string queryConsulta = "SELECT * FROM contato_usuario WHERE id_usuario = @IdUsuario";
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            ContatoNegocios contatoNegocios = new ContatoNegocios();
            ContatoUsuarioColecao contatoUsuarioColecao = new ContatoUsuarioColecao();
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdUsuario", IdUsuario);
            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                ContatoUsuario contatoUsuario = new ContatoUsuario();
                contatoUsuario.Contato = contatoNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_contato"]));
                contatoUsuario.Usuario = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario"]));
                contatoUsuarioColecao.Add(contatoUsuario);
            }
            return contatoUsuarioColecao;
        }
        public ContatoFornecedorColecao ConsultarPorFornecedor(int IdFornecedor)
        {
            string queryConsulta = "SELECT * FROM contato_fornecedor WHERE id_fornecedor = @IdFornecedor";
            FornecedorNegocios usuarioNegocios = new FornecedorNegocios();
            ContatoNegocios contatoNegocios = new ContatoNegocios();
            ContatoFornecedorColecao contatoFornecedorColecao = new ContatoFornecedorColecao();
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdFornecedor", IdFornecedor);
            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                ContatoFornecedor contatoFornecedor = new ContatoFornecedor();
                contatoFornecedor.Contato = contatoNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_contato"]));
                contatoFornecedor.Fornecedor = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_fornecedor"]));
                contatoFornecedorColecao.Add(contatoFornecedor);
            }
            return contatoFornecedorColecao;
        }
        public ContatoClienteColecao ConsultarPorCliente(int IdCliente)
        {
            string queryConsulta = "SELECT * FROM contato_cliente WHERE id_cliente = @IdCliente";
            ClienteNegocios clienteNegocios = new ClienteNegocios();
            ContatoNegocios contatoNegocios = new ContatoNegocios();
            ContatoClienteColecao contatoClienteColecao = new ContatoClienteColecao();
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdCliente", IdCliente);
            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {

                ContatoCliente contatoCliente = new ContatoCliente();
                contatoCliente.Contato = contatoNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_contato"]));
                contatoCliente.Cliente = clienteNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_cliente"]));
                contatoClienteColecao.Add(contatoCliente);
            }
            return contatoClienteColecao;
        }
        #endregion
    }
}
