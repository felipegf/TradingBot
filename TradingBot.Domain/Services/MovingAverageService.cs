using TradingBot.Domain.Results;
using TradingBot.Shared.Extensions;
using TradingBot.Shared.Resources;

namespace TradingBot.Domain.Services
{
    /// <summary>
    /// Serviço responsável pelo cálculo de médias móveis simples (SMA) e exponenciais (EMA).
    /// As médias móveis são usadas para suavizar dados de preços e identificar tendências.
    /// </summary>
    public class MovingAverageService
    {
        /// <summary>
        /// Calcula as médias móveis simples (SMA) e exponenciais (EMA) para um conjunto de preços.
        /// </summary>
        /// <param name="prices">Lista de preços.</param>
        /// <param name="period">Período para cálculo das médias móveis.</param>
        /// <returns>Um objeto do tipo MovingAverageResult contendo os valores de SMA e EMA.</returns>
        public MovingAverageResult CalculateMovingAverages(List<double> prices, int period)
        {
            if (prices.IsNullOrEmpty())
                return new MovingAverageResult(0, 0, period, ErrorMessages.EmptyPriceList);

            if (period <= 0)
                return new MovingAverageResult(0, 0, period, ErrorMessages.InvalidPeriod);

            // Cálculo da média móvel simples (SMA)
            double sma = prices.TakeLast(period).Average();

            // Cálculo da média móvel exponencial (EMA)
            double ema = CalculateEMA(prices, period);

            return new MovingAverageResult(sma, ema, period, null);
        }

        /// <summary>
        /// Calcula a média móvel exponencial (EMA) para um conjunto de preços.
        /// </summary>
        /// <param name="prices">Lista de preços.</param>
        /// <param name="period">Período para cálculo da EMA.</param>
        /// <returns>O valor da EMA calculado.</returns>
        private double CalculateEMA(List<double> prices, int period)
        {
            double multiplier = 2.0 / (period + 1); // Multiplicador para a EMA
            double ema = prices.Take(period).Average(); // Média inicial baseada no período

            // Aplica o cálculo da EMA para cada preço após o período inicial
            foreach (var price in prices.Skip(period))
            {
                ema = ((price - ema) * multiplier) + ema;
            }

            return ema;
        }
    }
}
