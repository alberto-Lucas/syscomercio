using Negocios;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmUsuarioCadastro : Form
    {
        int acaoNaTelaSelecionada;
        public FrmUsuarioCadastro(int acaoNaTela, Usuario usuario)
        {
            InitializeComponent();
            GrupoUsuarioNegocios grupoUsuarioNegocios = new GrupoUsuarioNegocios();
            GrupoUsuarioColecao grupoUsuarioColecao = new GrupoUsuarioColecao();
            cbxGrupoUsuario.DataSource = null;
            grupoUsuarioColecao = grupoUsuarioNegocios.ConsultarTodos();
            cbxGrupoUsuario.DataSource = grupoUsuarioColecao;
            cbxGrupoUsuario.ValueMember = "IdGrupoUsuario";
            cbxGrupoUsuario.DisplayMember = "Descricao";
            cbxGrupoUsuario.Update();
            cbxGrupoUsuario.Refresh();

            #region Tab
            this.pnlDadosCliente.Location = new System.Drawing.Point(12, 95);
            pnlContatoUsuario.Location = new System.Drawing.Point(12, 95);
            pnlEnderecoCliente.Location = new System.Drawing.Point(12, 95);
            lblBtnDados.BringToFront();
            this.Size = new System.Drawing.Size(496, 546);
            #endregion

            //1 - INSERIR
            //2 - ALTERAR
            //3 - VISUALIZAR

            acaoNaTelaSelecionada = acaoNaTela;
            switch (acaoNaTelaSelecionada)
            {
                case 1:
                    {
                        lblTituloTela.Text = "Inserir Usuário";
                        //pessoa_f();
                        //rdbFisica.Checked = true;
                        //pesquisarCidadePorEstado();
                        //cbxAtivo.Text = "S";
                    }
                    break;
                case 2:
                    {
                        lblTituloTela.Text = "Alterar Usuário";

                        string ativo = usuario.Ativo;
                        if (ativo.Equals("S"))
                        {
                            cbxAtivo.Text = "SIM";
                        }
                        else
                        {
                            cbxAtivo.Text = "NÃO";
                        }


                        txtId.Text = usuario.IdUsuario.ToString();
                        txtNome.Text = usuario.Nome;
                        txtCpf.Text = usuario.Cpf;
                        txtRg.Text = usuario.Rg;
                        txtSenha.Text = usuario.Senha;
                        txtConfirmaSenha.Text = usuario.Senha;
                        txtIdGrupoUsuario.Text = usuario.GrupoUsuario.IdGrupoUsuario.ToString();
                        cbxGrupoUsuario.Text = usuario.GrupoUsuario.Descricao;
                        mskDNas.Text = usuario.DataNascimento.ToString();
                        mskDCadastro.Text = usuario.DataCadastro.ToString();
                        mskDAlteracao.Text = usuario.DataAlteracao.ToString();
                        txtIdUserCadastro.Text = usuario.UsuarioCadastro.IdUsuario.ToString();
                        txtIdUserAlteracao.Text = usuario.UsuarioAlteracao.IdUsuario.ToString();
                        txtNomeUserCadastro.Text = usuario.UsuarioCadastro.Nome;
                        txtNomeUserAlteracao.Text = usuario.UsuarioAlteracao.Nome;
                    }
                    break;
                case 3:
                    {
                        visualizar();

                        lblTituloTela.Text = "Visualizar Usuário";

                        string ativo = usuario.Ativo;
                        if (ativo.Equals("S"))
                        {
                            cbxAtivo.Text = "SIM";
                        }
                        else
                        {
                            cbxAtivo.Text = "NÃO";
                        }

                        txtId.Text = usuario.IdUsuario.ToString();
                        txtNome.Text = usuario.Nome;
                        txtCpf.Text = usuario.Cpf;
                        txtRg.Text = usuario.Rg;
                        txtSenha.Text = usuario.Senha;
                        txtConfirmaSenha.Text = usuario.Senha;
                        txtIdGrupoUsuario.Text = usuario.GrupoUsuario.IdGrupoUsuario.ToString();
                        cbxGrupoUsuario.Text = usuario.GrupoUsuario.Descricao;
                        mskDNas.Text = usuario.DataNascimento.ToString();
                        mskDCadastro.Text = usuario.DataCadastro.ToString();
                        mskDAlteracao.Text = usuario.DataAlteracao.ToString();
                        txtIdUserCadastro.Text = usuario.UsuarioCadastro.IdUsuario.ToString();
                        txtIdUserAlteracao.Text = usuario.UsuarioAlteracao.IdUsuario.ToString();
                        txtNomeUserCadastro.Text = usuario.UsuarioCadastro.Nome;
                        txtNomeUserAlteracao.Text = usuario.UsuarioAlteracao.Nome;
                    }
                    break;
            }
        }

        #region Movimentar form
        //----Movimentar form-------------------------------------------------------------
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void pnlTopo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //----Movimentar form-------------------------------------------------------------
        #endregion
        public void visualizar()
        {
            txtId.ReadOnly = true;
            txtNome.ReadOnly = true;
            txtCpf.ReadOnly = true;
            txtRg.ReadOnly = true;
            mskDNas.ReadOnly = true;
            txtSenha.ReadOnly = true;
            cbxGrupoUsuario.Enabled = false;
            txtIdGrupoUsuario.ReadOnly = false;
            cbxAtivo.Enabled = false;


            btnSlavar.Visible = false;
            btnCancelar.Visible = false;
        }
        #region Animação Mouse
        //Dados = 1
        //Contato = 2
        //Endereco = 3
        bool dados = true, contato = false, endereco = false;
        void MouseLeaves(int mouseLeave)
        {
            if (mouseLeave == 1)
            {
                lblBtnDados.BackColor = Color.LightGray;
                lblBtnDados.ForeColor = Color.FromArgb(255, 177, 0);
            }

            if (mouseLeave == 2)
            {
                lblBtnContato.BackColor = Color.LightGray;
                lblBtnContato.ForeColor = Color.FromArgb(255, 177, 0);
            }

            if (mouseLeave == 3)
            {
                lblBtnEndereco.BackColor = Color.LightGray;
                lblBtnEndereco.ForeColor = Color.FromArgb(255, 177, 0);
            }

        }
        void MouseMoves(int mouseMove)
        {
            if (mouseMove == 1)
            {
                lblBtnDados.BackColor = Color.FromArgb(255, 177, 0);
                lblBtnDados.ForeColor = Color.White;
            }

            if (mouseMove == 2)
            {
                lblBtnContato.BackColor = Color.FromArgb(255, 177, 0);
                lblBtnContato.ForeColor = Color.White;
            }

            if (mouseMove == 3)
            {
                lblBtnEndereco.BackColor = Color.FromArgb(255, 177, 0);
                lblBtnEndereco.ForeColor = Color.White;
            }
        }

        void desabilita()
        {
            if (dados == false)
            {
                lblBtnDados.BackColor = Color.LightGray;
                lblBtnDados.ForeColor = Color.FromArgb(255, 177, 0);
                lblBtnDados.SendToBack();
            }

            if (contato == false)
            {
                lblBtnContato.BackColor = Color.LightGray;
                lblBtnContato.ForeColor = Color.FromArgb(255, 177, 0);
                lblBtnContato.SendToBack();
            }

            if (endereco == false)
            {
                lblBtnEndereco.BackColor = Color.LightGray;
                lblBtnEndereco.ForeColor = Color.FromArgb(255, 177, 0);
                lblBtnEndereco.SendToBack();
            }
        }

        void habilita()
        {
            if (dados == true)
            {
                lblBtnDados.BackColor = Color.FromArgb(255, 177, 0);
                lblBtnDados.ForeColor = Color.White;
                lblBtnDados.BringToFront();
            }

            if (contato == true)
            {
                lblBtnContato.BackColor = Color.FromArgb(255, 177, 0);
                lblBtnContato.ForeColor = Color.White;
                lblBtnContato.BringToFront();
            }

            if (endereco == true)
            {
                lblBtnEndereco.BackColor = Color.FromArgb(255, 177, 0);
                lblBtnEndereco.ForeColor = Color.White;
                lblBtnEndereco.BringToFront();
            }
        }

        //------DADOS----------------------------------------------------------------
        private void lblBtnDados_MouseLeave(object sender, EventArgs e)
        {
            if (dados == false)
            {
                MouseLeaves(1);
            }
        }

        private void lblBtnDados_MouseMove(object sender, MouseEventArgs e)
        {
            if (dados == false)
            {
                MouseMoves(1);
            }
        }

        private void lblBtnDados_Click(object sender, EventArgs e)
        {
            dados = true;
            contato = false;
            endereco = false;
            pnlDadosCliente.Location = new System.Drawing.Point(12, 95);
            pnlDadosCliente.BringToFront();
            pnlManter.BringToFront();
            habilita();
            desabilita();
        }
        //------CONTATO-------------------------------------------------
        void lblBtnContatoMouseLeave(object sender, EventArgs e)
        {

            if (contato == false)
            {
                MouseLeaves(2);
            }

        }
        void lblBtnContatoMouseMove(object sender, MouseEventArgs e)
        {

            if (contato == false)
            {
                MouseMoves(2);
            }

        }
        void lblBtnContatoClick(object sender, EventArgs e)
        {
            dados = false;
            contato = true;
            endereco = false;

            pnlContatoUsuario.BringToFront();
            habilita();
            desabilita();

            int id = int.Parse(txtId.Text);
            usrTelefone frmContato = new usrTelefone(3, id);
            pnlContatoUsuario.Controls.Add(frmContato);
        }
        //------ENDERECO-------------------------------------------------
        void lblBtnEnderecoMouseLeave(object sender, EventArgs e)
        {

            if (endereco == false)
            {
                MouseLeaves(3);
            }

        }
        void lblBtnEnderecoMouseMove(object sender, MouseEventArgs e)
        {

            if (endereco == false)
            {
                MouseMoves(3);
            }

        }
        void lblBtnEnderecoClick(object sender, EventArgs e)
        {
            dados = false;
            contato = false;
            endereco = true;

            pnlEnderecoCliente.BringToFront();
            habilita();
            desabilita();
        }
        //------FIM-------------------------------------------------
        #endregion
        private void ptbClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void ptbClose_MouseLeave(object sender, EventArgs e)
        {
            ptbClose.Image = global::Apresentacao.Properties.Resources.icons8_Close_Window_28px_11;
        }

        private void ptbClose_MouseMove(object sender, MouseEventArgs e)
        {
            ptbClose.Image = global::Apresentacao.Properties.Resources.icons8_Close_Window_28px;
        }

        private void btnSlavar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            string ativo = cbxAtivo.Text;
            if (ativo.Equals("SIM"))
            {
                usuario.Ativo = "S";
            }
            else
            {
                usuario.Ativo = "N";
            }


            usuario.Nome = txtNome.Text;
            usuario.Cpf= txtCpf.Text.Replace(".", "");
            usuario.Cpf= usuario.Cpf.Replace("-", "");
            usuario.Rg = txtRg.Text;
            int IdGrupoUsuario = int.Parse(txtIdGrupoUsuario.Text);


            if (txtConfirmaSenha.Text.Equals(txtSenha.Text))
            {
                usuario.Senha = txtSenha.Text;
            }
            else
            {

                MessageBox.Show("As senha não conferem.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtConfirmaSenha.Focus();

                return;
            }


            DateTime dtNasc;

            //Tenta converter a data de nascimento para DateTime.
            //Se conseguir, atribui para o objeto "cliente".
            if (DateTime.TryParse(mskDNas.Text, out dtNasc))
            {
                usuario.DataNascimento = dtNasc;
            }
            else
            {

                MessageBox.Show("Digite uma data de nascimento válida.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                mskDNas.Focus();

                return;
            }

            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();


            //Inserir
            if (acaoNaTelaSelecionada == 1)
            {
                //O método "Inserir" retorna o ID do cliente inserido.
                int IdUsuario = usuarioNegocios.Inserir(usuario, IdGrupoUsuario);

                //Se o ID for maior que zero significa que a inclusão deu certo.
                if (IdUsuario > 0)
                {
                    //Exibe no campo da tela o ID do cliente inserido.
                    txtId.Text = IdUsuario.ToString();

                    MessageBox.Show("Usuário inserido com sucesso.", "Informação",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Quando essa linha for executada a tela será fechada
                    //(da mesma forma que o comando Close() faz), porém,
                    //ela retornará que o botão "Salvar" foi clicado.
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Não foi possível inserir o usuário. " +
                        "Verifique a conexão com o banco de dados.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else //Alterar
            {
                //Para alterar o cliente é necessário que o objeto tenha
                //o ID do cliente.
                usuario.IdUsuario = int.Parse(txtId.Text);

                //O comando Alterar retorna quantas linhas foram alteradas.
                int linhasAlteradas = usuarioNegocios.Alterar(usuario, IdGrupoUsuario);

                if (linhasAlteradas > 0)
                {
                    MessageBox.Show("Usuário alterado com sucesso.", "Informação",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("O usuário não foi encontrado.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente cancelar as alterações?",
                "Confirmação", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //Quando essa linha for executada a tela será fechada
                //(da mesma forma que o comando Close() faz), porém,
                //ela retornará que o botão "Cancelar" foi clicado.
                //Com isso, na tela de seleção de clientes, nós saberemos
                //qual foi o botão que o usuário clicou (Salvar ou Cancelar).
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void FrmUsuarioCadastro_Load(object sender, EventArgs e)
        {

        }

        private void cbxGrupoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdGrupoUsuario.Text = cbxGrupoUsuario.SelectedValue.ToString();
        }
    }
}
