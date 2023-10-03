using GestaoProduto.Dominio.Model.Identidade;
using GestaoProduto.Dominio.Servico;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GestaoProduto.API.Controllers.Identidade
{
    [Route("api/[controller]")]
    public class IdentidadeController : MainController
    {
        private readonly IIdentidadeServico _identidadeServico;

        public IdentidadeController(IIdentidadeServico identidadeServico)
        {
            _identidadeServico = identidadeServico;
        }

        [HttpPost]
        [Route("novaConta")]
        public async Task<IActionResult> Registro(UsuarioRegistroModel usuarioRegistro)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var resposta = await _identidadeServico.Registro(usuarioRegistro);

            if (ResponsePossuiErros(resposta.responseResult)) return BadRequest(ModelState); // retorno erro nao deu certo

            await RealizarLogin(resposta);


            return Ok(resposta);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginModel usuarioLogin)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var resposta = await _identidadeServico.Login(usuarioLogin);

            if (ResponsePossuiErros(resposta.responseResult)) return BadRequest(ModelState); // retorno erro nao deu certo

            await RealizarLogin(resposta);

            return Ok(resposta);
        }

        [HttpPost]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        private async Task RealizarLogin(UsuarioRespostaLoginModel resposta)
        {
            var token = ObterTokenFormatado(resposta.AccessToken);

            var claims = new List<Claim>();
            claims.Add(new Claim("JWT", resposta.AccessToken));
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)
                , authProperties
                );
        }

        private static JwtSecurityToken ObterTokenFormatado(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }
    }
}
