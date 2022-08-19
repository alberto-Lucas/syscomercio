using Negocios;
using ObjetoTransferencia;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmClienteSelecao : Form
    {
        public Cliente clienteSelecao;

        public FrmClienteSelecao(string nome, bool ExibirBotaoSelecionar = false)
        {
            InitializeComponent();
            dgvRegistros.AutoGenerateColumns = false;
            btnSelecionar.Visible = ExibirBotaoSelecionar;
            txtCliente.Text = nome;
        }

        #region Perfumaria

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

        private void ptbClose_MouseLeave(object sender, EventArgs e)
        {
            ptbClose.Image = global::Apresentacao.Properties.Resources.icons8_Close_Window_28px_11;
        }

        private void ptbClose_MouseMove(object sender, MouseEventArgs e)
        {
            ptbClose.Image = global::Apresentacao.Properties.Resources.icons8_Close_Window_28px;
        }
        private void dgvRegistros_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvRegistros.Rows[e.RowIndex].DataBoundItem != null) && (dgvRegistros.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvRegistros.Rows[e.RowIndex].DataBoundItem, dgvRegistros.Columns[e.ColumnIndex].DataPropertyName);
            }
        }
        private string BindProperty(object property, string propertyName)
        {
            string retValue = "";
            if (propertyName.Contains("."))
            {
                PropertyInfo[] arrayProperties;
                string leftPropertyName;
                leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));
                arrayProperties = property.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                          propertyInfo.GetValue(property, null),
                          propertyName.Substring(propertyName.IndexOf(".") + 1));
                        break;
                    }
                }
            }
            else
            {
                Type propertyType;
                PropertyInfo propertyInfo;
                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }
            return retValue;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ptbClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Consulta
        private void FrmClienteSelecao_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
        private void Pesquisar()
        {
            int Id = 0;
            ClienteNegocios clienteNegocios = new ClienteNegocios();
            ClienteColecao clienteColecao = new ClienteColecao();
            dgvRegistros.DataSource = null;

            if (int.TryParse(txtCliente.Text, out Id))
            {
                Cliente cliente = clienteNegocios.ConsultarPorId(Id);
                if (cliente != null)
                {
                    clienteColecao.Add(cliente);
                }
            }
            else
            {
                clienteColecao = clienteNegocios.ConsultarPorNome(txtCliente.Text.Trim());
            }

            dgvRegistros.DataSource = clienteColecao;
            dgvRegistros.Update();
            dgvRegistros.Refresh();
            lblRegistro.Text = dgvRegistros.RowCount.ToString();
            //Limpar();
        }

        private void PesquisarTodos()
        {
            ClienteNegocios clienteNegocios = new ClienteNegocios();
            ClienteColecao clienteColecao = new ClienteColecao();
            dgvRegistros.DataSource = null;

            clienteColecao = clienteNegocios.ConsultarTodos();

            dgvRegistros.DataSource = clienteColecao;
            dgvRegistros.Update();
            dgvRegistros.Refresh();

            lblRegistro.Text = dgvRegistros.RowCount.ToString();
        }
        #endregion

        private void dgvRegistros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) // Checa se o index da linha clicada não é -1 (header por exemplo é -1)
            {
                Cliente clienteSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as Cliente);
                FrmClienteCadastro frm = new FrmClienteCadastro(3, clienteSelecionado);
                DialogResult dialogResult = frm.ShowDialog();
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum Cliente selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Cliente clienteSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as Cliente);

                FrmClienteCadastro frm = new FrmClienteCadastro(3, clienteSelecionado);
                DialogResult dialogResult = frm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    Pesquisar();
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum Cliente selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Cliente clienteSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as Cliente);

                FrmClienteCadastro frm = new FrmClienteCadastro(2, clienteSelecionado);
                DialogResult dialogResult = frm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    PesquisarTodos();
                }
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            FrmClienteCadastro frm = new FrmClienteCadastro(1, null);
            DialogResult dialogResult = frm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                PesquisarTodos();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Deseja realmente excluir este cliente?", "Confirmação...",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Cliente clienteSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as Cliente);
                    ClienteNegocios clienteNegocios = new ClienteNegocios();

                    if (clienteNegocios.Apagar(clienteSelecionado) > 0)
                    {
                        MessageBox.Show("Cliente excluído com sucesso.", "Informação...",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PesquisarTodos();
                    }
                    else
                    {
                        MessageBox.Show("O Cliente selecionado não foi encontrado no banco de dados.", "Atenção...",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                clienteSelecao = (dgvRegistros.SelectedRows[0].DataBoundItem as Cliente);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
