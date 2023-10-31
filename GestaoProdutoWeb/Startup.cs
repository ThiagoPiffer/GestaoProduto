using GestaoProduto.Dados.Contextos;
using Microsoft.EntityFrameworkCore;
using GestaoProduto.API.Configuracao;
using Microsoft.EntityFrameworkCore.Internal;
using GestaoProduto.Ioc;

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
            services.AddLogging(builder =>
            {
                builder.AddConsole(); // Log no console
                builder.AddDebug();   // Log na janela de saída durante a depuração
                builder.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
            });

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("DataBase"))
                     .EnableSensitiveDataLogging()
                );
            services.AddIdentityConfiguration(Configuration);
            services.AddMvcConfiguration(Configuration);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerConfiguration();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCorsExtensions(Configuration);

            services.AddCustomAutoMapping(Configuration);
            services.RegisterServicesInternal(Configuration); // Injeção de dependencia            
            services.RegisterServicesCompartilhado(Configuration); // Injeção de dependencia            
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
