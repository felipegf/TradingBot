using FluentAssertions;
using TradingBot.Domain.Results;

namespace TradingBot.Tests.Domain.Services
{
    public class RSIAnalysisResultTests
    {
        [Fact]
        public void ShouldInitializeCorrectly()
        {
            // Arrange
            double rsiValue = 45.6;
            string indication = "Neutral";

            // Act
            var result = new RSIAnalysisResult(rsiValue, indication);

            // Assert
            result.RSI.Should().Be(rsiValue);
            result.Indication.Should().Be(indication);
        }

        [Fact]
        public void ShouldAllowNullIndication()
        {
            // Arrange
            double rsiValue = 70.2;

            // Act
            var result = new RSIAnalysisResult(rsiValue, null);

            // Assert
            result.RSI.Should().Be(rsiValue);
            result.Indication.Should().BeNull();
        }
    }
}
