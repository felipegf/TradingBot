﻿using TradingBot.Domain.Interfaces.Services;
using TradingBot.Domain.Results;
using TradingBot.Shared.Resources;

namespace TradingBot.Domain.Services
{
    /// <summary>
    /// Serviço responsável pelo cálculo do índice de força relativa (RSI).
    /// O RSI é um indicador técnico utilizado para medir a velocidade e a mudança nos movimentos de preço.
    /// </summary>
    public class RSIAnalysisService : IRSIAnalysisService
    {
        /// <summary>
        /// Calcula o índice de força relativa (RSI) com base em uma lista de variações de preços.
        /// </summary>
        /// <param name="priceChanges">Lista de variações de preços.</param>
        /// <returns>Um objeto do tipo RSIAnalysisResult contendo o valor do RSI e a indicação de mercado.</returns>
        public RSIAnalysisResult CalculateRSI(List<double> priceChanges)
        {
            if (priceChanges == null || !priceChanges.Any())
                return new RSIAnalysisResult(double.NaN, ErrorMessages.EmptyPriceChangeList);

            var gains = priceChanges.Where(p => p > 0).Sum(); // Soma de todos os ganhos
            var losses = Math.Abs(priceChanges.Where(p => p < 0).Sum()); // Soma absoluta de todas as perdas

            if (losses == 0) return new RSIAnalysisResult(100, "Overbought"); // Nenhuma perda
            if (gains == 0) return new RSIAnalysisResult(0, "Oversold"); // Nenhum ganho

            var rs = gains / losses; // Relação entre ganhos e perdas
            var rsi = 100 - (100 / (1 + rs)); // Fórmula do RSI

            var indication = rsi switch
            {
                < 30 => "Oversold", // Mercado em sobrevenda
                > 70 => "Overbought", // Mercado em sobrecompra
                _ => "Neutral" // Mercado neutro
            };

            return new RSIAnalysisResult(rsi, indication);
        }
    }
}
