using FluentValidation;
using TradingBot.Domain.Entities.Alerts;
using TradingBot.Shared.Resources;

namespace TradingBot.Domain.Validators.Alerts
{
    public class BuyAlertValidator : AbstractValidator<BuyAlert>
    {
        public BuyAlertValidator()
        {
            RuleFor(alert => alert.Type)
                .NotEmpty().WithMessage(Messages.RequiredField)
                .Equal("Buy").WithMessage(Messages.InvalidFormat);

            RuleFor(alert => alert.Message)
                .NotEmpty().WithMessage(Messages.RequiredField)
                .MaximumLength(200).WithMessage(Messages.InvalidFormat);
        }
    }
}
