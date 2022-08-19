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
    public partial class FrmGrupoUsuario : Form
    {
        public GrupoUsuario grupoUsuarioSelecao;
        public FrmGrupoUsuario(string nome, bool ExibirBotaoSelecionar = false)
        {
            InitializeComponent();
            dgvRegistros.AutoGenerateColumns = false;
            btnSelecionar.Visible = ExibirBotaoSelecionar;
            txtDescricao.Text = nome;
        }

        private void ptbClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btnPesquisar_MouseClick(object sender, MouseEventArgs e)
        {
            Pesquisar();
        }

        private void btnVisualizar_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum grupo selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                GrupoUsuario grupoSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as GrupoUsuario);

                FrmGrupoCadastro frm = new FrmGrupoCadastro(3, grupoSelecionado);
                DialogResult dialogResult = frm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    Pesquisar();
                }
            }
        }

        private void btnExcluir_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum grupo selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Deseja realmente excluir este grupo?", "Confirmação...",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    GrupoUsuario grupoUsuarioSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as GrupoUsuario);
                    GrupoUsuarioNegocios grupoUsuarioNegocios = new GrupoUsuarioNegocios();

                    if (grupoUsuarioNegocios.Apagar(grupoUsuarioSelecionado) > 0)
                    {
                        MessageBox.Show("Grupo excluído com sucesso.", "Informação...",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PesquisarTodos();
                    }
                    else
                    {
                        MessageBox.Show("O Grupo selecionado não foi encontrado no banco de dados.", "Atenção...",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnAlterar_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum grupo selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                GrupoUsuario grupoUsuarioSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as GrupoUsuario);

                FrmGrupoCadastro frm = new FrmGrupoCadastro(2, grupoUsuarioSelecionado);
                DialogResult dialogResult = frm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    PesquisarTodos();
                }
            }
        }

        private void btnInserir_MouseClick(object sender, MouseEventArgs e)
        {
            FrmGrupoCadastro frm = new FrmGrupoCadastro(1, null);
            DialogResult dialogResult = frm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                PesquisarTodos();
            }
        }

        private void btnSelecionar_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum grupo selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                grupoUsuarioSelecao = (dgvRegistros.SelectedRows[0].DataBoundItem as GrupoUsuario);
                this.DialogResult = DialogResult.OK;
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void dgvRegistros_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvRegistros.Rows[e.RowIndex].DataBoundItem != null) && (dgvRegistros.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvRegistros.Rows[e.RowIndex].DataBoundItem, dgvRegistros.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

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

        private void FrmGrupoUsuario_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }
        private void Pesquisar()
        {
            int Id = 0;
            GrupoUsuarioNegocios grupoUsuarioNegociosNegocios = new GrupoUsuarioNegocios();
            GrupoUsuarioColecao grupoUsuarioColecao = new GrupoUsuarioColecao();
            dgvRegistros.DataSource = null;

            if (int.TryParse(txtDescricao.Text, out Id))
            {
                GrupoUsuario grupoUsuario = grupoUsuarioNegociosNegocios.ConsultarPorId(Id);
                if (grupoUsuario != null)
                {
                    grupoUsuarioColecao.Add(grupoUsuario);
                }
            }
            else
            {
                grupoUsuarioColecao = grupoUsuarioNegociosNegocios.ConsultarPorNome(txtDescricao.Text.Trim());
            }

            dgvRegistros.DataSource = grupoUsuarioColecao;
            dgvRegistros.Update();
            dgvRegistros.Refresh();
            lblRegistro.Text = dgvRegistros.RowCount.ToString();
            //Limpar();
        }

        private void dgvRegistros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) // Checa se o index da linha clicada não é -1 (header por exemplo é -1)
            {
                GrupoUsuario grupoUsuarioSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as GrupoUsuario);
                FrmGrupoCadastro frm = new FrmGrupoCadastro(3, grupoUsuarioSelecionado);
                DialogResult dialogResult = frm.ShowDialog();
            }
        }
        private void PesquisarTodos()
        {
            GrupoUsuarioNegocios grupoUsuarioNegociosNegocios = new GrupoUsuarioNegocios();
            GrupoUsuarioColecao grupoUsuarioColecao = new GrupoUsuarioColecao();
            dgvRegistros.DataSource = null;

            grupoUsuarioColecao = grupoUsuarioNegociosNegocios.ConsultarTodos();

            dgvRegistros.DataSource = grupoUsuarioColecao;
            dgvRegistros.Update();
            dgvRegistros.Refresh();

            lblRegistro.Text = dgvRegistros.RowCount.ToString();
        }
    }
}
