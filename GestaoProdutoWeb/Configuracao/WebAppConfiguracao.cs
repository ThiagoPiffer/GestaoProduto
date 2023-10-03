using GestaoProduto.Dominio._Base;
using Microsoft.AspNetCore.Builder;

namespace GestaoProduto.API.Configuracao
{
    public static class WebAppConfiguracao
    {
        public static void AddMvcConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
            services.Configure<AppSettings>(configuration);
        }

        public static void UseMvcConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseCors("AllowSpecificOrigin");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityConfiguration();
            //app.UseAuthentication();
            //app.UseAuthorization();

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
