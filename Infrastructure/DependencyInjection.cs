using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DDDTemplate.Domain.Interfaces.Repositories;
using DDDTemplate.Domain.Interfaces.Services;
using DDDTemplate.Infrastructure.Persistence;
using DDDTemplate.Infrastructure.Services;

namespace DDDTemplate.Infrastructure
{    
    public static class DependencyInjection
    {         
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)        
        {               
            services.AddScoped<IEmailService, SmtpEmailSender>();            

            services.AddDbContext<TemplateDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("SqlDb"),
                            b => b.MigrationsAssembly(typeof(TemplateDbContext).Assembly.FullName))
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors());

            services.AddDbContext<UserDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("SqlDb")));            

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();            

            services.AddHealthChecks().AddDbContextCheck<TemplateDbContext>();            

            return services;
        }        
    }
}
