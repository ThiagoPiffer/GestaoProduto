namespace GestaoProduto.API.Configuracao
{
    public static class CorsConfiguracao
    {
        private static readonly string SpecificOrigins = "AllowAllOrigins";

        public static void AddCorsExtensions(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

        }

        public static void AddCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors("AllowAllOrigins");
            // Use o mesmo nome da política definida em ConfigureServices
        }
    }
}
