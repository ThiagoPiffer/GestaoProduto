using GestaoProduto.Compartilhado.Model._Identidade;
using GestaoProduto.Identidade.Extensao;
//using GestaoProduto.Core.Identidade;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using GestaoProduto.Compartilhado.Interfaces.Servico._Empresa;
using GestaoProduto.Dominio.Entity._Empresa;

namespace GestaoProduto.Identidade.Controllers
{
    
    [Route("apiIdentidade/[controller]")]
    public class IdentidadeController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly IEmpresaServico _empresaServico;

        public IdentidadeController(SignInManager<IdentityUser> signInManager, 
                                    UserManager<IdentityUser> userManager, 
                                    IOptions<AppSettings> appSettings,
                                    IEmpresaServico empresaServico
            )
        {
            _signInManager=signInManager;
            _userManager=userManager;
            _appSettings=appSettings.Value;
            _empresaServico=empresaServico;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("Registrar")]
        public async Task<ActionResult> Registrar(UsuarioRegistroModel usuarioRegistro)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, usuarioRegistro.Senha);

            if (result.Succeeded)
            {
                //await _signInManager.SignInAsync(user, false);
                return CustomResponse(await GerarJwt(usuarioRegistro.Email));
            }

            foreach (var error in result.Errors)
                AdicionarErroProcessamento(error.Description);

            return CustomResponse();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("LoginAutenticacao")]
        public async Task<ActionResult> Login(UsuarioLoginModel usuariologin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(usuariologin.Email, usuariologin.Senha,
                    false, true);

            var usuario = _signInManager.ClaimsFactory;
            var usuario2 = _signInManager.UserManager;
            //var empresa = _empresaServico.ObterEmpresaUsuarioIdentity(result.);

            if (result.Succeeded)
                return CustomResponse(await GerarJwt(usuariologin.Email));

            if (result.IsLockedOut)
            {
                AdicionarErroProcessamento("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse();
            }

            AdicionarErroProcessamento("Usuário ou Senha incorretos");
            return CustomResponse(); 
        }

        private async Task<UsuarioRespostaLoginModel> GerarJwt(string email)
        {
            #region ObterClaims
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user!);
            var userRoles = await _userManager.GetRolesAsync(user!);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user!.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email!));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            var expiracao = DateTime.UtcNow.AddHours(2);
            claims.Add(new Claim("exp", ToUnixEpochDate(expiracao).ToString(), ClaimValueTypes.DateTime)); // Expira token            


            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }
            #endregion

            #region Regar Token
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new UsuarioRespostaLoginModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UsuarioToken = new UsuarioTokenModel
                {
                    Id = user.Id,
                    Email = user.Email!,
                    Claims = claims.Select(c => new UsuarioClaimModel { Type = c.Type, Value = c.Value })
                }
            };
            #endregion

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970,1,1,0,0,0, TimeSpan.Zero)).TotalSeconds);
    }
}
