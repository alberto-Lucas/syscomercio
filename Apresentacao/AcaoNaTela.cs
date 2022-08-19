using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apresentacao
{
    public enum AcaoNaTela
    {
        Inserir,
        Alterar,
        Dados,
        Contato,
        Endereco
    }

    public enum TipoLancamento
    {
        Orcamento,
        Venda
    }

    public enum StatusLancamento
    {
        Pendente,
        Cancelado,
        Finalizado
    }
}
