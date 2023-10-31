using GestaoProduto.Identidade;
using GestaoProduto.Compartilhado.Interfaces.Servico._Identidade;
using GestaoProduto.API.Controllers.Identidade;
using GestaoProduto.Compartilhado.Interfaces._User;
using GestaoProduto.Compartilhado.Interfaces.Servico._IdentidadeCurrent;
using GestaoProduto.Servico._IdentidadeCurrent;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._IdentidadeCurrent;
using GestaoProduto.Dados.Repositorios;
using GestaoProduto.Servico._User;

namespace GestaoProduto.API.Configuracao
{
    public static class IocConfiguracao
    {
        public static void RegisterServicesInternal(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IIdentidadeServico, IdentidadeServico>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper((serviceProvider, automapper) =>
            {
                automapper.ConstructServicesUsing(serviceProvider.GetService);
            }, typeof(Startup));

            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
        }
    }
}
