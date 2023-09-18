using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace Kernel.Base.Startup
{
    public static class ServiceBusStartup
    {
        public static IServiceCollection AddServiceBusBase(
            this IServiceCollection services,
            IConfiguration configuration,
            params Assembly[] scanningAssemblies)
        {
            var serviceBusConnectionString = configuration.GetConnectionString("AzServiceBus");

            var messageBusPrefix = configuration.GetSection("StartupOptions").GetValue<string>("MessageBusPrefix");
            if (string.IsNullOrEmpty(messageBusPrefix))
            {
                throw new ConfigurationException("configuration for connection string 'StartupOptions:MessageBusPrefix' is missing or failed");
            }

            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(messageBusPrefix, false));
                busConfigurator.AddConsumers(scanningAssemblies);

                if (!string.IsNullOrEmpty(serviceBusConnectionString))
                {
                    busConfigurator.UsingAzureServiceBus((context, cfg) =>
                    {
                        cfg.Host(serviceBusConnectionString);
                        cfg.ConfigureEndpoints(context);                        
                    });
                }
                else
                {
                    var rabbitMqHost = configuration.GetValue("RabbitMqHost", "localhost");

                    busConfigurator.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host(rabbitMqHost);
                        cfg.ConfigureEndpoints(context);                        
                    });
                }
            });

            return services;
        }
    }
}
