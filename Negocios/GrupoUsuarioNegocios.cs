using AcessoBancoDados;
using System;
using ObjetoTransferencia;
using System.Data;


namespace Negocios
{
    public class GrupoUsuarioNegocios
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public int Inserir(GrupoUsuario grupoUsuario)
        {
            string queryInserir = "INSERT INTO grupo_usuario " +
                "(" +
                "descricao," +
                "id_usuario_cadastro," +
                "id_usuario_alteracao," +
                "apagado," +
                "ativo," +
                "data_cadastro," +
                "data_alteracao" +
                ") values (" +
                "@descricao," +
                "@UsuarioCadastro," +
                "@UsuarioAlteracao," +
                "@Apagado," +
                "@Ativo," +
                "@DataCadastro," +
                "@DataAlteracao" +
                ")";

            acessoDados.LimparParametros();
            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.AdicionarParametros("@descricao", grupoUsuario.Descricao);
            acessoDados.AdicionarParametros("@UsuarioCadastro", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@Apagado", 'N');
            acessoDados.AdicionarParametros("@Ativo", grupoUsuario.Ativo);
            acessoDados.AdicionarParametros("@DataCadastro", DateTime.Now);
            acessoDados.AdicionarParametros("@DataAlteracao", DateTime.Now);


            acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);

            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT MAX(id_grupo_usuario) FROM grupo_usuario"));
        }
        /*public int Inserir(GrupoUsuario grupoUsuario)
        {
            string queryInserir = "INSERT INTO grupo_usuario " +
                "(" +
                "id_grupo_usuario        ," +
                "nome                    ," +
                "alterar_loja            ," +
                "emitir_nfe              ," +
                "cancelar_nfe            ," +
                "emitir_orcamento        ," +
                "cancelar_orcamento      ," +
                "visualizar_cliente      ," +
                "cadastrar_cliente       ," +
                "alterar_cliente         ," +
                "apagar_clinte           ," +
                "visualizar_produto      ," +
                "cadastrar_produto       ," +
                "alterar_produto         ," +
                "apagar_produto          ," +
                "visualizar_fornecedor   ," +
                "cadastrar_fornecedor    ," +
                "alterar_fornecedor      ," +
                "apagar_fornecedor       ," +
                "visualizar_usuario      ," +
                "cadastrar_usuario       ," +
                "alterar_usuario         ," +
                "apagar_usuario          ," +
                "visualizar_grupo_usuario," +
                "cadastrar_grupo_usuario ," +
                "alterar_grupo_usuario   ," +
                "apagar_grupo_usuario    ," +
                "rel_cliente             ," +
                "rel_produto             ," +
                "rel_orcamento           ," +
                "rel_venda               ," +
                "id_usuario_cadastro     ," +
                "id_usuario_alteracao    ," +
                "apagado                 ," +
                "ativo                   ," +
                "data_cadastro           ," +
                "data_alteracao          ," +
                ") values " +
                "(" +
                "@IdGrupoUsuario        ," +
                "@Nome                  ," +
                "@AlterarLoja           ," +
                "@EmitirNFe             ," +
                "@CancelarNFe           ," +
                "@EmitirOarcamento      ," +
                "@CancelarOrcamento     ," +
                "@VisualizarCliente     ," +
                "@CadastrarCliente      ," +
                "@AlterarCliente        ," +
                "@ApagarCliente         ," +
                "@VisualizarProduto     ," +
                "@CadastrarProduto      ," +
                "@AlterarProduto        ," +
                "@ApagarProduto         ," +
                "@VisualizarFornecedor  ," +
                "@CadastrarFornecedor   ," +
                "@AlterarFornecedor     ," +
                "@ApagarFornecedor      ," +
                "@VisualizarUsuario     ," +
                "@CadastrarUsuario      ," +
                "@AlterarUsuario        ," +
                "@ApagarUsuario         ," +
                "@VisualizarGrupoUsuario," +
                "@CadastroGrupoUsuario  ," +
                "@AlterarGrupoUsuario   ," +
                "@ApagarGrupoUsuario    ," +
                "@RelCliente            ," +
                "@RelProduto            ," +
                "@RelOrcamento          ," +
                "@Relvenda              ," +
                "@UsuarioCadastro       ," +
                "@UsuarioAlteracao      ," +
                "@Apagado               ," +
                "@Ativo                 ," +
                "@DataCadastro          ," +
                "@DataAlteracao         ," +
                ")";

            acessoDados.LimparParametros();

            acessoDados.AdicionarParametros("@IdGrupoUsuario", grupoUsuario.IdGrupoUsuario);
            acessoDados.AdicionarParametros("@Nome", grupoUsuario.Descricao);
            acessoDados.AdicionarParametros("@AlterarLoja", grupoUsuario.AlterarLoja);
            acessoDados.AdicionarParametros("@EmitirNFe", grupoUsuario.EmitirVenda);
            acessoDados.AdicionarParametros("@CancelarNFe", grupoUsuario.CancelarVenda);
            acessoDados.AdicionarParametros("@EmitirOarcamento", grupoUsuario.EmitirOarcamento);
            acessoDados.AdicionarParametros("@CancelarOrcamento", grupoUsuario.CancelarOrcamento);
            acessoDados.AdicionarParametros("@VisualizarCliente", grupoUsuario.VisualizarCliente);
            acessoDados.AdicionarParametros("@CadastrarCliente", grupoUsuario.CadastrarCliente);
            acessoDados.AdicionarParametros("@AlterarCliente", grupoUsuario.AlterarCliente);
            acessoDados.AdicionarParametros("@ApagarCliente", grupoUsuario.ApagarCliente);
            acessoDados.AdicionarParametros("@VisualizarProduto", grupoUsuario.VisualizarProduto);
            acessoDados.AdicionarParametros("@Cadastrarproduto", grupoUsuario.CadastrarProduto);
            acessoDados.AdicionarParametros("@AlterarProduto", grupoUsuario.AlterarProduto);
            acessoDados.AdicionarParametros("@ApagarProduto", grupoUsuario.ApagarProduto);
            acessoDados.AdicionarParametros("@VisualizarFornecedor", grupoUsuario.VisualizarFornecedor);
            acessoDados.AdicionarParametros("@CadastrarFornecedor", grupoUsuario.CadastrarFornecedor);
            acessoDados.AdicionarParametros("@AlterarFornecedor", grupoUsuario.AlterarFornecedor);
            acessoDados.AdicionarParametros("@ApagarFornecedor", grupoUsuario.ApagarFornecedor);
            acessoDados.AdicionarParametros("@VisualizarUsuario", grupoUsuario.VisualizarUsuario);
            acessoDados.AdicionarParametros("@CadastrarUsuario", grupoUsuario.CadastrarUsuario);
            acessoDados.AdicionarParametros("@AlterarUsuario", grupoUsuario.AlterarUsuario);
            acessoDados.AdicionarParametros("@ApagarUsuario", grupoUsuario.ApagarUsuario);
            acessoDados.AdicionarParametros("@VisualizarGrupoUsuario", grupoUsuario.VisualizarGrupoUsuario);
            acessoDados.AdicionarParametros("@CadastroGrupoUsuario", grupoUsuario.CadastroGrupoUsuario);
            acessoDados.AdicionarParametros("@AlterarGrupoUsuario", grupoUsuario.AlterarGrupoUsuario);
            acessoDados.AdicionarParametros("@ApagarGrupoUsuario", grupoUsuario.ApagarGrupoUsuario);
            acessoDados.AdicionarParametros("@RelCliente", grupoUsuario.RelCliente);
            acessoDados.AdicionarParametros("@RelProduto", grupoUsuario.RelProduto);
            acessoDados.AdicionarParametros("@RelOrcamento", grupoUsuario.RelOrcamento);
            acessoDados.AdicionarParametros("@Relvenda", grupoUsuario.Relvenda);
            acessoDados.AdicionarParametros("@UsuarioCadastro", grupoUsuario.UsuarioCadastro.IdUsuario);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", grupoUsuario.UsuarioAlteracao.IdUsuario);
            acessoDados.AdicionarParametros("@Apagado", grupoUsuario.Apagado);
            acessoDados.AdicionarParametros("@Ativo", grupoUsuario.Ativo);
            acessoDados.AdicionarParametros("@DataCadastro", grupoUsuario.DataCadastro);
            acessoDados.AdicionarParametros("@DataAlteracao", grupoUsuario.DataAlteracao);


            acessoDados.ExecutarManipulacao(CommandType.Text, queryInserir);

            return Convert.ToInt32(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT MAX(id_grupo_usuario) FROM grupo_usuario"));
        }*/
        public int AlterarPermissao(string tabela,  string conteudo, int idGrupo)
        {
            string queryAlterar = "UPDATE grupo_usuario SET " +
                    tabela + " = @conteudo " +
                "WHERE id_grupo_usuario = @IdGrupoUsuario";
            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdGrupoUsuario", idGrupo);
            acessoDados.AdicionarParametros("@conteudo", conteudo);
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }
        public int Alterar(GrupoUsuario grupoUsuario)
        {
            string queryAlterar = "UPDATE grupo_usuario SET " +
                    "descricao= @descricao, " +
                    "id_usuario_alteracao= @UsuarioAlteracao, " +
                    "ativo= @Ativo, " +
                    "data_alteracao= @DataAlteracao " +
                "WHERE id_grupo_usuario = @IdGrupoUsuario";

            var usuarioLogado = UsuarioLogado.Instancia;
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdGrupoUsuario", grupoUsuario.IdGrupoUsuario);
            acessoDados.AdicionarParametros("@descricao", grupoUsuario.Descricao);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", usuarioLogado.IdUsuario);
            acessoDados.AdicionarParametros("@Ativo", grupoUsuario.Ativo);
            acessoDados.AdicionarParametros("@DataAlteracao", DateTime.Now);
            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }

