using GestaoProduto.Dados.Repositorio._RepositorioBase;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dados.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GestaoProduto.Servico;
using GestaoProduto.Dominio.IServico._GrupoProcesso;
using GestaoProduto.Dominio.IServico._Processo;

namespace GestaoProduto.Ioc
{
    public static class StartupIoc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration["DataBase"]));

            #region Injeção de dependencia

            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            #endregion

        }
    }
}
