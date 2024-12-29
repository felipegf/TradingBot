using FluentAssertions;
using TradingBot.Domain.Services;
using TradingBot.Shared.Resources;

namespace TradingBot.Tests.Services
{
    public class RSIAnalysisServiceTests
    {
        private readonly RSIAnalysisService _service;

        public RSIAnalysisServiceTests()
        {
            _service = new RSIAnalysisService();
        }

        [Fact]
        public void CalculateRSI_ShouldReturnFailure_WhenPriceChangesAreEmpty()
        {
            // Arrange
            var priceChanges = new List<double>();

            // Act
            var result = _service.CalculateRSI(priceChanges);

            // Assert
            result.ErrorMessage.Should().Be(Messages.EmptyPriceChangeList);
        }

        [Fact]
        public void CalculateRSI_ShouldReturnSuccess_WithCorrectRSI()
        {
            // Arrange
            var priceChanges = new List<double> { 1.0, -1.0, 2.0, -0.5, 0.5 };

            // Act
            var result = _service.CalculateRSI(priceChanges);

            // Assert
            result.RSI.Should().BeGreaterThan(0);
            result.RSI.Should().BeLessThanOrEqualTo(100);
        }
    }
}
