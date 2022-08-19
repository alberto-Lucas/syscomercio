using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Data;

namespace Negocios
{
    public class UsuarioNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();
        
        public int TotalUsuarios()
        {
            acessoDados.LimparParametros();
            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT count(id_usuario) FROM usuario"));
        }

        public int Inserir(Usuario usuario, int IdGrupoUsuario)
        {

            string queryInserir = "INSERT INTO usuario (" +
                "nome                ," +
                "cpf                 ," +
                "rg                  ," +
                "data_nascimento     ," +
                "senha               ," +
                "id_grupo            ," +
                "id_usuario_cadastro ," +
                "id_usuario_alteracao," +
                "apagado             ," +
                "ativo               ," +
                "data_cadastro       ," +
                "data_alteracao       " +
                ") VALUES "+
                "("+
                "@Nome              ," +
                "@Cpf               ," +
                "@Rg                ," +
                "@DataNascimento    ," +
                "@Senha             ," +
                "@GrupoUsuario      ," +
                "@UsuarioCadastro   ," +
                "@UsuarioAlteracao  ," +
                "@Apagado           ," +
                "@Ativo             ," +
                "@DataCadastro      ," +
                "@DataAlteracao      " +
                ")";

            acessoDados.LimparParametros();
            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.AdicionarParametros("@Nome              ", usuario.Nome);
            acessoDados.AdicionarParametros("@Cpf               ", usuario.Cpf);
            acessoDados.AdicionarParametros("@Rg                ", usuario.Rg);
            acessoDados.AdicionarParametros("@DataNascimento    ", usuario.DataNascimento);
            acessoDados.AdicionarParametros("@Senha             ", usuario.Senha);
            acessoDados.AdicionarParametros("@GrupoUsuario      ", IdGrupoUsuario);
            acessoDados.AdicionarParametros("@UsuarioCadastro   ", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@UsuarioAlteracao  ", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@Apagado           ", "N");
            acessoDados.AdicionarParametros("@Ativo             ", usuario.Ativo);
            acessoDados.AdicionarParametros("@DataCadastro      ", DateTime.Now);
            acessoDados.AdicionarParametros("@DataAlteracao     ", DateTime.Now);

            acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);

            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT MAX(id_usuario) FROM usuario"));
        }

        public int Alterar(Usuario usuario, int IdGrupoUsuario)
        {
            string queryAlterar = "UPDATE usuario SET " +
                "nome=@Nome," +
                "cpf=@Cpf," +
                "rg=@Rg," +
                "data_nascimento=@DataNascimento," +
                "id_grupo = @GrupoUsuario," +
                "senha=@Senha," +
                "id_usuario_alteracao=@UsuarioAlteracao," +
                "ativo=@Ativo," +
                "data_alteracao=@DataAlteracao" +
                " WHERE id_usuario = @IdUsuario";

            acessoDados.LimparParametros();
            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.AdicionarParametros("@IdUsuario         ", usuario.IdUsuario);
            acessoDados.AdicionarParametros("@nOME               ", usuario.Nome);
            acessoDados.AdicionarParametros("@Cpf               ", usuario.Cpf);
            acessoDados.AdicionarParametros("@Rg                ", usuario.Rg);
            acessoDados.AdicionarParametros("@DataNascimento    ", usuario.DataNascimento);
            acessoDados.AdicionarParametros("@Senha             ", usuario.Senha);
            acessoDados.AdicionarParametros("@GrupoUsuario      ", IdGrupoUsuario);
            acessoDados.AdicionarParametros("@UsuarioAlteracao  ", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@Ativo             ", usuario.Ativo);
            acessoDados.AdicionarParametros("@DataAlteracao     ", DateTime.Now);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }

        public int AtualizarAlteracao(int idUsuario)
        {
            string queryAlterar = "UPDATE usuario SET " +
                "id_usuario_alteracao=@UsuarioAlteracao," +
                "data_alteracao=@DataAlteracao " +
                "WHERE id_usuario = @IdUsuario";

            acessoDados.LimparParametros();
            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.AdicionarParametros("@IdUsuario", idUsuario);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@DataAlteracao", DateTime.Now);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }
        public int Apagar(Usuario usuario)
        {
            string queryApagar = "UPDATE usuario SET " +
                "apagado = 'S'," +
                "ativo =  'N'," +
                "id_usuario_alteracao  =@UsuarioAlteracao," +
                "data_alteracao = @DataAlteracao " +
                "WHERE id_usuario = @id_usuario";

            acessoDados.LimparParametros();
            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.AdicionarParametros("@IdUsuario         ", usuario.IdUsuario);
            acessoDados.AdicionarParametros("@UsuarioAlteracao  ", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@DataAlteracao     ", DateTime.Now);

            return acessoDados.ExecutarManipulacao(
                CommandType.Text, queryApagar);
        }
        public UsuarioColecao ConsultarTodos()
        {
            UsuarioColecao usuarioColecao = new UsuarioColecao();
            string queryConsulta = "SELECT * FROM usuario WHERE apagado <> 'S' ORDER BY nome";
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);
            GrupoUsuarioNegocios grupoUsuarioNegocios = new GrupoUsuarioNegocios();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Usuario usuario = new Usuario();
                usuario.IdUsuario = Convert.ToInt32(dataRow["id_usuario"]);
                if (!(dataRow["nome"] is DBNull)) usuario.Nome = Convert.ToString(dataRow["nome"]); else usuario.Nome = "";
                if (!(dataRow["cpf"] is DBNull)) usuario.Cpf = Convert.ToString(dataRow["cpf"]); else usuario.Cpf = "";
                if (!(dataRow["rg"] is DBNull)) usuario.Rg = Convert.ToString(dataRow["rg"]); else usuario.Rg = "";
                if (!(dataRow["data_nascimento"] is DBNull)) usuario.DataNascimento = Convert.ToDateTime(dataRow["data_nascimento"]);
                if (!(dataRow["senha"] is DBNull)) usuario.Senha = Convert.ToString(dataRow["senha"]);
                usuario.GrupoUsuario = grupoUsuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_grupo"]));
                //if (!(dataRow["id_grupo"] is DBNull)) usuario.GrupoUsuario.IdGrupoUsuario = Convert.ToInt32(dataRow["id_grupo"]); else usuario.GrupoUsuario.IdGrupoUsuario = 0;
                if (!(dataRow["id_usuario_cadastro"] is DBNull)) usuario.UsuarioCadastro = usuarioNegocios.ConsultarPorIdAux(Convert.ToInt32(dataRow["id_usuario_cadastro"]));
                if (!(dataRow["id_usuario_alteracao"] is DBNull)) usuario.UsuarioAlteracao = usuarioNegocios.ConsultarPorIdAux(Convert.ToInt32(dataRow["id_usuario_alteracao"]));
                if (!(dataRow["ativo"] is DBNull)) usuario.Ativo = Convert.ToString(dataRow["ativo"]); else usuario.Ativo = "";
                if (!(dataRow["data_cadastro"] is DBNull)) usuario.DataCadastro = Convert.ToDateTime(dataRow["data_cadastro"]);
                if (!(dataRow["data_alteracao"] is DBNull)) usuario.DataAlteracao = Convert.ToDateTime(dataRow["data_alteracao"]);

                usuarioColecao.Add(usuario);
            }
            return usuarioColecao;

        }

        public UsuarioColecao ConsultarPorNome(string nome)
        {
            UsuarioColecao usuarioColecao = new UsuarioColecao();
            string query = "SELECT * FROM usuario WHERE nome LIKE '%' + @Nome + '%' AND apagado <> 'S'";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@Nome", nome.Trim());

            DataTable dataTable = acessoDados.ExecutarConsulta(
                CommandType.Text, query);
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            GrupoUsuarioNegocios grupoUsuarioNegocios = new GrupoUsuarioNegocios();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Usuario usuario = new Usuario();
                usuario.IdUsuario = Convert.ToInt32(dataRow["id_usuario"]);
                if (!(dataRow["nome"] is DBNull)) usuario.Nome = Convert.ToString(dataRow["nome"]); else usuario.Nome = "";
                if (!(dataRow["cpf"] is DBNull)) usuario.Cpf = Convert.ToString(dataRow["cpf"]); else usuario.Cpf = "";
                if (!(dataRow["rg"] is DBNull)) usuario.Rg = Convert.ToString(dataRow["rg"]); else usuario.Rg = "";
                if (!(dataRow["data_nascimento"] is DBNull)) usuario.DataNascimento = Convert.ToDateTime(dataRow["data_nascimento"]);
                if (!(dataRow["senha"] is DBNull)) usuario.Senha = Convert.ToString(dataRow["senha"]);
                usuario.GrupoUsuario = grupoUsuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_grupo"]));
                //if (!(dataRow["id_grupo"] is DBNull)) usuario.GrupoUsuario.IdGrupoUsuario = Convert.ToInt32(dataRow["id_grupo"]); else usuario.GrupoUsuario.IdGrupoUsuario = 0;
                if (!(dataRow["id_usuario_cadastro"] is DBNull)) usuario.UsuarioCadastro = usuarioNegocios.ConsultarPorIdAux(Convert.ToInt32(dataRow["id_usuario_cadastro"]));
                if (!(dataRow["id_usuario_alteracao"] is DBNull)) usuario.UsuarioAlteracao = usuarioNegocios.ConsultarPorIdAux(Convert.ToInt32(dataRow["id_usuario_alteracao"]));
                if (!(dataRow["ativo"] is DBNull)) usuario.Ativo = Convert.ToString(dataRow["ativo"]); else usuario.Ativo = "";
                if (!(dataRow["data_cadastro"] is DBNull)) usuario.DataCadastro = Convert.ToDateTime(dataRow["data_cadastro"]);
                if (!(dataRow["data_alteracao"] is DBNull)) usuario.DataAlteracao = Convert.ToDateTime(dataRow["data_alteracao"]);

                usuarioColecao.Add(usuario);
            }
            return usuarioColecao;


        }

        //criar consulta para login
        public Usuario ConsultarPorId(int id_usuario)
        {
            //Usuario usuario = new Usuario();
            string queryConsulta = "SELECT * FROM usuario WHERE id_usuario = @Id_usuario AND apagado <> 'S'";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@id_usuario", id_usuario);
            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);
            GrupoUsuarioNegocios grupoUsuarioNegocios = new GrupoUsuarioNegocios();

            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();

            if (dataTable.Rows.Count > 0)
            {
                Usuario usuario = new Usuario();
                usuario.IdUsuario = Convert.ToInt32(dataTable.Rows[0]["id_usuario"]);
                if (!(dataTable.Rows[0]["nome"] is DBNull)) usuario.Nome = Convert.ToString(dataTable.Rows[0]["nome"]); else usuario.Nome = "";
                if (!(dataTable.Rows[0]["cpf"] is DBNull)) usuario.Cpf = Convert.ToString(dataTable.Rows[0]["cpf"]); else usuario.Cpf = "";
                if (!(dataTable.Rows[0]["rg"] is DBNull)) usuario.Rg = Convert.ToString(dataTable.Rows[0]["rg"]); else usuario.Rg = "";
                if (!(dataTable.Rows[0]["data_nascimento"] is DBNull)) usuario.DataNascimento = Convert.ToDateTime(dataTable.Rows[0]["data_nascimento"]);
                if (!(dataTable.Rows[0]["senha"] is DBNull)) usuario.Senha = Convert.ToString(dataTable.Rows[0]["senha"]);
                usuario.GrupoUsuario = grupoUsuarioNegocios.ConsultarPorId(Convert.ToInt32(dataTable.Rows[0]["id_grupo"]));
                if(!(dataTable.Rows[0]["id_usuario_cadastro"] is DBNull)) usuario.UsuarioCadastro = usuarioNegocios.ConsultarPorIdAux(Convert.ToInt32(dataTable.Rows[0]["id_usuario_cadastro"]));
                if (!(dataTable.Rows[0]["id_usuario_alteracao"] is DBNull)) usuario.UsuarioAlteracao= usuarioNegocios.ConsultarPorIdAux(Convert.ToInt32(dataTable.Rows[0]["id_usuario_alteracao"]));
                if (!(dataTable.Rows[0]["ativo"] is DBNull)) usuario.Ativo = Convert.ToString(dataTable.Rows[0]["ativo"]); else usuario.Ativo = "";
                if (!(dataTable.Rows[0]["data_cadastro"] is DBNull)) usuario.DataCadastro = Convert.ToDateTime(dataTable.Rows[0]["data_cadastro"]);
                if (!(dataTable.Rows[0]["data_alteracao"] is DBNull)) usuario.DataAlteracao = Convert.ToDateTime(dataTable.Rows[0]["data_alteracao"]);

                return usuario;
            }
            else
            {
                return null;
            }
        }
        public Usuario ConsultarPorIdLogin(int id_usuario)
        {
            //Usuario usuario = new Usuario();
            string queryConsulta = "SELECT * FROM usuario WHERE id_usuario = @Id_usuario AND apagado <> 'S'";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@id_usuario", id_usuario);
            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);
            GrupoUsuarioNegocios grupoUsuarioNegocios = new GrupoUsuarioNegocios();

            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();

            if (dataTable.Rows.Count > 0)
            {
                Usuario usuario = new Usuario();
                usuario.IdUsuario = Convert.ToInt32(dataTable.Rows[0]["id_usuario"]);
                if (!(dataTable.Rows[0]["nome"] is DBNull)) usuario.Nome = Convert.ToString(dataTable.Rows[0]["nome"]); else usuario.Nome = "";
                if (!(dataTable.Rows[0]["cpf"] is DBNull)) usuario.Cpf = Convert.ToString(dataTable.Rows[0]["cpf"]); else usuario.Cpf = "";
                if (!(dataTable.Rows[0]["rg"] is DBNull)) usuario.Rg = Convert.ToString(dataTable.Rows[0]["rg"]); else usuario.Rg = "";
                if (!(dataTable.Rows[0]["data_nascimento"] is DBNull)) usuario.DataNascimento = Convert.ToDateTime(dataTable.Rows[0]["data_nascimento"]);
                if (!(dataTable.Rows[0]["senha"] is DBNull)) usuario.Senha = Convert.ToString(dataTable.Rows[0]["senha"]);
                //usuario.GrupoUsuario = grupoUsuarioNegocios.ConsultarPorId(Convert.ToInt32(dataTable.Rows[0]["id_grupo"]));
                if (!(dataTable.Rows[0]["id_usuario_cadastro"] is DBNull)) usuario.UsuarioCadastro = usuarioNegocios.ConsultarPorIdAux(Convert.ToInt32(dataTable.Rows[0]["id_usuario_cadastro"]));
                if (!(dataTable.Rows[0]["id_usuario_alteracao"] is DBNull)) usuario.UsuarioAlteracao = usuarioNegocios.ConsultarPorIdAux(Convert.ToInt32(dataTable.Rows[0]["id_usuario_alteracao"]));
                if (!(dataTable.Rows[0]["ativo"] is DBNull)) usuario.Ativo = Convert.ToString(dataTable.Rows[0]["ativo"]); else usuario.Ativo = "";
                if (!(dataTable.Rows[0]["data_cadastro"] is DBNull)) usuario.DataCadastro = Convert.ToDateTime(dataTable.Rows[0]["data_cadastro"]);
                if (!(dataTable.Rows[0]["data_alteracao"] is DBNull)) usuario.DataAlteracao = Convert.ToDateTime(dataTable.Rows[0]["data_alteracao"]);

                return usuario;
            }
            else
            {
                return null;
            }
        }
        //----
        public Usuario ConsultarPorIdAux(int id_usuario)
        {
            string queryConsulta = "SELECT * FROM usuario WHERE id_usuario = @Id_usuario AND apagado <> 'S'";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@id_usuario", id_usuario);
            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();

            if (dataTable.Rows.Count > 0)
            {
                Usuario usuario = new Usuario();
                usuario.IdUsuario = Convert.ToInt32(dataTable.Rows[0]["id_usuario"]);
                if (!(dataTable.Rows[0]["nome"] is DBNull)) usuario.Nome = Convert.ToString(dataTable.Rows[0]["nome"]); else usuario.Nome = "";

                return usuario;
            }
            else
            {
                return null;
            }
        }
    }
}
