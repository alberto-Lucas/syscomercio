using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class ContatoNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public int Inserir(Contato contato)
        {
            string queryInserir = "INSERT INTO contato " +
                "(" +
                "responsavel," +
                "contato," +
                "tipo_contato" +
                ") values " +
                "(" +
                "@Responsavel," +
                "@Contatos," +
                "@TipoContato" +
                ")";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@Responsavel", contato.Responsavel );
            acessoDados.AdicionarParametros("@Contatos", contato.Contatos );
            acessoDados.AdicionarParametros("@TipoContato", contato.TipoContato );

            acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);

            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT MAX(id_contato) FROM contato"));
        }

        public int Alterar(Contato contato)
        {
            string queryAlterar = "UPDATE contato SET " +
                "responsavel=@Responsavel," +
                "contato=@Contatos," +
                "tipo_contato=@TipoContato " +
                "WHERE id_contato = @IdContato";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdContato", contato.IdContato );
            acessoDados.AdicionarParametros("@Responsavel", contato.Responsavel);
            acessoDados.AdicionarParametros("@Contatos", contato.Contatos);
            acessoDados.AdicionarParametros("@TipoContato", contato.TipoContato);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }

        public int Apagar(int IdContato)
        {
            string queryApagar = "delete from contato " +
                "WHERE id_contato = @IdContato";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdCliente", IdContato);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }

        public Contato ConsultarPorId(int IdContato)
        {
            string queryConsulta = "SELECT * FROM contato WHERE id_contato = @IdContato";
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdContato", IdContato);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            if (dataTable.Rows.Count > 0)
            {
                Contato contato = new Contato();
                contato.IdContato = Convert.ToInt32(dataTable.Rows[0]["id_contato"]);
                contato.Responsavel = Convert.ToString(dataTable.Rows[0]["responsavel"]);
                contato.Contatos = Convert.ToString(dataTable.Rows[0]["contato"]);
                contato.TipoContato = Convert.ToString(dataTable.Rows[0]["tipo_contato"]);

                return contato;
            }
            else
            {
                return null;
            }
        }
    }
}
