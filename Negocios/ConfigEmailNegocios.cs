using AcessoBancoDados;
using System;
using System.Data;
using ObjetoTransferencia;

namespace Negocios
{
    public class ConfigEmailNegocios
    {
        //Variável local e privada que faz o acesso ao banco de dados
        //e executa os comandos de manipulação e consulta.
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        //Método público que insere na tabela de clientes um novo registro.
        //Os dados que serão inseridos são passados no parâmetro através
        //de um objeto do tipo Cliente. Os dados foram preenchidos pelo
        //usuário na tela de cadastro de clientes.
        public int Inserir(ConfigEmail configEmail)
        {
            //Variável local que armazena o comando que será executado
            //no banco de dados.
            // O "@" indica para o SQL Server a utilização de um parâmetro.
            string queryInserir = "INSERT INTO config_email(" +
            "nome, senha, host, porta, ssl_email, assinatura" +
            ") VALUES (" +
            "@nome, @senha, @host, @porta, @ssl_email, @assinatura)";

            //Limpa qualquer sujeira do objeto que armazena as variáveis.
            acessoDados.LimparParametros();

            //Adiciona o valore de cada parâmetro que está sendo utilizado
            //no comando que será executado no banco de dados.
            acessoDados.AdicionarParametros("@email", configEmail.Email);
            acessoDados.AdicionarParametros("@senha", configEmail.Senha);
            acessoDados.AdicionarParametros("@host", configEmail.Host);
            acessoDados.AdicionarParametros("@porta", configEmail.Porta);
            acessoDados.AdicionarParametros("@ssl_email", configEmail.SslEmail);
            acessoDados.AdicionarParametros("@assinatura", configEmail.Assinatura);



            //Solicita à camada de "Acesso A Dados" a execução
            //do comando SQL que está na variável "queryInserir".
            acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);

            //Consulta qual é o valor da última chave primária gerada
            //automaticamente no banco de dados.
            //É necessário para que o código do cliente que acabou de
            //ser inserido seja exibido na tela para o usuário.
            //O comando "ExecutarConsultaScalar" retorna apenas a primeira
            //coluna da primeira linha da consulta que foi executada. Como
            //o resultado da consulta "SELECT @@IDENTITY" retorna apenas
            //uma coluna e uma linha, a utilização do comando "ExecutarConsultaScalar"
            //faz todo o sentido.
            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT @@IDENTITY"));
        }

        public int Alterar(ConfigEmail configEmail)
        {
            string queryAlterar = "UPDATE config_email SET " +
                "email  =@email," +
                "senha = @senha," +
                "host = @host," +
                "porta = @porta," +
                "ssl_email = @ssl_email," +
                "assinatura = @assinatura";



            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@email", configEmail.Email);
            acessoDados.AdicionarParametros("@senha", configEmail.Senha);
            acessoDados.AdicionarParametros("@host", configEmail.Host);
            acessoDados.AdicionarParametros("@porta", configEmail.Porta);
            acessoDados.AdicionarParametros("@ssl_email", configEmail.SslEmail);
            acessoDados.AdicionarParametros("@assinatura", configEmail.Assinatura);


            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }

        public ConfigEmail ConsultarPorId(int id_email)
        {
            string queryConsulta = "SELECT * FROM configEmail WHERE id_email = @id_email";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@id_email", id_email);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            if (dataTable.Rows.Count > 0)
            {
                ConfigEmail configEmail = new ConfigEmail();

                if (!(dataTable.Rows[0]["email"] is DBNull))
                    configEmail.Email = Convert.ToString(dataTable.Rows[0]["email"]);

                if (!(dataTable.Rows[0]["senha"] is DBNull))
                    configEmail.Senha = Convert.ToString(dataTable.Rows[0]["senha"]);
                if (!(dataTable.Rows[0]["host"] is DBNull))

                    configEmail.Host = Convert.ToString(dataTable.Rows[0]["host"]);

                if (!(dataTable.Rows[0]["porta"] is DBNull))
                    configEmail.Porta = Convert.ToInt32(dataTable.Rows[0]["porta"]);

                if (!(dataTable.Rows[0]["ssl_email"] is DBNull))
                    configEmail.SslEmail = Convert.ToString(dataTable.Rows[0]["ssl_email"]);

                if (!(dataTable.Rows[0]["assinatura"] is DBNull))
                    configEmail.Assinatura = Convert.ToString(dataTable.Rows[0]["assinatura"]);

                return configEmail;
            }
            else
            {
                return null;
            }
        }

    }
}
