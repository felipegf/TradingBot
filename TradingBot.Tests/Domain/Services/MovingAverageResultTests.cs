using FluentAssertions;
using TradingBot.Domain.Results;

namespace TradingBot.Tests.Domain.Services
{
    public class MovingAverageResultTests
    {
        [Fact]
        public void ShouldInitializeCorrectly()
        {
            // Arrange
            double sma = 1.23;
            double ema = 2.34;
            int period = 14;

            // Act
            var result = new MovingAverageResult(sma, ema, period);

            // Assert
            result.SMA.Should().Be(sma);
            result.EMA.Should().Be(ema);
            result.Period.Should().Be(period);
        }
    }
}
