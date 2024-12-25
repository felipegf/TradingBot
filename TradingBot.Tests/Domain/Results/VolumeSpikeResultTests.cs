using FluentAssertions;
using TradingBot.Domain.Results;

namespace TradingBot.Tests.Domain.Results
{
    public class VolumeSpikeResultTests
    {
        [Fact]
        public void ShouldInitializeCorrectly()
        {
            // Arrange
            var spikeIndexes = new List<int> { 1, 5, 7 };
            var spikeVolumes = new List<double> { 1200.5, 1500.3, 2000.8 };

            // Act
            var result = new VolumeSpikeResult(spikeIndexes, spikeVolumes);

            // Assert
            result.SpikeIndexes.Should().BeEquivalentTo(spikeIndexes);
            result.SpikeVolumes.Should().BeEquivalentTo(spikeVolumes);
        }

        [Fact]
        public void ShouldHandleEmptyCollections()
        {
            // Act
            var result = new VolumeSpikeResult(new List<int>(), new List<double>());

            // Assert
            result.SpikeIndexes.Should().BeEmpty();
            result.SpikeVolumes.Should().BeEmpty();
        }
    }
}
