using System;
using System.Windows.Forms;

namespace ConfigurarAcessoSistema
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCacnel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtsenha.Text != string.Empty)
            {
                if (txtsenha.Text.Equals("135790" + dateTimePicker1.Text))
                {
                    ConfigurarAcessoSistema cas = new ConfigurarAcessoSistema();
                   cas.Show();

                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Senha do Adminsitrador Inválida!", "Senha Inválida...");
                    txtsenha.Focus();
                    txtsenha.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Digita a senha do Adminsitrador!", "Digite a senha...");
                txtsenha.Focus();
                txtsenha.SelectAll();
            }
        }

        private void txtsenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnCacnel.PerformClick();
            }
        }

        private void txtsenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 13)
            {
                e.Handled = true;
                //MessageBox.Show("Este campo aceita apenas números!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtsenha_Click(object sender, EventArgs e)
        {
            txtsenha.SelectAll();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
