using ObjetoTransferencia;
using System;
using System.Data;
using System.Data.SqlClient;


namespace AcessoBancoDados
{
    public class AcessoDadosSqlServer
    {

        //Método privado que cria e retorna uma nova conexão com o banco de dados
        private SqlConnection CriarConexao()
        {
            var bancoDados = BancoDados.Instancia;
            string servidor = bancoDados.Servidor;
            string banco = bancoDados.Banco;
            string usuario = bancoDados.Usuario;
            string senha = bancoDados.Senha;

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString =
                //"Server=tcp:estagio.database.windows.net,1433;"+
               "Server=" + servidor + ";" +
               "Initial Catalog=" + banco + ";" +
               "Persist Security Info=False;" +
               "User ID=" + usuario + ";" +
               "Password=" + senha + ";";
               /*"MultipleActiveResultSets=False;"+
               "Encrypt=True;"+
               "TrustServerCertificate=False;"+
               "Connection Timeout=30;";
               */

            /*"Data Source=127.0.0.1;" +
                "Initial Catalog=sys;" +
                "Integrated Security=SSPI;";*/

         //Server=tcp:estagio.database.windows.net,1433;Initial Catalog=syscomercio;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

            //Linx - BBDDSKFS015827
            //conn.ConnectionString = "Data Source=LUCAS;Initial Catalog=SYSCOMERCIO;User ID=root;Password=*2245654";

           /* conn.ConnectionString =
                "Data Source=BBDDSKFS015827;" +
                "Initial Catalog=SYSCOMERCIO;" +
                "User = root;" +
                "Password=123456big"; 

            conn.ConnectionString = 
                @"Server=localhost;"+
                "Database=syscomercio;"+
                "Uid=root;Pwd='123456big';"+
                "Connect Timeout=30;";*/

            //O comando Open() é responsável por abrir a conexão.
            //Se ele não for executado, um erro será lançado na
            //primeira vez em que a conexão for utilizada.
            conn.Open();
            return conn;
        }

        //Variável privada que armazena os parâmetros que serão
        //utilizados dentro dos comandos SQL.
        private SqlParameterCollection sqlParameterCollection =
            new SqlCommand().Parameters;

        //Método público que limpa todos os parâmetros da coleção.
        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        //Método público que adiciona novos parâmetros à coleção.
        public void AdicionarParametros(string nomeParametro,
            object valorParametro)
        {
            sqlParameterCollection.Add(
                new SqlParameter(nomeParametro, valorParametro));
        }

        //Método publico que executa comandos INSERT, UPDATE e DELETE
        //no banco de dados.
        //Retorna a quantidade de linhas afetadas.
        public int ExecutarManipulacao(CommandType commandType,
            string nomeStoredProcedureOuTextoSql)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextoSql;

                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new
                        SqlParameter(sqlParameter.ParameterName,
                                     sqlParameter.Value));
                }

                //Executa o comando SQL e retorna quantas linhas foram afetadas
                return sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Houve uma falha ao executar o " +
                    "comando no banco de dados.\r\n" +
                    "Mensagem original: " + ex.Message);
            }
        }

        //Método público que executa comandos SELECT no banco de dados.
        //Retorna apenas a primeira coluna da primeira linha do retorno
        //obtido do banco de dados.
        public object ExecutarConsultaScalar(CommandType commandType,
            string nomeStoredProcedureOuTextoSql)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextoSql;

                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new
                        SqlParameter(sqlParameter.ParameterName,
                                     sqlParameter.Value));
                }

                //Executa o comando SQL e retorna apenas a primeira coluna da primeira linha
                return sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Houve uma falha ao executar o " +
                    "comando no banco de dados.\r\n" +
                    "Mensagem original: " + ex.Message);
            }
        }

        //Método público que executa comandos SELECT no banco de dados.
        //Retorna todas as linhas e colunas obtidas do banco de dados.
        public DataTable ExecutarConsulta(CommandType commandType,
            string nomeStoredProcedureOuTextoSql)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextoSql;

                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new
                        SqlParameter(sqlParameter.ParameterName,
                        sqlParameter.Value));
                }

                //O C# precisa que o retorno do banco de dados seja convertido
                //para um objeto. Para isto, ele utiliza o SqlDataAdapter,
                //que irá "adaptar" o retorno da consulta para um objeto do
                //tipo DataTable. É o DataTable que será utilizado dentro do
                //código C#
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();

                //Nesse ponto o comando SQL é executado, o resultado é
                //"adaptado" (convertido) e o objeto "dataTable" é preenchido
                sqlDataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve uma falha a o recuperar os " +
                    "dados do banco de dados.\r\n" +
                    "Mensagem original: " + ex.Message);
            }
        }
    }
}
