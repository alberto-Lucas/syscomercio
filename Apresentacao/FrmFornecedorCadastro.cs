using Negocios;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmFornecedorCadastro : Form
    {
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

        int acaoNaTelaSelecionada;
        public FrmFornecedorCadastro(int acaoNaTela, Fornecedor fornecedor)
        {
            InitializeComponent();
            #region Tab
            lblBtnDados.BringToFront();
            this.Size = new System.Drawing.Size(496, 546);
            #endregion
            //1 - INSERIR
            //2 - ALTERAR
            //3 - VISUALIZAR

            acaoNaTelaSelecionada = acaoNaTela;
            switch (acaoNaTelaSelecionada)
            {
                case 1:
                    {
                        lblTituloTela.Text = "Inserir Fornecedor";
                        //pessoa_f();
                        //rdbFisica.Checked = true;
                        //pesquisarCidadePorEstado();
                        //cbxAtivo.Text = "S";
                    }
                    break;
                case 2:
                    {
                        lblTituloTela.Text = "Alterar Fornecedor";

                        string ativo = fornecedor.Ativo;
                        if (ativo.Equals("S"))
                        {
                            cbxAtivo.Text = "SIM";
                        }
                        else
                        {
                            cbxAtivo.Text = "NÃO";
                        }


                        txtId.Text = fornecedor.IdFornecedor.ToString();
                        txtRazaoSocial.Text = fornecedor.RazaoSocial.ToString();
                        txtNomeFantasia.Text = fornecedor.NomeFantasia.ToString();
                        txtCnpj.Text = fornecedor.Cnpj.ToString();
                        txtIe.Text = fornecedor.InscricaoEstadual.ToString();
                        txtObs.Text = fornecedor.Observacao;
                        mskDReg.Text = fornecedor.DataRegistro.ToString();
                        mskDCadastro.Text = fornecedor.DataCadastro.ToString();
                        mskDAlteracao.Text = fornecedor.DataAlteracao.ToString();
                        txtIdUserCadastro.Text = fornecedor.UsuarioCadastro.IdUsuario.ToString();
                        txtIdUserAlteracao.Text = fornecedor.UsuarioAlteracao.IdUsuario.ToString();
                        txtNomeUserCadastro.Text = fornecedor.UsuarioCadastro.Nome;
                        txtNomeUserAlteracao.Text = fornecedor.UsuarioAlteracao.Nome;
                    }
                    break;
                case 3:
                    {
                        visualizar();

                        lblTituloTela.Text = "Visualizar Fornecedor";

                        string ativo = fornecedor.Ativo;
                        if (ativo.Equals("S"))
                        {
                            cbxAtivo.Text = "SIM";
                        }
                        else
                        {
                            cbxAtivo.Text = "NÃO";
                        }


                        txtId.Text = fornecedor.IdFornecedor.ToString();
                        txtRazaoSocial.Text = fornecedor.RazaoSocial.ToString();
                        txtNomeFantasia.Text = fornecedor.NomeFantasia.ToString();
                        txtCnpj.Text = fornecedor.Cnpj.ToString();
                        txtIe.Text = fornecedor.InscricaoEstadual.ToString();
                        txtObs.Text = fornecedor.Observacao;
                        mskDReg.Text = fornecedor.DataRegistro.ToString();
                        mskDCadastro.Text = fornecedor.DataCadastro.ToString();
                        mskDAlteracao.Text = fornecedor.DataAlteracao.ToString();
                        txtIdUserCadastro.Text = fornecedor.UsuarioCadastro.IdUsuario.ToString();
                        txtIdUserAlteracao.Text = fornecedor.UsuarioAlteracao.IdUsuario.ToString();
                        txtNomeUserCadastro.Text = fornecedor.UsuarioCadastro.Nome;
                        txtNomeUserAlteracao.Text = fornecedor.UsuarioAlteracao.Nome;
                    }
                    break;
            }
        }
        public void visualizar()
        {
            txtId.ReadOnly = true;
            txtRazaoSocial.ReadOnly = true;
            txtNomeFantasia.ReadOnly = true;
            txtCnpj.ReadOnly = true;
            txtIe.ReadOnly = true;
            txtObs.ReadOnly = true;
            mskDReg.ReadOnly = true;
            cbxAtivo.Enabled = false;


            btnSalvar.Visible = false;
            btnCancelar.Visible = false;
        }

        private void FrmFornecedorCadastro_Load(object sender, EventArgs e)
        {

        }
        #region Animação Mouse
        //Dados = 1
        //Contato = 2
        //Endereco = 3
        bool dados = true, contato = false, endereco = false;
        void MouseLeaves(int mouseLeave)
        {
            if (mouseLeave == 1)
            {
                lblBtnDados.BackColor = Color.LightGray;
                lblBtnDados.ForeColor = Color.FromArgb(109, 129, 140);
            }

            if (mouseLeave == 2)
            {
                lblBtnContato.BackColor = Color.LightGray;
                lblBtnContato.ForeColor = Color.FromArgb(109, 129, 140);
            }

            if (mouseLeave == 3)
            {
                /*lblBtnEndereco.BackColor = Color.LightGray;
                lblBtnEndereco.ForeColor = Color.FromArgb(255, 177, 0);*/
            }

        }
        void MouseMoves(int mouseMove)
        {
            if (mouseMove == 1)
            {
                lblBtnDados.BackColor = Color.FromArgb(109, 129, 140);
                lblBtnDados.ForeColor = Color.White;
            }

            if (mouseMove == 2)
            {
                lblBtnContato.BackColor = Color.FromArgb(109, 129, 140);
                lblBtnContato.ForeColor = Color.White;
            }

            if (mouseMove == 3)
            {
                /*lblBtnEndereco.BackColor = Color.FromArgb(255, 177, 0);
                lblBtnEndereco.ForeColor = Color.White;*/
            }
        }

        void desabilita()
        {
            if (dados == false)
            {
                lblBtnDados.BackColor = Color.LightGray;
                lblBtnDados.ForeColor = Color.FromArgb(109, 129, 140);
                lblBtnDados.SendToBack();
            }

            if (contato == false)
            {
                lblBtnContato.BackColor = Color.LightGray;
                lblBtnContato.ForeColor = Color.FromArgb(109, 129, 140);
                lblBtnContato.SendToBack();
            }

            if (endereco == false)
            {
                /*lblBtnEndereco.BackColor = Color.LightGray;
                lblBtnEndereco.ForeColor = Color.FromArgb(255, 177, 0);
                lblBtnEndereco.SendToBack();*/
            }
        }

        void habilita()
        {
            if (dados == true)
            {
                lblBtnDados.BackColor = Color.FromArgb(109, 129, 140);
                lblBtnDados.ForeColor = Color.White;
                lblBtnDados.BringToFront();
            }

            if (contato == true)
            {
                lblBtnContato.BackColor = Color.FromArgb(109, 129, 140);
                lblBtnContato.ForeColor = Color.White;
                lblBtnContato.BringToFront();
            }

            if (endereco == true)
            {
                /*lblBtnEndereco.BackColor = Color.FromArgb(255, 177, 0);
                lblBtnEndereco.ForeColor = Color.White;
                lblBtnEndereco.BringToFront();*/
            }
        }

        //------DADOS----------------------------------------------------------------
        private void lblBtnDados_MouseLeave(object sender, EventArgs e)
        {
            if (dados == false)
            {
                MouseLeaves(1);
            }
        }

        private void lblBtnDados_MouseMove(object sender, MouseEventArgs e)
        {
            if (dados == false)
            {
                MouseMoves(1);
            }
        }

        private void lblBtnDados_Click(object sender, EventArgs e)
        {
            dados = true;
            contato = false;
            endereco = false;
            pnlDados.Location = new System.Drawing.Point(12, 95);
            pnlDados.BringToFront();
            pnlManter.BringToFront();
            habilita();
            desabilita();
        }
        //------CONTATO-------------------------------------------------
        void lblBtnContatoMouseLeave(object sender, EventArgs e)
        {

            if (contato == false)
            {
                MouseLeaves(2);
            }

        }
        void lblBtnContatoMouseMove(object sender, MouseEventArgs e)
        {

            if (contato == false)
            {
                MouseMoves(2);
            }

        }
        void lblBtnContatoClick(object sender, EventArgs e)
        {
            dados = false;
            contato = true;
            endereco = false;
            pnlContato.Location = new System.Drawing.Point(12, 95);
            pnlContato.BringToFront();
            habilita();
            desabilita();

            int id = int.Parse(txtId.Text);
            usrTelefone frmContato = new usrTelefone(2, id);
            pnlContato.Controls.Add(frmContato);
        }
        //------ENDERECO-------------------------------------------------
        void lblBtnEnderecoMouseLeave(object sender, EventArgs e)
        {

            if (endereco == false)
            {
                MouseLeaves(3);
            }

        }
        void lblBtnEnderecoMouseMove(object sender, MouseEventArgs e)
        {

            if (endereco == false)
            {
                MouseMoves(3);
            }

        }
        void lblBtnEnderecoClick(object sender, EventArgs e)
        {
            dados = false;
            contato = false;
            endereco = true;

            //pnlEnderecoCliente.BringToFront();
            habilita();
            desabilita();
        }
        //------FIM-------------------------------------------------
        
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
        #endregion

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();

            string ativo = cbxAtivo.Text;
            if (ativo.Equals("SIM"))
            {
                fornecedor.Ativo = "S";
            }
            else
            {
                fornecedor.Ativo = "N";
            }

            fornecedor.RazaoSocial = txtRazaoSocial.Text;
            fornecedor.NomeFantasia = txtNomeFantasia.Text;
            fornecedor.Cnpj = txtCnpj.Text.Replace(".", "");
            fornecedor.Cnpj = fornecedor.Cnpj.Replace("-", "");
            fornecedor.InscricaoEstadual = txtIe.Text;
            fornecedor.Observacao = txtObs.Text;

            DateTime dtRegi;
            if (DateTime.TryParse(mskDReg.Text, out dtRegi))
            {
                fornecedor.DataRegistro = dtRegi;
            }
            else
            {
                MessageBox.Show("Digite uma data de nascimento/registro válida.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDReg.Focus();
                return;
            }
            FornecedorNegocios fornecedorNegocios = new FornecedorNegocios();

            if (acaoNaTelaSelecionada == 1)
            {
                int IdFornecedor = fornecedorNegocios.Inserir(fornecedor);

                if (IdFornecedor > 0)
                {
                    txtId.Text = IdFornecedor.ToString();

                    MessageBox.Show("Fornecedor inserido com sucesso.", "Informação",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Não foi possível inserir o forncedor. " +
                        "Verifique a conexão com o banco de dados.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                fornecedor.IdFornecedor = int.Parse(txtId.Text);
                int linhasAlteradas = fornecedorNegocios.Alterar(fornecedor);

                if (linhasAlteradas > 0)
                {
                    MessageBox.Show("Fornecedor alterado com sucesso.", "Informação",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("O fornecedor não foi encontrado.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


    }
}
