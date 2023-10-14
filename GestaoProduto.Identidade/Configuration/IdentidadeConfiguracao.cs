using GestaoProduto.Dados.Contextos;
using GestaoProduto.Identidade.Extensao;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GestaoProduto.Identidade.Configuration
{
    public static class IdentidadeConfiguracao
    {
        public static void AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("DataBase"))
                );

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        }

        //public static IApplicationBuilder UseIdentityConfiguration(this IApplicationBuilder app)
        //{
        //    app.UseAuthentication();
        //    app.UseAuthorization();

        //    return app;
        //}
    }
}
