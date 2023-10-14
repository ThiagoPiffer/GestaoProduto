using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GestaoProduto.API.Configuracao
{
    public static class IdentidadeConfiguracao
    {
        public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {
            //        options.Events = new CookieAuthenticationEvents
            //        {
            //            OnRedirectToLogin = (ctx) =>
            //            {
            //                ctx.Response.StatusCode = 401; // Unauthorized
            //                return Task.CompletedTask;
            //            },
            //            OnRedirectToAccessDenied = (ctx) =>
            //            {
            //                ctx.Response.StatusCode = 403; // Forbidden
            //                return Task.CompletedTask;
            //            }
            //        };
            //    });

            var appSettiongsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettiongsSection);

            var appSettings = appSettiongsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                bearerOptions.RequireHttpsMetadata = true;
                bearerOptions.SaveToken = true;

                var tokenValidationParameters = bearerOptions.TokenValidationParameters;
                tokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(key);
                tokenValidationParameters.ValidAudience = appSettings.ValidoEm;
                tokenValidationParameters.ValidIssuer = appSettings.Emissor;

                // Valida a assinatura de um token recebido
                tokenValidationParameters.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                tokenValidationParameters.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                tokenValidationParameters.ClockSkew = TimeSpan.Zero;
            });
        }

        public static void UseIdentityConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
