using FluentValidation;
using TradingBot.Domain.Results;
using TradingBot.Shared.Resources;

namespace TradingBot.Domain.Validators.Results
{
    public class VolumeSpikeResultValidator : AbstractValidator<VolumeSpikeResult>
    {
        public VolumeSpikeResultValidator()
        {
            RuleFor(result => result.SpikeIndexes)
                .NotNull()
                .WithMessage(Messages.RequiredField);

            RuleFor(result => result.SpikeVolumes)
                .NotNull()
                .WithMessage(Messages.RequiredField);

            RuleFor(result => result.Error)
                .Must(error => string.IsNullOrEmpty(error))
                .WithMessage(Messages.ValidationFailed);
        }
    }
}
