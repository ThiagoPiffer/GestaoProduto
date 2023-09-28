using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorios;
using GestaoProduto.Dominio._Base;
using Microsoft.EntityFrameworkCore;
using GestaoProduto.Servico;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Repositorio;
using GestaoProduto.Dominio.Servico;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace GestaoProduto.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("DataBase"))
                );

            // Injeção de dependencia
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



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Gestão Produto API",
                    Description = "Api de autenticação",
                    Contact = new OpenApiContact() { Name = "Nome Teste", Email = "email.teste@gmail.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }

                });
            });


            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();            

            app.UseRouting();

            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.Use(async (context, next) =>
            {
                await next.Invoke();
                var unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
                await unitOfWork.Commit();
            });

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
