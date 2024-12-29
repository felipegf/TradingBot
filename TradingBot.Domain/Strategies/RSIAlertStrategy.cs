using TradingBot.Domain.Entities.Alerts;
using TradingBot.Domain.Interfaces.Strategies;
using TradingBot.Domain.Results;
using TradingBot.Domain.ValueObjects;

namespace TradingBot.Domain.Strategies
{
    /// <summary>
    /// Estratégia para gerar alertas com base no Índice de Força Relativa (RSI).
    /// </summary>
    public class RSIAlertStrategy : IAlertStrategy
    {
        private readonly AlertThresholds _thresholds;

        public RSIAlertStrategy(AlertThresholds thresholds)
        {
            _thresholds = thresholds;
        }

        public List<Alert> GenerateAlerts(
            RSIAnalysisResult rsiResult,
            MovingAverageResult maResult,
            VolumeSpikeResult volumeResult)
        {
            var alerts = new List<Alert>();

            if (rsiResult.RSI < _thresholds.RSIOversold)
            {
                alerts.Add(new BuyAlert($"RSI abaixo de {_thresholds.RSIOversold}: {rsiResult.RSI} (sobrevendido)."));
            }

            if (rsiResult.RSI > _thresholds.RSIOverbought)
            {
                alerts.Add(new SellAlert($"RSI acima de {_thresholds.RSIOverbought}: {rsiResult.RSI} (sobrecomprado)."));
            }

            return alerts;
        }
    }
}
