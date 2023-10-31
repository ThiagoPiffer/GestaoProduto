using System.Security.Claims;
using GestaoProduto.Compartilhado.Interfaces._User;
using GestaoProduto.Compartilhado.Interfaces.Servico._Empresa;
using GestaoProduto.Compartilhado.Interfaces.Servico._Identidade;
using GestaoProduto.Compartilhado.Interfaces.Servico._IdentidadeCurrent;
using GestaoProduto.Compartilhado.Interfaces.Servico._Usuario;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Ioc;


namespace GestaoProduto.Identidade
{
    //public class AspNetUser : IUser
    //{
    //    private readonly IHttpContextAccessor _accessor;
    //    private readonly IIdentidadeCurrentServico _idantidadeCurrentServico;

    //    public AspNetUser(
    //        IHttpContextAccessor accessor,
    //        IIdentidadeCurrentServico idantidadeCurrentServico
    //        )
    //    {
    //        _accessor=accessor;
    //        _idantidadeCurrentServico=idantidadeCurrentServico;
    //    }

    //    public string Name => _accessor.HttpContext!.User.Identity!.Name!;

    //    public Guid ObterUserId()
    //    {
    //        return EstaAutenticado() ? Guid.Parse(_accessor.HttpContext!.User.GetUserId()) : Guid.Empty;
    //    }

    //    public string ObterUserEmail()
    //    {
    //        return EstaAutenticado() ? _accessor.HttpContext!.User.GetUserEmail() : string.Empty;
    //    }

    //    public string ObterUserToken() 
    //    { 
    //        return EstaAutenticado() ? _accessor.HttpContext!.User.GetUserToken() : string.Empty;
    //    }

    //    public bool EstaAutenticado() 
    //    {
    //        return _accessor!.HttpContext!.User!.Identity!.IsAuthenticated;
    //    }

    //    public bool PossuiRole(string role)
    //    {
    //        return _accessor.HttpContext!.User.IsInRole(role);
    //    }

    //    public IEnumerable<Claim> ObterClaims()
    //    {
    //        return _accessor.HttpContext!.User.Claims;
    //    }

    //    public HttpContext ObterHttpContext()
    //    {
    //        return _accessor.HttpContext!;
    //    }

    //    public async Task<Usuario> UsuarioCurrent()
    //    {
    //        var idAspNetUser = ObterUserId();
    //        return await _idantidadeCurrentServico.ObterUsuarioCurrentAsync(idAspNetUser);
    //    }

    //    public async Task<Empresa> EmpresaCurrent()
    //    {
    //        var idAspNetUser = ObterUserId();
    //        return await _idantidadeCurrentServico.ObterEmpresaCurrentAsync(idAspNetUser);
    //    }
    //}

    //public static class ClamisPrincipalExtesions
    //{
    //    public static string GetUserId(this ClaimsPrincipal princiapl)
    //    {
    //        if (princiapl == null)
    //        {
    //            throw new ArgumentException(nameof(princiapl));
    //        }

    //        var claim = princiapl.FindFirst(ClaimTypes.NameIdentifier);//sub

    //        return claim?.Value!;
    //    }

    //    public static string GetUserEmail(this ClaimsPrincipal principal)
    //    {
    //        if (principal == null)
    //        {
    //            throw new ArgumentException(nameof(principal));
    //        }

    //        var claim = principal.FindFirst(ClaimTypes.Email);
    //        return claim?.Value!;
    //    }

    //    public static string GetUserToken(this ClaimsPrincipal principal)
    //    {
    //        if (principal == null)
    //        {
    //            throw new ArgumentException(nameof(principal));
    //        }

    //        var claim = principal.FindFirst("JWT");
    //        return claim?.Value!;
    //    }
    //}
}

