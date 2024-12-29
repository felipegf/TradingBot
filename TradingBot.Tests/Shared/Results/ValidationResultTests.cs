using FluentAssertions;
using TradingBot.Shared.Resources;
using TradingBot.Shared.Results;

namespace TradingBot.Tests.Shared.Results
{
    public class ValidationResultTests
    {
        [Fact]
        public void Failure_ShouldIncludeDefaultErrorMessage_WhenErrorsAreEmpty()
        {
            var result = ValidationResult.Failure(new List<string>());

            result.IsSuccess.Should().BeFalse();
            result.ValidationErrors.Should().BeEquivalentTo(new[] { Messages.ValidationFailed });
        }

        [Fact]
        public void Failure_ShouldReturnValidationErrors()
        {
            var errors = new[] { "Erro 1", "Erro 2" };
            var result = ValidationResult.Failure(errors);

            result.IsSuccess.Should().BeFalse();
            result.ValidationErrors.Should().BeEquivalentTo(errors);
        }
    }
}
