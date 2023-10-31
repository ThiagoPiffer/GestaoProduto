using GestaoProduto.Compartilhado.Model._Empresa;

namespace GestaoProduto.Compartilhado.Model._Identidade
{
    public class UsuarioRegistroModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string SenhaConfirmacao { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public EmpresaModel EmpresaModel { get; set; }
    }
}
