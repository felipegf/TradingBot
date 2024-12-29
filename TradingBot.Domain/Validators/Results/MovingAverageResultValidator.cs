using FluentValidation;
using TradingBot.Domain.Results;
using TradingBot.Shared.Resources;

namespace TradingBot.Domain.Validators.Results
{
    /// <summary>
    /// Validador para a classe MovingAverageResult.
    /// </summary>
    public class MovingAverageResultValidator : AbstractValidator<MovingAverageResult>
    {
        public MovingAverageResultValidator()
        {
            // Regra para o campo SMA (deve ser maior ou igual a zero)
            RuleFor(result => result.SMA)
                .GreaterThanOrEqualTo(0)
                .WithMessage(Messages.InvalidData);

            // Regra para o campo EMA (deve ser maior ou igual a zero)
            RuleFor(result => result.EMA)
                .GreaterThanOrEqualTo(0)
                .WithMessage(Messages.InvalidData);

            // Regra para o campo Period (deve ser maior que zero)
            RuleFor(result => result.Period)
                .GreaterThan(0)
                .WithMessage(Messages.InvalidPeriod);
        }
    }
}
