using FluentAssertions;
using TradingBot.Domain.Services;

namespace TradingBot.Tests.Services
{
    public class RSIAnalysisServiceTests
    {
        private readonly RSIAnalysisService _rsiAnalysisService;

        public RSIAnalysisServiceTests()
        {
            _rsiAnalysisService = new RSIAnalysisService();
        }

        [Fact]
        public void CalculateRSI_ShouldReturnOversold_WhenRSIIsBelow30()
        {
            // Arrange
            var priceChanges = new List<double> { -1.5, -0.8, -1.2, 0.2, -0.4, -0.6 };

            // Act
            var result = _rsiAnalysisService.CalculateRSI(priceChanges);

            // Assert
            result.RSI.Should().BeLessThan(30.0);
            result.Indication.Should().Be("Oversold");
        }

        [Fact]
        public void CalculateRSI_ShouldReturnOverbought_WhenRSIIsAbove70()
        {
            // Arrange
            var priceChanges = new List<double> { 1.5, 0.8, 0.9, 1.2, -0.1, 0.5, 1.3 };

            // Act
            var result = _rsiAnalysisService.CalculateRSI(priceChanges);

            // Assert
            result.RSI.Should().BeGreaterThan(70);
            result.Indication.Should().Be("Overbought");
        }

        [Fact]
        public void CalculateRSI_ShouldReturnIntermediateValue_WhenRSIIsBetween30And70()
        {
            // Arrange
            var priceChanges = new List<double> { 1.0, -0.5, 0.7, -0.3, 0.2, -0.1 };

            // Act
            var result = _rsiAnalysisService.CalculateRSI(priceChanges);

            // Assert
            result.RSI.Should().BeInRange(30.0, 70.0);
            result.Indication.Should().Be("Neutral");
        }
    }
}
