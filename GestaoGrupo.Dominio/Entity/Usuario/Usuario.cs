using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;

namespace GestaoProduto.Dominio.Entity._Usuario
{
    public class Usuario : Entidade
    {
        public Usuario() { }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public int IdEmpresa { get; set; }
        public string IdAspNetUser { get; set; }
    }
}
