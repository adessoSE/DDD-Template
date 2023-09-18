using FluentValidation.AspNetCore;
using Kernel.Contracts.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;
using System.Text.Json.Serialization;

namespace Kernel.Base.Startup
{    
    public static class StartupBase
    {
        public static void ConfigureStartupServices(WebApplicationBuilder builder, params Assembly[] assemblies)
        {            
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            builder.Services.AddServiceBusBase(builder.Configuration, assemblies);
            builder.Services.AddDomainBase();            

            // Add services to the container.
            builder.Services.AddEndpointsApiExplorer();            
            HealthCheckStartup.ConfigureServices(builder.Services);

            builder.Services.AddControllersWithViews();
            builder.Services.AddFluentValidationAutoValidation();

            builder.Services
                .AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))                
                .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);           

            // Customise default API behaviour
            builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);            
        }

        public static void ConfigureApp(WebApplication app)
        {
            HealthCheckStartup.ConfigureApp(app);
            app.MapControllers().RequireAuthorization();            
        }
    }
}
