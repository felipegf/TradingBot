using TradingBot.Shared.Resources;

namespace TradingBot.Domain.Services
{
    public class RSIAnalysisService
    {
        public double CalculateRSI(List<double> priceChanges)
        {
            if (priceChanges == null || !priceChanges.Any())
                throw new ArgumentException(ErrorMessages.EmptyPriceChangeList);

            var gains = priceChanges.Where(p => p > 0).Sum();
            var losses = Math.Abs(priceChanges.Where(p => p < 0).Sum());

            if (losses == 0) return 100; // Nenhuma perda
            if (gains == 0) return 0;   // Nenhum ganho

            var rs = gains / losses;
            var rsi = 100 - (100 / (1 + rs));

            return rsi;
        }
    }
}
