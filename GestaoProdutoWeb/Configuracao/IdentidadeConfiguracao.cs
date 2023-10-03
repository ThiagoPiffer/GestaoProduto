using Microsoft.AspNetCore.Authentication.Cookies;

namespace GestaoProduto.API.Configuracao
{
    public static class IdentidadeConfiguracao
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/login";
                   options.AccessDeniedPath = "/acesso-negado";

               });
        }

        public static void UseIdentityConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
