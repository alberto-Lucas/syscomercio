using Negocios;
using ObjetoTransferencia;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmProdutoCadastro : Form
    {
        //AcaoNaTela acaoNaTelaSelecionada;
        int acaoNaTelaSelecionada;
        public FrmProdutoCadastro(int acaoNaTela, Produto produto)//AcaoNaTela acaoNaTela, Produto produto)
        {
            InitializeComponent();
            #region Tab
            this.pnlDadosProduto.Location = new System.Drawing.Point(12, 95);
            pnlFornecedor.Location = new System.Drawing.Point(12, 95);
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
                        lblTituloTela.Text = "Inserir Produto";
                        //pessoa_f();
                        //rdbFisica.Checked = true;
                        //pesquisarCidadePorEstado();
                        //cbxAtivo.Text = "S";
                    }
                    break;
                case 2:
                    {
                        lblTituloTela.Text = "Alterar Produto";


                        string ativo = produto.Ativo;
                        if (ativo.Equals("S"))
                        {
                            cbxAtivo.Text = "SIM";
                        }
                        else
                        {
                            cbxAtivo.Text = "NÃO";
                        }


                        txtId.Text = produto.IdProduto.ToString();
                        txtDescricao.Text = produto.Descricao;
                        txtBarras.Text = produto.CodigoBarras;
                        txtNcm.Text = produto.Ncm;
                        txtUnidade.Text = produto.Unidade;
                        txtEstoque.Text = produto.Estoque.ToString();
                        txtPrecoCompra.Text = produto.PrecoCompra.ToString();
                        txtPrecoVenda.Text = produto.PrecoVenda.ToString();
                        txtMargemLucro.Text = produto.MargemLucro.ToString();
                        txtObs.Text = produto.Observacao;
                        //txtIdUserCadastro.Text = produto.UsuarioCadastro.IdUsuario.ToString();
                        //txtIdUserAlteracao.Text = produto.UsuarioAlteracao.IdUsuario.ToString();
                        //txtNomeUserCadastro.Text = produto.UsuarioCadastro.Nome;
                        //txtNomeUserAlteracao.Text = produto.UsuarioAlteracao.Nome;
                        mskDataCadastro.Text = produto.DataCadastro.ToString();
                        mskDataAleracao.Text = produto.DataAlteracao.ToString();
                    }
                    break;
                case 3:
                    {
                        visualizar();

                        lblTituloTela.Text = "Visualizar Produto";
                        string ativo = produto.Ativo;
                        if (ativo.Equals("S"))
                        {
                            cbxAtivo.Text = "SIM";
                        }
                        else
                        {
                            cbxAtivo.Text = "NÃO";
                        }

                        txtId.Text = produto.IdProduto.ToString();
                        txtDescricao.Text = produto.Descricao;
                        txtBarras.Text = produto.CodigoBarras;
                        txtNcm.Text = produto.Ncm;
                        txtUnidade.Text = produto.Unidade;
                        txtEstoque.Text = produto.Estoque.ToString();
                        txtPrecoCompra.Text = produto.PrecoCompra.ToString();
                        txtPrecoVenda.Text = produto.PrecoVenda.ToString();
                        txtMargemLucro.Text = produto.MargemLucro.ToString();
                        txtObs.Text = produto.Observacao;
                        txtIdUserCadastro.Text = produto.UsuarioCadastro.IdUsuario.ToString();
                        txtIdUserAlteracao.Text = produto.UsuarioAlteracao.IdUsuario.ToString();
                        txtNomeUserCadastro.Text = produto.UsuarioCadastro.Nome;
                        txtNomeUserAlteracao.Text = produto.UsuarioAlteracao.Nome;
                        mskDataCadastro.Text = produto.DataCadastro.ToString();
                        mskDataAleracao.Text = produto.DataAlteracao.ToString();
                    }
                    break;
            }
        }

        public void visualizar()
        {
            txtId.ReadOnly = true;
            txtDescricao.ReadOnly = true;
            txtBarras.ReadOnly = true;
            txtNcm.ReadOnly = true;
            txtUnidade.ReadOnly = true;
            txtEstoque.ReadOnly = true;
            txtPrecoCompra.ReadOnly = true;
            txtPrecoVenda.ReadOnly = true;
            txtMargemLucro.ReadOnly = true;
            txtObs.ReadOnly = true;
            cbxAtivo.Enabled = false;

            btnSalvar.Visible = false;
            btnCancelar.Visible = false;
        }
        #region Animação Mouse
        //Dados = 1
        //Fornecedor = 2
        bool dados = true, fornecedor = false;
        void MouseLeaves(int mouseLeave)
        {
            if (mouseLeave == 1)
            {
                lblBtnDados.BackColor = Color.LightGray;
                lblBtnDados.ForeColor = Color.FromArgb(109, 129, 140);
            }

            if (mouseLeave == 2)
            {
                lblBtnFornecedor.BackColor = Color.LightGray;
                lblBtnFornecedor.ForeColor = Color.FromArgb(109, 129, 140);
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
                lblBtnFornecedor.BackColor = Color.FromArgb(109, 129, 140);
                lblBtnFornecedor.ForeColor = Color.White;
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

            if (fornecedor == false)
            {
                lblBtnFornecedor.BackColor = Color.LightGray;
                lblBtnFornecedor.ForeColor = Color.FromArgb(109, 129, 140);
                lblBtnFornecedor.SendToBack();
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

            if (fornecedor == true)
            {
                lblBtnFornecedor.ForeColor = Color.FromArgb(109, 129, 140);
                lblBtnFornecedor.ForeColor = Color.White;
                lblBtnFornecedor.BringToFront();
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
            fornecedor = false;
            pnlDadosProduto.Location = new System.Drawing.Point(12, 95);
            pnlDadosProduto.BringToFront();
            habilita();
            desabilita();
        }
        //------CONTATO-------------------------------------------------
        void lblBtnFornecedorMouseLeave(object sender, EventArgs e)
        {

            if (fornecedor == false)
            {
                MouseLeaves(2);
            }

        }
        void lblBtnForencedorMouseMove(object sender, MouseEventArgs e)
        {

            if (fornecedor == false)
            {
                MouseMoves(2);
            }

        }
        void lblBtnFornecedorClick(object sender, EventArgs e)
        {
            dados = false;
            fornecedor = true;

            pnlFornecedor.BringToFront();
            habilita();
            desabilita();
        }

        private void FrmProdutoCadastro_Load(object sender, EventArgs e)
        {

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
        #endregion

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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();

            string ativo = cbxAtivo.Text;
            if (ativo.Equals("SIM"))
            {
                produto.Ativo = "S";
            }
            else
            {
                produto.Ativo = "N";
            }



            /*cliente.NomeRazaoSocial = txtNomeRazao.Text;
            cliente.ApelidoNomeFantasia = txtApelidoFantasia.Text;
            cliente.CpfCnpj = txtCpfCnpj.Text.Replace(".", "");
            cliente.CpfCnpj = cliente.CpfCnpj.Replace("-", "");
            cliente.RgIe = txtRgIe.Text;
            cliente.Observacao = txtObs.Text;*/



            ProdutoNegocios produtoNegocios = new ProdutoNegocios();


            //Inserir
            if (acaoNaTelaSelecionada == 1)
            {
                //O método "Inserir" retorna o ID do cliente inserido.
                int IdCliente = produtoNegocios.Inserir(produto);

                //Se o ID for maior que zero significa que a inclusão deu certo.
                if (IdCliente > 0)
                {
                    //Exibe no campo da tela o ID do cliente inserido.
                    txtId.Text = IdCliente.ToString();

                    MessageBox.Show("Produto inserido com sucesso.", "Informação",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Quando essa linha for executada a tela será fechada
                    //(da mesma forma que o comando Close() faz), porém,
                    //ela retornará que o botão "Salvar" foi clicado.
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Não foi possível inserir o produto. " +
                        "Verifique a conexão com o banco de dados.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else //Alterar
            {
                //Para alterar o cliente é necessário que o objeto tenha
                //o ID do cliente.
                produto.IdProduto = int.Parse(txtId.Text);

                //O comando Alterar retorna quantas linhas foram alteradas.
                int linhasAlteradas = produtoNegocios.Alterar(produto);

                if (linhasAlteradas > 0)
                {
                    MessageBox.Show("Produto alterado com sucesso.", "Informação",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("O produto não foi encontrado.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
