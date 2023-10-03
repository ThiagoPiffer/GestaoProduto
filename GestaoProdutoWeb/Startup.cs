using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorios;
using GestaoProduto.Dominio._Base;
using Microsoft.EntityFrameworkCore;
using GestaoProduto.Servico;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Repositorio;
using GestaoProduto.Dominio.Servico;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using GestaoProduto.API.Configuracao;

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
            services.AddIdentityConfiguration();

            services.AddMvcConfiguration(Configuration);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()  // Permite qualquer cabeçalho
                        .AllowAnyMethod()  // Permite qualquer método, como GET, POST, etc.
                        .AllowCredentials());  // Se você precisa de cookies, autenticação http, etc.
            });


            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("DataBase"))
                );

            // Injeção de dependencia
            services.RegisterServices(Configuration);

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
            app.UseMvcConfiguration(env);
        }
    }
}
