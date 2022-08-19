using Negocios;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmFornecedorSelecao : Form
    {
        public Fornecedor fornecedorSelecao;
        public FrmFornecedorSelecao()
        {
            InitializeComponent();
            dgvRegistros.AutoGenerateColumns = false;
        }

        private void FrmFornecedorSelecao_Load(object sender, EventArgs e)
        {
            PesquisarTodos();
        }
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


        private void Pesquisar()
        {
            int Id = 0;
            FornecedorNegocios fornecedorNegocios = new FornecedorNegocios();
            FornecedorColecao fornecedorColecao = new FornecedorColecao();
            dgvRegistros.DataSource = null;

            if (int.TryParse(txtId.Text, out Id))
            {
                Fornecedor fornecedor = fornecedorNegocios.ConsultarPorId(Id);
                if (fornecedor != null)
                {
                    fornecedorColecao.Add(fornecedor);
                }
            }
            else
            {
                fornecedorColecao = fornecedorNegocios.ConsultarPorNome(txtId.Text.Trim());
            }

            dgvRegistros.DataSource = fornecedorColecao;
            dgvRegistros.Update();
            dgvRegistros.Refresh();
            lblRegistro.Text = dgvRegistros.RowCount.ToString();
            //Limpar();
        }
        private void PesquisarTodos()
        {
            FornecedorNegocios fornecedorNegocios = new FornecedorNegocios();
            FornecedorColecao fornecedorColecao = new FornecedorColecao();
            dgvRegistros.DataSource = null;

            fornecedorColecao = fornecedorNegocios.ConsultarPorNome("");

            dgvRegistros.DataSource = fornecedorColecao;
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

        private void btnInserir_Click(object sender, EventArgs e)
        {
            FrmFornecedorCadastro frm = new FrmFornecedorCadastro(1, null);
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
                MessageBox.Show("Nenhum forencedor selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Fornecedor fornecedorSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as Fornecedor);

                FrmFornecedorCadastro frm = new FrmFornecedorCadastro(2, fornecedorSelecionado);
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
                MessageBox.Show("Nenhum fornecedor selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Deseja realmente excluir este fornecedor?", "Confirmação...",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Fornecedor fornecedorSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as Fornecedor);
                    FornecedorNegocios fornecedorNegocios = new FornecedorNegocios();

                    if (fornecedorNegocios.Apagar(fornecedorSelecionado) > 0)
                    {
                        MessageBox.Show("Fornecedor excluído com sucesso.", "Informação...",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PesquisarTodos();
                    }
                    else
                    {
                        MessageBox.Show("O fornecedor selecionado não foi encontrado no banco de dados.", "Atenção...",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum fornecedor selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Fornecedor fornecedorSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as Fornecedor);

                FrmFornecedorCadastro frm = new FrmFornecedorCadastro(3, fornecedorSelecionado);
                DialogResult dialogResult = frm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    Pesquisar();
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
    }
}
