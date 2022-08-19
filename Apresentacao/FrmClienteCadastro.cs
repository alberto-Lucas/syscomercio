using Negocios;
using ObjetoTransferencia;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmClienteCadastro : Form
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

        public FrmClienteCadastro(int acaoNaTela, Cliente cliente)
        {
            InitializeComponent();
            #region Tab
            this.pnlDadosCliente.Location = new System.Drawing.Point(12, 95);
            pnlContatoCliente.Location = new System.Drawing.Point(12, 95);
            pnlEnderecoCliente.Location = new System.Drawing.Point(12, 95);
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
                        lblTituloTela.Text = "Inserir Cliente";
                        //pessoa_f();
                        //rdbFisica.Checked = true;
                        //pesquisarCidadePorEstado();
                        //cbxAtivo.Text = "S";
                    }
                    break;
                case 2:
                    {
                        lblTituloTela.Text = "Alterar Cliente";
                        string tipoPessoas = cliente.TipoPessoa.ToString();
                        if (tipoPessoas.Equals("J"))
                        {
                            tipoPessoa = false;
                            habilitaTipoPessoa(2);
                        }
                        else
                        {
                            tipoPessoa = true;
                            habilitaTipoPessoa(1);
                        }

                        string ativo = cliente.Ativo;
                        if (ativo.Equals("S"))
                        {
                            cbxAtivo.Text = "SIM";
                        }
                        else
                        {
                            cbxAtivo.Text = "NÃO";
                        }
                        

                        txtId.Text = cliente.IdCliente.ToString();
                        txtNomeRazao.Text = cliente.NomeRazaoSocial.ToString();
                        txtApelidoFantasia.Text = cliente.ApelidoNomeFantasia.ToString();
                        txtCpfCnpj.Text = cliente.CpfCnpj.ToString();
                        txtRgIe.Text = cliente.RgIe.ToString();
                        txtObs.Text = cliente.Observacao;
                        mskDNasReg.Text = cliente.DataNascimentoRegistro.ToString();
                        mskDCadastro.Text = cliente.DataCadastro.ToString();
                        mskDAlteracao.Text = cliente.DataAlteracao.ToString();
                        txtIdUserCadastro.Text = cliente.UsuarioCadastro.IdUsuario.ToString();
                        txtIdUserAlteracao.Text = cliente.UsuarioAlteracao.IdUsuario.ToString();
                        txtNomeUserCadastro.Text = cliente.UsuarioCadastro.Nome;
                        txtNomeUserAlteracao.Text = cliente.UsuarioAlteracao.Nome;
                    }
                    break;
                case 3:
                    {
                        visualizar();

                        lblTituloTela.Text = "Visualizar Cliente";
                        string tipoPessoas = cliente.TipoPessoa.ToString();
                        if (tipoPessoas.Equals("J"))
                        {
                            tipoPessoa = false;
                            habilitaTipoPessoa(2);
                        }
                        else
                        {
                            tipoPessoa = true;
                            habilitaTipoPessoa(1);
                        }

                        string ativo = cliente.Ativo;
                        if (ativo.Equals("S"))
                        {
                            cbxAtivo.Text = "SIM";
                        }
                        else
                        {
                            cbxAtivo.Text = "NÃO";
                        }



                        txtId.Text = cliente.IdCliente.ToString();
                        txtNomeRazao.Text = cliente.NomeRazaoSocial.ToString();
                        txtApelidoFantasia.Text = cliente.ApelidoNomeFantasia.ToString();
                        txtCpfCnpj.Text = cliente.CpfCnpj.ToString();
                        txtRgIe.Text = cliente.RgIe.ToString();
                        txtObs.Text = cliente.Observacao;
                        mskDNasReg.Text = cliente.DataNascimentoRegistro.ToString();
                        mskDCadastro.Text = cliente.DataCadastro.ToString();
                        mskDAlteracao.Text = cliente.DataAlteracao.ToString();
                        txtIdUserCadastro.Text = cliente.UsuarioCadastro.IdUsuario.ToString();
                        txtIdUserAlteracao.Text = cliente.UsuarioAlteracao.IdUsuario.ToString();
                        txtNomeUserCadastro.Text = cliente.UsuarioCadastro.Nome;
                        txtNomeUserAlteracao.Text = cliente.UsuarioAlteracao.Nome;
                    }
                    break;
            }
        }
        public void visualizar()
        {
            txtId.ReadOnly = true;
            txtNomeRazao.ReadOnly = true;
            txtApelidoFantasia.ReadOnly = true;
            txtCpfCnpj.ReadOnly = true;
            txtRgIe.ReadOnly = true;
            txtObs.ReadOnly = true;
            mskDNasReg.ReadOnly = true;
            cbxAtivo.Enabled = false;
            ptbTipoPessoa.Enabled = false;

            btnSalvar.Visible = false;
            btnCancelar.Visible = false;
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
                lblBtnDados.ForeColor = Color.FromArgb(255, 177, 0);
            }

            if (mouseLeave == 2)
            {
                lblBtnContato.BackColor = Color.LightGray;
                lblBtnContato.ForeColor = Color.FromArgb(255, 177, 0);
            }

            if (mouseLeave == 3)
            {
                lblBtnEndereco.BackColor = Color.LightGray;
                lblBtnEndereco.ForeColor = Color.FromArgb(255, 177, 0);
            }
            
        }
        void MouseMoves(int mouseMove)
        {
            if (mouseMove == 1)
            {
                lblBtnDados.BackColor = Color.FromArgb(255, 177, 0);
                lblBtnDados.ForeColor = Color.White;
            }

            if (mouseMove == 2)
            {
                lblBtnContato.BackColor = Color.FromArgb(255, 177, 0);
                lblBtnContato.ForeColor = Color.White;
            }

            if (mouseMove == 3)
            {
                lblBtnEndereco.BackColor = Color.FromArgb(255, 177, 0);
                lblBtnEndereco.ForeColor = Color.White;
            }
        }

        void desabilita()
        {
            if (dados == false)
            {
                lblBtnDados.BackColor = Color.LightGray;
                lblBtnDados.ForeColor = Color.FromArgb(255, 177, 0);
                lblBtnDados.SendToBack();
            }

            if (contato == false)
            {
                lblBtnContato.BackColor = Color.LightGray;
                lblBtnContato.ForeColor = Color.FromArgb(255, 177, 0);
                lblBtnContato.SendToBack();
            }

            if (endereco == false)
            {
                lblBtnEndereco.BackColor = Color.LightGray;
                lblBtnEndereco.ForeColor = Color.FromArgb(255, 177, 0);
                lblBtnEndereco.SendToBack();
            }
        }

        void habilita()
        {
            if (dados == true)
            {
                lblBtnDados.BackColor = Color.FromArgb(255, 177, 0);
                lblBtnDados.ForeColor = Color.White;
                lblBtnDados.BringToFront();
            }

            if (contato == true)
            {
                lblBtnContato.BackColor = Color.FromArgb(255, 177, 0);
                lblBtnContato.ForeColor = Color.White;
                lblBtnContato.BringToFront();
            }

            if (endereco == true)
            {
                lblBtnEndereco.BackColor = Color.FromArgb(255, 177, 0);
                lblBtnEndereco.ForeColor = Color.White;
                lblBtnEndereco.BringToFront();
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
            pnlDadosCliente.Location = new System.Drawing.Point(12, 95);
            pnlDadosCliente.BringToFront();
            pnlManterCliente.BringToFront();
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
            
            pnlContatoCliente.BringToFront();
            habilita();
            desabilita();

            int id = int.Parse(txtId.Text);
            usrTelefone frmContato = new usrTelefone(1, id);
            pnlContatoCliente.Controls.Add(frmContato);
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
            
            pnlEnderecoCliente.BringToFront();
            habilita();
            desabilita();

            int id = int.Parse(txtId.Text);
            usrEndereco frmEndereco = new usrEndereco(1, id);
            pnlEnderecoCliente.Controls.Add(frmEndereco);
        }
        //------FIM-------------------------------------------------
        #endregion

        #region Animação Tipo Pessoa
        //Fisica = True
        //Juridica = False
        bool tipoPessoa = true;
        void habilitaTipoPessoa(int tipoPessoa)
        {
            if (tipoPessoa == 1)
            {
                ptbTipoPessoa.Image = global::Apresentacao.Properties.Resources.icons8_Toggle_On_28px_1;
                lblTipoPessoa.Text = "Física";
                lblNome.Text = "Nome";
                lblCpf.Text = "CPF";
                lblApelido.Text = "Apelido";
                lblRg.Text = "RG";
                lblData.Text = "D. Nascimento";
                pessoaTipo = "F";
            }
            if (tipoPessoa == 2)
            {
                ptbTipoPessoa.Image = global::Apresentacao.Properties.Resources.icons8_Toggle_On_28px;
                lblTipoPessoa.Text = "Jurídica";
                lblNome.Text = "Razão Social";
                lblCpf.Text = "CNPJ";
                lblApelido.Text = "Nome Fantasia";
                lblRg.Text = "IE";
                lblData.Text = "D. Registro";
                pessoaTipo = "J";
            }
        }

        string pessoaTipo;
        private void ptbTipoPessoa_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (tipoPessoa == true)
            {
                tipoPessoa = false;
                habilitaTipoPessoa(2);
                //ptbTipoPessoa.Image = global::Apresentacao.Properties.Resources.icons8_Toggle_On_28px_1;
                //lblTipoPessoa.Text = "Física";
            }

            else //if (tipoPessoa == false)
            {
                tipoPessoa = true;
                habilitaTipoPessoa(1);
                //ptbTipoPessoa.Image = global::Apresentacao.Properties.Resources.icons8_Toggle_On_28px;
                //lblTipoPessoa.Text = "Jurídica";
            }
        }
        #endregion

        private void FrmClienteCadastro_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
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



        private void button1_Click(object sender, EventArgs e)
        {

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
            Cliente cliente = new Cliente();

            string ativo = cbxAtivo.Text;
            if (ativo.Equals("SIM"))
            {
                cliente.Ativo = "S";
            }
            else
            {
                cliente.Ativo = "N";
            }

            if (string.IsNullOrEmpty(pessoaTipo))
            {
                pessoaTipo = "F";
            }


            cliente.NomeRazaoSocial = txtNomeRazao.Text;
            cliente.ApelidoNomeFantasia = txtApelidoFantasia.Text;
            cliente.CpfCnpj = txtCpfCnpj.Text.Replace(".", "");
            cliente.CpfCnpj = cliente.CpfCnpj.Replace("-", "");
            cliente.RgIe = txtRgIe.Text;
            cliente.Observacao = txtObs.Text;

            cliente.TipoPessoa = pessoaTipo;
            //MessageBox.Show("Tipo pessa: " + cliente.TipoPessoa);
       
            DateTime dtNasc;

            //Tenta converter a data de nascimento para DateTime.
            //Se conseguir, atribui para o objeto "cliente".
            if (DateTime.TryParse(mskDNasReg.Text, out dtNasc))
            {
                cliente.DataNascimentoRegistro = dtNasc;
            }
            else
            {

                MessageBox.Show("Digite uma data de nascimento/registro válida.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                mskDNasReg.Focus();

                return;
            }

            ClienteNegocios clienteNegocios = new ClienteNegocios();


            //Inserir
            if (acaoNaTelaSelecionada == 1)
            {
                //O método "Inserir" retorna o ID do cliente inserido.
                int IdCliente = clienteNegocios.Inserir(cliente);

                //Se o ID for maior que zero significa que a inclusão deu certo.
                if (IdCliente > 0)
                {
                    //Exibe no campo da tela o ID do cliente inserido.
                    txtId.Text = IdCliente.ToString();

                    MessageBox.Show("Cliente inserido com sucesso.", "Informação",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Quando essa linha for executada a tela será fechada
                    //(da mesma forma que o comando Close() faz), porém,
                    //ela retornará que o botão "Salvar" foi clicado.
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Não foi possível inserir o cliente. " +
                        "Verifique a conexão com o banco de dados.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else //Alterar
            {
                //Para alterar o cliente é necessário que o objeto tenha
                //o ID do cliente.
                cliente.IdCliente = int.Parse(txtId.Text);

                //O comando Alterar retorna quantas linhas foram alteradas.
                int linhasAlteradas = clienteNegocios.Alterar(cliente);

                if (linhasAlteradas > 0)
                {
                    MessageBox.Show("Cliente alterado com sucesso.", "Informação",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("O cliente não foi encontrado.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        } 
    }
}
