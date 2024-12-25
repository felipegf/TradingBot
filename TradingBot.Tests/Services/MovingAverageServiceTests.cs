using FluentAssertions;
using TradingBot.Domain.Services;
using TradingBot.Shared.Resources;

namespace TradingBot.Tests.Services
{
    public class MovingAverageServiceTests
    {
        private readonly TechnicalAnalysisService _service;

        public MovingAverageServiceTests()
        {
            _service = new TechnicalAnalysisService();
        }

        //Testes para SMA (CalculateSMA)

        [Fact]
        public void CalculateSMA_ShouldReturnFailure_WhenPricesAreEmpty()
        {
            // Arrange
            var prices = new List<double>();
            int period = 5;

            // Act
            var result = _service.CalculateSMA(prices, period);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(ErrorMessages.InvalidData);
        }

        [Fact]
        public void CalculateSMA_ShouldReturnFailure_WhenPeriodIsInvalid()
        {
            // Arrange
            var prices = new List<double> { 1.0, 2.0, 3.0 };
            int period = 0;

            // Act
            var result = _service.CalculateSMA(prices, period);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(ErrorMessages.InvalidData);
        }

        [Fact]
        public void CalculateSMA_ShouldReturnSuccess_WithCorrectValues()
        {
            // Arrange
            var prices = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 };
            int period = 3;

            // Act
            var result = _service.CalculateSMA(prices, period);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(new List<double> { 2.0, 3.0, 4.0 });
        }

        [Fact]
        public void CalculateEMA_ShouldReturnFailure_WhenPricesAreEmpty()
        {
            // Arrange
            var prices = new List<double>();
            int period = 5;

            // Act
            var result = _service.CalculateEMA(prices, period);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(ErrorMessages.InvalidData);
        }

        //Testes para EMA (CalculateEMA)

        [Fact]
        public void CalculateEMA_ShouldReturnSuccess_WithCorrectValues()
        {
            // Arrange
            var prices = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 };
            int period = 3;

            // Act
            var result = _service.CalculateEMA(prices, period);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
        }

        //Testes para Volume Spikes(IdentifyVolumeSpikes)

        [Fact]
        public void IdentifyVolumeSpikes_ShouldReturnFailure_WhenVolumesAreEmpty()
        {
            // Arrange
            var volumes = new List<double>();

            // Act
            var result = _service.IdentifyVolumeSpikes(volumes);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(ErrorMessages.InvalidData);
        }

        [Fact]
        public void IdentifyVolumeSpikes_ShouldReturnSuccess_WithCorrectIndexes()
        {
            // Arrange
            var volumes = new List<double> { 10, 15, 50, 20, 12 };
            double multiplier = 2.0;

            // Act
            var result = _service.IdentifyVolumeSpikes(volumes, multiplier);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(new List<int> { 2 });
        }
    }
}
