using TradingBot.Domain.Entities.Alerts;
using TradingBot.Domain.Interfaces.Strategies;
using TradingBot.Domain.Results;

namespace TradingBot.Domain.Strategies
{
    /// <summary>
    /// Estratégia para gerar alertas com base em spikes de volume.
    /// </summary>
    public class VolumeSpikeAlertStrategy : IAlertStrategy
    {
        public List<Alert> GenerateAlerts(
            RSIAnalysisResult rsiResult,
            MovingAverageResult maResult,
            VolumeSpikeResult volumeResult)
        {
            var alerts = new List<Alert>();

            // Verifica se há spikes de volume
            if (volumeResult.SpikeIndexes.Any())
            {
                var spikeIndexes = string.Join(", ", volumeResult.SpikeIndexes);
                alerts.Add(new RiskAlert($"Spikes de volume detectados nos índices: {spikeIndexes}."));
            }

            return alerts;
        }
    }
}
