namespace TradingBot.Domain.Results
{
    /// <summary>
    /// Representa o resultado da análise de picos de volume.
    /// </summary>
    public class VolumeSpikeResult
    {
        public IEnumerable<int> SpikeIndexes { get; }
        public IEnumerable<double> SpikeVolumes { get; }
        public string? Error { get; }

        /// <summary>
        /// Construtor para casos de sucesso.
        /// </summary>
        public VolumeSpikeResult(IEnumerable<int> spikeIndexes, IEnumerable<double> spikeVolumes)
        {
            SpikeIndexes = spikeIndexes ?? Enumerable.Empty<int>();
            SpikeVolumes = spikeVolumes ?? Enumerable.Empty<double>();
            Error = null;
        }

        /// <summary>
        /// Construtor para casos de falha.
        /// </summary>
        public VolumeSpikeResult(IEnumerable<int> spikeIndexes, IEnumerable<double> spikeVolumes, string error)
        {
            SpikeIndexes = spikeIndexes ?? Enumerable.Empty<int>();
            SpikeVolumes = spikeVolumes ?? Enumerable.Empty<double>();
            Error = error;
        }

        /// <summary>
        /// Indica se a operação foi bem-sucedida.
        /// </summary>
        public bool IsSuccess => string.IsNullOrEmpty(Error);
    }
}
