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
    public partial class FrmRelatorio : Form
    {
        public FrmRelatorio(int rel)
        {
            InitializeComponent();

            if(rel == 1)//Venda
            {
                this.DataTable1TableAdapter.Fill(this.sysDataSet.DataTable1);
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSource1.Name = "DataSet1";
                reportDataSource1.Value = this.DataTable1BindingSource;
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Apresentacao.Relatorio.RelVenda.rdlc";
                this.reportViewer1.RefreshReport();
            }
            if (rel == 2)//Produto
            {
                this.RelProdutoTableAdapter.Fill(this.sysDataSet.RelProduto);
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSource1.Name = "DataSet1";
                reportDataSource1.Value = this.RelProdutoBindingSource;
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Apresentacao.Relatorio.RelProduto.rdlc";
                this.reportViewer1.RefreshReport();
            }
            if (rel == 3)//Forncedor
            {
                this.RelFornecedorTableAdapter.Fill(this.sysDataSet.RelFornecedor);
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSource1.Name = "DataSet1";
                reportDataSource1.Value = this.RelFornecedorBindingSource;
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Apresentacao.Relatorio.RelFornecedor.rdlc";
                this.reportViewer1.RefreshReport();
            }
            if (rel == 4)//Usuario
            {
                this.RelUsuarioTableAdapter.Fill(this.sysDataSet.RelUsuario);
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSource1.Name = "DataSet1";
                reportDataSource1.Value = this.RelUsuarioBindingSource;
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Apresentacao.Relatorio.RelUsuario.rdlc";
                this.reportViewer1.RefreshReport();
            }
            if (rel == 5)//Cliente
            {
                this.RelClienteTableAdapter.Fill(this.sysDataSet.RelCliente);
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSource1.Name = "DataSet1";
                reportDataSource1.Value = this.RelClienteBindingSource;
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Apresentacao.Relatorio.RelCliente.rdlc";
                this.reportViewer1.RefreshReport();
            }
            if (rel == 9)//Cupom
            {
                this.DataTable2TableAdapter.Fill(this.sysDataSet.DataTable2);
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSource1.Name = "DataSet1";
                reportDataSource1.Value = this.DataTable2BindingSource;
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Apresentacao.Relatorio.CupomNaoFiscal.rdlc";
                this.reportViewer1.RefreshReport();
            }
        }

        private void FrmRelatorio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sysDataSet.RelCliente' table. You can move, or remove it, as needed.
            this.RelClienteTableAdapter.Fill(this.sysDataSet.RelCliente);
            // TODO: This line of code loads data into the 'sysDataSet.RelUsuario' table. You can move, or remove it, as needed.
            this.RelUsuarioTableAdapter.Fill(this.sysDataSet.RelUsuario);
            // TODO: This line of code loads data into the 'sysDataSet.RelFornecedor' table. You can move, or remove it, as needed.
            this.RelFornecedorTableAdapter.Fill(this.sysDataSet.RelFornecedor);
            // TODO: This line of code loads data into the 'sysDataSet.RelProduto' table. You can move, or remove it, as needed.
            this.RelProdutoTableAdapter.Fill(this.sysDataSet.RelProduto);
            this.DataTable1TableAdapter.Fill(this.sysDataSet.DataTable1);

            this.DataTable2TableAdapter.Fill(this.sysDataSet.DataTable2);



            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ptbMinimaze_MouseLeave(object sender, EventArgs e)
        {
            ptbMinimaze.Image = global::Apresentacao.Properties.Resources.icons8_Minimize_Window_28px1;
        }
        private void ptbMinimaze_MouseMove(object sender, MouseEventArgs e)
        {
            ptbMinimaze.Image = global::Apresentacao.Properties.Resources.icons8_Minimize_Window_28px_1;
        }
        private void ptbMaximaze_MouseLeave(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                ptbMaximaze.Image = global::Apresentacao.Properties.Resources.icons8_Restore_Window_28px;
            }
            else
            {
                ptbMaximaze.Image = global::Apresentacao.Properties.Resources.icons8_Maximize_Window_28px1;
            }

        }
        private void ptbMaximaze_MouseMove(object sender, MouseEventArgs e)
        {

            if (this.WindowState == FormWindowState.Maximized)
            {
                ptbMaximaze.Image = global::Apresentacao.Properties.Resources.icons8_Restore_Window_28px_1;
            }
            else
            {
                ptbMaximaze.Image = global::Apresentacao.Properties.Resources.icons8_Maximize_Window_28px_1;
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

        private void ptbMaximaze_MouseClick(object sender, MouseEventArgs e)
        {
            //Maximizar e desmaximizar fomr
            if (this.WindowState == FormWindowState.Maximized)
            {

                ptbMaximaze.Image = global::Apresentacao.Properties.Resources.icons8_Restore_Window_28px_1;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {

                ptbMaximaze.Image = global::Apresentacao.Properties.Resources.icons8_Restore_Window_28px;

                this.WindowState = FormWindowState.Maximized;
                //this.Height -= 40;
            }
            //ajustatela();
        }

        private void ptbMinimaze_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //-----------------------------------------------------------------------------------------------------
 
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
        //-----------------------------------------------------------------------------------------------------

    }
}
