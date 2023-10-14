namespace GestaoProduto.Identidade.Configuration
{
    public static class CorsConfiguracao
    {
        private static readonly string SpecificOrigins = "_specificOrigins";//"AllowEverything";

        public static void AddCorsExtensions(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: SpecificOrigins,
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
            app.UseCors(SpecificOrigins); // Use a política de CORS que você definiu

        }
    }
}


