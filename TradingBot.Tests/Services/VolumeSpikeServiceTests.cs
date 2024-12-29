using FluentAssertions;
using TradingBot.Domain.Services;
using TradingBot.Shared.Resources;

namespace TradingBot.Tests.Services
{
    public class VolumeSpikeServiceTests
    {
        private readonly VolumeSpikeService _service;

        public VolumeSpikeServiceTests()
        {
            _service = new VolumeSpikeService();
        }

        [Fact]
        public void IdentifyVolumeSpikes_ShouldReturnFailure_WhenVolumesAreEmpty()
        {
            // Arrange
            var volumes = new List<double>();

            // Act
            var result = _service.IdentifyVolumeSpikes(volumes, 2.0);

            // Assert
            result.Error.Should().Be(Messages.EmptyVolumeList);
        }

        [Fact]
        public void IdentifyVolumeSpikes_ShouldReturnSuccess_WithCorrectSpikes()
        {
            // Arrange
            var volumes = new List<double> { 10, 15, 50, 20, 12 };
            double multiplier = 2.0;

            // Act
            var result = _service.IdentifyVolumeSpikes(volumes, multiplier);

            // Assert
            result.SpikeIndexes.Should().BeEquivalentTo(new List<int> { 2 });
            result.SpikeVolumes.Should().BeEquivalentTo(new List<double> { 50 });
        }
    }
}
