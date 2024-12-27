using TradingBot.Domain.Entities.Alerts;
using TradingBot.Domain.Results;

namespace TradingBot.Domain.Interfaces.Strategies
{
    /// <summary>
    /// Interface para estratégias de geração de alertas.
    /// </summary>
    public interface IAlertStrategy
    {
        List<Alert> GenerateAlerts(RSIAnalysisResult rsiResult, MovingAverageResult maResult, VolumeSpikeResult volumeResult);
    }
}
