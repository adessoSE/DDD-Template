using Kernel.Base.Services;
using Kernel.Contracts.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kernel.Base.Startup
{
    public static class DomainStartup
    {
        public static IServiceCollection AddDomainBase(this IServiceCollection services)
        {
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddScoped<IUserAccessorService, UserAccessorService>();
            services.AddSingleton<IDateTimeService, DateTimeService>();
            return services;
        }
    }
}
