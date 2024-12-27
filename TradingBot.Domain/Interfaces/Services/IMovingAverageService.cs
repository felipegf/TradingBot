using TradingBot.Domain.Results;

namespace TradingBot.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para o serviço de cálculo de médias móveis.
    /// </summary>
    public interface IMovingAverageService
    {
        /// <summary>
        /// Calcula as médias móveis simples (SMA) e exponenciais (EMA) para um conjunto de preços.
        /// </summary>
        /// <param name="prices">Lista de preços.</param>
        /// <param name="period">Período para cálculo das médias móveis.</param>
        /// <returns>Um objeto do tipo MovingAverageResult contendo os valores de SMA e EMA.</returns>
        MovingAverageResult CalculateMovingAverages(List<double> prices, int period);
    }
}
