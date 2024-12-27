namespace TradingBot.Application.Config
{
    /// <summary>
    /// Configurações para os limiares de geração de alertas.
    /// </summary>
    public class AlertThresholdsConfig
    {
        /// <summary>
        /// Limite superior para o RSI (sobrecomprado).
        /// </summary>
        public double RSIOverbought { get; set; }

        /// <summary>
        /// Limite inferior para o RSI (sobrevendido).
        /// </summary>
        public double RSIOversold { get; set; }

        /// <summary>
        /// Multiplicador para identificar spikes de volume.
        /// </summary>
        public double VolumeSpikeMultiplier { get; set; }
    }
}
