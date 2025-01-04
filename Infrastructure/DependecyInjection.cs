using Application.Interfaces;
using Azure.Messaging.ServiceBus;
using Domain.Primitives;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services;
using Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistenceSQLServer(configuration);
            services.AddAzureServiceBus(configuration);
            services.AddRedis(configuration);

            return services;
        }

        private static IServiceCollection AddPersistenceSQLServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DatabaseConnection"), options => options.EnableRetryOnFailure());
            });

            services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            // Repositories dependency inyection
            services.AddScoped<ICustomerRepository, CustomerRepository>();


            return services;
        }

        private static IServiceCollection AddAzureServiceBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ServiceBusClient>(options =>
            {
                var connectionString = configuration.GetConnectionString("AzureServiceBus");
                return new ServiceBusClient(connectionString);
            });

            services.AddScoped<IMessageBusService, AzureServiceBusService>();


            return services;
        }

        private static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnectionMultiplexer>(options =>
            {
                var redisSettings = configuration.GetSection("RedisSettings").Get<RedisSettings>();
                return ConnectionMultiplexer.Connect(redisSettings!.ConnectionString);
            });

            services.AddTransient<IRedisCacheService, RedisCacheService>();

            return services;
        }
    }
}
