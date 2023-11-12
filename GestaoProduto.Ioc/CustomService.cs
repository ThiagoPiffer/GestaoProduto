using GestaoProduto.Compartilhado.Interfaces._User;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._ArquivoProcesso;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._ArquivoProcessoTemplate;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._ControlePessoaExterna;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Empresa;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Evento;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._EventoStatusPersonalizado;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._GrupoProcesso;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._IdentidadeCurrent;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Notificacao;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Pessoa;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._PessoaProcesso;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Processo;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._ProcessoStatusPersonalizado;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._TipoPessoa;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._TipoPessoaTemplateRepositorio;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Usuario;
using GestaoProduto.Compartilhado.Interfaces.Servico._ArquivoProcesso;
using GestaoProduto.Compartilhado.Interfaces.Servico._ArquivoProcessoTemplate;
using GestaoProduto.Compartilhado.Interfaces.Servico._ControlePessoaExterna;
using GestaoProduto.Compartilhado.Interfaces.Servico._Empresa;
using GestaoProduto.Compartilhado.Interfaces.Servico._Evento;
using GestaoProduto.Compartilhado.Interfaces.Servico._EventoStatusPersonalizado;
using GestaoProduto.Compartilhado.Interfaces.Servico._GrupoProcesso;
using GestaoProduto.Compartilhado.Interfaces.Servico._Identidade;
using GestaoProduto.Compartilhado.Interfaces.Servico._IdentidadeCurrent;
using GestaoProduto.Compartilhado.Interfaces.Servico._Notificacao;
using GestaoProduto.Compartilhado.Interfaces.Servico._Pessoa;
using GestaoProduto.Compartilhado.Interfaces.Servico._Processo;
using GestaoProduto.Compartilhado.Interfaces.Servico._ProcessoStatusPersonalizado;
using GestaoProduto.Compartilhado.Interfaces.Servico._TipoPessoa;
using GestaoProduto.Compartilhado.Interfaces.Servico._TipoPessoaTemplateServico;
using GestaoProduto.Compartilhado.Interfaces.Servico._Usuario;

using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorio._ArquivoProcesso;
using GestaoProduto.Dados.Repositorio._ArquivoProcessoTemplateRepositorio;
using GestaoProduto.Dados.Repositorio._ControlePessoaExterna;
using GestaoProduto.Dados.Repositorio._Empresa;
using GestaoProduto.Dados.Repositorio._Evento;
using GestaoProduto.Dados.Repositorio._EventoStatusPersonalizado;
using GestaoProduto.Dados.Repositorio._GrupoProcesso;
using GestaoProduto.Dados.Repositorio._Notificaao;
using GestaoProduto.Dados.Repositorio._Pessoa;
using GestaoProduto.Dados.Repositorio._Processo;
using GestaoProduto.Dados.Repositorio._ProcessoStatusPersonalizado;
using GestaoProduto.Dados.Repositorio._RepositorioBase;
using GestaoProduto.Dados.Repositorio._TipoPessoa;
using GestaoProduto.Dados.Repositorio._Usuario;
using GestaoProduto.Dados.Repositorios;
using GestaoProduto.Dados.Repositorios._TipoPessoaTemplate;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Servico._ArquivoProcesso;
using GestaoProduto.Servico._ArquivoProcessoTemplate;
using GestaoProduto.Servico._ControlePessoaExterna;
using GestaoProduto.Servico._Empresa;
using GestaoProduto.Servico._Evento;
using GestaoProduto.Servico._EventoStatusPersonalizado;
using GestaoProduto.Servico._GrupoProcesso;
using GestaoProduto.Servico._Identidade;
using GestaoProduto.Servico._IdentidadeCurrent;
using GestaoProduto.Servico._Notificacao;
using GestaoProduto.Servico._Processo;
using GestaoProduto.Servico._ProcessoStatusPersonalizado;
using GestaoProduto.Servico._TipoPessoa;
using GestaoProduto.Servico._TipoPessoaTemplate;
using GestaoProduto.Servico._User;
using GestaoProduto.Servico._Usuario;
using GestaoProduto.Servico_Pessoa;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoProduto.Ioc
{
    public static class CustomService
    {
        public static void RegisterServicesCompartilhado(this IServiceCollection services, IConfiguration configuration)
        {
            

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("DataBase"))
                     .EnableSensitiveDataLogging()
                );

            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>))

            .AddScoped<IProcessoServico, ProcessoServico>();


            services.AddScoped<IProcessoRepositorio, ProcessoRepositorio>();

            services.AddScoped<IGrupoProcessoServico, GrupoProcessoServico>();
            services.AddScoped<IGrupoProcessoRepositorio, GrupoProcessoRepositorio>();

            services.AddScoped<IPessoaServico, PessoaServico>();
            services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();

            services.AddScoped<IArquivoProcessoServico, ArquivoProcessoServico>();
            services.AddScoped<IArquivoProcessoRepositorio, ArquivoProcessoRepositorio>();


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

            services.AddScoped<IIdentidadeCurrentServico, IdentidadeCurrentServico>();
            services.AddScoped<IIdentidadeCurrentRepositorio, IdentidadeCurrentRepositorio>();

            services.AddScoped<IControlePessoaExternaServico, ControlePessoaExternaServico>();
            services.AddScoped<IControlePessoaExternaRepositorio, ControlePessoaExternaRepositorio>();

            services.AddScoped<INotificacaoServico, NotificacaoServico>();
            services.AddScoped<INotificacaoRepositorio, NotificacaoRepositorio>();

            services.AddScoped<IEventoServico, EventoServico>();
            services.AddScoped<IEventoRepositorio, EventoRepositorio>();

            services.AddScoped<IPessoaProcessoRepositorio, PessoaProcessoRepositorio>();

            services.AddScoped<IEventoStatusPersonalizadoServico, EventoStatusPersonalizadoServico>();
            services.AddScoped<IEventoStatusPersonalizadoRepositorio, EventoStatusPersonalizadoRepositorio>();

            services.AddScoped<IProcessoStatusPersonalizadoServico, ProcessoStatusPersonalizadoServico>();
            services.AddScoped<IProcessoStatusPersonalizadoRepositorio, ProcessoStatusPersonalizadoRepositorio>();

            services.AddScoped<IUser, UserService>();

            services.AddScoped(serviceType: typeof(IUnitOfWork), typeof(UnitOfWork));

        }
        
    }
}
