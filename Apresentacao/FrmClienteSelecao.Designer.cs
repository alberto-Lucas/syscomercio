namespace Apresentacao
{
    partial class FrmClienteSelecao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClienteSelecao));
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvRegistros = new System.Windows.Forms.DataGridView();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.lblTituloTela = new System.Windows.Forms.Label();
            this.ptbIcon = new System.Windows.Forms.PictureBox();
            this.ptbMinimaze = new System.Windows.Forms.PictureBox();
            this.ptbMaximaze = new System.Windows.Forms.PictureBox();
            this.ptbClose = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.IdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeRazaoSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApelidoNomeFantasia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CpfCnpj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RgIe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataNascimentoRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMinimaze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMaximaze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(0)))));
            this.pnlGrid.Controls.Add(this.dgvRegistros);
            this.pnlGrid.Location = new System.Drawing.Point(12, 96);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(922, 425);
            this.pnlGrid.TabIndex = 10;
            // 
            // dgvRegistros
            // 
            this.dgvRegistros.AllowUserToAddRows = false;
            this.dgvRegistros.AllowUserToDeleteRows = false;
            this.dgvRegistros.AllowUserToResizeColumns = false;
            this.dgvRegistros.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Moccasin;
            this.dgvRegistros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegistros.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRegistros.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvRegistros.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegistros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdCliente,
            this.TipoPessoa,
            this.NomeRazaoSocial,
            this.ApelidoNomeFantasia,
            this.CpfCnpj,
            this.RgIe,
            this.DataNascimentoRegistro,
            this.Ativo});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRegistros.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRegistros.EnableHeadersVisualStyles = false;
            this.dgvRegistros.Location = new System.Drawing.Point(3, 3);
            this.dgvRegistros.MultiSelect = false;
            this.dgvRegistros.Name = "dgvRegistros";
            this.dgvRegistros.ReadOnly = true;
            this.dgvRegistros.RowHeadersVisible = false;
            this.dgvRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistros.Size = new System.Drawing.Size(916, 419);
            this.dgvRegistros.TabIndex = 0;
            this.dgvRegistros.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistros_CellDoubleClick);
            this.dgvRegistros.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRegistros_CellFormatting);
            // 
            // lblRegistro
            // 
            this.lblRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.Location = new System.Drawing.Point(165, 8);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(16, 17);
            this.lblRegistro.TabIndex = 16;
            this.lblRegistro.Text = "0";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Registros Encontrados:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSelecionar);
            this.panel1.Controls.Add(this.btnVisualizar);
            this.panel1.Controls.Add(this.btnInserir);
            this.panel1.Controls.Add(this.btnAlterar);
            this.panel1.Controls.Add(this.btnExcluir);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblRegistro);
            this.panel1.Location = new System.Drawing.Point(12, 527);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(922, 34);
            this.panel1.TabIndex = 17;
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelecionar.BackgroundImage = global::Apresentacao.Properties.Resources.icons8_Check_File_30px;
            this.btnSelecionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelecionar.FlatAppearance.BorderSize = 0;
            this.btnSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionar.Location = new System.Drawing.Point(742, 2);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(30, 30);
            this.btnSelecionar.TabIndex = 21;
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Visible = false;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizar.BackgroundImage = global::Apresentacao.Properties.Resources.icons8_View_30px;
            this.btnVisualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVisualizar.FlatAppearance.BorderSize = 0;
            this.btnVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualizar.Location = new System.Drawing.Point(886, 2);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(30, 30);
            this.btnVisualizar.TabIndex = 20;
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInserir.BackgroundImage = global::Apresentacao.Properties.Resources.icons8_New_Copy_30px;
            this.btnInserir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnInserir.FlatAppearance.BorderSize = 0;
            this.btnInserir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInserir.Location = new System.Drawing.Point(778, 2);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(30, 30);
            this.btnInserir.TabIndex = 19;
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlterar.BackgroundImage = global::Apresentacao.Properties.Resources.icons8_Edit_File_30px;
            this.btnAlterar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAlterar.FlatAppearance.BorderSize = 0;
            this.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlterar.Location = new System.Drawing.Point(814, 2);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(30, 30);
            this.btnAlterar.TabIndex = 18;
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.BackgroundImage = global::Apresentacao.Properties.Resources.icons8_Delete_File_30px;
            this.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Location = new System.Drawing.Point(850, 2);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(30, 30);
            this.btnExcluir.TabIndex = 17;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnPesquisar);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.txtCliente);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(12, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(922, 47);
            this.panel3.TabIndex = 18;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPesquisar.BackgroundImage = global::Apresentacao.Properties.Resources.icons8_Search_30px;
            this.btnPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisar.FlatAppearance.BorderSize = 0;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Location = new System.Drawing.Point(884, 8);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(30, 30);
            this.btnPesquisar.TabIndex = 11;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(914, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(8, 100);
            this.panel8.TabIndex = 0;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.White;
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(10, 14);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(872, 19);
            this.txtCliente.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(2113, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = resources.GetString("label10.Text");
            // 
            // pnlTopo
            // 
            this.pnlTopo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTopo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(0)))));
            this.pnlTopo.Controls.Add(this.lblTituloTela);
            this.pnlTopo.Controls.Add(this.ptbIcon);
            this.pnlTopo.Controls.Add(this.ptbMinimaze);
            this.pnlTopo.Controls.Add(this.ptbMaximaze);
            this.pnlTopo.Controls.Add(this.ptbClose);
            this.pnlTopo.Location = new System.Drawing.Point(12, 6);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(922, 35);
            this.pnlTopo.TabIndex = 19;
            this.pnlTopo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopo_MouseDown);
            // 
            // lblTituloTela
            // 
            this.lblTituloTela.AutoSize = true;
            this.lblTituloTela.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTela.ForeColor = System.Drawing.Color.White;
            this.lblTituloTela.Location = new System.Drawing.Point(37, 6);
            this.lblTituloTela.Name = "lblTituloTela";
            this.lblTituloTela.Size = new System.Drawing.Size(195, 25);
            this.lblTituloTela.TabIndex = 16;
            this.lblTituloTela.Text = "Cadastro de Clientes";
            this.lblTituloTela.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopo_MouseDown);
            // 
            // ptbIcon
            // 
            this.ptbIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbIcon.Image = global::Apresentacao.Properties.Resources.icons8_User_30px_10;
            this.ptbIcon.Location = new System.Drawing.Point(3, 3);
            this.ptbIcon.Name = "ptbIcon";
            this.ptbIcon.Size = new System.Drawing.Size(28, 28);
            this.ptbIcon.TabIndex = 15;
            this.ptbIcon.TabStop = false;
            // 
            // ptbMinimaze
            // 
            this.ptbMinimaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbMinimaze.BackColor = System.Drawing.Color.Transparent;
            this.ptbMinimaze.Image = global::Apresentacao.Properties.Resources.icons8_Minimize_Window_28px1;
            this.ptbMinimaze.Location = new System.Drawing.Point(832, 3);
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
            this.ptbMaximaze.Location = new System.Drawing.Point(861, 3);
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
            this.ptbClose.Location = new System.Drawing.Point(890, 3);
            this.ptbClose.Name = "ptbClose";
            this.ptbClose.Size = new System.Drawing.Size(28, 28);
            this.ptbClose.TabIndex = 12;
            this.ptbClose.TabStop = false;
            this.ptbClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptbClose_MouseClick);
            this.ptbClose.MouseLeave += new System.EventHandler(this.ptbClose_MouseLeave);
            this.ptbClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbClose_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(946, 573);
            this.panel2.TabIndex = 20;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // IdCliente
            // 
            this.IdCliente.DataPropertyName = "IdCliente";
            this.IdCliente.HeaderText = "Código";
            this.IdCliente.Name = "IdCliente";
            this.IdCliente.ReadOnly = true;
            this.IdCliente.Width = 65;
            // 
            // TipoPessoa
            // 
            this.TipoPessoa.DataPropertyName = "TipoPessoa";
            this.TipoPessoa.HeaderText = "T.Pessoa";
            this.TipoPessoa.Name = "TipoPessoa";
            this.TipoPessoa.ReadOnly = true;
            this.TipoPessoa.Width = 80;
            // 
            // NomeRazaoSocial
            // 
            this.NomeRazaoSocial.DataPropertyName = "NomeRazaoSocial";
            this.NomeRazaoSocial.HeaderText = "Nome / Razão Social";
            this.NomeRazaoSocial.Name = "NomeRazaoSocial";
            this.NomeRazaoSocial.ReadOnly = true;
            this.NomeRazaoSocial.Width = 400;
            // 
            // ApelidoNomeFantasia
            // 
            this.ApelidoNomeFantasia.DataPropertyName = "ApelidoNomeFantasia";
            this.ApelidoNomeFantasia.HeaderText = "Apelido / Nome Fantasia";
            this.ApelidoNomeFantasia.Name = "ApelidoNomeFantasia";
            this.ApelidoNomeFantasia.ReadOnly = true;
            this.ApelidoNomeFantasia.Width = 300;
            // 
            // CpfCnpj
            // 
            this.CpfCnpj.DataPropertyName = "CpfCnpj";
            this.CpfCnpj.HeaderText = "CPF /CNPJ";
            this.CpfCnpj.Name = "CpfCnpj";
            this.CpfCnpj.ReadOnly = true;
            this.CpfCnpj.Width = 140;
            // 
            // RgIe
            // 
            this.RgIe.DataPropertyName = "RgIe";
            this.RgIe.HeaderText = "RG/IE";
            this.RgIe.Name = "RgIe";
            this.RgIe.ReadOnly = true;
            this.RgIe.Width = 120;
            // 
            // DataNascimentoRegistro
            // 
            this.DataNascimentoRegistro.DataPropertyName = "DataNascimentoRegistro";
            this.DataNascimentoRegistro.HeaderText = "D.Nas/Reg";
            this.DataNascimentoRegistro.Name = "DataNascimentoRegistro";
            this.DataNascimentoRegistro.ReadOnly = true;
            this.DataNascimentoRegistro.Width = 90;
            // 
            // Ativo
            // 
            this.Ativo.DataPropertyName = "Ativo";
            this.Ativo.HeaderText = "Ativo";
            this.Ativo.Name = "Ativo";
            this.Ativo.ReadOnly = true;
            this.Ativo.Width = 60;
            // 
            // FrmClienteSelecao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(946, 573);
            this.Controls.Add(this.pnlTopo);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "FrmClienteSelecao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSelecaoCliente";
            this.Load += new System.EventHandler(this.FrmClienteSelecao_Load);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlTopo.ResumeLayout(false);
            this.pnlTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMinimaze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMaximaze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvRegistros;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Panel pnlTopo;
        private System.Windows.Forms.Label lblTituloTela;
        private System.Windows.Forms.PictureBox ptbIcon;
        private System.Windows.Forms.PictureBox ptbMinimaze;
        private System.Windows.Forms.PictureBox ptbMaximaze;
        private System.Windows.Forms.PictureBox ptbClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeRazaoSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApelidoNomeFantasia;
        private System.Windows.Forms.DataGridViewTextBoxColumn CpfCnpj;
        private System.Windows.Forms.DataGridViewTextBoxColumn RgIe;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataNascimentoRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ativo;
    }
}