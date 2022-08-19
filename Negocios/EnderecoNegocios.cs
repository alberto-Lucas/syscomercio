using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class EnderecoNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public int Inserir(Endereco endereco)
        {
            string queryInserir = "INSERT INTO endereco " +
                "(" +
                "logradouro," +
                "endereco," +
                "numero," +
                "coplemento," +
                "bairro," +
                "cep," +
                "cidade," +
                "uf" +
                ") values " +
                "(" +
                "@Logradouro," +
                "@Enderecos," +
                "@Numero," +
                "@Complemento," +
                "@Bairro," +
                "@Cep," +
                "@Cidade," +
                "@Uf" +
                ")";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@Logradouro", endereco.Logradouro );
            acessoDados.AdicionarParametros("@Enderecos", endereco.Enderecos );
            acessoDados.AdicionarParametros("@Numero", endereco.Numero );
            acessoDados.AdicionarParametros("@Complemento", endereco.Complemento );
            acessoDados.AdicionarParametros("@Bairro", endereco.Bairro );
            acessoDados.AdicionarParametros("@Cep", endereco.Cep );
            acessoDados.AdicionarParametros("@Cidade", endereco.Cidade );
            acessoDados.AdicionarParametros("@Uf", endereco.Uf);

            acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);

            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT MAX(id_endereco) FROM endereco"));
        }

        public int Alterar(Endereco endereco)
        {
            string queryAlterar = "UPDATE endereco SET " +
                "logradouro=@Logradouro," +
                "endereco=@Enderecos," +
                "numero=@Numero," +
                "coplemento=@Complemento," +
                "bairro=@Bairro," +
                "cep=@Cep," +
                "cidade=@Cidade," +
                "uf=@Uf " +
                "WHERE id_endereco = @IdEndereco";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdEndereco", endereco.IdEndereco);
            acessoDados.AdicionarParametros("@Logradouro", endereco.Logradouro);
            acessoDados.AdicionarParametros("@Enderecos", endereco.Enderecos);
            acessoDados.AdicionarParametros("@Numero", endereco.Numero);
            acessoDados.AdicionarParametros("@Complemento", endereco.Complemento);
            acessoDados.AdicionarParametros("@Bairro", endereco.Bairro);
            acessoDados.AdicionarParametros("@Cep", endereco.Cep);
            acessoDados.AdicionarParametros("@Cidade", endereco.Cidade);
            acessoDados.AdicionarParametros("@Uf", endereco.Uf);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }

        public int Apagar(int IdEndereco)
        {
            string queryApagar = "delete from endereco " +
                "WHERE id_endereco = @IdEndereco";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdEndereco", IdEndereco);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }

        public Endereco ConsultarPorId(int IdEndereco)
        {
            string queryConsulta = "SELECT * FROM endereco WHERE id_endereco = @IdEndereco";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdEndereco", IdEndereco);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            if (dataTable.Rows.Count > 0)
            {
                Endereco endereco = new Endereco();
                endereco.IdEndereco = Convert.ToInt32(dataTable.Rows[0]["id_endereco"]);
                endereco.Logradouro = Convert.ToString(dataTable.Rows[0]["logradouro"]);
                endereco.Enderecos = Convert.ToString(dataTable.Rows[0]["endereco"]);
                endereco.Numero = Convert.ToString(dataTable.Rows[0]["numero"]);
                endereco.Complemento = Convert.ToString(dataTable.Rows[0]["coplemento"]);
                endereco.Bairro = Convert.ToString(dataTable.Rows[0]["bairro"]);
                endereco.Cep = Convert.ToString(dataTable.Rows[0]["cep"]);
                endereco.Cidade = Convert.ToString(dataTable.Rows[0]["cidade"]);
                endereco.Uf = Convert.ToString(dataTable.Rows[0]["uf"]);

                return endereco;
            }
            else
            {
                return null;
            }
        }
    }
}
