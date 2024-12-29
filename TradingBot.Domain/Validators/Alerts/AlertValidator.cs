using FluentValidation;
using TradingBot.Domain.Entities.Alerts;
using TradingBot.Shared.Resources;

namespace TradingBot.Domain.Validators.Alerts
{
    public class AlertValidator : AbstractValidator<Alert>
    {
        public AlertValidator()
        {
            RuleFor(alert => alert.Type)
                .NotEmpty().WithMessage(Messages.RequiredField)
                .MaximumLength(50).WithMessage(Messages.InvalidFormat);

            RuleFor(alert => alert.Message)
                .NotEmpty().WithMessage(Messages.RequiredField)
                .MaximumLength(200).WithMessage(Messages.InvalidFormat);

            RuleFor(alert => alert.CreatedAt)
                .NotNull().WithMessage(Messages.RequiredField)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage(Messages.InvalidData);
        }
    }
}
