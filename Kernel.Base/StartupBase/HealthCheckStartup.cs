using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Kernel.Base.Startup
{
    public static class HealthCheckStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
        }

        public static void ConfigureApp(WebApplication app)
        {
            app.MapHealthChecks("/health");

            app.MapHealthChecks(
                "/health/details",
                new HealthCheckOptions { ResponseWriter = HealthCheckResponseWriterAsync });
        }

        private static async Task HealthCheckResponseWriterAsync(HttpContext context, HealthReport report)
        {
            var healthResult = new
            {
                Status = report.Status.ToString(),
                Duration = report.TotalDuration,
                Info = report.Entries.Select(e => new
                {
                    Key = e.Key,
                    Description = e.Value.Description,
                    Duration = e.Value.Duration,
                    Status = Enum.GetName(typeof(HealthStatus), e.Value.Status),
                    Error = e.Value.Exception?.Message
                }).ToArray()
            };

            var result = JsonSerializer.Serialize(
                healthResult,
                new JsonSerializerOptions
                {
                    WriteIndented = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });

            context.Response.ContentType = MediaTypeNames.Application.Json;

            await context.Response.WriteAsync(result);
        }
    }
}
