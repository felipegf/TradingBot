using FluentValidation;
using TradingBot.Domain.Interfaces.Services;
using TradingBot.Domain.Results;
using TradingBot.Domain.Validators.Results;
using TradingBot.Shared.Extensions;
using TradingBot.Shared.Resources;

namespace TradingBot.Domain.Services
{
    /// <summary>
    /// Serviço responsável por identificar picos de volume em dados históricos.
    /// Um pico de volume ocorre quando o volume ultrapassa um limite determinado.
    /// </summary>
    public class VolumeSpikeService : IVolumeSpikeService
    {
        private readonly IValidator<VolumeSpikeResult> _validator;

        /// <summary>
        /// Construtor para injeção de dependências.
        /// </summary>
        public VolumeSpikeService()
        {
            _validator = new VolumeSpikeResultValidator();
        }

        /// <summary>
        /// Identifica picos de volume em uma lista de volumes com base em um multiplicador de limiar.
        /// </summary>
        /// <param name="volumes">Lista de volumes históricos.</param>
        /// <param name="thresholdMultiplier">Multiplicador para determinar o limite de pico.</param>
        /// <returns>Um objeto do tipo VolumeSpikeResult contendo os índices e volumes dos picos identificados.</returns>
        public VolumeSpikeResult IdentifyVolumeSpikes(List<double> volumes, double thresholdMultiplier)
        {
            if (volumes.IsNullOrEmpty())
                return new VolumeSpikeResult(new List<int>(), new List<double>(), Messages.EmptyVolumeList);

            if (thresholdMultiplier <= 0)
                return new VolumeSpikeResult(new List<int>(), new List<double>(), Messages.InvalidData);

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

            // Cria o resultado
            var result = new VolumeSpikeResult(spikeIndexes, spikeVolumes);

            // Valida o resultado
            var validation = _validator.Validate(result);
            if (!validation.IsValid)
            {
                // Coleta os erros de validação
                var errorMessages = string.Join("; ", validation.Errors.Select(e => e.ErrorMessage));
                return new VolumeSpikeResult(new List<int>(), new List<double>(), errorMessages);
            }

            return result;
        }
    }
}
