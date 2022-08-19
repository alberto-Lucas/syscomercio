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
    public partial class FrmLojaCadastro : Form
    {
        int acaoNaTelaSelecionada;
        public FrmLojaCadastro(int acaoNaTela)
        {


            InitializeComponent();

            //1 - INSERIR
            //2 - ALTERAR
            //3 - VISUALIZAR

            acaoNaTelaSelecionada = acaoNaTela;
            switch (acaoNaTelaSelecionada)
            {
                case 2:
                    {
                        lblTituloTela.Text = "Alterar Loja";

                        carregar();
                    }
                    break;
                case 3:
                    {
                        visualizar();

                        lblTituloTela.Text = "Visualizar Loja";
                        carregar();

                    }
                    break;
            }
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

        public void carregar()
        {
            LojaNegocios lojaNegocios = new LojaNegocios();
            Loja loja = lojaNegocios.ConsultarPorId(1);
            txtId.Text = loja.IdLoja.ToString();
            txtRazaoSocial.Text = loja.RazaoSocial.ToString();
            txtNomeFantasia.Text = loja.NomeFantatasia.ToString();
            txtCnpj.Text = loja.CNPJ.ToString();
            txtIe.Text = loja.InscricaoEstadual.ToString();
            mskDRegistro.Text = loja.DataRegistro.ToString();
            mskDCadastro.Text = loja.DataCadastro.ToString();
            mskDAlteracao.Text = loja.DataAlteracao.ToString();
            txtIdUserCadastro.Text = "0";
            txtIdUserAlteracao.Text = loja.UsuarioAlteracao.IdUsuario.ToString();
            txtNomeUserCadastro.Text = "IMPLANTADOR";
            txtNomeUserAlteracao.Text = loja.UsuarioAlteracao.Nome;
        }
        public void visualizar()
        {
            txtId.ReadOnly = true;
            txtRazaoSocial.ReadOnly = true;
            txtNomeFantasia.ReadOnly = true;
            txtCnpj.ReadOnly = true;
            txtIe.ReadOnly = true;
            mskDRegistro.ReadOnly = true;
            btnSalvar.Visible = false;
            btnCancelar.Visible = false;
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente cancelar as alterações?",
        "Confirmação", MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //Quando essa linha for executada a tela será fechada
                //(da mesma forma que o comando Close() faz), porém,
                //ela retornará que o botão "Cancelar" foi clicado.
                //Com isso, na tela de seleção de clientes, nós saberemos
                //qual foi o botão que o usuário clicou (Salvar ou Cancelar).
                this.DialogResult = DialogResult.Cancel;
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

        private void btnSlavar_Click(object sender, EventArgs e)
        {
            Loja loja = new Loja();


            loja.RazaoSocial = txtRazaoSocial.Text;
            loja.NomeFantatasia = txtNomeFantasia.Text;
            loja.CNPJ = txtCnpj.Text.Replace(".", "");
            loja.CNPJ = loja.CNPJ.Replace("-", "");
            loja.InscricaoEstadual = txtIe.Text;

            DateTime dtReg;
            if (DateTime.TryParse(mskDRegistro.Text, out dtReg))
            {
                loja.DataRegistro = dtReg;
            }
            else
            {
                MessageBox.Show("Digite uma data de registro válida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDRegistro.Focus();
                return;
            }

            LojaNegocios lojaNegocios = new LojaNegocios();

            //Para alterar o cliente é necessário que o objeto tenha
            //o ID do cliente.
            loja.IdLoja = int.Parse(txtId.Text);

            //O comando Alterar retorna quantas linhas foram alteradas.
            int linhasAlteradas = lojaNegocios.Alterar(loja);

            if (linhasAlteradas > 0)
            {
                MessageBox.Show("Loja alterada com sucesso.", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                carregar();
            }
            else
            {
                MessageBox.Show("A loja não foi encontrado.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
