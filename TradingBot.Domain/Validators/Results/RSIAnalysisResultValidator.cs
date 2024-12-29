using FluentValidation;
using TradingBot.Domain.Results;
using TradingBot.Shared.Resources;

namespace TradingBot.Domain.Validators.Results
{
    public class RSIAnalysisResultValidator : AbstractValidator<RSIAnalysisResult>
    {
        public RSIAnalysisResultValidator()
        {
            RuleFor(result => result.RSI)
                .InclusiveBetween(0, 100).WithMessage(Messages.InvalidData);

            RuleFor(result => result.Indication)
                .NotEmpty().WithMessage(Messages.RequiredField)
                .MaximumLength(50).WithMessage(Messages.InvalidFormat);
        }
    }
}
