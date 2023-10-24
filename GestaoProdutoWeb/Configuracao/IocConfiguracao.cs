using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Servico;
using GestaoProduto.Identidade;

using GestaoProduto.Dominio.IServico._ArquivoProcesso;
using GestaoProduto.Dominio.IServico._GrupoProcesso;
using GestaoProduto.Dominio.IServico._Identidade;
using GestaoProduto.Dominio.IServico._Pessoa;
using GestaoProduto.Dominio.IServico._Processo;

using GestaoProduto.Dominio.IRepositorio._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.IRepositorio._ArquivoProcesso;
using GestaoProduto.Dominio.IRepositorio._Processo;
using GestaoProduto.Dominio.IRepositorio._GrupoProcesso;
using GestaoProduto.Dominio.IRepositorio._Pessoa;

using GestaoProduto.Dados.Repositorio._RepositorioBase;
using GestaoProduto.Dados.Repositorio._ArquivoProcesso;
using GestaoProduto.Dados.Repositorio._Processo;
using GestaoProduto.Dados.Repositorio._GrupoProcesso;
using GestaoProduto.Dados.Repositorio._Pessoa;

using GestaoProduto.Dominio.IServico._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.IServico._Empresa;
using GestaoProduto.Dominio.IServico._Usuario;

using GestaoProduto.Servico._Empresa;
using GestaoProduto.Dados.Repositorio._ArquivoProcessoTemplateRepositorio;
using GestaoProduto.Dados.Repositorio._Empresa;
using GestaoProduto.Dominio.IRepositorio._Empresa;
using GestaoProduto.Dados.Repositorio._Usuario;
using GestaoProduto.Dominio.IRepositorio._Usuario;
using GestaoProduto.Servico._Processo;
using GestaoProduto.Servico._GrupoProcesso;
using GestaoProduto.Servico_Pessoa;
using GestaoProduto.Servico._ArquivoProcesso;
using GestaoProduto.API.Controllers.Identidade;
using GestaoProduto.Servico._ArquivoProcessoTemplate;
using GestaoProduto.Servico._Usuario;
using GestaoProduto.Dominio.IServico._TipoPessoa;
using GestaoProduto.Dominio.IRepositorio._TipoPessoa;
using GestaoProduto.Servico._TipoPessoa;
using GestaoProduto.Dados.Repositorio._TipoPessoa;
using GestaoProduto.Servico._TipoPessoaTemplate;
using GestaoProduto.Dominio.IRepositorio._TipoPessoaTemplateRepositorio;
using GestaoProduto.Dados.Repositorios._TipoPessoaTemplate;
using GestaoProduto.Dominio.IServico._TipoPessoaTemplateServico;

namespace GestaoProduto.API.Configuracao
{
    public static class IocConfiguracao
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            
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

            services.AddScoped<IArquivoProcessoTemplateServico, ArquivoProcessoTemplateServico>();
            services.AddScoped<IArquivoProcessoTemplateRepositorio, ArquivoProcessoTemplateRepositorio>();

            services.AddScoped<IEmpresaServico, EmpresaServico>();
            services.AddScoped<IEmpresaRepositorio, EmpresaRepositorio>();

            services.AddScoped<IUsuarioServico, UsuarioServico>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddScoped<ITipoPessoaServico, TipoPessoaServico>();
            services.AddScoped<ITipoPessoaRepositorio, TipoPessoaRepositorio>();

            services.AddScoped<ITipoPessoaTemplateServico, TipoPessoaTemplateServico>();
            services.AddScoped<ITipoPessoaTemplateRepositorio, TipoPessoaTemplateRepositorio>();

            services.AddAutoMapper((serviceProvider, automapper) =>
            {
                automapper.ConstructServicesUsing(serviceProvider.GetService);
            }, typeof(Startup));

            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.AddScoped(serviceType: typeof(IUnitOfWork), typeof(UnitOfWork));


        }
    }
}
