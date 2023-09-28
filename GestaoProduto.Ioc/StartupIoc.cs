using GestaoProduto.Dados.Repositorios;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dados.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Servico;
using GestaoProduto.Dominio.Repositorio;
using GestaoProduto.Dominio.Servico;


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
            services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
            services.AddScoped<ArmazenadorFornecedor>();

            services.AddScoped<IObjetoCustomizadoServico, ObjetoCustomizadoServico>();

            services.AddScoped<IProcessoServico, ProcessoServico>();
            services.AddScoped<IGrupoProcessoServico, GrupoProcessoServico>();
            #endregion

        }
    }
}
