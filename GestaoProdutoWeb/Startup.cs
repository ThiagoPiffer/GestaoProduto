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
using GestaoProduto.Core.Identidade;
using System.Net;
using GestaoProduto.API.Controllers.Identidade;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

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
            services.AddIdentityConfiguration(Configuration);
            services.AddMvcConfiguration(Configuration);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerConfiguration();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCorsExtensions(Configuration);


            //var appSettiongsSection = Configuration.GetSection("AppSettings");
            //services.Configure<AppSettings>(appSettiongsSection);

            //var appSettings = appSettiongsSection.Get<AppSettings>();
            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(bearreroptions =>
            //{
            //    bearreroptions.RequireHttpsMetadata = true;
            //    bearreroptions.SaveToken = true;
            //    bearreroptions.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,// coloquei depois 
            //        //validaudiences
            //        ValidAudience = appSettings.ValidoEm,
            //        ValidIssuer = appSettings.Emissor
            //    };
            //});


            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("DataBase"))
                );

            services.RegisterServices(Configuration); // Injeção de dependencia
            services.AddResponseCompression();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.AddCorsConfig(); 
            app.UseMvcConfiguration(env);
            app.UseResponseCompression();
        }
    }
}
