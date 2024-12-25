using TradingBot.Shared.Resources;

namespace TradingBot.Domain.Results
{
    /// <summary>
    /// Resultado para os cálculos de médias móveis.
    /// </summary>
    public class MovingAverageResult
    {
        public double SMA { get; }
        public double EMA { get; }
        public int Period { get; }
        public string? ErrorMessage { get; }

        /// <summary>
        /// Construtor para casos de sucesso.
        /// </summary>
        public MovingAverageResult(double sma, double ema, int period)
        {
            SMA = sma;
            EMA = ema;
            Period = period;
            ErrorMessage = null;
        }

        /// <summary>
        /// Construtor para casos de falha.
        /// </summary>
        public MovingAverageResult(double sma, double ema, int period, string? errorMessage)
        {
            SMA = sma;
            EMA = ema;
            Period = period;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Indica se o cálculo foi bem-sucedido.
        /// </summary>
        public bool IsSuccess => string.IsNullOrEmpty(ErrorMessage);
    }
}
