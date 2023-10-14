using GestaoProduto.Dominio.Model.Identidade;
using GestaoProduto.Dominio.Servico;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        [Route("registro")]
        public async Task<IActionResult> Registro([FromBody] UsuarioRegistroModel usuarioRegistro)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var resposta = await _identidadeServico.Registro(usuarioRegistro);

            if (ResponsePossuiErros(resposta.responseResult)) return BadRequest(ModelState); // retorno erro nao deu certo

            RealizarLogin(resposta);


            return Ok(resposta);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginModel usuarioLogin)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var resposta = await _identidadeServico.Login(usuarioLogin);

            if (ResponsePossuiErros(resposta.responseResult)) return BadRequest(ModelState); // retorno erro nao deu certo

            RealizarLogin(resposta);
            string json = JsonConvert.SerializeObject(resposta);

            return Ok(resposta);
        }

        [HttpGet]
        [Route("sair")]
        public IActionResult Logout()
        {
            // Você pode adicionar a lógica necessária para revogar o token aqui, se necessário.

            // Para efetuar o logout no lado do cliente, você pode apenas retornar um OkResult.
            return Ok(new { message = "Logout bem-sucedido" });
        }

        //private async Task RealizarLogin(UsuarioRespostaLoginModel resposta)
        //{
        //    var token = ObterTokenFormatado(resposta.AccessToken);

        //    var claims = new List<Claim>();
        //    claims.Add(new Claim("JWT", resposta.AccessToken));
        //    claims.AddRange(token.Claims);

        //    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //    var authProperties = new AuthenticationProperties
        //    {
        //        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
        //        IsPersistent = true
        //    };

        //    await HttpContext.SignInAsync(
        //        CookieAuthenticationDefaults.AuthenticationScheme,
        //        new ClaimsPrincipal(claimsIdentity)
        //        , authProperties
        //        );
        //}

        private void RealizarLogin(UsuarioRespostaLoginModel resposta)
        {
            var token = ObterTokenFormatado(resposta.AccessToken);

            var claims = new List<Claim>();
            claims.Add(new Claim("JWT", resposta.AccessToken));
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, "Bearer"); // Usando o esquema "Bearer"

            var principal = new ClaimsPrincipal(claimsIdentity);

            // Defina o contexto de usuário manualmente
            HttpContext.User = principal;
        }



        private static JwtSecurityToken ObterTokenFormatado(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }
    }
}
