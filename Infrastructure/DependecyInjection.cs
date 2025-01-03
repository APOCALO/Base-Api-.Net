using Application.Interfaces;
using Azure.Messaging.ServiceBus;
using Domain.Primitives;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistenceSQLServer(configuration);
            services.AddAzureServiceBus(configuration);
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
                var connectionString = configuration["ConnectionStrings:AzureServiceBus"];
                return new ServiceBusClient(connectionString);
            });

            services.AddScoped<IMessageBusService, AzureServiceBusService>();


            return services;
        }
    }
}
