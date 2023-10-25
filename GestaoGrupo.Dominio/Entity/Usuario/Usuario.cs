using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;

namespace GestaoProduto.Dominio.Entity._Usuario
{
    public class Usuario : Entidade
    {
        public Usuario() { }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; } 
        public string IdAspNetUser { get; set; }
    }
}
