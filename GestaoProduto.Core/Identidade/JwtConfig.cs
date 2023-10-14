using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Core.Identidade
{
    public static class JwtConfig
    {
        public static void AddJwtConfiguration (this IServiceCollection services,
            IConfiguration configuration)
        {
            var appSettiongsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettiongsSection);

            var appSettings = appSettiongsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(bearrerOptions =>
            //{
            //    bearrerOptions.RequireHttpsMetadata = true;
            //    bearrerOptions.SaveToken = true;
            //    bearrerOptions.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        //ValidAudiences
            //        ValidAudience = appSettings.ValidoEm,
            //        ValidIssuer = appSettings.Emissor
            //    };
            //});

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

        public static void UseAuthConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
