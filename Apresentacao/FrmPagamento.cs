using Negocios;
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
    public partial class FrmPagamento : Form
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
        private void ptbClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        int idLancamento;

        public FrmPagamento(int id_lancamento, decimal valor)
        {
            idLancamento = id_lancamento;
            InitializeComponent();
            lblPagar.Text = "R$ " + string.Format("{0:N2}", valor);
            teste();
        }

        private void txtValorDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

        }

        void teste()
        {
            lblPago.Text = "R$ "+
                            string.Format("{0:N2}",
                            (double.Parse(txtValorDinheiro.Text) +
                            double.Parse(txtValorCredito.Text) +
                            double.Parse(txtValorDebito.Text) +
                            double.Parse(txtValorCheque.Text) +
                            double.Parse(txtValorBoleto.Text) +
                            double.Parse(txtValorDeposito.Text) +
                            double.Parse(txtValorOutros.Text)));

            lblDiferenca.Text = "R$ " +
                                string.Format("{0:N2}",(
                                double.Parse(lblPagar.Text.Replace("R$ ", ""))-
                                double.Parse(lblPago.Text.Replace("R$ ", ""))));

            txtTotalDinheiro.Text = string.Format("{0:N2}",(txtValorDinheiro.Text));
            txtTotalDebito.Text = string.Format("{0:N2}",(txtValorDebito.Text));
            txtTotalDeposito.Text = string.Format("{0:N2}", (txtValorDeposito.Text));


            txtQtdeParcelaCredito.Text = txtQtdeParcelaCredito.Text.Replace("x", "");
            txtTotalCredito.Text = string.Format("{0:N2}", (
                double.Parse(txtValorCredito.Text) / double.Parse(txtQtdeParcelaCredito.Text)));
            txtQtdeParcelaCredito.Text = "x" + txtQtdeParcelaCredito.Text;

            txtQtdeParcelaCheque.Text=txtQtdeParcelaCheque.Text.Replace("x", "");
            txtTotalCheque.Text = string.Format("{0:N2}", (
                double.Parse(txtValorCheque.Text) / double.Parse(txtQtdeParcelaCheque.Text)));
            txtQtdeParcelaCheque.Text = "x" + txtQtdeParcelaCheque.Text;

            txtQtdeParcelaBoleto.Text=txtQtdeParcelaBoleto.Text.Replace("x", "");
            txtTotalBoleto.Text = string.Format("{0:N2}", (
                double.Parse(txtValorBoleto.Text) / double.Parse(txtQtdeParcelaBoleto.Text)));
            txtQtdeParcelaBoleto.Text = "x" + txtQtdeParcelaBoleto.Text;

            txtQtdeParcelaOutros.Text=txtQtdeParcelaOutros.Text.Replace("x", "");
            txtTotalOutros.Text = string.Format("{0:N2}", (
                double.Parse(txtValorOutros.Text) / double.Parse(txtQtdeParcelaOutros.Text)));
            txtQtdeParcelaOutros.Text = "x" + txtQtdeParcelaOutros.Text;
        }

        private void txtValorDinheiro_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtQtdeParcelaCredito_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtValorCredito_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void FrmPagamento_Load(object sender, EventArgs e)
        {

        }

        private void txtValorDinheiro_Leave(object sender, EventArgs e)
        {
            if (!(double.Parse(txtValorDinheiro.Text) > double.Parse(lblDiferenca.Text.Replace("R$ ", ""))))
            {
                teste();
                txtValorDinheiro.Text = string.Format("{0:N2}", txtValorDinheiro.Text);
            }
            else
            {
                MessageBox.Show("Informe um valor menor ou igual a: " + lblDiferenca.Text);
                txtValorDinheiro.SelectAll();
                txtValorDinheiro.Focus();
            }
        }

        private void txtQtdeParcelaCredito_Leave(object sender, EventArgs e)
        {
            teste();
        }

        private void txtValorCredito_Leave(object sender, EventArgs e)
        {
            if (!(double.Parse(txtValorCredito.Text) > double.Parse(lblDiferenca.Text.Replace("R$ ", ""))))
            {
                teste();
                txtValorCredito.Text = string.Format("{0:N2}", txtValorCredito.Text);
            }
            else
            {
                MessageBox.Show("Informe um valor menor ou igual a: " + lblDiferenca.Text);
                txtValorCredito.SelectAll();
                txtValorCredito.Focus();
            }
        }

        private void txtValorDebito_Leave(object sender, EventArgs e)
        {
            if (!(double.Parse(txtValorDebito.Text) > double.Parse(lblDiferenca.Text.Replace("R$ ", ""))))
            {
                teste();
                txtValorDebito.Text = string.Format("{0:N2}", txtValorDebito.Text);
            }
            else
            {
                MessageBox.Show("Informe um valor menor ou igual a: " + lblDiferenca.Text);
                txtValorDebito.SelectAll();
                txtValorDebito.Focus();
            }
        }

        private void txtValorCheque_Leave(object sender, EventArgs e)
        {
            if (!(double.Parse(txtValorCheque.Text) > double.Parse(lblDiferenca.Text.Replace("R$ ", ""))))
            {
                teste();
                txtValorCheque.Text = string.Format("{0:N2}", txtValorCheque.Text);
            }
            else
            {
                MessageBox.Show("Informe um valor menor ou igual a: " + lblDiferenca.Text);
                txtValorCheque.SelectAll();
                txtValorCheque.Focus();
            }
        }

        private void txtValorBoleto_Leave(object sender, EventArgs e)
        {
            if (!(double.Parse(txtValorBoleto.Text) > double.Parse(lblDiferenca.Text.Replace("R$ ", ""))))
            {
                teste();
                txtValorBoleto.Text = string.Format("{0:N2}", txtValorBoleto.Text);
            }
            else
            {
                MessageBox.Show("Informe um valor menor ou igual a: " + lblDiferenca.Text);
                txtValorBoleto.SelectAll();
                txtValorBoleto.Focus();
            }
        }

        private void txtValorDeposito_Leave(object sender, EventArgs e)
        {
            if (!(double.Parse(txtValorDeposito.Text) > double.Parse(lblDiferenca.Text.Replace("R$ ", ""))))
            {
                teste();
                txtValorDeposito.Text = string.Format("{0:N2}", txtValorDeposito.Text);
            }
            else
            {
                MessageBox.Show("Informe um valor menor ou igual a: " + lblDiferenca.Text);
                txtValorDeposito.SelectAll();
                txtValorDeposito.Focus();
            }
        }

        private void txtValorOutros_Leave(object sender, EventArgs e)
        {
            if (!(double.Parse(txtValorOutros.Text) > double.Parse(lblDiferenca.Text.Replace("R$ ", ""))))
            {
                teste();
                txtValorOutros.Text = string.Format("{0:N2}", txtValorOutros.Text);
            }
            else
            {
                MessageBox.Show("Informe um valor menor ou igual a: " + lblDiferenca.Text);
                txtValorOutros.SelectAll();
                txtValorOutros.Focus();
            }
        }

        private void txtQtdeParcelaCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 13)
            {
                e.Handled = true;
                //MessageBox.Show("Este campo aceita apenas números!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void txtValorDinheiro_MouseClick(object sender, MouseEventArgs e)
        {
            txtValorDinheiro.SelectAll();
        }

        private void txtValorCredito_MouseClick(object sender, MouseEventArgs e)
        {
            txtValorCredito.SelectAll();
        }

        private void txtQtdeParcelaCredito_MouseClick(object sender, MouseEventArgs e)
        {
            txtQtdeParcelaCredito.SelectAll();
        }

        private void txtValorDebito_MouseClick(object sender, MouseEventArgs e)
        {
            txtValorDebito.SelectAll();
        }

        private void txtValorCheque_MouseClick(object sender, MouseEventArgs e)
        {
            txtValorCheque.SelectAll();
        }

        private void txtQtdeParcelaCheque_MouseClick(object sender, MouseEventArgs e)
        {
            txtQtdeParcelaCheque.SelectAll();
        }

        private void txtValorBoleto_MouseClick(object sender, MouseEventArgs e)
        {
            txtValorBoleto.SelectAll();
        }

        private void txtQtdeParcelaBoleto_MouseClick(object sender, MouseEventArgs e)
        {
            txtQtdeParcelaBoleto.SelectAll();
        }

        private void txtValorDeposito_MouseClick(object sender, MouseEventArgs e)
        {
            txtValorDeposito.SelectAll();
        }

        private void txtValorOutros_MouseClick(object sender, MouseEventArgs e)
        {
            txtValorOutros.SelectAll();
        }

        private void txtQtdeParcelaOutros_MouseClick(object sender, MouseEventArgs e)
        {
            txtQtdeParcelaOutros.SelectAll();
        }

        private void btnFinalizaVenda_Click(object sender, EventArgs e)
        {
           // double diferenca = 
            if (double.Parse(lblDiferenca.Text.Replace("R$ ", "")) == 0)
            {
                PagamentoVendaNegocios pagamentoVendaNegocios = new PagamentoVendaNegocios(); 
                if(double.Parse(txtValorDinheiro.Text) > 0)
                {
                    if (pagamentoVendaNegocios.Inserir(idLancamento, 1, 1, double.Parse(txtTotalDinheiro.Text)) > 0) { }
                    else
                    {
                        MessageBox.Show("Erro durante o processo, tente novamente."); 
                        if (pagamentoVendaNegocios.rollBack(idLancamento) > 0) { }
                        else
                            MessageBox.Show("Falha no processo de rollback, contate o suporte."); 
                        return;
                    }
                }
                //-------------------------------
                if (double.Parse(txtValorCredito.Text) > 0)
                {
                    if (pagamentoVendaNegocios.Inserir(idLancamento, 2, int.Parse(txtQtdeParcelaCredito.Text.Replace("x", "")), double.Parse(txtTotalCredito.Text)) > 0) { }
                    else
                    {
                        MessageBox.Show("Erro durante o processo, tente novamente.");
                        if (pagamentoVendaNegocios.rollBack(idLancamento) > 0) { }
                        else
                            MessageBox.Show("Falha no processo de rollback, contate o suporte.");
                        return;
                    }
                }
                //-------------------------------
                if (double.Parse(txtValorDebito.Text) > 0)
                {
                    if (pagamentoVendaNegocios.Inserir(idLancamento, 3, 1, double.Parse(txtTotalDebito.Text)) > 0) { }
                    else
                    {
                        MessageBox.Show("Erro durante o processo, tente novamente.");
                        if (pagamentoVendaNegocios.rollBack(idLancamento) > 0) { }
                        else
                            MessageBox.Show("Falha no processo de rollback, contate o suporte.");
                        return;
                    }
                }
                //-------------------------------
                if (double.Parse(txtValorCheque.Text) > 0)
                {
                    if (pagamentoVendaNegocios.Inserir(idLancamento, 4, int.Parse(txtQtdeParcelaCheque.Text.Replace("x", "")), double.Parse(txtTotalCheque.Text)) > 0) { }
                    else
                    {
                        MessageBox.Show("Erro durante o processo, tente novamente.");
                        if (pagamentoVendaNegocios.rollBack(idLancamento) > 0) { }
                        else
                            MessageBox.Show("Falha no processo de rollback, contate o suporte.");
                        return;
                    }
                }
                //-------------------------------
                if (double.Parse(txtValorBoleto.Text) > 0)
                {
                    if (pagamentoVendaNegocios.Inserir(idLancamento, 5, int.Parse(txtQtdeParcelaBoleto.Text.Replace("x", "")), double.Parse(txtTotalBoleto.Text)) > 0) { }
                    else
                    {
                        MessageBox.Show("Erro durante o processo, tente novamente.");
                        if (pagamentoVendaNegocios.rollBack(idLancamento) > 0) { }
                        else
                            MessageBox.Show("Falha no processo de rollback, contate o suporte.");
                        return;
                    }
                }
                //-------------------------------
                if (double.Parse(txtValorDeposito.Text) > 0)
                {
                    if (pagamentoVendaNegocios.Inserir(idLancamento, 6, 1, double.Parse(txtTotalDeposito.Text)) > 0) { }
                    else
                    {
                        MessageBox.Show("Erro durante o processo, tente novamente.");
                        if (pagamentoVendaNegocios.rollBack(idLancamento) > 0) { }
                        else
                            MessageBox.Show("Falha no processo de rollback, contate o suporte.");
                        return;
                    }
                }
                //-------------------------------
                if (double.Parse(txtValorOutros.Text) > 0)
                {
                    if (pagamentoVendaNegocios.Inserir(idLancamento, 7, int.Parse(txtQtdeParcelaOutros.Text.Replace("x", "")), double.Parse(txtTotalOutros.Text)) > 0) { }
                    else
                    {
                        MessageBox.Show("Erro durante o processo, tente novamente.");
                        if (pagamentoVendaNegocios.rollBack(idLancamento) > 0) { }
                        else
                            MessageBox.Show("Falha no processo de rollback, contate o suporte.");
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("O valor da diferença deve ser igual a 0");
        }
    }
}
