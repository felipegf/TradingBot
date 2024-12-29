using Serilog;
using TradingBot.Application.Config;
using TradingBot.Domain.Interfaces.Services;
using TradingBot.Domain.Interfaces.Strategies;
using TradingBot.Domain.Services;
using TradingBot.Domain.Strategies;
using TradingBot.Domain.ValueObjects;

namespace TradingBot.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configurar Serilog
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build())
                .WriteTo.Console() // Logs no console
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // Logs em arquivo
                .CreateLogger();

            try
            {
                Log.Information("Iniciando a aplicação...");

                var builder = WebApplication.CreateBuilder(args);

                // Integrar Serilog com o sistema de logging do ASP.NET Core
                builder.Host.UseSerilog();

                // Adicionar appsettings.json e carregar configurações
                builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                // Configurar serviços
                ConfigureServices(builder.Services, builder.Configuration);

                var app = builder.Build();

                // Configurar middleware
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

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Configurar Health Checks
            services.AddHealthChecks();

            // Registrar configurações AlertThresholdsConfig
            services.Configure<AlertThresholdsConfig>(configuration.GetSection("AlertThresholds"));

            // Carregar AlertThresholdsConfig e converter para AlertThresholds
            var alertThresholdsConfig = configuration.GetSection("AlertThresholds").Get<AlertThresholdsConfig>();
            if (alertThresholdsConfig == null)
            {
                throw new InvalidOperationException("Configuração 'AlertThresholds' não encontrada no appsettings.json.");
            }

            var alertThresholds = new AlertThresholds(
                alertThresholdsConfig.RSIOverbought,
                alertThresholdsConfig.RSIOversold,
                alertThresholdsConfig.VolumeSpikeMultiplier
            );

            // Registrar AlertThresholds como singleton
            services.AddSingleton(alertThresholds);

            // Registro dos serviços
            services.AddTransient<IMovingAverageService, MovingAverageService>();
            services.AddTransient<IRSIAnalysisService, RSIAnalysisService>();
            services.AddTransient<IVolumeSpikeService, VolumeSpikeService>();
            services.AddTransient<IAlertService, AlertService>();

            // Registro das estratégias
            services.AddTransient<IAlertStrategy, RSIAlertStrategy>();
            services.AddTransient<IAlertStrategy, VolumeSpikeAlertStrategy>();
        }

        private static void ConfigureMiddleware(WebApplication app)
        {
            // Rota para Health Checks
            app.MapHealthChecks("/health");

            // (Opcional) Middleware adicional
        }
    }
}
