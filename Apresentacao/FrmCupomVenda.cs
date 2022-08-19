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
    public partial class FrmCupomVenda : Form
    {
        int idvenda = 0;
        public FrmCupomVenda(int idLancamento)
        {
            idvenda = idLancamento;
            InitializeComponent();
        }

        private void FrmCupomVenda_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sysDataSet.DataTable2' table. You can move, or remove it, as needed.
            this.DataTable2TableAdapter.Fill(this.sysDataSet.DataTable2);
            // TODO: This line of code loads data into the 'sysDataSet.DataTable2' table. You can move, or remove it, as needed.
            this.DataTable2TableAdapter.ConsultaPorIdLancamento(this.sysDataSet.DataTable2, idvenda);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