        /*public int Alterar(GrupoUsuario grupoUsuario)
        {
            string queryAlterar = "UPDATE grupo_usuario SET" +

                    "nome                    = @Nome                  ," +
                    "alterar_loja            = @AlterarLoja           ," +
                    "emitir_nfe              = @EmitirNFe             ," +
                    "cancelar_nfe            = @CancelarNFe           ," +
                    "emitir_orcamento        = @EmitirOarcamento      ," +
                    "cancelar_orcamento       = @CancelarOrcamento     ," +
                    "visualizar_cliente      = @VisualizarCliente     ," +
                    "cadastrar_cliente       = @CadastrarCliente      ," +
                    "alterar_cliente         = @AlterarCliente        ," +
                    "apagar_clinte           = @ApagarCliente         ," +
                    "visualizar_produto      = @VisualizarProduto     ," +
                    "cadastrar_produto       = @Cadastrarproduto      ," +
                    "alterar_produto         = @AlterarProduto        ," +
                    "apagar_produto          = @ApagarProduto         ," +
                    "visualizar_fornecedor   = @VisualizarFornecedor  ," +
                    "cadastrar_fornecedor    = @CadastrarFornecedor   ," +
                    "alterar_fornecedor      = @AlterarFornecedor     ," +
                    "apagar_fornecedor       = @ApagarFornecedor      ," +
                    "visualizar_usuario      = @VisualizarUsuario     ," +
                    "cadastrar_usuario       = @CadastrarUsuario      ," +
                    "alterar_usuario         = @AlterarUsuario        ," +
                    "apagar_usuario          = @ApagarUsuario         ," +
                    "visualizar_grupo_usuario= @VisualizarGrupoUsuario," +
                    "cadastrar_grupo_usuario = @CadastroGrupoUsuario  ," +
                    "alterar_grupo_usuario   = @AlterarGrupoUsuario   ," +
                    "apagar_grupo_usuario    = @ApagarGrupoUsuario    ," +
                    "rel_cliente             = @RelCliente            ," +
                    "rel_produto             = @RelProduto            ," +
                    "rel_orcamento           = @RelOrcamento          ," +
                    "rel_venda               = @Relvenda              ," +
                    "id_usuario_cadastro     = @UsuarioCadastro       ," +
                    "id_usuario_alteracao    = @UsuarioAlteracao      ," +
                    "apagado                 = @Apagado               ," +
                    "ativo                   = @Ativo                 ," +
                    "data_cadastro           = @DataCadastro          ," +
                    "data_alteracao          = @DataAlteracao         " +
                "WHERE id_grupo_usuario = @IdGrupoUsuario";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdGrupoUsuario", grupoUsuario.IdGrupoUsuario);
            acessoDados.AdicionarParametros("@Nome", grupoUsuario.Descricao);
            acessoDados.AdicionarParametros("@AlterarLoja", grupoUsuario.AlterarLoja);
            acessoDados.AdicionarParametros("@EmitirNFe", grupoUsuario.EmitirVenda);
            acessoDados.AdicionarParametros("@CancelarNFe", grupoUsuario.CancelarVenda);
            acessoDados.AdicionarParametros("@EmitirOarcamento", grupoUsuario.EmitirOarcamento);
            acessoDados.AdicionarParametros("@CancelarOrcamento", grupoUsuario.CancelarOrcamento);
            acessoDados.AdicionarParametros("@VisualizarCliente", grupoUsuario.VisualizarCliente);
            acessoDados.AdicionarParametros("@CadastrarCliente", grupoUsuario.CadastrarCliente);
            acessoDados.AdicionarParametros("@AlterarCliente", grupoUsuario.AlterarCliente);
            acessoDados.AdicionarParametros("@ApagarCliente", grupoUsuario.ApagarCliente);
            acessoDados.AdicionarParametros("@VisualizarProduto", grupoUsuario.VisualizarProduto);
            acessoDados.AdicionarParametros("@Cadastrarproduto", grupoUsuario.CadastrarProduto);
            acessoDados.AdicionarParametros("@AlterarProduto", grupoUsuario.AlterarProduto);
            acessoDados.AdicionarParametros("@ApagarProduto", grupoUsuario.ApagarProduto);
            acessoDados.AdicionarParametros("@VisualizarFornecedor", grupoUsuario.VisualizarFornecedor);
            acessoDados.AdicionarParametros("@CadastrarFornecedor", grupoUsuario.CadastrarFornecedor);
            acessoDados.AdicionarParametros("@AlterarFornecedor", grupoUsuario.AlterarFornecedor);
            acessoDados.AdicionarParametros("@ApagarFornecedor", grupoUsuario.ApagarFornecedor);
            acessoDados.AdicionarParametros("@VisualizarUsuario", grupoUsuario.VisualizarUsuario);
            acessoDados.AdicionarParametros("@CadastrarUsuario", grupoUsuario.CadastrarUsuario);
            acessoDados.AdicionarParametros("@AlterarUsuario", grupoUsuario.AlterarUsuario);
            acessoDados.AdicionarParametros("@ApagarUsuario", grupoUsuario.ApagarUsuario);
            acessoDados.AdicionarParametros("@VisualizarGrupoUsuario", grupoUsuario.VisualizarGrupoUsuario);
            acessoDados.AdicionarParametros("@CadastroGrupoUsuario", grupoUsuario.CadastroGrupoUsuario);
            acessoDados.AdicionarParametros("@AlterarGrupoUsuario", grupoUsuario.AlterarGrupoUsuario);
            acessoDados.AdicionarParametros("@ApagarGrupoUsuario", grupoUsuario.ApagarGrupoUsuario);
            acessoDados.AdicionarParametros("@RelCliente", grupoUsuario.RelCliente);
            acessoDados.AdicionarParametros("@RelProduto", grupoUsuario.RelProduto);
            acessoDados.AdicionarParametros("@RelOrcamento", grupoUsuario.RelOrcamento);
            acessoDados.AdicionarParametros("@Relvenda", grupoUsuario.Relvenda);
            acessoDados.AdicionarParametros("@UsuarioCadastro", grupoUsuario.UsuarioCadastro.IdUsuario);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", grupoUsuario.UsuarioAlteracao.IdUsuario);
            acessoDados.AdicionarParametros("@Apagado", grupoUsuario.Apagado);
            acessoDados.AdicionarParametros("@Ativo", grupoUsuario.Ativo);
            acessoDados.AdicionarParametros("@DataCadastro", grupoUsuario.DataCadastro);
            acessoDados.AdicionarParametros("@DataAlteracao", grupoUsuario.DataAlteracao);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }*/

