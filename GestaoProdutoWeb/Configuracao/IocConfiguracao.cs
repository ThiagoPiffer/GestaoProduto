using GestaoProduto.Dados.Repositorios;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Repositorio;
using GestaoProduto.Dominio.Servico;
using GestaoProduto.Servico;
using Microsoft.Extensions.Configuration;

namespace GestaoProduto.API.Configuracao
{
    public static class IocConfiguracao
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            services.AddScoped<IFornecedorServico, FornecedorServico>();
            services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
            services.AddScoped<ArmazenadorFornecedor>();

            services.AddScoped<IFornecedorServico, FornecedorServico>();
            services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
            services.AddScoped<ArmazenadorFornecedor>();

            services.AddScoped<IProdutoServico, ProdutoServico>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<ArmazenadorProduto>();

            services.AddScoped<IObjetoCustomizadoServico, ObjetoCustomizadoServico>();
            services.AddScoped<IObjetoCustomizadoRepositorio, ObjetoCustomizadoRepositorio>();

            services.AddScoped<IProcessoServico, ProcessoServico>();
            services.AddScoped<IProcessoRepositorio, ProcessoRepositorio>();

            services.AddScoped<IGrupoProcessoServico, GrupoProcessoServico>();
            services.AddScoped<IGrupoProcessoRepositorio, GrupoProcessoRepositorio>();

            services.AddScoped<IPessoaServico, PessoaServico>();
            services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();

            services.AddScoped<IArquivoProcessoServico, ArquivoProcessoServico>();
            services.AddScoped<IArquivoProcessoRepositorio, ArquivoProcessoRepositorio>();

            services.AddHttpClient<IIdentidadeServico, IdentidadeServico>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));

        }
    }
}
