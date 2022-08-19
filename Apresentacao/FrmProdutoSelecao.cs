using Negocios;
using ObjetoTransferencia;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmProdutoSelecao : Form
    {
        public Produto produtoSelecao;
        public FrmProdutoSelecao(string descri, bool ExibirBotaoSelecionar = false)
        {
            InitializeComponent();
            dgvRegistros.AutoGenerateColumns = false;
            btnSelecionar.Visible = ExibirBotaoSelecionar;
            txtProduto.Text = descri;
        }



        private void FrmProdutoSelecao_Load(object sender, EventArgs e)
        {
            Pesquisar();
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

        private void ptbClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void Pesquisar()
        {
            int Id = 0;
            ProdutoNegocios produtoNegocios = new ProdutoNegocios();
            ProdutoColecao produtoColecao = new ProdutoColecao();
            dgvRegistros.DataSource = null;

            if (int.TryParse(txtProduto.Text, out Id))
            {
                Produto produto = produtoNegocios.ConsultarPorId(Id);
                if (produto != null)
                {
                    produtoColecao.Add(produto);
                }
            }
            else
            {
                produtoColecao = produtoNegocios.ConsultarPorDescricao(txtProduto.Text.Trim());
            }

            dgvRegistros.DataSource = produtoColecao;
            dgvRegistros.Update();
            dgvRegistros.Refresh();
            lblRegistro.Text = dgvRegistros.RowCount.ToString();
            //Limpar();
        }
        private void PesquisarTodos()
        {
            ProdutoNegocios produtoNegocios = new ProdutoNegocios();
            ProdutoColecao produtoColecao = new ProdutoColecao();
            dgvRegistros.DataSource = null;

            produtoColecao = produtoNegocios.ConsultarTodos();

            dgvRegistros.DataSource =produtoColecao;
            dgvRegistros.Update();
            dgvRegistros.Refresh();

            lblRegistro.Text = dgvRegistros.RowCount.ToString();
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void dgvRegistros_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvRegistros.Rows[e.RowIndex].DataBoundItem != null) && (dgvRegistros.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvRegistros.Rows[e.RowIndex].DataBoundItem, dgvRegistros.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum produto selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Produto produtoSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as Produto);

                FrmProdutoCadastro frm = new FrmProdutoCadastro(3, produtoSelecionado);
                DialogResult dialogResult = frm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    Pesquisar();
                }
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            FrmProdutoCadastro frm = new FrmProdutoCadastro(1, null);
            DialogResult dialogResult = frm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                PesquisarTodos();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum produto selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Produto produtoSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as Produto);

                FrmProdutoCadastro frm = new FrmProdutoCadastro(2, produtoSelecionado);
                DialogResult dialogResult = frm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    PesquisarTodos();
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum produto selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Deseja realmente excluir este produto?", "Confirmação...",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Produto produtoSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as Produto);
                    ProdutoNegocios produtoNegocios = new ProdutoNegocios();

                    if (produtoNegocios.Apagar(produtoSelecionado) > 0)
                    {
                        MessageBox.Show("Produto excluído com sucesso.", "Informação...",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PesquisarTodos();
                    }
                    else
                    {
                        MessageBox.Show("O Produto selecionado não foi encontrado no banco de dados.", "Atenção...",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum Produto selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                produtoSelecao = (dgvRegistros.SelectedRows[0].DataBoundItem as Produto);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dgvRegistros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) // Checa se o index da linha clicada não é -1 (header por exemplo é -1)
            {
                Produto produtoSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as Produto);
                FrmProdutoCadastro frm = new FrmProdutoCadastro(3, produtoSelecionado);
                DialogResult dialogResult = frm.ShowDialog();
            }
        }
    }
}
