using ObjetoTransferencia;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {
            InitializeComponent();
        }

        public void testConexao()
        {
            var bancoDados = BancoDados.Instancia;
            string servidor = bancoDados.Servidor;
            string banco = bancoDados.Banco;
            string usuario = bancoDados.Usuario;
            string senha = bancoDados.Senha;
            try
            {
                

                SqlConnection conn = new SqlConnection();

                conn.ConnectionString =
                    "Data Source=" + servidor + ";" +
                    "Initial Catalog=" + banco + ";" +
                    "User=" + usuario + ";" +
                    "Password=" + senha;

                //O comando Open() é responsável por abrir a conexão.
                //Se ele não for executado, um erro será lançado na
                //primeira vez em que a conexão for utilizada.
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                   // MessageBox.Show("Conexão estabelecida com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o servidor." +
                "\nPor favor, realize a configuração.",
                "Informação!", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Exclamation);

                Application.Exit();
            }
        }

        #region Converter Hex
        string HextoString(string hexString)
        {
            if (hexString == null || (hexString.Length & 1) == 1)
            {
                throw new ArgumentException();
            }
            var sb = new StringBuilder();
            for (var i = 0; i < hexString.Length; i += 2)
            {
                var hexChar = hexString.Substring(i, 2);
                sb.Append((char)Convert.ToByte(hexChar, 16));
            }
            return sb.ToString();
        }
        #endregion

        #region Pegar Conexão
        public void PegarConexao()
        {
            try
            {
                IniFile objIniFile = new IniFile();
                string strFilePath = objIniFile.filePath("connection.conf");
                string servidor = objIniFile.IniReadString("connection", "Servidor", strFilePath).ToString();
                string banco = objIniFile.IniReadString("connection", "Banco", strFilePath).ToString();
                string usuario = objIniFile.IniReadString("connection", "Usuario", strFilePath).ToString();
                string senha = objIniFile.IniReadString("connection", "Senha", strFilePath).ToString();
                var bancoDados = BancoDados.Instancia;
                bancoDados.Servidor = HextoString(servidor);
                bancoDados.Banco = HextoString(banco);
                bancoDados.Usuario = HextoString(usuario);
                bancoDados.Senha = HextoString(senha);

                testConexao();
            }
            catch
            {
                MessageBox.Show("Não foi possível, localizar o arquivo de configuração do banco de dados\nPor favor, realize a configuração.", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
        }
        #endregion


        int porcentagem = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (porcentagem < 100)
            {
                pgrLoading.Width += 4;
                porcentagem++;
                //lblPor.Text = porcentagem.ToString() + "%";
            }
            else
            {
                timerLoading.Stop();
                porcentagem = 0;

                FrmLogin objFrm = new FrmLogin();
                this.Hide();
                objFrm.Show();
            }
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            string caminho = Application.StartupPath + "\\";
            if (System.IO.File.Exists(caminho + "connection.conf"))
            {
                PegarConexao();
            }
            else
            {
                MessageBox.Show("Não foi possível, localizar o arquivo de configuração do banco de dados\nPor favor, realize a configuração.", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
            timerLoading.Start();
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            ptbClose.Image = global::Apresentacao.Properties.Resources.icons8_Delete_25px;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            ptbClose.Image = global::Apresentacao.Properties.Resources.icons8_Delete_25px_1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
