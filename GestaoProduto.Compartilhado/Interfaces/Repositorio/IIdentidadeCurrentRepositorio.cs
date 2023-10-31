using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._Usuario;

namespace GestaoProduto.Compartilhado.Interfaces.Repositorio._IdentidadeCurrent
{
    public interface IIdentidadeCurrentRepositorio
    {
        Task<Usuario> ObterUsuarioCurrentAsync(Guid idAspNetUser);
        Task<Empresa> ObterEmpresaCurrentAsync(Guid idAspNetUser);
    }
}
