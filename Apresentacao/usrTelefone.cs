using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Negocios;
using ObjetoTransferencia;

namespace Apresentacao
{
    public partial class usrTelefone : UserControl
    {
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
        private void dgvContato_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvContato.Rows[e.RowIndex].DataBoundItem != null) && (dgvContato.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvContato.Rows[e.RowIndex].DataBoundItem, dgvContato.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        int idTabela = 0; // 1 - Cliente | 2 - Forencedor | 3 - Usuário | 4 - Loja  
        int idExterno = 0;
        int idContato = 0;
        bool inserir = false;

        ContatoExternoNegocios contatoExternoNegocios = new ContatoExternoNegocios();
        ContatoClienteColecao contatoClienteColecao = new ContatoClienteColecao();
        ContatoFornecedorColecao contatoFornecedorColecao = new ContatoFornecedorColecao();
        ContatoUsuarioColecao contatoUsuarioColecao = new ContatoUsuarioColecao();
        ContatoLojaColecao contatoLojaColecao = new ContatoLojaColecao();

        public usrTelefone(int tabelaExterna, int idTabelaExterna, bool visualizar = false)
        {
            InitializeComponent();
            idTabela = tabelaExterna;
            idExterno = idTabelaExterna;
            dgvContato.AutoGenerateColumns = false;
            carregaGrade();
            desbilita();
        }
        void habilita()
        {
            txtResponsavel.Enabled = true;
            txtContato.Enabled = true;
            cbxTipo.Enabled = true;
        }
        void desbilita()
        {
            txtResponsavel.Enabled = false;
            txtContato.Enabled = false;
            cbxTipo.Enabled = false;
        }
        void limpaTela()
        {
            inserir = false;
            btnSalvar.Enabled = false;
            btnInserir.Enabled = true;
            btnExcluir.Enabled = true;
            btnAlterar.Enabled = true;
            idContato = 0;
            txtResponsavel.Clear();
            txtContato.Clear();
            cbxTipo.Text = "CELULAR";
        }
        void carregaGrade()
        {
            if (idTabela == 1)
            {
                dgvContato.DataSource = null;
                contatoClienteColecao = contatoExternoNegocios.ConsultarPorCliente(idExterno);
                dgvContato.DataSource = contatoClienteColecao;
                dgvContato.Update();
                dgvContato.Refresh();
            }

            if (idTabela == 2)
            {
                dgvContato.DataSource = null;
                contatoFornecedorColecao = contatoExternoNegocios.ConsultarPorFornecedor(idExterno);
                dgvContato.DataSource = contatoFornecedorColecao;
                dgvContato.Update();
                dgvContato.Refresh();
            }

            if (idTabela == 3)
            {
                dgvContato.DataSource = null;
                contatoUsuarioColecao = contatoExternoNegocios.ConsultarPorUsuario(idExterno);
                dgvContato.DataSource = contatoUsuarioColecao;
                dgvContato.Update();
                dgvContato.Refresh();
            }

            if (idTabela == 4)
            {
                dgvContato.DataSource = null;
                contatoLojaColecao = contatoExternoNegocios.ConsultarPorLoja(idExterno);
                dgvContato.DataSource = contatoLojaColecao;
                dgvContato.Update();
                dgvContato.Refresh();
            }
        }

        void inserirExterno()
        {
            if (inserir == true)
            {
                int idRetorno = 0;

                if (idTabela == 1)
                    idRetorno = contatoExternoNegocios.InserirContatoCliente(idExterno, idContato);
                if (idTabela == 2)
                    idRetorno = contatoExternoNegocios.InserirContatoFornecedor(idExterno, idContato);
                if (idTabela == 3)
                    idRetorno = contatoExternoNegocios.InserirContatoUsuario(idExterno, idContato);
                if (idTabela == 4)
                    idRetorno = contatoExternoNegocios.InserirContatoLoja(idExterno, idContato);

                if (idRetorno > 0)
                {
                    MessageBox.Show("Contato inserido com sucesso. ", "Atenção...",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    atualizarAlteracao();
                }
                else
                    MessageBox.Show("Não foi possível inserir o contato. " +
                        "Verifique se a conexão com o banco de dados está correta.", "Atenção...",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);

                limpaTela();
                desbilita();
                carregaGrade();
            }
        }

        void excluirExterno()
        {
            int idRetorno = 0;

            if (idTabela == 1)
            {
                ContatoCliente contatoClienteSelecionado = (dgvContato.SelectedRows[0].DataBoundItem as ContatoCliente);
                idRetorno = contatoExternoNegocios.ApagarContatoCliente(contatoClienteSelecionado.Contato.IdContato, idExterno);
            }
            if (idTabela == 2)
            {
                ContatoFornecedor contatoFornecedorSelecionado = (dgvContato.SelectedRows[0].DataBoundItem as ContatoFornecedor);
                idRetorno = contatoExternoNegocios.ApagarContatoFornecedor(contatoFornecedorSelecionado.Contato.IdContato, idExterno);
            }
            if (idTabela == 3)
            {
                ContatoUsuario contatoUsuarioSelecionado = (dgvContato.SelectedRows[0].DataBoundItem as ContatoUsuario);
                idRetorno = contatoExternoNegocios.ApagarContatoUsuario(contatoUsuarioSelecionado.Contato.IdContato, idExterno);
            }
            if (idTabela == 4)
            {
                ContatoLoja contatoLojaSelecionado = (dgvContato.SelectedRows[0].DataBoundItem as ContatoLoja);
                idRetorno = contatoExternoNegocios.ApagarContatoLoja(contatoLojaSelecionado.Contato.IdContato, idExterno);
            }

            if (idRetorno > 0)
            {
                MessageBox.Show("Contato excluído com sucesso.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                atualizarAlteracao();
                carregaGrade();
            }
            else
                MessageBox.Show("O contato selecionado não foi encontrado no banco de dados.", "Atenção...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        void alterarContato()
        {
            inserir = false;
            btnSalvar.Enabled = true;
            btnInserir.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            habilita();


            if (idTabela == 1)
            {
                ContatoCliente contatoClienteSelecionado = (dgvContato.SelectedRows[0].DataBoundItem as ContatoCliente);
                idContato = contatoClienteSelecionado.Contato.IdContato;
                txtResponsavel.Text = contatoClienteSelecionado.Contato.Responsavel;
                txtContato.Text = contatoClienteSelecionado.Contato.Contatos;
                cbxTipo.Text = contatoClienteSelecionado.Contato.TipoContato;

            }
            if (idTabela == 2)
            {
                ContatoFornecedor contatoFornecedorSelecionado = (dgvContato.SelectedRows[0].DataBoundItem as ContatoFornecedor);
                idContato = contatoFornecedorSelecionado.Contato.IdContato;
                txtResponsavel.Text = contatoFornecedorSelecionado.Contato.Responsavel;
                txtContato.Text = contatoFornecedorSelecionado.Contato.Contatos;
                cbxTipo.Text = contatoFornecedorSelecionado.Contato.TipoContato;
            }
            if (idTabela == 3)
            {
                ContatoUsuario contatoUsuarioSelecionado = (dgvContato.SelectedRows[0].DataBoundItem as ContatoUsuario);
                idContato = contatoUsuarioSelecionado.Contato.IdContato;
                txtResponsavel.Text = contatoUsuarioSelecionado.Contato.Responsavel;
                txtContato.Text = contatoUsuarioSelecionado.Contato.Contatos;
                cbxTipo.Text = contatoUsuarioSelecionado.Contato.TipoContato;
            }
            if (idTabela == 4)
            {
                ContatoLoja contatoLojaSelecionado = (dgvContato.SelectedRows[0].DataBoundItem as ContatoLoja);
                idContato = contatoLojaSelecionado.Contato.IdContato;
                txtResponsavel.Text = contatoLojaSelecionado.Contato.Responsavel;
                txtContato.Text = contatoLojaSelecionado.Contato.Contatos;
                cbxTipo.Text = contatoLojaSelecionado.Contato.TipoContato;
            }
            atualizarAlteracao();
            txtResponsavel.Focus();
        }

        void atualizarAlteracao()
        {
            int idRetorno = 0;

            if (idTabela == 1)
            {
                ClienteNegocios clienteNegocios = new ClienteNegocios();
                idRetorno = clienteNegocios.AltualizarAlteracao(idExterno);
            }
            if (idTabela == 2)
            {
                FornecedorNegocios fornecedorNegocios = new FornecedorNegocios();
                idRetorno = fornecedorNegocios.AtualizarAlteracao(idExterno);
            }
            if (idTabela == 3)
            {
                UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
                idRetorno = usuarioNegocios.AtualizarAlteracao(idExterno);
            }
            if (idTabela == 4)
            {
                LojaNegocios lojaNegocios = new LojaNegocios();
                idRetorno = lojaNegocios.AtualizarAlteracao();
            }

            if (idRetorno < 1)
                MessageBox.Show("Não foi possível atualizar das de alteração. " +
                    "Verifique se a conexão com o banco de dados está correta.", "Atenção...",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);                
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvContato.SelectedRows.Count == 0)
                MessageBox.Show("Nenhum contato selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                alterarContato();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvContato.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum contato selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Deseja realmente excluir este contato?", "Confirmação...",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    excluirExterno();
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato();
            ContatoNegocios contatoNegocios = new ContatoNegocios();

            contato.Responsavel = txtResponsavel.Text;
            contato.Contatos = txtContato.Text;
            contato.TipoContato = cbxTipo.Text;

            if (inserir == true)
            {
                int idRetorno = contatoNegocios.Inserir(contato);
                if (idRetorno > 0)
                {
                    idContato = idRetorno;
                    inserirExterno();
                }
                else
                    MessageBox.Show("Não foi possível inserir o contato. " +
                        "Verifique se a conexão com o banco de dados está correta.", "Atenção...",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                contato.IdContato = idContato;
                int LinhasAlteradas = contatoNegocios.Alterar(contato);
                if (LinhasAlteradas > 0)
                {
                    MessageBox.Show("Contato alterado com sucesso.", "Informação...",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                    desbilita();
                    limpaTela();
                    carregaGrade();
                }
                else
                {
                    MessageBox.Show("O contato não foi encontrado.", "Atenção...",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            inserir = true;
            btnSalvar.Enabled = true;
            btnInserir.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            habilita();
            txtResponsavel.Focus();
        }
    }
}
