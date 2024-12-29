using FluentAssertions;
using TradingBot.Domain.Services;
using TradingBot.Shared.Resources;

namespace TradingBot.Tests.Services
{
    public class MovingAverageServiceTests
    {
        private readonly MovingAverageService _service;

        public MovingAverageServiceTests()
        {
            _service = new MovingAverageService();
        }

        [Fact]
        public void CalculateMovingAverages_ShouldReturnFailure_WhenPricesAreEmpty()
        {
            // Arrange
            var prices = new List<double>();
            int period = 5;

            // Act
            var result = _service.CalculateMovingAverages(prices, period);

            // Assert
            result.ErrorMessage.Should().Be(Messages.EmptyPriceList);
        }

        [Fact]
        public void CalculateMovingAverages_ShouldReturnFailure_WhenPeriodIsInvalid()
        {
            // Arrange
            var prices = new List<double> { 1.0, 2.0, 3.0 };
            int period = 0;

            // Act
            var result = _service.CalculateMovingAverages(prices, period);

            // Assert
            result.ErrorMessage.Should().Be(Messages.InvalidPeriod);
        }

        [Fact]
        public void CalculateMovingAverages_ShouldReturnSuccess_WithCorrectValues()
        {
            // Arrange
            var prices = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 };
            int period = 3;

            // Act
            var result = _service.CalculateMovingAverages(prices, period);

            // Assert
            result.SMA.Should().Be(4.0);
            result.EMA.Should().NotBe(0); // Valida que o EMA foi calculado
        }
    }
}
