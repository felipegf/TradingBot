namespace TradingBot.Domain.Results
{
    public class MovingAverageResult
    {
        public double SMA { get; }
        public double EMA { get; }
        public int Period { get; }

        public MovingAverageResult(double sma, double ema, int period)
        {
            SMA = sma;
            EMA = ema;
            Period = period;
        }
    }
}
