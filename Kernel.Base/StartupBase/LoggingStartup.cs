using Serilog;

namespace Kernel.Base.Startup
{
    public static class LoggingStartup
    {
        public static void ConfigureBootstrapLogging()
        {
            var logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateBootstrapLogger();

            Log.Logger = logger;
        }
    }
}
