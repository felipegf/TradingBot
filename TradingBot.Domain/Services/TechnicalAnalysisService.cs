using TradingBot.Shared.Extensions;
using TradingBot.Shared.Resources;
using TradingBot.Shared.Results;

namespace TradingBot.Domain.Services
{
    public class TechnicalAnalysisService
    {
        // Cálculo de Média Móvel Simples (SMA)
        public Result<List<double>> CalculateSMA(List<double> prices, int period)
        {
            if (prices.IsNullOrEmpty() || period <= 0)
            {
                return Result<List<double>>.Failure(ErrorMessages.InvalidData);
            }

            if (prices.Count < period)
            {
                return Result<List<double>>.Failure(ErrorMessages.InsufficientData);
            }

            var sma = new List<double>();

            for (int i = 0; i <= prices.Count - period; i++)
            {
                var average = prices.Skip(i).Take(period).Average();
                sma.Add(average);
            }

            return Result<List<double>>.Success(sma);
        }

        // Cálculo de Média Móvel Exponencial (EMA)
        public Result<List<double>> CalculateEMA(List<double> prices, int period)
        {
            if (prices.IsNullOrEmpty() || period <= 0)
            {
                return Result<List<double>>.Failure(ErrorMessages.InvalidData);
            }

            if (prices.Count < period)
            {
                return Result<List<double>>.Failure(ErrorMessages.InsufficientData);
            }

            var ema = new List<double>();
            double multiplier = 2.0 / (period + 1);

            // Calcular EMA inicial com base em SMA
            var initialSMA = prices.Take(period).Average();
            ema.Add(initialSMA);

            // Calcular EMA para os períodos subsequentes
            for (int i = period; i < prices.Count; i++)
            {
                var value = (prices[i] - ema.Last()) * multiplier + ema.Last();
                ema.Add(value);
            }

            return Result<List<double>>.Success(ema);
        }

        // Identificar Volume Spikes
        public Result<List<int>> IdentifyVolumeSpikes(List<double> volumes, double multiplier = 2.0)
        {
            if (volumes.IsNullOrEmpty() || multiplier <= 0)
            {
                return Result<List<int>>.Failure(ErrorMessages.InvalidData);
            }

            var averageVolume = volumes.Average();
            var threshold = averageVolume * multiplier;
            var spikes = volumes.Select((v, i) => v > threshold ? i : -1).Where(i => i != -1).ToList();

            return Result<List<int>>.Success(spikes);
        }
    }
}
