using GestaoProduto.Compartilhado.Interfaces.Servico._Identidade;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._Usuario;
using System.Security.Claims;

namespace GestaoProduto.Compartilhado.Interfaces._User
{
    public interface IUser
    {
        Usuario UsuarioCurrent { get; }
        Empresa EmpresaCurrent { get; }
        string Name { get; }
        Guid ObterUserId();
        string ObterUserEmail();
        string ObterUserToken();
        bool EstaAutenticado();
        bool PossuiRole(string role);
        IEnumerable<Claim> ObterClaims();
    }
}