        public int Apagar(GrupoUsuario grupoUsuario)
        {
            string queryApagar = "UPDATE grupo_usuario SET " +
                "id_usuario_alteracao = @UsuarioAlteracao," +
                "apagado = 'S'," +
                "ativo =  'N'," +
                "data_alteracao = @DataAlteracao " +
                "WHERE id_grupo_usuario = @IdGrupoUsuario";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdGrupoUsuario", grupoUsuario.IdGrupoUsuario);
            acessoDados.AdicionarParametros("@UsuarioAlteracao", grupoUsuario.UsuarioAlteracao.IdUsuario);
            acessoDados.AdicionarParametros("@DataAlteracao", grupoUsuario.DataAlteracao);

            return acessoDados.ExecutarManipulacao(CommandType.Text, queryApagar);
        }
        public string ConsultarPermisao(string campo, int idGrupo)
        {
            acessoDados.LimparParametros();
            return Convert.ToString(acessoDados.ExecutarConsultaScalar(
                CommandType.Text, "SELECT " + campo + " FROM grupo_usuario WHERE id_grupo_usuario = " + idGrupo));
        }
        public GrupoUsuarioColecao ConsultarPorNome(string nome)
        {
            GrupoUsuarioColecao grupoUsuarioColecao = new GrupoUsuarioColecao();
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            string query = "SELECT * FROM grupo_usuario WHERE descricao LIKE '%' + @descricao + '%' AND apagado <> 'S'";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@descricao", nome.Trim());

            DataTable dataTable = acessoDados.ExecutarConsulta(
                CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                GrupoUsuario grupoUsuario = new GrupoUsuario();
                //UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
                grupoUsuario.IdGrupoUsuario = Convert.ToInt32(dataRow["id_grupo_usuario"]);

                if (!(dataRow["descricao"] is DBNull))
                    grupoUsuario.Descricao = Convert.ToString(dataRow["descricao"]);
                if (!(dataRow["alterar_loja"] is DBNull))	
                    grupoUsuario.AlterarLoja			= Convert.ToString(dataRow["alterar_loja"]);
                if (!(dataRow["emitir_venda"] is DBNull))
                    grupoUsuario.EmitirVenda = Convert.ToString(dataRow["emitir_venda"]);
                if (!(dataRow["cancelar_venda"] is DBNull))
                    grupoUsuario.CancelarVenda = Convert.ToString(dataRow["cancelar_venda"]);
                if (!(dataRow["emitir_orcamento"] is DBNull))	
                    grupoUsuario.EmitirOarcamento			= Convert.ToString(dataRow["emitir_orcamento"]);
                if (!(dataRow["cancelar_orcamento"] is DBNull))	
                    grupoUsuario.CancelarOrcamento			= Convert.ToString(dataRow["cancelar_orcamento"]);
                if (!(dataRow["visualizar_cliente"] is DBNull))	
                    grupoUsuario.VisualizarCliente			= Convert.ToString(dataRow["visualizar_cliente"]);
                if (!(dataRow["cadastrar_cliente"] is DBNull))	
                    grupoUsuario.CadastrarCliente			= Convert.ToString(dataRow["cadastrar_cliente"]);
                if (!(dataRow["alterar_cliente"] is DBNull))	
                    grupoUsuario.AlterarCliente			= Convert.ToString(dataRow["alterar_cliente"]);
                if (!(dataRow["apagar_cliente"] is DBNull))	
                    grupoUsuario.ApagarCliente			= Convert.ToString(dataRow["apagar_cliente"]);
                if (!(dataRow["visualizar_produto"] is DBNull))	
                    grupoUsuario.VisualizarProduto			= Convert.ToString(dataRow["visualizar_produto"]);
                if (!(dataRow["cadastrar_produto"] is DBNull))	
                    grupoUsuario.CadastrarProduto			= Convert.ToString(dataRow["cadastrar_produto"]);
                if (!(dataRow["alterar_produto"] is DBNull))	
                    grupoUsuario.AlterarProduto			= Convert.ToString(dataRow["alterar_produto"]);
                if (!(dataRow["apagar_produto"] is DBNull))	
                    grupoUsuario.ApagarProduto			= Convert.ToString(dataRow["apagar_produto"]);
                if (!(dataRow["visualizar_fornecedor"] is DBNull))	
                    grupoUsuario.VisualizarFornecedor			= Convert.ToString(dataRow["visualizar_fornecedor"]);
                if (!(dataRow["cadastrar_fornecedor"] is DBNull))	
                    grupoUsuario.CadastrarFornecedor			= Convert.ToString(dataRow["cadastrar_fornecedor"]);
                if (!(dataRow["alterar_fornecedor"] is DBNull))	
                    grupoUsuario.AlterarFornecedor			= Convert.ToString(dataRow["alterar_fornecedor"]);
                if (!(dataRow["apagar_fornecedor"] is DBNull))	
                    grupoUsuario.ApagarFornecedor			= Convert.ToString(dataRow["apagar_fornecedor"]);
                if (!(dataRow["visualizar_usuario"] is DBNull))	
                    grupoUsuario.VisualizarUsuario			= Convert.ToString(dataRow["visualizar_usuario"]);
                if (!(dataRow["cadastrar_usuario"] is DBNull))	
                    grupoUsuario.CadastrarUsuario			= Convert.ToString(dataRow["cadastrar_usuario"]);
                if (!(dataRow["alterar_usuario"] is DBNull))	
                    grupoUsuario.AlterarUsuario			= Convert.ToString(dataRow["alterar_usuario"]);
                if (!(dataRow["apagar_usuario"] is DBNull))	
                    grupoUsuario.ApagarUsuario			= Convert.ToString(dataRow["apagar_usuario"]);
                if (!(dataRow["visualizar_grupo_usuario"] is DBNull))	
                    grupoUsuario.VisualizarGrupoUsuario			= Convert.ToString(dataRow["visualizar_grupo_usuario"]);
                if (!(dataRow["cadastrar_grupo_usuario"] is DBNull))	
                    grupoUsuario.CadastroGrupoUsuario			= Convert.ToString(dataRow["cadastrar_grupo_usuario"]);
                if (!(dataRow["alterar_grupo_usuario"] is DBNull))	
                    grupoUsuario.AlterarGrupoUsuario			= Convert.ToString(dataRow["alterar_grupo_usuario"]);
                if (!(dataRow["apagar_grupo_usuario"] is DBNull))	
                    grupoUsuario.ApagarGrupoUsuario			= Convert.ToString(dataRow["apagar_grupo_usuario"]);
                if (!(dataRow["rel_cliente"] is DBNull))	
                    grupoUsuario.RelCliente			= Convert.ToString(dataRow["rel_cliente"]);
                if (!(dataRow["rel_produto"] is DBNull))	
                    grupoUsuario.RelProduto			= Convert.ToString(dataRow["rel_produto"]);
                if (!(dataRow["rel_orcamento"] is DBNull))	
                    grupoUsuario.RelOrcamento			= Convert.ToString(dataRow["rel_orcamento"]);
                if (!(dataRow["rel_venda"] is DBNull))	
                    grupoUsuario.Relvenda			= Convert.ToString(dataRow["rel_venda"]);
                if (!(dataRow["id_usuario_cadastro"] is DBNull))	
                    grupoUsuario.UsuarioCadastro = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_cadastro"]));
                if (!(dataRow["id_usuario_alteracao"] is DBNull))	
                    grupoUsuario.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_alteracao"]));
                if (!(dataRow["apagado"] is DBNull))	
                    grupoUsuario.Apagado			= Convert.ToString(dataRow["apagado"]);
                if (!(dataRow["ativo"] is DBNull))	
                    grupoUsuario.Ativo			= Convert.ToString(dataRow["ativo"]);
                if (!(dataRow["data_cadastro"] is DBNull))	
                    grupoUsuario.DataCadastro			= Convert.ToDateTime(dataRow["data_cadastro"]);
                if (!(dataRow["data_alteracao"] is DBNull))	
                    grupoUsuario.DataAlteracao			= Convert.ToDateTime(dataRow["data_alteracao"]);



                grupoUsuarioColecao.Add(grupoUsuario);
            }
            return grupoUsuarioColecao;

        }

