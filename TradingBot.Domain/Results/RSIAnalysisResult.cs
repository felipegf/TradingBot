namespace TradingBot.Domain.Results
{
    public class RSIAnalysisResult
    {
        public double RSI { get; }
        public string Indication { get; }
        public string ErrorMessage { get; }

        public RSIAnalysisResult(double rsi, string indication)
        {
            RSI = rsi;
            Indication = indication;
        }

        public RSIAnalysisResult(string errorMessage)
        {
            RSI = double.NaN;
            Indication = null;
            ErrorMessage = errorMessage;
        }
    }
}
