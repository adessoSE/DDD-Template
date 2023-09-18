using Microsoft.Extensions.DependencyInjection;

using DDDTemplate.Domain.Interfaces.Services;
using DDDTemplate.Domain.Services;
using DDDTemplate.Domain.Interfaces.Factories;
using DDDTemplate.Domain.Factories;

namespace DDDTemplate.Domain
{   
    public static class DependencyInjection
    {        
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {            
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<IDomainEventFactory, DomainEventFactory>();            

            return services;
        }
    }
}
