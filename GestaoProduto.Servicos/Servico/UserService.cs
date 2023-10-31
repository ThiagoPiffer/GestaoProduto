using GestaoProduto.Compartilhado.Interfaces._User;
using GestaoProduto.Compartilhado.Interfaces.Servico._IdentidadeCurrent;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._Usuario;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Servico._User
{
    public class UserService : IUser
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IIdentidadeCurrentServico _idantidadeCurrentServico;

        public UserService(
            IHttpContextAccessor accessor,
            IIdentidadeCurrentServico idantidadeCurrentServico
            )
        {
            _accessor=accessor;
            _idantidadeCurrentServico=idantidadeCurrentServico;
        }

        public string Name => _accessor.HttpContext!.User.Identity!.Name!;

        public Guid ObterUserId()
        {
            return EstaAutenticado() ? Guid.Parse(_accessor.HttpContext!.User.GetUserId()) : Guid.Empty;
        }

        public string ObterUserEmail()
        {
            return EstaAutenticado() ? _accessor.HttpContext!.User.GetUserEmail() : string.Empty;
        }

        public string ObterUserToken()
        {
            return EstaAutenticado() ? _accessor.HttpContext!.User.GetUserToken() : string.Empty;
        }

        public bool EstaAutenticado()
        {
            return _accessor!.HttpContext!.User!.Identity!.IsAuthenticated;
        }

        public bool PossuiRole(string role)
        {
            return _accessor.HttpContext!.User.IsInRole(role);
        }

        public IEnumerable<Claim> ObterClaims()
        {
            return _accessor.HttpContext!.User.Claims;
        }

        private HttpContext ObterHttpContext()
        {
            return _accessor.HttpContext!;
        }

        public async Task<Usuario> UsuarioCurrentMethod()
        {
            var idAspNetUser = ObterUserId();
            return await _idantidadeCurrentServico.ObterUsuarioCurrentAsync(idAspNetUser);
        }

        public Usuario UsuarioCurrent
        {
            get 
            {
                return UsuarioCurrentMethod().Result;
            }
        }

        public Empresa EmpresaCurrent
        {
            get
            {
                return UsuarioCurrentMethod().Result.Empresa;
            }
        }

        //public async Task<Empresa> EmpresaCurrent()
        //{
        //    var idAspNetUser = ObterUserId();
        //    return await _idantidadeCurrentServico.ObterEmpresaCurrentAsync(idAspNetUser);
        //}
    }

    public static class ClamisPrincipalExtesions
    {
        public static string GetUserId(this ClaimsPrincipal princiapl)
        {
            if (princiapl == null)
            {
                throw new ArgumentException(nameof(princiapl));
            }

            var claim = princiapl.FindFirst(ClaimTypes.NameIdentifier);//sub

            return claim?.Value!;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(ClaimTypes.Email);
            return claim?.Value!;
        }

        public static string GetUserToken(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst("JWT");
            return claim?.Value!;
        }
    }
}
