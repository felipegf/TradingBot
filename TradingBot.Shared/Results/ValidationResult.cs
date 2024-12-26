using TradingBot.Shared.Resources;

namespace TradingBot.Shared.Results
{
    public class ValidationResult : Result<bool>
    {
        public IEnumerable<string> ValidationErrors { get; }

        private ValidationResult(bool isSuccess, IEnumerable<string> validationErrors)
            : base(isSuccess, isSuccess ? true : default, isSuccess ? null : ErrorMessages.ValidationFailed)
        {
            ValidationErrors = validationErrors ?? new List<string>();
        }

        public static ValidationResult Success()
        {
            return new ValidationResult(true, Enumerable.Empty<string>());
        }

        public static ValidationResult Failure(IEnumerable<string> errors)
        {
            var validationErrors = errors?.Any() == true ? errors : new[] { ErrorMessages.ValidationFailed };
            return new ValidationResult(false, validationErrors);
        }
    }
}
