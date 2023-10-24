using GestaoProduto.Dominio.Model._Identidade;

namespace GestaoProduto.Dominio.IServico._Identidade
{
    public interface IIdentidadeServico
    {
        Task<UsuarioRespostaLoginModel> Login(UsuarioLoginModel usuarioLogin);
        Task<UsuarioRespostaLoginModel> Registro(UsuarioRegistroModel usuarioRegistroModel);
        //Task<string> Logout();
    }
}
