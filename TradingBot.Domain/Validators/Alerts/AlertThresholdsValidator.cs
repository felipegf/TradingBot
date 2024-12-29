using FluentValidation;
using TradingBot.Domain.ValueObjects;
using TradingBot.Shared.Resources;

namespace TradingBot.Domain.Validators.Alerts
{
    public class AlertThresholdsValidator : AbstractValidator<AlertThresholds>
    {
        public AlertThresholdsValidator()
        {
            RuleFor(thresholds => thresholds.RSIOverbought)
                .InclusiveBetween(0, 100).WithMessage(Messages.InvalidData);

            RuleFor(thresholds => thresholds.RSIOversold)
                .InclusiveBetween(0, 100).WithMessage(Messages.InvalidData);

            RuleFor(thresholds => thresholds.VolumeSpikeMultiplier)
                .GreaterThan(0).WithMessage(Messages.InvalidData);
        }
    }
}
