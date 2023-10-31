using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._Usuario;

namespace GestaoProduto.Compartilhado.Interfaces.Servico._IdentidadeCurrent
{
    public interface IIdentidadeCurrentServico
    {
        Task<Usuario> ObterUsuarioCurrentAsync(Guid idAspNetUser);
        //Task<Empresa> ObterEmpresaCurrentAsync(Guid idAspNetUser);
        //Task<string> Logout();
    }
}
