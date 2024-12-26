namespace TradingBot.Domain.Results
{
    /// <summary>
    /// Resultado do cálculo do índice de força relativa (RSI).
    /// </summary>
    public class RSIAnalysisResult
    {
        /// <summary>
        /// Valor calculado do RSI.
        /// </summary>
        public double RSI { get; }

        /// <summary>
        /// Indicação do mercado com base no RSI (ex.: "Oversold", "Overbought", "Neutral").
        /// Pode ser nula em cenários específicos.
        /// </summary>
        public string? Indication { get; }

        /// <summary>
        /// Mensagem de erro, se houver.
        /// </summary>
        public string? ErrorMessage { get; }

        /// <summary>
        /// Construtor para resultados válidos.
        /// </summary>
        /// <param name="rsi">Valor do RSI.</param>
        /// <param name="indication">Indicação do mercado, pode ser nula.</param>
        public RSIAnalysisResult(double rsi, string? indication)
        {
            RSI = rsi;
            Indication = indication;
            ErrorMessage = null;
        }

        /// <summary>
        /// Construtor para resultados inválidos.
        /// </summary>
        /// <param name="errorMessage">Mensagem de erro.</param>
        public RSIAnalysisResult(string errorMessage)
        {
            RSI = double.NaN;
            Indication = null;
            ErrorMessage = errorMessage;
        }
    }
}
