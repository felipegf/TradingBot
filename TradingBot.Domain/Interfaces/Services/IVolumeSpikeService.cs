using TradingBot.Domain.Results;

namespace TradingBot.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para o serviço de análise de picos de volume.
    /// </summary>
    public interface IVolumeSpikeService
    {
        /// <summary>
        /// Identifica picos de volume em uma lista de volumes históricos com base em um multiplicador de limiar.
        /// </summary>
        /// <param name="volumes">Lista de volumes históricos.</param>
        /// <param name="thresholdMultiplier">Multiplicador para determinar o limite de pico.</param>
        /// <returns>Um resultado contendo os índices e volumes dos picos identificados.</returns>
        VolumeSpikeResult IdentifyVolumeSpikes(List<double> volumes, double thresholdMultiplier);
    }
}
