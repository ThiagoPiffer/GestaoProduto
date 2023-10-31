using GestaoProduto.Compartilhado.Model._Empresa;

namespace GestaoProduto.Compartilhado.Model._Usuario
{
    public class UsuarioModel
    {
        public UsuarioModel() { }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public EmpresaModel Empresa { get; set; }
        public int EmpresaId { get; set; }
        public string AspNetUserId { get; set; }
    }
}
