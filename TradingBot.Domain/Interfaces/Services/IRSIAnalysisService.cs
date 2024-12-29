using TradingBot.Domain.Results;

namespace TradingBot.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para o serviço de análise de RSI (Índice de Força Relativa).
    /// </summary>
    public interface IRSIAnalysisService
    {
        /// <summary>
        /// Calcula o Índice de Força Relativa (RSI) com base nas variações de preço.
        /// </summary>
        /// <param name="priceChanges">Lista de variações de preço.</param>
        /// <returns>Um resultado contendo o valor do RSI e uma indicação de mercado.</returns>
        RSIAnalysisResult CalculateRSI(List<double> priceChanges);
    }
}
