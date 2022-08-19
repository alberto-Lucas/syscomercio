using Negocios;
using ObjetoTransferencia;
using System;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {

            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnSair.PerformClick();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnSair.PerformClick();
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != string.Empty && txtPass.Text != string.Empty)
            {
                int Id = 0;
                Usuario user = new Usuario();
                UsuarioNegocios userLogadoNegocios = new UsuarioNegocios();

                Id = int.Parse(txtUser.Text);
                user = userLogadoNegocios.ConsultarPorIdLogin(Id);

                try
                {
                    if (Id == user.IdUsuario)
                    {
                       

                        if (txtPass.Text.Equals(user.Senha) == true)
                        {
                            var usuarioLogado = UsuarioLogado.Instancia;
                            usuarioLogado.IdUsuario = user.IdUsuario;
                            usuarioLogado.Nome = user.Nome;

                            FrmPrincipal frmprin = new FrmPrincipal();
                            frmprin.Show();
                            this.Visible = false;
                        }
                        else
                        {
                            lblAtencao.Text = "Senha Inválida";
                            ptbAtencao.Visible = true;
                            lblAtencao.Visible = true;
                            txtPass.Text = "";
                            txtPass.Focus();
                        }
                    }
                }
                catch
                {
                    //MessageBox.Show(ex.ToString());
                    lblAtencao.Text = "Usuário não consta no banco de dados!";
                    ptbAtencao.Visible = true;
                    lblAtencao.Visible = true;
                    txtUser.Text = "";
                    txtPass.Text = "";
                    txtUser.Focus();
                }
            }
            else
            {
                //MessageBox.Show("Preencha os campos");
                lblAtencao.Text = "Preencha os campos!";
                ptbAtencao.Visible = true;
                lblAtencao.Visible = true;
                txtUser.Text = "";
                txtPass.Text = "";
                txtUser.Focus();
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 13)
            {
                e.Handled = true;
                //MessageBox.Show("Este campo aceita apenas números!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEntrar_Enter(object sender, EventArgs e)
        {
            btnEntrar.FlatAppearance.BorderSize = 1;
        }

        private void btnEntrar_Validated(object sender, EventArgs e)
        {
            btnEntrar.FlatAppearance.BorderSize = 0;
        }

        private void btnSair_Enter(object sender, EventArgs e)
        {
            btnSair.FlatAppearance.BorderSize = 1;
        }

        private void btnSair_Validated(object sender, EventArgs e)
        {
            btnSair.FlatAppearance.BorderSize = 0;
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
            txtUser.SelectAll();
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.SelectAll();
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            btnSair.FlatAppearance.BorderSize = 0;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            btnSair.FlatAppearance.BorderSize = 1;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