        public GrupoUsuario ConsultarPorId(int IdGrupoUsuario)
        {
            string queryConsulta = "SELECT * FROM grupo_usuario WHERE id_grupo_usuario = @IdGrupoUsuario AND apagado <> 'S'";

            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdGrupoUsuario", IdGrupoUsuario);

            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.Text, queryConsulta);

            if (dataTable.Rows.Count > 0)
            {
                GrupoUsuario grupoUsuario = new GrupoUsuario();
                UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
                grupoUsuario.IdGrupoUsuario = Convert.ToInt32(dataTable.Rows[0]["id_grupo_usuario"]);
                grupoUsuario.Descricao = Convert.ToString(dataTable.Rows[0]["descricao"]);
                grupoUsuario.AlterarLoja = Convert.ToString(dataTable.Rows[0]["alterar_loja"]);
                grupoUsuario.EmitirVenda = Convert.ToString(dataTable.Rows[0]["emitir_venda"]);
                grupoUsuario.CancelarVenda = Convert.ToString(dataTable.Rows[0]["cancelar_venda"]);
                grupoUsuario.EmitirOarcamento = Convert.ToString(dataTable.Rows[0]["emitir_orcamento"]);
                grupoUsuario.CancelarOrcamento = Convert.ToString(dataTable.Rows[0]["cancelar_orcamento"]);
                grupoUsuario.VisualizarCliente = Convert.ToString(dataTable.Rows[0]["visualizar_cliente"]);
                grupoUsuario.CadastrarCliente = Convert.ToString(dataTable.Rows[0]["cadastrar_cliente"]);
                grupoUsuario.AlterarCliente = Convert.ToString(dataTable.Rows[0]["alterar_cliente"]);
                grupoUsuario.ApagarCliente = Convert.ToString(dataTable.Rows[0]["apagar_cliente"]);
                grupoUsuario.VisualizarProduto = Convert.ToString(dataTable.Rows[0]["visualizar_produto"]);
                grupoUsuario.CadastrarProduto = Convert.ToString(dataTable.Rows[0]["cadastrar_produto"]);
                grupoUsuario.AlterarProduto = Convert.ToString(dataTable.Rows[0]["alterar_produto"]);
                grupoUsuario.ApagarProduto = Convert.ToString(dataTable.Rows[0]["apagar_produto"]);
                grupoUsuario.VisualizarFornecedor = Convert.ToString(dataTable.Rows[0]["visualizar_fornecedor"]);
                grupoUsuario.CadastrarFornecedor = Convert.ToString(dataTable.Rows[0]["cadastrar_fornecedor"]);
                grupoUsuario.AlterarFornecedor = Convert.ToString(dataTable.Rows[0]["alterar_fornecedor"]);
                grupoUsuario.ApagarFornecedor = Convert.ToString(dataTable.Rows[0]["apagar_fornecedor"]);
                grupoUsuario.VisualizarUsuario = Convert.ToString(dataTable.Rows[0]["visualizar_usuario"]);
                grupoUsuario.CadastrarUsuario = Convert.ToString(dataTable.Rows[0]["cadastrar_usuario"]);
                grupoUsuario.AlterarUsuario = Convert.ToString(dataTable.Rows[0]["alterar_usuario"]);
                grupoUsuario.ApagarUsuario = Convert.ToString(dataTable.Rows[0]["apagar_usuario"]);
                grupoUsuario.VisualizarGrupoUsuario = Convert.ToString(dataTable.Rows[0]["visualizar_grupo_usuario"]);
                grupoUsuario.CadastroGrupoUsuario = Convert.ToString(dataTable.Rows[0]["cadastrar_grupo_usuario"]);
                grupoUsuario.AlterarGrupoUsuario = Convert.ToString(dataTable.Rows[0]["alterar_grupo_usuario"]);
                grupoUsuario.ApagarGrupoUsuario = Convert.ToString(dataTable.Rows[0]["apagar_grupo_usuario"]);
                grupoUsuario.RelCliente = Convert.ToString(dataTable.Rows[0]["rel_cliente"]);
                grupoUsuario.RelProduto = Convert.ToString(dataTable.Rows[0]["rel_produto"]);
                grupoUsuario.RelOrcamento = Convert.ToString(dataTable.Rows[0]["rel_orcamento"]);
                grupoUsuario.Relvenda = Convert.ToString(dataTable.Rows[0]["rel_venda"]);
                //grupoUsuario.UsuarioCadastro = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataTable.Rows[0]["id_usuario_cadastro"]));
                //grupoUsuario.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataTable.Rows[0]["id_usuario_alteracao"]));
                grupoUsuario.Apagado = Convert.ToString(dataTable.Rows[0]["apagado"]);
                grupoUsuario.Ativo = Convert.ToString(dataTable.Rows[0]["ativo"]);
                grupoUsuario.DataCadastro = Convert.ToDateTime(dataTable.Rows[0]["data_cadastro"]);
                grupoUsuario.DataAlteracao = Convert.ToDateTime(dataTable.Rows[0]["data_alteracao"]);

                return grupoUsuario;
            }
            else
            {
                return null;
            }
        }
        public GrupoUsuarioColecao ConsultarTodos()
        {
            GrupoUsuarioColecao grupoUsuarioColecao = new GrupoUsuarioColecao();
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            string query = "SELECT * FROM grupo_usuario WHERE apagado <> 'S'";

            acessoDados.LimparParametros();

            DataTable dataTable = acessoDados.ExecutarConsulta(
                CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                GrupoUsuario grupoUsuario = new GrupoUsuario();

                grupoUsuario.IdGrupoUsuario = Convert.ToInt32(dataRow["id_grupo_usuario"]);

                if (!(dataRow["descricao"] is DBNull))
                    grupoUsuario.Descricao = Convert.ToString(dataRow["descricao"]);
                if (!(dataRow["alterar_loja"] is DBNull))
                    grupoUsuario.AlterarLoja = Convert.ToString(dataRow["alterar_loja"]);
                if (!(dataRow["emitir_venda"] is DBNull))
                    grupoUsuario.EmitirVenda = Convert.ToString(dataRow["emitir_venda"]);
                if (!(dataRow["cancelar_venda"] is DBNull))
                    grupoUsuario.CancelarVenda = Convert.ToString(dataRow["cancelar_venda"]);
                if (!(dataRow["emitir_orcamento"] is DBNull))
                    grupoUsuario.EmitirOarcamento = Convert.ToString(dataRow["emitir_orcamento"]);
                if (!(dataRow["cancelar_orcamento"] is DBNull))
                    grupoUsuario.CancelarOrcamento = Convert.ToString(dataRow["cancelar_orcamento"]);
                if (!(dataRow["visualizar_cliente"] is DBNull))
                    grupoUsuario.VisualizarCliente = Convert.ToString(dataRow["visualizar_cliente"]);
                if (!(dataRow["cadastrar_cliente"] is DBNull))
                    grupoUsuario.CadastrarCliente = Convert.ToString(dataRow["cadastrar_cliente"]);
                if (!(dataRow["alterar_cliente"] is DBNull))
                    grupoUsuario.AlterarCliente = Convert.ToString(dataRow["alterar_cliente"]);
                if (!(dataRow["apagar_cliente"] is DBNull))
                    grupoUsuario.ApagarCliente = Convert.ToString(dataRow["apagar_cliente"]);
                if (!(dataRow["visualizar_produto"] is DBNull))
                    grupoUsuario.VisualizarProduto = Convert.ToString(dataRow["visualizar_produto"]);
                if (!(dataRow["cadastrar_produto"] is DBNull))
                    grupoUsuario.CadastrarProduto = Convert.ToString(dataRow["cadastrar_produto"]);
                if (!(dataRow["alterar_produto"] is DBNull))
                    grupoUsuario.AlterarProduto = Convert.ToString(dataRow["alterar_produto"]);
                if (!(dataRow["apagar_produto"] is DBNull))
                    grupoUsuario.ApagarProduto = Convert.ToString(dataRow["apagar_produto"]);
                if (!(dataRow["visualizar_fornecedor"] is DBNull))
                    grupoUsuario.VisualizarFornecedor = Convert.ToString(dataRow["visualizar_fornecedor"]);
                if (!(dataRow["cadastrar_fornecedor"] is DBNull))
                    grupoUsuario.CadastrarFornecedor = Convert.ToString(dataRow["cadastrar_fornecedor"]);
                if (!(dataRow["alterar_fornecedor"] is DBNull))
                    grupoUsuario.AlterarFornecedor = Convert.ToString(dataRow["alterar_fornecedor"]);
                if (!(dataRow["apagar_fornecedor"] is DBNull))
                    grupoUsuario.ApagarFornecedor = Convert.ToString(dataRow["apagar_fornecedor"]);
                if (!(dataRow["visualizar_usuario"] is DBNull))
                    grupoUsuario.VisualizarUsuario = Convert.ToString(dataRow["visualizar_usuario"]);
                if (!(dataRow["cadastrar_usuario"] is DBNull))
                    grupoUsuario.CadastrarUsuario = Convert.ToString(dataRow["cadastrar_usuario"]);
                if (!(dataRow["alterar_usuario"] is DBNull))
                    grupoUsuario.AlterarUsuario = Convert.ToString(dataRow["alterar_usuario"]);
                if (!(dataRow["apagar_usuario"] is DBNull))
                    grupoUsuario.ApagarUsuario = Convert.ToString(dataRow["apagar_usuario"]);
                if (!(dataRow["visualizar_grupo_usuario"] is DBNull))
                    grupoUsuario.VisualizarGrupoUsuario = Convert.ToString(dataRow["visualizar_grupo_usuario"]);
                if (!(dataRow["cadastrar_grupo_usuario"] is DBNull))
                    grupoUsuario.CadastroGrupoUsuario = Convert.ToString(dataRow["cadastrar_grupo_usuario"]);
                if (!(dataRow["alterar_grupo_usuario"] is DBNull))
                    grupoUsuario.AlterarGrupoUsuario = Convert.ToString(dataRow["alterar_grupo_usuario"]);
                if (!(dataRow["apagar_grupo_usuario"] is DBNull))
                    grupoUsuario.ApagarGrupoUsuario = Convert.ToString(dataRow["apagar_grupo_usuario"]);
                if (!(dataRow["rel_cliente"] is DBNull))
                    grupoUsuario.RelCliente = Convert.ToString(dataRow["rel_cliente"]);
                if (!(dataRow["rel_produto"] is DBNull))
                    grupoUsuario.RelProduto = Convert.ToString(dataRow["rel_produto"]);
                if (!(dataRow["rel_orcamento"] is DBNull))
                    grupoUsuario.RelOrcamento = Convert.ToString(dataRow["rel_orcamento"]);
                if (!(dataRow["rel_venda"] is DBNull))
                    grupoUsuario.Relvenda = Convert.ToString(dataRow["rel_venda"]);
                if (!(dataRow["id_usuario_cadastro"] is DBNull))
                    grupoUsuario.UsuarioCadastro = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_cadastro"]));
                if (!(dataRow["id_usuario_alteracao"] is DBNull))
                    grupoUsuario.UsuarioAlteracao = usuarioNegocios.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario_alteracao"]));
                if (!(dataRow["apagado"] is DBNull))
                    grupoUsuario.Apagado = Convert.ToString(dataRow["apagado"]);
                if (!(dataRow["ativo"] is DBNull))
                    grupoUsuario.Ativo = Convert.ToString(dataRow["ativo"]);
                if (!(dataRow["data_cadastro"] is DBNull))
                    grupoUsuario.DataCadastro = Convert.ToDateTime(dataRow["data_cadastro"]);
                if (!(dataRow["data_alteracao"] is DBNull))
                    grupoUsuario.DataAlteracao = Convert.ToDateTime(dataRow["data_alteracao"]);



                grupoUsuarioColecao.Add(grupoUsuario);
            }
            return grupoUsuarioColecao;

        }
    }
}
