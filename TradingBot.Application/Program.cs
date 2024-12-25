namespace TradingBot.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar serviços (Dependências)
            ConfigureServices(builder.Services);

            var app = builder.Build();

            // Configurar o pipeline de requisições HTTP
            ConfigureMiddleware(app);

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Adicionar Health Checks
            services.AddHealthChecks();

            // Adicionar outras dependências, ex.:
            // services.AddSingleton<IMyService, MyService>();
        }

        private static void ConfigureMiddleware(WebApplication app)
        {
            // Endpoint para Health Check
            app.MapHealthChecks("/health");

            // Mapear outras rotas, se necessário
            // app.MapGet("/", () => "Hello, TradingBot!");
        }
    }
}
