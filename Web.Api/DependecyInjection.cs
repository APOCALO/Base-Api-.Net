using Web.Api.Middlewares;

namespace Web.Api
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services) 
        {
            services.AddControllers();

            // Add Swagger
            services.AddSwaggerGen();

            // Agregamos endpoint de salud /health
            services.AddHealthChecks();

            services.AddTransient<GlobalExceptionHandlingMiddleware>();

            return services;
        }
    }
}
