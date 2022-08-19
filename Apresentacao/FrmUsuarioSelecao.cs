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
    public partial class FrmUsuarioSelecao : Form
    {
        public Usuario usuarioSelecao;
        public FrmUsuarioSelecao()
        {
            InitializeComponent();
            dgvRegistros.AutoGenerateColumns = false;
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

        private void FrmUsuarioSelecao_Load(object sender, EventArgs e)
        {
            PesquisarTodos();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
        private void Pesquisar()
        {
            int Id = 0;
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            UsuarioColecao usuarioColecao = new UsuarioColecao();
            dgvRegistros.DataSource = null;

            if (int.TryParse(txtUsuario.Text, out Id))
            {
                Usuario usuario = usuarioNegocios.ConsultarPorId(Id);
                if (usuario != null)
                {
                    usuarioColecao.Add(usuario);
                }
            }
            else
            {
                usuarioColecao = usuarioNegocios.ConsultarPorNome(txtUsuario.Text.Trim());
            }

            dgvRegistros.DataSource = usuarioColecao;
            dgvRegistros.Update();
            dgvRegistros.Refresh();
            lblRegistro.Text = dgvRegistros.RowCount.ToString();
        }
        private void PesquisarTodos()
        {
            UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
            UsuarioColecao usuarioColecao = new UsuarioColecao();
            dgvRegistros.DataSource = null;

            usuarioColecao = usuarioNegocios.ConsultarTodos();

            dgvRegistros.DataSource = usuarioColecao;
            dgvRegistros.Update();
            dgvRegistros.Refresh();

            lblRegistro.Text = dgvRegistros.RowCount.ToString();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum usuário selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Usuario usuarioSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as Usuario);

                FrmUsuarioCadastro frm = new FrmUsuarioCadastro(3, usuarioSelecionado);
                DialogResult dialogResult = frm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    Pesquisar();

                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum usuário selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Deseja realmente excluir este usuário?", "Confirmação...",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Usuario usuarioSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as Usuario);
                    UsuarioNegocios usuarioNegocios = new UsuarioNegocios();

                    if (usuarioNegocios.Apagar(usuarioSelecionado) > 0)
                    {
                        MessageBox.Show("Usuário excluído com sucesso.", "Informação...",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PesquisarTodos();
                    }
                    else
                    {
                        MessageBox.Show("O usuário selecionado não foi encontrado no banco de dados.", "Atenção...",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum usuário selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Usuario usuarioSelecionado = (dgvRegistros.SelectedRows[0].DataBoundItem as Usuario);

                FrmUsuarioCadastro frm = new FrmUsuarioCadastro(2, usuarioSelecionado);
                DialogResult dialogResult = frm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    PesquisarTodos();
                }
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            FrmUsuarioCadastro frm = new FrmUsuarioCadastro(1, null);
            DialogResult dialogResult = frm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                PesquisarTodos();
            }
        }
    }
}
