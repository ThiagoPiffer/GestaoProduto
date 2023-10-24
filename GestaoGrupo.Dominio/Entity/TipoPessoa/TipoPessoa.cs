using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;

namespace GestaoProduto.Dominio.Entity._TipoPessoa
{
    public class TipoPessoa : Entidade
    {
        public string Descricao { get; set; } = string.Empty;
        public int IdEmpresa { get; set; }
    }
}


