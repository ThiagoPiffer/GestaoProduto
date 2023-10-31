using GestaoProduto.Compartilhado.Model._Identidade;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._Usuario;

namespace GestaoProduto.Compartilhado.Interfaces.Servico._Identidade
{
    public interface IIdentidadeServico
    {
        Task<UsuarioRespostaLoginModel> Login(UsuarioLoginModel usuarioLogin);
        Task<UsuarioRespostaLoginModel> Registro(UsuarioRegistroModel usuarioRegistroModel);
        //Task<string> Logout();
    }
}
