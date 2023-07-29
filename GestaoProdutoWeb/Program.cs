using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorios;
using GestaoProduto.Dominio._Base;
using Microsoft.EntityFrameworkCore;
using GestaoProduto.Servico;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Repositorio;

namespace GestaoProduto.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            #region Injeção de dependencia
            builder.Services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));

            builder.Services.AddScoped<IFornecedorServico, FornecedorServico>();
            builder.Services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
            builder.Services.AddScoped<ArmazenadorFornecedor>();

            builder.Services.AddScoped<IProdutoServico, ProdutoServico>();
            builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            builder.Services.AddScoped<ArmazenadorProduto>();

            builder.Services.AddScoped<IObjetoCustomizadoServico, ObjetoCustomizadoServico>();
            builder.Services.AddScoped<IObjetoCustomizadoRepositorio, ObjetoCustomizadoRepositorio>();

            builder.Services.AddScoped<IProcessoServico, ProcessoServico>();
            builder.Services.AddScoped<IProcessoRepositorio, ProcessoRepositorio>();

            builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            #endregion

            var app = builder.Build();

            app.Use(async (context, next) =>
            {
                //depois que eu invokar todas as minhas requisicoes
                await next.Invoke();

                // busco o metodo para commitar
                var unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
                await unitOfWork.Commit();
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}