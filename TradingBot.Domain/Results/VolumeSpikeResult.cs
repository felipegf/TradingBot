namespace TradingBot.Domain.Results
{
    public class VolumeSpikeResult
    {
        public IReadOnlyList<int> SpikeIndexes { get; }
        public IReadOnlyList<double> SpikeVolumes { get; }

        public VolumeSpikeResult(IEnumerable<int> spikeIndexes, IEnumerable<double> spikeVolumes)
        {
            SpikeIndexes = spikeIndexes.ToList().AsReadOnly();
            SpikeVolumes = spikeVolumes.ToList().AsReadOnly();
        }
    }
}
