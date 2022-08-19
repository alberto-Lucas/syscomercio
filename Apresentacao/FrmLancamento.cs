using Negocios;
using ObjetoTransferencia;
using System;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmLancamento : Form
    {
        TipoLancamento tipoLancamentoSelecionada;
        LancamentoNegocios lancamentoNegocios = new LancamentoNegocios();
        LancamentoItemNegocios lancamentoItemNegocios = new LancamentoItemNegocios();

        public FrmLancamento(TipoLancamento lancamento) // 1 -- Orçamento / 0 -- Venda
        {

            tipoLancamentoSelecionada = lancamento;
            InitializeComponent();
            dgvDados.AutoGenerateColumns = false;
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToShortDateString();
            var usuarioLogado = UsuarioLogado.Instancia;
            txtUsuario.Text = usuarioLogado.IdUsuario.ToString();
            lblUsuarioNome.Text = usuarioLogado.Nome;


            if (lancamento == TipoLancamento.Venda)
            {
                #region DefiniEstiloOrcamento
                pnlTopo.BackColor = Color.FromArgb(109, 129, 140);
                pnlGrid.BackColor = Color.FromArgb(109, 129, 140);
                pnlpPreco.BackColor = Color.FromArgb(109, 129, 140);
                pnlLancamento.BackColor = Color.FromArgb(109, 129, 140);
                lblTituloTela.Text = "Vendas";
                btnFinalizaVenda.Text = "FINALIZAR VENDA";
                btnFinalizaVenda.Location = new System.Drawing.Point(793, 3);
                btnFinalizaVenda.Size = new System.Drawing.Size(206, 30);

                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(129)))), ((int)(((byte)(140)))));
                dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
                dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
                dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                this.dgvDados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
                //this.dgvDados.DefaultCellStyle = dataGridViewCellStyle1;
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
                dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
                dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
                dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
                dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                this.dgvDados.DefaultCellStyle = dataGridViewCellStyle2;

                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
                dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
                this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
                #endregion
            }

            if (lancamento == TipoLancamento.Orcamento)
            {
                #region DefiniEstiloVenda
                ptbIcon.Image = global::Apresentacao.Properties.Resources.icons8_Purchase_Order_30px_1___Copia;
                pnlTopo.BackColor = Color.FromArgb(255, 177, 0);
                pnlGrid.BackColor = Color.FromArgb(255, 177, 0);
                pnlpPreco.BackColor = Color.FromArgb(255, 177, 0);
                pnlLancamento.BackColor = Color.FromArgb(255, 177, 0);
                lblTituloTela.Text = "Orçamento";
                btnFinalizaVenda.Text = "FINALIZAR ORÇAMENTO";
                btnFinalizaVenda.Location = new System.Drawing.Point(751, 3);
                btnFinalizaVenda.Size = new System.Drawing.Size(248, 30);

                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(0)))));
                dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
                dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Orange;
                dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                this.dgvDados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
                //this.dgvDados.DefaultCellStyle = dataGridViewCellStyle1;
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
                dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
                dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
                dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
                dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                this.dgvDados.DefaultCellStyle = dataGridViewCellStyle2;

                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
                dataGridViewCellStyle3.BackColor = System.Drawing.Color.Moccasin;
                this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
                btnOrcamento.Visible = false;
                #endregion
            }
        }

        #region Perfumaria
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //-----------------------------------------------------------------------------------------------------
        //Maximizar tela sem sobrepor barra de tarefas
        int a, b, posi = 0;
        public void ajustatela()
        {
            if (posi == 1)
            {
                posi = 0;

                this.Size = new Size(948, 572);//Define tamanho do form
                this.Location = new Point(a, b);//defini posição na tela do windows- no caso no centro da tela.
                StartPosition = FormStartPosition.Manual;//precisar ser manul para definir a posicação acima      
            }
            else
            {
                posi = 1;

                a = this.Location.X;//pega posição atual do form no widnows - no caso no centro da tela.
                b = this.Location.Y;//pega posição atual do form no widnows - no caso no centro da tela.

                Width = Screen.PrimaryScreen.Bounds.Width;//define tamanho do form
                Height = Screen.PrimaryScreen.Bounds.Height - 40; //define tamanho do form 
                //menos 40 que seria o tamano 
                //da barras de tarefas

                this.Location = new Point(0, 0);//defini posição na tela do windows 
                //no caso no canto esquerdo superior da tela.
                StartPosition = FormStartPosition.Manual;//precisar ser manul para definir a posicação acima  	
            }
        }
        //-----------------------------------------------------------------------------------------------------

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void ptbClose_MouseLeave(object sender, EventArgs e)
        {
            ptbClose.Image = global::Apresentacao.Properties.Resources.icons8_Close_Window_28px_11;
        }

        private void ptbClose_MouseMove(object sender, MouseEventArgs e)
        {
            ptbClose.Image = global::Apresentacao.Properties.Resources.icons8_Close_Window_28px;
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

        private void ptbMinimaze_MouseLeave(object sender, EventArgs e)
        {
            ptbMinimaze.Image = global::Apresentacao.Properties.Resources.icons8_Minimize_Window_28px1;
        }

        private void ptbMinimaze_MouseMove(object sender, MouseEventArgs e)
        {
            ptbMinimaze.Image = global::Apresentacao.Properties.Resources.icons8_Minimize_Window_28px_1;
        }

        private void ptbClose_Click(object sender, EventArgs e)
        {
            ExcluirLancamento(true);

        }

        private void ptbMaximaze_Click(object sender, EventArgs e)
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
            }
            //ajustatela();
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //ajustatela();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToShortDateString();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

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


        private void dgvDados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvDados.Rows[e.RowIndex].DataBoundItem != null) && (dgvDados.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvDados.Rows[e.RowIndex].DataBoundItem, dgvDados.Columns[e.ColumnIndex].DataPropertyName);
            }
        }
        #endregion

        private void PesquisarCliente()
        {
            int Id = 0;
            ClienteNegocios clienteNegocios = new ClienteNegocios();
            if (int.TryParse(txtCliente.Text, out Id))
            {
                Cliente cliente = clienteNegocios.ConsultarPorId(Id);
                if (cliente != null)
                {
                    lblClienteNome.Text = cliente.NomeRazaoSocial;
                    txtProduto.Focus();
                }
                else
                {
                    MessageBox.Show("O Cliente selecionado não encontrado ou inativo.", "Atenção...",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCliente.SelectAll();
                    txtCliente.Focus();
                }
            }
            else
            {
                FrmClienteSelecao frm = new FrmClienteSelecao(txtCliente.Text, true);
                DialogResult dialogResult = frm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    txtCliente.Text = frm.clienteSelecao.IdCliente.ToString();
                    lblClienteNome.Text = frm.clienteSelecao.NomeRazaoSocial;
                    txtProduto.Focus();
                }
            }
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PesquisarCliente();
            }
        }
        private void PesquisarProduto()
        {
            int Id = 0;
            ProdutoNegocios produtoNegocios = new ProdutoNegocios();
            if (int.TryParse(txtProduto.Text, out Id))
            {
                Produto produto = produtoNegocios.ConsultarPorId(Id);
                if (produto != null)
                {
                    lblDescriProduto.Text = produto.Descricao;
                    txtPrecoVenda.Text = produto.PrecoVenda.ToString();
                    txtQtde.Focus();
                }
                else
                {
                    MessageBox.Show("O Produto selecionado não encontrado ou inativo.", "Atenção...",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProduto.SelectAll();
                    txtProduto.Focus();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtProduto.Text))
                {
                    FrmProdutoSelecao frm = new FrmProdutoSelecao(txtProduto.Text, true);
                    DialogResult dialogResult = frm.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        txtProduto.Text = frm.produtoSelecao.IdProduto.ToString();
                        lblDescriProduto.Text = frm.produtoSelecao.Descricao;
                        txtPrecoVenda.Text = frm.produtoSelecao.PrecoVenda.ToString();
                        txtQtde.Focus();
                    }
                }
                else
                    MessageBox.Show("Informe o código ou descrição do produto.", "Atenção...",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PesquisarProduto();
            }
        }

        private void txtQtde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQtde.Text = OnlyNumbers(txtQtde.Text);
                txtValorTotal.Text = string.Format("{0:N2}", (int.Parse(txtQtde.Text) * double.Parse(txtPrecoVenda.Text)));
                txtQtde.Text = "x" + txtQtde.Text;
                txtDesconto.Focus();
            }
        }

        private void txtDesconto_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                if (txtDesconto.Text.Equals("0%"))

                    txtDesconto.Text = OnlyNumbers(txtDesconto.Text);

                double desconto = 0;
                if (double.TryParse(txtDesconto.Text, out desconto) && (desconto > -1) && (desconto <= 100))
                {
                    txtValorTotal.Text = string.Format("{0:N2}", ((double.Parse(txtValorTotal.Text) - (double.Parse(txtValorTotal.Text) / 100) * double.Parse(txtDesconto.Text))));
                    txtDesconto.Text += "%";
                    btnIncluirItem.Focus();
                }
                else
                {
                    MessageBox.Show("Não é possível aplicar um desconto menor que 100%.", "Atenção...",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDesconto.Text = "0%";
                    txtDesconto.Focus();
                }

            }
        }

        #region DeixarSomenteNumerosNoCampo
        public string OnlyNumbers(string toNormalize)
        {
            string resultString = string.Empty;
            Regex regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(toNormalize, "");
            return resultString;
        }
        #endregion

        private void FrmLancamento_Load(object sender, EventArgs e)
        {
            txtCliente.Focus();
            txtIdLancamento.Text = "";
        }

        void criarLancamento()
        {
            Lancamento lancamento = new Lancamento();
            int IdCliente = int.Parse(txtCliente.Text);
            if (tipoLancamentoSelecionada == TipoLancamento.Orcamento)
            {
                lancamento.TipoOperacao = "O";
                lancamento.StatusLancamento = "P";
            }
            if (tipoLancamentoSelecionada == TipoLancamento.Venda)
            {
                lancamento.TipoOperacao = "V";
                lancamento.StatusLancamento = "V";
            }

            int IdLancamento = lancamentoNegocios.Inserir(lancamento, IdCliente);
            if (IdLancamento > 0)
            {
                txtIdLancamento.Text = IdLancamento.ToString();
            }
            else
            {
                MessageBox.Show("Não foi possível inserir o Frete. " +
                                "Verifique a conexão com o banco de dados.", "Atenção",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        bool alterarQuantidadeEDesconto = false;
        void criaLancamentoItem()
        {
            LancamentoItem lancamentoItem = new LancamentoItem();
            LancamentoItemNegocios lancamentoItemNegocios = new LancamentoItemNegocios();

            txtQtde.Text = OnlyNumbers(txtQtde.Text);
            lancamentoItem.Quantidade = int.Parse(txtQtde.Text);
            lancamentoItem.PrecoUnitario = decimal.Parse(txtPrecoVenda.Text);
            lancamentoItem.ValorDesconto = (((decimal.Parse(txtPrecoVenda.Text)) * decimal.Parse(txtQtde.Text)) - (decimal.Parse(txtValorTotal.Text)));
            lancamentoItem.ordemItem = int.Parse(lblTotalItem.Text) + 1;

            int IdProduto = int.Parse(txtProduto.Text);
            int IdLan = int.Parse(txtIdLancamento.Text);


            if (alterarQuantidadeEDesconto == true)
            {
                int idAlteracao = lancamentoItemNegocios.AlterarItem(IdLan, IdProduto, lancamentoItem.Quantidade, lancamentoItem.ValorDesconto);
                if (idAlteracao > 0)
                {
                    atualizarGrade();
                    alterarQuantidadeEDesconto = false;
                    txtProduto.ReadOnly = false;
                }
                else
                {
                    MessageBox.Show("Não foi possível inserir o item. " +
                                    "Verifique a conexão com o banco de dados.", "Atenção",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (int.Parse(lblTotalItem.Text) == 0)
                    lancamentoItem.ordemItem = 1;
                else
                    lancamentoItem.ordemItem = lancamentoItemNegocios.maxItem(IdLan) + 1;


                int idLancamentoItemAlterado = lancamentoItemNegocios.AtualizarItem(IdLan, IdProduto, lancamentoItem.Quantidade, lancamentoItem.ValorDesconto);
                if (idLancamentoItemAlterado > 0)
                {
                    atualizarGrade();
                }
                else
                {
                    int idLancamentoItem = lancamentoItemNegocios.Inserir(lancamentoItem, IdProduto, IdLan);

                    if (idLancamentoItem > 0)
                    {
                        atualizarGrade();

                    }
                    else
                    {
                        MessageBox.Show("Não foi possível inserir o item. " +
                                        "Verifique a conexão com o banco de dados.", "Atenção",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        void limparProduto()
        {
            txtProduto.Clear();
            txtQtde.Text = "x1";
            txtPrecoVenda.Text = "0,00";
            txtDesconto.Text = "0%";
            txtValorTotal.Text = "0,00";
            lblDescriProduto.Text = "";
        }

        void limparTela()
        {
            txtCliente.Clear();
            lblClienteNome.Text = "";
            limparProduto();
            txtIdLancamento.Text = "";
            lblEconomia.Text = "R$ 0,00";
            lblTotalBruto.Text = "R$ 0,00";
            lblPrecoLiquido.Text = "0,00";
            lblTotalItem.Text = "0";
            dgvDados.DataSource = null;
            dgvDados.Update();
            dgvDados.Refresh();
            txtCliente.Focus();
        }

        private void btnIncluirItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                MessageBox.Show("É necessário selecionar o cliente.", "Atenção...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCliente.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtProduto.Text))
            {
                MessageBox.Show("É necessário selecionar o produto.", "Atenção...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProduto.Focus();
                return;
            }

            txtQtde.Text = OnlyNumbers(txtQtde.Text);
            Lancamento lancamento = new Lancamento();
            int quantidade = 0;
            if (int.TryParse(txtQtde.Text, out quantidade) && (quantidade > 0) && (quantidade <= 99))
            {
                if (string.IsNullOrEmpty(txtIdLancamento.Text))
                {
                    criarLancamento();

                }
                criaLancamentoItem();
            }
            else
            {
                MessageBox.Show("A quantidade deve ser um número inteiro, maior que 0 (zero) e menor ou igual a 99.", "Atenção...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtde.Text = "x" + txtQtde.Text;
                txtQtde.Focus();
            }
        }

        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (e.RowIndex != -1) // Checa se o index da linha clicada não é -1 (header por exemplo é -1)
            {
                Produto produtoSelecionado = (dgvDados.SelectedRows[0].DataBoundItem as Produto);
                FrmProdutoCadastro frm = new FrmProdutoCadastro(3, produtoSelecionado);
                DialogResult dialogResult = frm.ShowDialog();
            }*/
        }

        void ExcluirLancamento(bool fecharTela = false)
        {
            if (!string.IsNullOrEmpty(txtIdLancamento.Text))
            {
                if (MessageBox.Show("Deseja realmente cancelar este lançamento?", "Confirmação...",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    LancamentoItemNegocios lancamentoItemNegocios = new LancamentoItemNegocios();
                    LancamentoNegocios lancamentoNegocios = new LancamentoNegocios();
                    int IdLan = int.Parse(txtIdLancamento.Text);
                    if (lancamentoItemNegocios.ExcluirLancamento(IdLan) > 0)
                    {
                        if (lancamentoNegocios.ExcluirLancamento(IdLan) > 0)
                        {
                            MessageBox.Show("Lançamento cancelado com sucesso.", "Informação...",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limparTela();
                            if (fecharTela == true)
                                this.Close();
                        }
                        else
                        {
                            MessageBox.Show("O Lançamento não foi encontrado no banco de dados.", "Atenção...",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O Lançamento não foi encontrado no banco de dados.", "Atenção...",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            if (string.IsNullOrEmpty(txtIdLancamento.Text))
            {
                if (fecharTela == true)
                    this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ExcluirLancamento();
        }

        void atualizarGrade()
        {
            int IdLan = int.Parse(txtIdLancamento.Text);
            LancamentoItemColecao lancamentoItemColecao = new LancamentoItemColecao();
            dgvDados.DataSource = null;

            lancamentoItemColecao = lancamentoItemNegocios.ConsultarPorLancamento(IdLan);

            dgvDados.DataSource = lancamentoItemColecao;
            dgvDados.Update();
            dgvDados.Refresh();

            limparProduto();
            txtProduto.Focus();

            lblPrecoLiquido.Text = string.Format("{0:N2}", lancamentoItemNegocios.ValorTotalBruto(IdLan) - lancamentoItemNegocios.ValorTotalDesc(IdLan));
            lblTotalBruto.Text = "R$ " + string.Format("{0:N2}", lancamentoItemNegocios.ValorTotalBruto(IdLan));
            lblTotalItem.Text = lancamentoItemNegocios.QuantidadeItens(IdLan).ToString();
            lblEconomia.Text = "R$ " + string.Format("{0:N2}", lancamentoItemNegocios.ValorTotalDesc(IdLan));
        }

        void apagarItem()
        {
            int IdLan = int.Parse(txtIdLancamento.Text);
            LancamentoItem lancamentoItemSelecionado = (dgvDados.SelectedRows[0].DataBoundItem as LancamentoItem);
            LancamentoItemNegocios lancamentoItemNegocios = new LancamentoItemNegocios();

            if (lancamentoItemNegocios.ExcluirItem(IdLan, lancamentoItemSelecionado.Produto.IdProduto) > 0)
            {
                MessageBox.Show("Item excluído com sucesso.", "Informação...",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                atualizarGrade();
            }
            else
            {
                MessageBox.Show("O item selecionado não foi encontrado no banco de dados.", "Atenção...",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvDados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Subtract)
            {
                if (dgvDados.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Nenhum item selecionado.", "Informação...",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Deseja realmente excluir este item?", "Confirmação...",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        apagarItem();
                    }
                }
            }
            if (e.KeyCode == Keys.F6)
            {
                //int IdLan = int.Parse(txtIdLancamento.Text);
                LancamentoItem lancamentoItemSelecionado = (dgvDados.SelectedRows[0].DataBoundItem as LancamentoItem);
                txtProduto.Text = lancamentoItemSelecionado.Produto.IdProduto.ToString();
                lblDescriProduto.Text = lancamentoItemSelecionado.Produto.Descricao;
                txtQtde.Text = lancamentoItemSelecionado.Quantidade.ToString();
                txtPrecoVenda.Text = lancamentoItemSelecionado.PrecoUnitario.ToString();
                txtQtde.Focus();
                txtProduto.ReadOnly = true;
                alterarQuantidadeEDesconto = true;
            }
        }

        private void btnFinalizaVenda_Click(object sender, EventArgs e)
        {
            LancamentoNegocios lancamentoNegocios = new LancamentoNegocios();
            int IdLan = int.Parse(txtIdLancamento.Text);
            decimal valorTotal = decimal.Parse(lblPrecoLiquido.Text);

            if (lancamentoNegocios.AtualizarValorTotal(IdLan, valorTotal) > 0)
            {
                if (tipoLancamentoSelecionada == TipoLancamento.Venda)
                {
                    FrmPagamento frm = new FrmPagamento(IdLan, valorTotal);
                    DialogResult dialogResult = frm.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        lancamentoNegocios.TruncarTabelaAux();
                        lancamentoNegocios.PopularTabelaAux();
                        FrmCupomVenda frmCupom = new FrmCupomVenda(IdLan);
                        frmCupom.ShowDialog();
                    } 
                }
                MessageBox.Show("Lançamento finalizado com sucesso.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparTela();
            }
            else
            {
                MessageBox.Show("O Lançamento não foi encontrado no banco de dados.", "Atenção...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}