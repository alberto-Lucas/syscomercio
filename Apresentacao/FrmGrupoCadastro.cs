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
    public partial class FrmGrupoCadastro : Form
    {
        int acaoNaTelaSelecionada;
        GrupoUsuario grupoUsuarioa;
        public FrmGrupoCadastro(int acaoNaTela, GrupoUsuario grupoUsuario)
        {
            InitializeComponent();
            //1 - INSERIR
            //2 - ALTERAR
            //3 - VISUALIZAR
            grupoUsuarioa = grupoUsuario;
            acaoNaTelaSelecionada = acaoNaTela;
            switch (acaoNaTelaSelecionada)
            {
                case 1:
                    {
                        lblTituloTela.Text = "Inserir Grupo";
                    }
                    break;
                case 2:
                    {
                        lblTituloTela.Text = "Alterar Grupo";

                        string ativo = grupoUsuario.Ativo;
                        if (ativo.Equals("S"))
                        {
                            cbxAtivo.Text = "SIM";
                        }
                        else
                        {
                            cbxAtivo.Text = "NÃO";
                        }


                        txtId.Text = grupoUsuario.IdGrupoUsuario.ToString();
                        txtDescricao.Text = grupoUsuario.Descricao.ToString();

                        GrupoUsuarioNegocios GrupoUsuarioNegocios = new GrupoUsuarioNegocios();
                        foreach (Control c in pnlDadosCliente.Controls)
                        {
                            if ((c is CheckBox))
                            {
                                if (GrupoUsuarioNegocios.ConsultarPermisao(c.Name, grupoUsuario.IdGrupoUsuario) == "S")
                                    ((CheckBox)c).Checked = true;
                                else
                                    ((CheckBox)c).Checked = false;
                            }
                        }

                        mskDCadastro.Text = grupoUsuario.DataCadastro.ToString();
                        mskDAlteracao.Text = grupoUsuario.DataAlteracao.ToString();
                        txtIdUserCadastro.Text = grupoUsuario.UsuarioCadastro.IdUsuario.ToString();
                        txtIdUserAlteracao.Text = grupoUsuario.UsuarioAlteracao.IdUsuario.ToString();
                        txtNomeUserCadastro.Text = grupoUsuario.UsuarioCadastro.Nome;
                        txtNomeUserAlteracao.Text = grupoUsuario.UsuarioAlteracao.Nome;
                    }
                    break;
                case 3:
                    {
                        visualizar();

                        lblTituloTela.Text = "Visualizar Grupo";
                        string ativo = grupoUsuario.Ativo;
                        if (ativo.Equals("S"))
                        {
                            cbxAtivo.Text = "SIM";
                        }
                        else
                        {
                            cbxAtivo.Text = "NÃO";
                        }


                        txtId.Text = grupoUsuario.IdGrupoUsuario.ToString();
                        txtDescricao.Text = grupoUsuario.Descricao.ToString();

                        GrupoUsuarioNegocios GrupoUsuarioNegocios = new GrupoUsuarioNegocios();
                        foreach (Control c in pnlDadosCliente.Controls)
                        {
                            if ((c is CheckBox))
                            {
                                c.Enabled = false;
                                if (GrupoUsuarioNegocios.ConsultarPermisao(c.Name, grupoUsuario.IdGrupoUsuario) == "S")
                                    ((CheckBox)c).Checked = true;
                                else
                                    ((CheckBox)c).Checked = false;
                            }
                        }

                        mskDCadastro.Text = grupoUsuario.DataCadastro.ToString();
                        mskDAlteracao.Text = grupoUsuario.DataAlteracao.ToString();
                        txtIdUserCadastro.Text = grupoUsuario.UsuarioCadastro.IdUsuario.ToString();
                        txtIdUserAlteracao.Text = grupoUsuario.UsuarioAlteracao.IdUsuario.ToString();
                        txtNomeUserCadastro.Text = grupoUsuario.UsuarioCadastro.Nome;
                        txtNomeUserAlteracao.Text = grupoUsuario.UsuarioAlteracao.Nome;
                    }
                    break;
            }
        }
        public void visualizar()
        {
            txtId.ReadOnly = true;
            txtDescricao.ReadOnly = true;
            btnSalvar.Visible = false;
            btnCancelar.Visible = false;
            cbxAtivo.Enabled = false;
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pnlDadosCliente_Paint(object sender, PaintEventArgs e)
        {

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

        private void btnCancelar_MouseClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente cancelar as alterações?",
                        "Confirmação", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnSalvar_MouseClick(object sender, MouseEventArgs e)
        {
            GrupoUsuario grupoUsuario = new GrupoUsuario();

            string ativo = cbxAtivo.Text;
            if (ativo.Equals("SIM"))
                grupoUsuario.Ativo = "S";
            else
                grupoUsuario.Ativo = "N";

            grupoUsuario.Descricao = txtDescricao.Text;
            GrupoUsuarioNegocios grupoUsuarioNegocios = new GrupoUsuarioNegocios();

            if (acaoNaTelaSelecionada == 1)
            {
                int IdGrupo = grupoUsuarioNegocios.Inserir(grupoUsuario);

                if (IdGrupo > 0)
                {
                    txtId.Text = IdGrupo.ToString();

                    MessageBox.Show("Grupo inserido com sucesso.", "Informação",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Não foi possível inserir o grupo. " +
                        "Verifique a conexão com o banco de dados.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                grupoUsuario.IdGrupoUsuario = int.Parse(txtId.Text);
                int linhasAlteradas = grupoUsuarioNegocios.Alterar(grupoUsuario);
                if (linhasAlteradas > 0)
                {
                    MessageBox.Show("Grupo alterado com sucesso.", "Informação",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("O grupo não foi encontrado.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            int id = int.Parse(txtId.Text);

            foreach (Control c in pnlDadosCliente.Controls)
            {
                if ((c is CheckBox) && ((CheckBox)c).Checked)
                    grupoUsuarioNegocios.AlterarPermissao(c.Name, "S", id);
                if ((c is CheckBox) && !((CheckBox)c).Checked)
                    grupoUsuarioNegocios.AlterarPermissao(c.Name, "N", id);
            }
            this.DialogResult = DialogResult.OK;

            /*int rowsAlteradas = grupoUsuarioNegocios.Alterar(grupoUsuario);
            if (rowsAlteradas > 0)
            {
                //MessageBox.Show("Grupo alterado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                //MessageBox.Show("O grupo não foi encontrado.", "Atenção",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FrmGrupoCadastro_Load(object sender, EventArgs e)
        {

        }
    }
}
