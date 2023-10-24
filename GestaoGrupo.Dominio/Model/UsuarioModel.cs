using GestaoProduto.Dominio.Model._Empresa;

namespace GestaoProduto.Dominio.Model._Usuario
{
    public class UsuarioModel
    {
        public UsuarioModel() { }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public EmpresaModel Empresa { get; set; }
        public int Idempresa { get; set; }
        public string IdAspNetUser { get; set; }
    }
}
