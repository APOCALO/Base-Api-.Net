using Infrastructure.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Text;
using Web.Api.Middlewares;
using Web.Api.OptionsSetup;

namespace Web.Api
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Autenticación JWT usando el esquema Bearer. \r\n\r\n " +
                      "Introduce 'Bearer' [espacio] y luego el token en la entrada de texto abajo.\r\n\r\n" +
                      "Ejemplo: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            services.AddTransient<GlobalExceptionHandlingMiddleware>();
            services.AddHealthChecks();

            return services;
        }

        public static IServiceCollection AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // Add authentication
            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionsName));
            services.ConfigureOptions<JwtBearerOptionsSetup>();

            // Get the secret key from the configuration
            var jwtOptions = configuration.GetSection(JwtOptions.SectionsName).Get<JwtOptions>();
            var secretKey = Encoding.UTF8.GetBytes(jwtOptions!.SecretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

            return services;
        }
    }
}
