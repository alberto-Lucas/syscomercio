using ObjetoTransferencia;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            var usuarioLogado = UsuarioLogado.Instancia;
            tstUser.Text = usuarioLogado.Nome;
            atualizaDataHora();
        }

        public void atualizaDataHora()
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToLongDateString();
        }

        string dirAplicacao = Application.StartupPath + "\\";

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            var bancoDados = BancoDados.Instancia;
            tstHost.Text = Environment.MachineName;

            tstDb.Text = bancoDados.Servidor + "\\" + bancoDados.Banco;
            this.Text = "SysComercio - Versão: " + Application.ProductVersion.ToString();
            toolTip1.SetToolTip(this.btnVenda, "Emitir Venda.");
            toolTip1.SetToolTip(this.btnOrcamento, "Emitir Orçamento.");
            toolTip1.SetToolTip(this.btnCliente, "Cadastro de Clientes.");
            toolTip1.SetToolTip(this.btnProduto, "Cadastro de Produtos.");
            toolTip1.SetToolTip(this.btnFornecedor, "Cadastro de Fornecedores.");
            toolTip1.SetToolTip(this.btnLogoff, "Trocar Usuário.");
            toolTip1.SetToolTip(this.btnSair, "Sair do Sistema.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            atualizaDataHora();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja sair ?",
               "Atenção",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button2
               ) == DialogResult.No)
            {
                e.Cancel = true;
                logoff = 0;
            }
            else
            {
                if (logoff == 1)
                {
                    System.Diagnostics.Process.Start(dirAplicacao + "SysComercio.exe", "a");

                }
            }
        }

        private void tstSite_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/lucas.alberto.140193"); 
        }

        int logoff = 0;

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            logoff = 1;
            Application.Exit();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSair.PerformClick();
        }

        private void trocarUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLogoff.PerformClick();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSobre frmSobre = new FrmSobre();
            frmSobre.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Listar os IPs da maquina
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    MessageBox.Show(ip.ToString() + "\n" + ip.Address.ToString());
                }
            }
            */

        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            FrmProdutoSelecao frmProdutoSelecao = new FrmProdutoSelecao(null);
            frmProdutoSelecao.ShowDialog();
        }

        private void produtosF2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnProduto.PerformClick();
        }

        private void FrmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
          /*  if (e.KeyCode == Keys.F1)
            {
                //btnNFe.PerformClick();
            }
            if (e.KeyCode == Keys.F2)
            {
                //btnProduto.PerformClick();
                MessageBox.Show("oi");
            }
            if (e.KeyCode == Keys.F3)
            {
                //btnCliente.PerformClick();
            }*/
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            FrmLancamento frmLancamento = new FrmLancamento(TipoLancamento.Venda);
            frmLancamento.Show();
        }

        private void btnOrcamento_Click(object sender, EventArgs e)
        {
            FrmLancamento frmLancamento = new FrmLancamento(TipoLancamento.Orcamento);
            frmLancamento.Show();
        }

        private void emitirVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnVenda.PerformClick();
        }

        private void emitirOrçamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnOrcamento.PerformClick();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmClienteSelecao frmSeleceoCliente = new FrmClienteSelecao(null);
            frmSeleceoCliente.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCliente.PerformClick();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarioSelecao frmSeleceoUsuario = new FrmUsuarioSelecao();
            frmSeleceoUsuario.ShowDialog();
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            FrmFornecedorSelecao frm = new FrmFornecedorSelecao();
            frm.ShowDialog();
        }

        private void lojaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* if (permissao == )
             {
                 FrmLojaCadastro frm = new FrmLojaCadastro(3);
                 DialogResult dialogResult = frm.ShowDialog();
                 if (dialogResult == DialogResult.OK)
                 {
                     //Pesquisar();
                 }
             }
             else
             {*/

            FrmLojaCadastro frm = new FrmLojaCadastro(2);
                frm.ShowDialog();

           // }
        }

        private void pagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void grupoUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGrupoUsuario frm = new FrmGrupoUsuario("");
            frm.ShowDialog();
        }
        private void vendasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRelatorio frmRel = new FrmRelatorio(1);
            frmRel.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRelatorio frmRel = new FrmRelatorio(2);
            frmRel.Show();
        }

        private void fornecedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRelatorio frmRel = new FrmRelatorio(3);
            frmRel.Show();
        }

        private void usuáriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRelatorio frmRel = new FrmRelatorio(4);
            frmRel.Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRelatorio frmRel = new FrmRelatorio(5);
            frmRel.Show();
        }
    }
}
