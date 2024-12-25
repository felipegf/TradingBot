using TradingBot.Domain.Results;
using TradingBot.Shared.Extensions;
using TradingBot.Shared.Resources;

namespace TradingBot.Domain.Services
{
    /// <summary>
    /// Serviço responsável por identificar picos de volume em dados históricos.
    /// Um pico de volume ocorre quando o volume ultrapassa um limite determinado.
    /// </summary>
    public class VolumeSpikeService
    {
        /// <summary>
        /// Identifica picos de volume em uma lista de volumes com base em um multiplicador de limiar.
        /// </summary>
        /// <param name="volumes">Lista de volumes históricos.</param>
        /// <param name="thresholdMultiplier">Multiplicador para determinar o limite de pico.</param>
        /// <returns>Um objeto do tipo VolumeSpikeResult contendo os índices e volumes dos picos identificados.</returns>
        public VolumeSpikeResult IdentifyVolumeSpikes(List<double> volumes, double thresholdMultiplier)
        {
            if (volumes.IsNullOrEmpty())
                return new VolumeSpikeResult(new List<int>(), new List<double>(), ErrorMessages.EmptyVolumeList);

            double averageVolume = volumes.Average(); // Cálculo do volume médio
            double threshold = averageVolume * thresholdMultiplier; // Limiar para detectar picos

            var spikeIndexes = new List<int>();
            var spikeVolumes = new List<double>();

            // Identifica os índices e volumes que ultrapassam o limiar
            for (int i = 0; i < volumes.Count; i++)
            {
                if (volumes[i] > threshold)
                {
                    spikeIndexes.Add(i);
                    spikeVolumes.Add(volumes[i]);
                }
            }

            return new VolumeSpikeResult(spikeIndexes, spikeVolumes, null);
        }
    }
}
