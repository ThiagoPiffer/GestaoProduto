using GestaoProduto.Compartilhado.Model._Empresa;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;

namespace GestaoProduto.Compartilhado.Model._ControlePessoaExterna
{
    public class ControlePessoaExternaModel: Entidade
    {
        public ControlePessoaExternaModel() { }

        public Guid IdUrl { get; set; }
        public string Url { get; set; }
        public DateTime Expiracao { get; set; }
        public int EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }
    }
}
