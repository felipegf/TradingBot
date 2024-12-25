namespace TradingBot.Domain.Results
{
    public class RSIAnalysisResult
    {
        public double RSIValue { get; }
        public string? Indication { get; }

        public RSIAnalysisResult(double rsiValue, string? indication = null)
        {
            RSIValue = rsiValue;
            Indication = indication;
        }
    }
}
