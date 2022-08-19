using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class LojaNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public int AtualizarAlteracao()
        {
            string queryAlterar = "UPDATE loja SET " +
                "id_usuario_alteracao=@UsuarioAlteracao," +
                "data_alteracao=@DataAlteracao " +
                "WHERE id_loja = 1";

            var usuarioLogado = UsuarioLogado.Instancia;

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@DataAlteracao", DateTime.Now);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }
        public int Alterar(Loja loja)
        {
            string queryAlterar = "UPDATE loja SET " +
                "razao_social			=@RazaoSocial        ," +
                "nome_fantasia			=@NomeFantatasia     ," +
                "cnpj			=@CNPJ               ," +
                "inscr_estadual			=@InscricaoEstadual  ," +
                "data_registro			=@DataRegistro       ," +
                "id_usuario_alteracao	=@UsuarioAlteracao   ," +
                "data_alteracao			=@DataAlteracao       " +
                "WHERE id_loja = 1";

            var usuarioLogado = UsuarioLogado.Instancia;

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@RazaoSocial        ", loja.RazaoSocial );
            acessoDados.AdicionarParametros("@NomeFantatasia     ", loja.NomeFantatasia );
            acessoDados.AdicionarParametros("@CNPJ               ", loja.CNPJ );
            acessoDados.AdicionarParametros("@InscricaoEstadual  ", loja.InscricaoEstadual );
            acessoDados.AdicionarParametros("@DataRegistro       ", loja.DataRegistro );  
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@DataAlteracao", DateTime.Now);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }

        public Loja ConsultarPorId(int IdLoja)
        {
            string queryConsulta = "SELECT * FROM loja WHERE id_loja = @IdLoja";
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdLoja", IdLoja);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            if (dataTable.Rows.Count > 0)
            {
                Loja loja = new Loja();

                loja.IdLoja = Convert.ToInt32(dataTable.Rows[0]["id_loja"]);
                loja.RazaoSocial = Convert.ToString(dataTable.Rows[0]["razao_social"]);
                loja.NomeFantatasia = Convert.ToString(dataTable.Rows[0]["nome_fantasia"]);
                loja.CNPJ = Convert.ToString(dataTable.Rows[0]["cnpj"]);
                loja.InscricaoEstadual = Convert.ToString(dataTable.Rows[0]["inscr_estadual"]);
                loja.DataRegistro = Convert.ToDateTime(dataTable.Rows[0]["data_registro"]);
                loja.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataTable.Rows[0]["id_usuario_alteracao"]));
                loja.DataCadastro = Convert.ToDateTime(dataTable.Rows[0]["data_cadastro"]);
                loja.DataAlteracao = Convert.ToDateTime(dataTable.Rows[0]["data_alteracao"]);

                return loja;
            }
            else
            {
                return null;
            }
        }
    }
}
