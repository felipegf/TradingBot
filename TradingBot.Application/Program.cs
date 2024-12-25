using Serilog;

namespace TradingBot.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configurar Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console() // Logs no console
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // Logs em arquivo
                .CreateLogger();

            try
            {
                Log.Information("Iniciando a aplicação...");

                var builder = WebApplication.CreateBuilder(args);

                // Integrar Serilog com o sistema de logging do ASP.NET Core
                builder.Host.UseSerilog();

                ConfigureServices(builder.Services);

                var app = builder.Build();

                ConfigureMiddleware(app);

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "A aplicação falhou ao iniciar");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
        }

        private static void ConfigureMiddleware(WebApplication app)
        {
            app.MapHealthChecks("/health");
        }
    }
}

