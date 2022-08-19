using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ConfigurarAcessoSistema
{
    public partial class ConfigurarAcessoSistema : Form
    {
        public ConfigurarAcessoSistema()
        {
            InitializeComponent();
        }

        private void ConfigurarAcessoSistema_Load(object sender, EventArgs e)
        {

        }

        public void testConexao()
        {
            try
            {
                SqlConnection conn = new SqlConnection();

                conn.ConnectionString =
                    "Data Source=" + txtIP.Text + ";" +
                    "Initial Catalog=" + txtBanco.Text + ";" +
                    "User=" + txtUsuario.Text + ";" +
                    "Password=" + txtSenha.Text;

                //O comando Open() é responsável por abrir a conexão.
                //Se ele não for executado, um erro será lançado na
                //primeira vez em que a conexão for utilizada.
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("Conexão estabelecida com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o servidor." +
                "\nHostName: " + txtIP.Text +
                "\nDataBase: " + txtBanco.Text +
                "\nErro: " + ex);
            }
        }

        private void btnTesta_Click(object sender, EventArgs e)
        {
            testConexao();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja abandonar o processo de configuração ?",
               "Confirmação",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2
               ) == DialogResult.No)
            {
                
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection();

                conn.ConnectionString =
                    "Data Source=" + txtIP.Text + ";" +
                    "Initial Catalog=" + txtBanco.Text + ";" +
                    "User=" + txtUsuario.Text + ";" +
                    "Password=" + txtSenha.Text;

                //O comando Open() é responsável por abrir a conexão.
                //Se ele não for executado, um erro será lançado na
                //primeira vez em que a conexão for utilizada.
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    gravaConfiguracao();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o servidor." +
                "\nHostName: " + txtIP.Text +
                "\nDataBase: " + txtBanco.Text +
                "\nErro: " + ex);
                txtIP.Focus();
                txtIP.SelectAll();
            }
        }

        public void gravaConfiguracao()
        {
            string ip = ToHexString(txtIP.Text);
            string banco = ToHexString(txtBanco.Text);
            string usuario = ToHexString(txtUsuario.Text);
            string senha = ToHexString(txtSenha.Text);

            txtDados.Text = txtDados.Text.Replace("Servidor=", "Servidor=" + ip);
            txtDados.Text = txtDados.Text.Replace("Banco=", "Banco=" + banco);
            txtDados.Text = txtDados.Text.Replace("Usuario=", "Usuario=" + usuario);
            txtDados.Text = txtDados.Text.Replace("Senha=", "Senha=" + senha);



            gravaArquivo();

            
        }

        string caminho = Application.StartupPath + "\\";

        public void criaArquivo()
        {
            if (!System.IO.File.Exists(caminho + "connection.conf"))
            {
                System.IO.File.Create(caminho + "connection.conf").Close();
                gravaArquivo();
            }
        }

        public void gravaArquivo()
        {
            if (!System.IO.File.Exists(caminho + "connection.conf"))
            {
                criaArquivo();
            }
            else
            {
                StreamWriter config = new StreamWriter(caminho + "connection.conf");
                config.Write(txtDados.Text);
                config.Close();

                MessageBox.Show("Configuração realizada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDados.Text = "[connection]" + "\r\n" +
                                "Servidor=" + "\r\n" +
                                "Banco=" + "\r\n" +
                                "Usuario=" + "\r\n" +
                                "Senha=";
            }
        }
        private void btnCriar_Click(object sender, EventArgs e)
        {
            
        }

        private string ToHexString(string hexstring)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char t in hexstring)
            {
                sb.Append(Convert.ToInt32(t).ToString("X"));
            }
            return sb.ToString();
        }

        private void txtIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBanco.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar.PerformClick();
            }
        }

        private void txtBanco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUsuario.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar.PerformClick();
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenha.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar.PerformClick();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTesta.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar.PerformClick();
            }
        }

        private void txtIP_Click(object sender, EventArgs e)
        {
            txtIP.SelectAll();
        }

        private void txtBanco_Click(object sender, EventArgs e)
        {
            txtBanco.SelectAll();
        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {
            txtUsuario.SelectAll();
        }

        private void txtSenha_Click(object sender, EventArgs e)
        {
            txtSenha.SelectAll();
        }

        private void ConfigurarAcessoSistema_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
