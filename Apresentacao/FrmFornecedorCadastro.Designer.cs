namespace Apresentacao
{
    partial class FrmFornecedorCadastro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBtnDados = new System.Windows.Forms.Label();
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.lblTituloTela = new System.Windows.Forms.Label();
            this.ptbIcon = new System.Windows.Forms.PictureBox();
            this.ptbMinimaze = new System.Windows.Forms.PictureBox();
            this.ptbMaximaze = new System.Windows.Forms.PictureBox();
            this.ptbClose = new System.Windows.Forms.PictureBox();
            this.pnlManter = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlDados = new System.Windows.Forms.Panel();
            this.txtIdUserAlteracao = new System.Windows.Forms.TextBox();
            this.txtIdUserCadastro = new System.Windows.Forms.TextBox();
            this.mskDAlteracao = new System.Windows.Forms.MaskedTextBox();
            this.mskDCadastro = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNomeUserAlteracao = new System.Windows.Forms.TextBox();
            this.txtNomeUserCadastro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.cbxAtivo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mskDReg = new System.Windows.Forms.MaskedTextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.lblApelido = new System.Windows.Forms.Label();
            this.txtNomeFantasia = new System.Windows.Forms.TextBox();
            this.lblRg = new System.Windows.Forms.Label();
            this.txtIe = new System.Windows.Forms.TextBox();
            this.lblCpf = new System.Windows.Forms.Label();
            this.txtCnpj = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBtnContato = new System.Windows.Forms.Label();
            this.pnlContato = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMinimaze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMaximaze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbClose)).BeginInit();
            this.pnlManter.SuspendLayout();
            this.pnlDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBtnDados
            // 
            this.lblBtnDados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBtnDados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(129)))), ((int)(((byte)(140)))));
            this.lblBtnDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBtnDados.ForeColor = System.Drawing.Color.White;
            this.lblBtnDados.Location = new System.Drawing.Point(23, 65);
            this.lblBtnDados.Name = "lblBtnDados";
            this.lblBtnDados.Size = new System.Drawing.Size(116, 39);
            this.lblBtnDados.TabIndex = 44;
            this.lblBtnDados.Text = "Dados";
            this.lblBtnDados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBtnDados.Click += new System.EventHandler(this.lblBtnDados_Click);
            // 
            // pnlTopo
            // 
            this.pnlTopo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(129)))), ((int)(((byte)(140)))));
            this.pnlTopo.Controls.Add(this.lblTituloTela);
            this.pnlTopo.Controls.Add(this.ptbIcon);
            this.pnlTopo.Controls.Add(this.ptbMinimaze);
            this.pnlTopo.Controls.Add(this.ptbMaximaze);
            this.pnlTopo.Controls.Add(this.ptbClose);
            this.pnlTopo.Location = new System.Drawing.Point(13, 13);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(471, 35);
            this.pnlTopo.TabIndex = 47;
            this.pnlTopo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopo_MouseDown);
            // 
            // lblTituloTela
            // 
            this.lblTituloTela.AutoSize = true;
            this.lblTituloTela.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTela.ForeColor = System.Drawing.Color.White;
            this.lblTituloTela.Location = new System.Drawing.Point(37, 6);
            this.lblTituloTela.Name = "lblTituloTela";
            this.lblTituloTela.Size = new System.Drawing.Size(224, 25);
            this.lblTituloTela.TabIndex = 16;
            this.lblTituloTela.Text = "Cadastro de Fornecedor";
            this.lblTituloTela.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopo_MouseDown);
            // 
            // ptbIcon
            // 
            this.ptbIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbIcon.Image = global::Apresentacao.Properties.Resources.icons8_Trolley_30px_1___Copia;
            this.ptbIcon.Location = new System.Drawing.Point(3, 3);
            this.ptbIcon.Name = "ptbIcon";
            this.ptbIcon.Size = new System.Drawing.Size(28, 28);
            this.ptbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbIcon.TabIndex = 15;
            this.ptbIcon.TabStop = false;
            // 
            // ptbMinimaze
            // 
            this.ptbMinimaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbMinimaze.BackColor = System.Drawing.Color.Transparent;
            this.ptbMinimaze.Image = global::Apresentacao.Properties.Resources.icons8_Minimize_Window_28px1;
            this.ptbMinimaze.Location = new System.Drawing.Point(381, 3);
            this.ptbMinimaze.Name = "ptbMinimaze";
            this.ptbMinimaze.Size = new System.Drawing.Size(28, 28);
            this.ptbMinimaze.TabIndex = 14;
            this.ptbMinimaze.TabStop = false;
            this.ptbMinimaze.Visible = false;
            // 
            // ptbMaximaze
            // 
            this.ptbMaximaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbMaximaze.BackColor = System.Drawing.Color.Transparent;
            this.ptbMaximaze.Image = global::Apresentacao.Properties.Resources.icons8_Maximize_Window_28px1;
            this.ptbMaximaze.Location = new System.Drawing.Point(410, 3);
            this.ptbMaximaze.Name = "ptbMaximaze";
            this.ptbMaximaze.Size = new System.Drawing.Size(28, 28);
            this.ptbMaximaze.TabIndex = 13;
            this.ptbMaximaze.TabStop = false;
            this.ptbMaximaze.Visible = false;
            // 
            // ptbClose
            // 
            this.ptbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbClose.BackColor = System.Drawing.Color.Transparent;
            this.ptbClose.Image = global::Apresentacao.Properties.Resources.icons8_Close_Window_28px_11;
            this.ptbClose.Location = new System.Drawing.Point(439, 3);
            this.ptbClose.Name = "ptbClose";
            this.ptbClose.Size = new System.Drawing.Size(28, 28);
            this.ptbClose.TabIndex = 12;
            this.ptbClose.TabStop = false;
            this.ptbClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptbClose_MouseClick);
            this.ptbClose.MouseLeave += new System.EventHandler(this.ptbClose_MouseLeave);
            this.ptbClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbClose_MouseMove);
            // 
            // pnlManter
            // 
            this.pnlManter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlManter.BackColor = System.Drawing.Color.White;
            this.pnlManter.Controls.Add(this.btnSalvar);
            this.pnlManter.Controls.Add(this.btnCancelar);
            this.pnlManter.Location = new System.Drawing.Point(13, 499);
            this.pnlManter.Name = "pnlManter";
            this.pnlManter.Size = new System.Drawing.Size(471, 34);
            this.pnlManter.TabIndex = 46;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.BackgroundImage = global::Apresentacao.Properties.Resources.icons8_Save_30px;
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Location = new System.Drawing.Point(438, 3);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(30, 28);
            this.btnSalvar.TabIndex = 22;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackgroundImage = global::Apresentacao.Properties.Resources.icons8_Unavailable_30px;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(402, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(30, 28);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // pnlDados
            // 
            this.pnlDados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlDados.BackColor = System.Drawing.Color.White;
            this.pnlDados.Controls.Add(this.txtIdUserAlteracao);
            this.pnlDados.Controls.Add(this.txtIdUserCadastro);
            this.pnlDados.Controls.Add(this.mskDAlteracao);
            this.pnlDados.Controls.Add(this.mskDCadastro);
            this.pnlDados.Controls.Add(this.label7);
            this.pnlDados.Controls.Add(this.label5);
            this.pnlDados.Controls.Add(this.txtNomeUserAlteracao);
            this.pnlDados.Controls.Add(this.txtNomeUserCadastro);
            this.pnlDados.Controls.Add(this.label3);
            this.pnlDados.Controls.Add(this.txtObs);
            this.pnlDados.Controls.Add(this.cbxAtivo);
            this.pnlDados.Controls.Add(this.label1);
            this.pnlDados.Controls.Add(this.mskDReg);
            this.pnlDados.Controls.Add(this.lblData);
            this.pnlDados.Controls.Add(this.lblApelido);
            this.pnlDados.Controls.Add(this.txtNomeFantasia);
            this.pnlDados.Controls.Add(this.lblRg);
            this.pnlDados.Controls.Add(this.txtIe);
            this.pnlDados.Controls.Add(this.lblCpf);
            this.pnlDados.Controls.Add(this.txtCnpj);
            this.pnlDados.Controls.Add(this.lblNome);
            this.pnlDados.Controls.Add(this.txtRazaoSocial);
            this.pnlDados.Controls.Add(this.txtId);
            this.pnlDados.Controls.Add(this.label2);
            this.pnlDados.Location = new System.Drawing.Point(12, 95);
            this.pnlDados.Name = "pnlDados";
            this.pnlDados.Size = new System.Drawing.Size(471, 399);
            this.pnlDados.TabIndex = 43;
            // 
            // txtIdUserAlteracao
            // 
            this.txtIdUserAlteracao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtIdUserAlteracao.Location = new System.Drawing.Point(13, 366);
            this.txtIdUserAlteracao.Name = "txtIdUserAlteracao";
            this.txtIdUserAlteracao.ReadOnly = true;
            this.txtIdUserAlteracao.Size = new System.Drawing.Size(60, 20);
            this.txtIdUserAlteracao.TabIndex = 51;
            this.txtIdUserAlteracao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIdUserCadastro
            // 
            this.txtIdUserCadastro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtIdUserCadastro.Location = new System.Drawing.Point(13, 317);
            this.txtIdUserCadastro.Name = "txtIdUserCadastro";
            this.txtIdUserCadastro.ReadOnly = true;
            this.txtIdUserCadastro.Size = new System.Drawing.Size(60, 20);
            this.txtIdUserCadastro.TabIndex = 50;
            this.txtIdUserCadastro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mskDAlteracao
            // 
            this.mskDAlteracao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mskDAlteracao.Location = new System.Drawing.Point(347, 366);
            this.mskDAlteracao.Mask = "00/00/0000 90:00";
            this.mskDAlteracao.Name = "mskDAlteracao";
            this.mskDAlteracao.ReadOnly = true;
            this.mskDAlteracao.Size = new System.Drawing.Size(106, 20);
            this.mskDAlteracao.TabIndex = 45;
            this.mskDAlteracao.ValidatingType = typeof(System.DateTime);
            // 
            // mskDCadastro
            // 
            this.mskDCadastro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mskDCadastro.Location = new System.Drawing.Point(347, 317);
            this.mskDCadastro.Mask = "00/00/0000 90:00";
            this.mskDCadastro.Name = "mskDCadastro";
            this.mskDCadastro.ReadOnly = true;
            this.mskDCadastro.Size = new System.Drawing.Size(106, 20);
            this.mskDCadastro.TabIndex = 49;
            this.mskDCadastro.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 350);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Alteração";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Cadastro";
            // 
            // txtNomeUserAlteracao
            // 
            this.txtNomeUserAlteracao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNomeUserAlteracao.Location = new System.Drawing.Point(79, 366);
            this.txtNomeUserAlteracao.Name = "txtNomeUserAlteracao";
            this.txtNomeUserAlteracao.ReadOnly = true;
            this.txtNomeUserAlteracao.Size = new System.Drawing.Size(262, 20);
            this.txtNomeUserAlteracao.TabIndex = 40;
            // 
            // txtNomeUserCadastro
            // 
            this.txtNomeUserCadastro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNomeUserCadastro.Location = new System.Drawing.Point(79, 317);
            this.txtNomeUserCadastro.Name = "txtNomeUserCadastro";
            this.txtNomeUserCadastro.ReadOnly = true;
            this.txtNomeUserCadastro.Size = new System.Drawing.Size(262, 20);
            this.txtNomeUserCadastro.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Observação";
            // 
            // txtObs
            // 
            this.txtObs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtObs.Location = new System.Drawing.Point(13, 188);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(440, 101);
            this.txtObs.TabIndex = 44;
            // 
            // cbxAtivo
            // 
            this.cbxAtivo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbxAtivo.FormattingEnabled = true;
            this.cbxAtivo.Items.AddRange(new object[] {
            "SIM",
            "NÃO"});
            this.cbxAtivo.Location = new System.Drawing.Point(367, 47);
            this.cbxAtivo.Name = "cbxAtivo";
            this.cbxAtivo.Size = new System.Drawing.Size(86, 21);
            this.cbxAtivo.TabIndex = 43;
            this.cbxAtivo.Text = "SIM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Ativo";
            // 
            // mskDReg
            // 
            this.mskDReg.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mskDReg.Location = new System.Drawing.Point(379, 142);
            this.mskDReg.Mask = "00/00/0000";
            this.mskDReg.Name = "mskDReg";
            this.mskDReg.Size = new System.Drawing.Size(74, 20);
            this.mskDReg.TabIndex = 39;
            this.mskDReg.ValidatingType = typeof(System.DateTime);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(376, 126);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(60, 13);
            this.lblData.TabIndex = 38;
            this.lblData.Text = "D. Registro";
            // 
            // lblApelido
            // 
            this.lblApelido.AutoSize = true;
            this.lblApelido.Location = new System.Drawing.Point(10, 126);
            this.lblApelido.Name = "lblApelido";
            this.lblApelido.Size = new System.Drawing.Size(78, 13);
            this.lblApelido.TabIndex = 37;
            this.lblApelido.Text = "Nome Fantasia";
            // 
            // txtNomeFantasia
            // 
            this.txtNomeFantasia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNomeFantasia.Location = new System.Drawing.Point(13, 142);
            this.txtNomeFantasia.Name = "txtNomeFantasia";
            this.txtNomeFantasia.Size = new System.Drawing.Size(360, 20);
            this.txtNomeFantasia.TabIndex = 36;
            // 
            // lblRg
            // 
            this.lblRg.AutoSize = true;
            this.lblRg.Location = new System.Drawing.Point(248, 32);
            this.lblRg.Name = "lblRg";
            this.lblRg.Size = new System.Drawing.Size(17, 13);
            this.lblRg.TabIndex = 35;
            this.lblRg.Text = "IE";
            // 
            // txtIe
            // 
            this.txtIe.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtIe.Location = new System.Drawing.Point(251, 48);
            this.txtIe.Name = "txtIe";
            this.txtIe.Size = new System.Drawing.Size(110, 20);
            this.txtIe.TabIndex = 34;
            this.txtIe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.Location = new System.Drawing.Point(132, 32);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(34, 13);
            this.lblCpf.TabIndex = 33;
            this.lblCpf.Text = "CNPJ";
            // 
            // txtCnpj
            // 
            this.txtCnpj.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCnpj.Location = new System.Drawing.Point(135, 48);
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(110, 20);
            this.txtCnpj.TabIndex = 32;
            this.txtCnpj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(10, 79);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(70, 13);
            this.lblNome.TabIndex = 29;
            this.lblNome.Text = "Razão Social";
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRazaoSocial.Location = new System.Drawing.Point(13, 95);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Size = new System.Drawing.Size(440, 20);
            this.txtRazaoSocial.TabIndex = 28;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtId.Location = new System.Drawing.Point(13, 48);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(60, 20);
            this.txtId.TabIndex = 27;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Código";
            // 
            // lblBtnContato
            // 
            this.lblBtnContato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBtnContato.BackColor = System.Drawing.Color.LightGray;
            this.lblBtnContato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBtnContato.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(129)))), ((int)(((byte)(140)))));
            this.lblBtnContato.Location = new System.Drawing.Point(145, 65);
            this.lblBtnContato.Name = "lblBtnContato";
            this.lblBtnContato.Size = new System.Drawing.Size(116, 39);
            this.lblBtnContato.TabIndex = 45;
            this.lblBtnContato.Text = "Contato";
            this.lblBtnContato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBtnContato.Click += new System.EventHandler(this.lblBtnContatoClick);
            this.lblBtnContato.MouseLeave += new System.EventHandler(this.lblBtnContatoMouseLeave);
            this.lblBtnContato.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblBtnContatoMouseMove);
            // 
            // pnlContato
            // 
            this.pnlContato.BackColor = System.Drawing.SystemColors.Control;
            this.pnlContato.Location = new System.Drawing.Point(506, 54);
            this.pnlContato.Name = "pnlContato";
            this.pnlContato.Size = new System.Drawing.Size(471, 439);
            this.pnlContato.TabIndex = 48;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(496, 1);
            this.panel4.TabIndex = 51;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Location = new System.Drawing.Point(495, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 546);
            this.panel3.TabIndex = 50;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 546);
            this.panel2.TabIndex = 49;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DimGray;
            this.panel5.Location = new System.Drawing.Point(0, 545);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(496, 1);
            this.panel5.TabIndex = 52;
            // 
            // FrmFornecedorCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 546);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlContato);
            this.Controls.Add(this.lblBtnDados);
            this.Controls.Add(this.pnlTopo);
            this.Controls.Add(this.pnlManter);
            this.Controls.Add(this.pnlDados);
            this.Controls.Add(this.lblBtnContato);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmFornecedorCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFornecedorCadastro";
            this.Load += new System.EventHandler(this.FrmFornecedorCadastro_Load);
            this.pnlTopo.ResumeLayout(false);
            this.pnlTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMinimaze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMaximaze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbClose)).EndInit();
            this.pnlManter.ResumeLayout(false);
            this.pnlDados.ResumeLayout(false);
            this.pnlDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBtnDados;
        private System.Windows.Forms.Panel pnlTopo;
        private System.Windows.Forms.Label lblTituloTela;
        private System.Windows.Forms.PictureBox ptbIcon;
        private System.Windows.Forms.PictureBox ptbMinimaze;
        private System.Windows.Forms.PictureBox ptbMaximaze;
        private System.Windows.Forms.PictureBox ptbClose;
        private System.Windows.Forms.Panel pnlManter;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlDados;
        private System.Windows.Forms.Label lblBtnContato;
        private System.Windows.Forms.TextBox txtIdUserAlteracao;
        private System.Windows.Forms.TextBox txtIdUserCadastro;
        private System.Windows.Forms.MaskedTextBox mskDAlteracao;
        private System.Windows.Forms.MaskedTextBox mskDCadastro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNomeUserAlteracao;
        private System.Windows.Forms.TextBox txtNomeUserCadastro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.ComboBox cbxAtivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mskDReg;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblApelido;
        private System.Windows.Forms.TextBox txtNomeFantasia;
        private System.Windows.Forms.Label lblRg;
        private System.Windows.Forms.TextBox txtIe;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.TextBox txtCnpj;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtRazaoSocial;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlContato;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
    }
}