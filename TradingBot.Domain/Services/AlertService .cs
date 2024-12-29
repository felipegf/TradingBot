using TradingBot.Domain.Entities.Alerts;
using TradingBot.Domain.Interfaces.Services;
using TradingBot.Domain.Interfaces.Strategies;
using TradingBot.Domain.Results;

namespace TradingBot.Domain.Services
{
    /// <summary>
    /// Serviço para geração de alertas com base nos resultados de análises técnicas.
    /// </summary>
    public class AlertService : IAlertService
    {
        private readonly IEnumerable<IAlertStrategy> _alertStrategies;

        /// <summary>
        /// Construtor para injetar as estratégias de geração de alertas.
        /// </summary>
        /// <param name="alertStrategies">Coleção de estratégias de alertas.</param>
        public AlertService(IEnumerable<IAlertStrategy> alertStrategies)
        {
            _alertStrategies = alertStrategies;
        }

        /// <summary>
        /// Gera alertas com base nos resultados de análises técnicas.
        /// </summary>
        /// <param name="rsiResult">Resultado da análise RSI.</param>
        /// <param name="maResult">Resultado das médias móveis.</param>
        /// <param name="volumeResult">Resultado da análise de picos de volume.</param>
        /// <returns>Uma lista de alertas gerados.</returns>
        public List<Alert> GenerateAlerts(
            RSIAnalysisResult rsiResult,
            MovingAverageResult maResult,
            VolumeSpikeResult volumeResult)
        {
            var alerts = new List<Alert>();

            foreach (var strategy in _alertStrategies)
            {
                alerts.AddRange(strategy.GenerateAlerts(rsiResult, maResult, volumeResult));
            }

            return alerts;
        }
    }
}
