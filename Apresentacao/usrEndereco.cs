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
    public partial class usrEndereco : UserControl
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
        private void dgvEndereco_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvEndereco.Rows[e.RowIndex].DataBoundItem != null) && (dgvEndereco.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvEndereco.Rows[e.RowIndex].DataBoundItem, dgvEndereco.Columns[e.ColumnIndex].DataPropertyName);
            }
        }
        
        int idTabela = 0; // 1 - Cliente | 2 - Forencedor | 3 - Usuário | 4 - Loja  
        int idExterno = 0;
        int idEndereco = 0;
        bool inserir = false;

        EnderecoExternoNegocios enderecoExternoNegocios = new EnderecoExternoNegocios();
        EnderecoClienteColecao enderecoClienteColecao = new EnderecoClienteColecao();
        EnderecoFornecedorColecao enderecoFornecedorColecao = new EnderecoFornecedorColecao();
        EnderecoUsuarioColecao enderecoUsuarioColecao = new EnderecoUsuarioColecao();
        EnderecoLojaColecao enderecoLojaColecao = new EnderecoLojaColecao();
        public usrEndereco(int tabelaExterna, int idTabelaExterna, bool visualizar = false)
        {
            InitializeComponent();
            idTabela = tabelaExterna;
            idExterno = idTabelaExterna;
            dgvEndereco.AutoGenerateColumns = false;
            carregaGrade();
            desbilita();
        }
        void habilita()
        {
            cbxLogradouro.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtComplemento.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            mskCep.Enabled = true;
            cbxUf.Enabled = true;
        }
        void desbilita()
        {
            cbxLogradouro.Enabled = false;
            txtEndereco.Enabled = false;
            txtNumero.Enabled = false;
            txtComplemento.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            mskCep.Enabled = false;
            cbxUf.Enabled = false;
        }
        void limpaTela()
        {
            inserir = false;
            btnSalvar.Enabled = false;
            btnInserir.Enabled = true;
            btnExcluir.Enabled = true;
            btnAlterar.Enabled = true;
            idEndereco = 0;
            cbxLogradouro.Text = "";
            txtEndereco.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            mskCep.Clear();
            cbxUf.Text = "";
        }
        void carregaGrade()
        {
            if (idTabela == 1)
            {
                dgvEndereco.DataSource = null;
                enderecoClienteColecao = enderecoExternoNegocios.ConsultarPorCliente(idExterno);
                dgvEndereco.DataSource = enderecoClienteColecao;
                dgvEndereco.Update();
                dgvEndereco.Refresh();
            }

            if (idTabela == 2)
            {
                dgvEndereco.DataSource = null;
                enderecoFornecedorColecao = enderecoExternoNegocios.ConsultarPorFornecedor(idExterno);
                dgvEndereco.DataSource = enderecoFornecedorColecao;
                dgvEndereco.Update();
                dgvEndereco.Refresh();
            }

            if (idTabela == 3)
            {
                dgvEndereco.DataSource = null;
                enderecoUsuarioColecao = enderecoExternoNegocios.ConsultarPorUsuario(idExterno);
                dgvEndereco.DataSource = enderecoUsuarioColecao;
                dgvEndereco.Update();
                dgvEndereco.Refresh();
            }

            if (idTabela == 4)
            {
                dgvEndereco.DataSource = null;
                enderecoLojaColecao = enderecoExternoNegocios.ConsultarPorLoja(idExterno);
                dgvEndereco.DataSource = enderecoLojaColecao;
                dgvEndereco.Update();
                dgvEndereco.Refresh();
            }
        }

        void inserirExterno()
        {
            if (inserir == true)
            {
                int idRetorno = 0;

                if (idTabela == 1)
                    idRetorno = enderecoExternoNegocios.InserirEnderecoCliente(idExterno, idEndereco);
                if (idTabela == 2)
                    idRetorno = enderecoExternoNegocios.InserirEnderecoFornecedor(idExterno, idEndereco);
                if (idTabela == 3)
                    idRetorno = enderecoExternoNegocios.InserirEnderecoUsuario(idExterno, idEndereco);
                if (idTabela == 4)
                    idRetorno = enderecoExternoNegocios.InserirEnderecoLoja(idExterno, idEndereco);

                if (idRetorno > 0)
                {
                    MessageBox.Show("Endereço inserido com sucesso. ", "Atenção...",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    atualizarAlteracao();
                }
                else
                    MessageBox.Show("Não foi possível inserir o endereço. " +
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
                EnderecoCliente enderecoClienteSelecionado = (dgvEndereco.SelectedRows[0].DataBoundItem as EnderecoCliente);
                idRetorno = enderecoExternoNegocios.ApagarEnderecoCliente(enderecoClienteSelecionado.Endereco.IdEndereco, idExterno);
            }
            if (idTabela == 2)
            {
                EnderecoFornecedor enderecoFornecedorSelecionado = (dgvEndereco.SelectedRows[0].DataBoundItem as EnderecoFornecedor);
                idRetorno = enderecoExternoNegocios.ApagarEnderecoFornecedor(enderecoFornecedorSelecionado.Endereco.IdEndereco, idExterno);
            }
            if (idTabela == 3)
            {
                EnderecoUsuario enderecoUsuarioSelecionado = (dgvEndereco.SelectedRows[0].DataBoundItem as EnderecoUsuario);
                idRetorno = enderecoExternoNegocios.ApagarEnderecoUsuario(enderecoUsuarioSelecionado.Endereco.IdEndereco, idExterno);
            }
            if (idTabela == 4)
            {
                EnderecoLoja enderecoLojaSelecionado = (dgvEndereco.SelectedRows[0].DataBoundItem as EnderecoLoja);
                idRetorno = enderecoExternoNegocios.ApagarEnderecoLoja(enderecoLojaSelecionado.Endereco.IdEndereco, idExterno);
            }

            if (idRetorno > 0)
            {
                MessageBox.Show("Endereço excluído com sucesso.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                atualizarAlteracao();
                carregaGrade();
            }
            else
                MessageBox.Show("O endereço selecionado não foi encontrado no banco de dados.", "Atenção...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        void alterarEndereco()
        {
            inserir = false;
            btnSalvar.Enabled = true;
            btnInserir.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            habilita();


            if (idTabela == 1)
            {
                EnderecoCliente enderecoClienteSelecionado = (dgvEndereco.SelectedRows[0].DataBoundItem as EnderecoCliente);
                idEndereco = enderecoClienteSelecionado.Endereco.IdEndereco;
                cbxLogradouro.Text = enderecoClienteSelecionado.Endereco.Logradouro;
                txtEndereco.Text = enderecoClienteSelecionado.Endereco.Enderecos;
                txtNumero.Text = enderecoClienteSelecionado.Endereco.Numero.ToString();
                txtComplemento.Text = enderecoClienteSelecionado.Endereco.Complemento;
                txtBairro.Text = enderecoClienteSelecionado.Endereco.Bairro;
                txtCidade.Text = enderecoClienteSelecionado.Endereco.Cidade;
                mskCep.Text = enderecoClienteSelecionado.Endereco.Cep;
                cbxUf.Text = enderecoClienteSelecionado.Endereco.Uf;

            }
            if (idTabela == 2)
            {
                EnderecoFornecedor enderecoFornecedorSelecionado = (dgvEndereco.SelectedRows[0].DataBoundItem as EnderecoFornecedor);
                idEndereco = enderecoFornecedorSelecionado.Endereco.IdEndereco;
                cbxLogradouro.Text = enderecoFornecedorSelecionado.Endereco.Logradouro;
                txtEndereco.Text = enderecoFornecedorSelecionado.Endereco.Enderecos;
                txtNumero.Text = enderecoFornecedorSelecionado.Endereco.Numero.ToString();
                txtComplemento.Text = enderecoFornecedorSelecionado.Endereco.Complemento;
                txtBairro.Text = enderecoFornecedorSelecionado.Endereco.Bairro;
                txtCidade.Text = enderecoFornecedorSelecionado.Endereco.Cidade;
                mskCep.Text = enderecoFornecedorSelecionado.Endereco.Cep;
                cbxUf.Text = enderecoFornecedorSelecionado.Endereco.Uf;
            }
            if (idTabela == 3)
            {
                EnderecoUsuario enderecoUsuarioSelecionado = (dgvEndereco.SelectedRows[0].DataBoundItem as EnderecoUsuario);
                idEndereco = enderecoUsuarioSelecionado.Endereco.IdEndereco;
                cbxLogradouro.Text = enderecoUsuarioSelecionado.Endereco.Logradouro;
                txtEndereco.Text = enderecoUsuarioSelecionado.Endereco.Enderecos;
                txtNumero.Text = enderecoUsuarioSelecionado.Endereco.Numero.ToString();
                txtComplemento.Text = enderecoUsuarioSelecionado.Endereco.Complemento;
                txtBairro.Text = enderecoUsuarioSelecionado.Endereco.Bairro;
                txtCidade.Text = enderecoUsuarioSelecionado.Endereco.Cidade;
                mskCep.Text = enderecoUsuarioSelecionado.Endereco.Cep;
                cbxUf.Text = enderecoUsuarioSelecionado.Endereco.Uf;
            }
            if (idTabela == 4)
            {
                EnderecoLoja enderecoLojaSelecionado = (dgvEndereco.SelectedRows[0].DataBoundItem as EnderecoLoja);
                idEndereco = enderecoLojaSelecionado.Endereco.IdEndereco;
                cbxLogradouro.Text = enderecoLojaSelecionado.Endereco.Logradouro;
                txtEndereco.Text = enderecoLojaSelecionado.Endereco.Enderecos;
                txtNumero.Text = enderecoLojaSelecionado.Endereco.Numero.ToString();
                txtComplemento.Text = enderecoLojaSelecionado.Endereco.Complemento;
                txtBairro.Text = enderecoLojaSelecionado.Endereco.Bairro;
                txtCidade.Text = enderecoLojaSelecionado.Endereco.Cidade;
                mskCep.Text = enderecoLojaSelecionado.Endereco.Cep;
                cbxUf.Text = enderecoLojaSelecionado.Endereco.Uf;
            }
            atualizarAlteracao();
            txtEndereco.Focus();
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

        private void btnInserir_Click(object sender, EventArgs e)
        {
            inserir = true;
            btnSalvar.Enabled = true;
            btnInserir.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            habilita();
            cbxLogradouro.Focus();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvEndereco.SelectedRows.Count == 0)
                MessageBox.Show("Nenhum ENDEREÇO selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                alterarEndereco();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvEndereco.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum endereço selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Deseja realmente excluir este endereço?", "Confirmação...",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    excluirExterno();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Endereco endereco = new Endereco();
            EnderecoNegocios enderecoNegocios = new EnderecoNegocios();

            endereco.Logradouro = cbxLogradouro.Text;
            endereco.Enderecos = txtEndereco.Text;
            endereco.Numero = txtNumero.Text;
            endereco.Complemento = txtComplemento.Text;
            endereco.Bairro = txtBairro.Text;
            endereco.Cidade = txtCidade.Text;
            endereco.Cep = mskCep.Text;
            endereco.Uf = cbxUf.Text;

            if (inserir == true)
            {
                int idRetorno = enderecoNegocios.Inserir(endereco);
                if (idRetorno > 0)
                {
                    idEndereco = idRetorno;
                    inserirExterno();
                }
                else
                    MessageBox.Show("Não foi possível inserir o endereço. " +
                        "Verifique se a conexão com o banco de dados está correta.", "Atenção...",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                endereco.IdEndereco= idEndereco;
                int LinhasAlteradas = enderecoNegocios.Alterar(endereco);
                if (LinhasAlteradas > 0)
                {
                    MessageBox.Show("Endereço alterado com sucesso.", "Informação...",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                    desbilita();
                    limpaTela();
                    carregaGrade();
                }
                else
                {
                    MessageBox.Show("O endereço não foi encontrado.", "Atenção...",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        
    }
}
