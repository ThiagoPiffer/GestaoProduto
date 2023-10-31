using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;

namespace GestaoProduto.Dominio.Entity._ControlePessoaExterna
{
    public class ControlePessoaExterna: Entidade
    {
        public ControlePessoaExterna() { }

        public Guid IdUrl { get; set; }
        public string Url { get; set; }
        public DateTime Expiracao { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
