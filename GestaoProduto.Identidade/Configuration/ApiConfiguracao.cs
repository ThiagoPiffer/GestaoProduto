using GestaoProduto.Core.Identidade;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace GestaoProduto.Identidade.Configuration
{
    public static class ApiConfiguracao
    {
        public static IServiceCollection AddApiConfiguration (this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();
            app.UseAuthConfiguration();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });

            return app;
        }
    }
}
