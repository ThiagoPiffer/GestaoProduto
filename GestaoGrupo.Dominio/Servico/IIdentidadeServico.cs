using GestaoProduto.Dominio.Model.Identidade;

namespace GestaoProduto.Dominio.Servico
{
    public interface IIdentidadeServico
    {
        Task<UsuarioRespostaLoginModel> Login(UsuarioLoginModel usuarioLogin);
        Task<UsuarioRespostaLoginModel> Registro(UsuarioRegistroModel usuarioRegistroModel);
        //Task<string> Logout();
    }
}
