using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace AcessoBancoDados
{
    public class AcessoDadosMysql
    {
        //Método privado que cria e retorna uma nova conexão com o banco de dados
        private MySqlConnection CriarConexao()
        {
            MySqlConnection conn = new MySqlConnection();

            //"Data Source=LUCAS-PC;Initial Catalog=TESTE;User=VOUCHER2;Password=*2245654"

            /*conn.ConnectionString =
                "Data Source=LUCAS-PC;" +
                "Initial Catalog=AUTOSOFTWARE;" +
                "User = VOUCHER2;"+
                "Password=*2245654";*/

            //conn.ConnectionString = "Data Source=LUCAS-PC;Initial Catalog=AUTOSOFTWARE;User=VOUCHER2;Password=*2245654";

            conn.ConnectionString = @"Server=lucas;Database=syscomercio;Uid=root;Pwd='123456big';Connect Timeout=30;";

            //O comando Open() é responsável por abrir a conexão.
            //Se ele não for executado, um erro será lançado na
            //primeira vez em que a conexão for utilizada.




            conn.Open();
            return conn;
        }

        //Variável privada que armazena os parâmetros que serão
        //utilizados dentro dos comandos SQL.
        private MySqlParameterCollection sqlParameterCollection =
            new MySqlCommand().Parameters;

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
                new MySqlParameter(nomeParametro, valorParametro));
        }

        //Método publico que executa comandos INSERT, UPDATE e DELETE
        //no banco de dados.
        //Retorna a quantidade de linhas afetadas.
        public int ExecutarManipulacao(CommandType commandType,
            string nomeStoredProcedureOuTextoSql)
        {
            try
            {
                MySqlConnection sqlConnection = CriarConexao();
                MySqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextoSql;

                foreach (MySqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new
                        MySqlParameter(sqlParameter.ParameterName,
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
                MySqlConnection sqlConnection = CriarConexao();
                MySqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextoSql;

                foreach (MySqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new
                        MySqlParameter(sqlParameter.ParameterName,
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
                MySqlConnection sqlConnection = CriarConexao();
                MySqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextoSql;

                foreach (MySqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new
                        MySqlParameter(sqlParameter.ParameterName,
                        sqlParameter.Value));
                }

                //O C# precisa que o retorno do banco de dados seja convertido
                //para um objeto. Para isto, ele utiliza o SqlDataAdapter,
                //que irá "adaptar" o retorno da consulta para um objeto do
                //tipo DataTable. É o DataTable que será utilizado dentro do
                //código C#
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
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
