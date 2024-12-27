using TradingBot.Domain.Entities.Alerts;
using TradingBot.Domain.Results;

namespace TradingBot.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para o serviço de geração de alertas.
    /// </summary>
    public interface IAlertService
    {
        /// <summary>
        /// Gera alertas com base nos resultados de análises técnicas.
        /// </summary>
        /// <param name="rsiResult">Resultado da análise RSI.</param>
        /// <param name="maResult">Resultado das médias móveis.</param>
        /// <param name="volumeResult">Resultado da análise de picos de volume.</param>
        /// <returns>Uma lista de alertas gerados.</returns>
        List<Alert> GenerateAlerts(
            RSIAnalysisResult rsiResult,
            MovingAverageResult maResult,
            VolumeSpikeResult volumeResult);
    }
}
