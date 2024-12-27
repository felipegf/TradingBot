namespace TradingBot.Domain.ValueObjects
{
    /// <summary>
    /// Representa os limiares configuráveis para geração de alertas.
    /// </summary>
    public class AlertThresholds
    {
        public double RSIOverbought { get; }
        public double RSIOversold { get; }
        public double VolumeSpikeMultiplier { get; }

        public AlertThresholds(double rsiOverbought, double rsiOversold, double volumeSpikeMultiplier)
        {
            RSIOverbought = rsiOverbought;
            RSIOversold = rsiOversold;
            VolumeSpikeMultiplier = volumeSpikeMultiplier;
        }
    }
}
