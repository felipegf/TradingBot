using FluentAssertions;
using FluentValidation.TestHelper;
using TradingBot.Domain.Results;
using TradingBot.Domain.Validators.Results;
using TradingBot.Shared.Resources;

namespace TradingBot.Tests.Domain.Results
{
    public class MovingAverageResultTests
    {
        private readonly MovingAverageResultValidator _validator;

        public MovingAverageResultTests()
        {
            _validator = new MovingAverageResultValidator();
        }

        [Fact]
        public void ShouldInitializeCorrectly()
        {
            // Arrange
            double sma = 1.23;
            double ema = 2.34;
            int period = 14;

            // Act
            var result = new MovingAverageResult(sma, ema, period);

            // Assert
            result.SMA.Should().Be(sma);
            result.EMA.Should().Be(ema);
            result.Period.Should().Be(period);
        }

        [Fact]
        public void ShouldHaveError_WhenSMAIsNegative()
        {
            // Arrange
            var result = new MovingAverageResult(-1, 2.34, 14);

            // Act
            var validationResult = _validator.TestValidate(result);

            // Assert
            validationResult.ShouldHaveValidationErrorFor(r => r.SMA)
                .WithErrorMessage(Messages.InvalidData);
        }

        [Fact]
        public void ShouldHaveError_WhenEMAIsNegative()
        {
            // Arrange
            var result = new MovingAverageResult(1.23, -2.34, 14);

            // Act
            var validationResult = _validator.TestValidate(result);

            // Assert
            validationResult.ShouldHaveValidationErrorFor(r => r.EMA)
                .WithErrorMessage(Messages.InvalidData);
        }

        [Fact]
        public void ShouldHaveError_WhenPeriodIsInvalid()
        {
            // Arrange
            var result = new MovingAverageResult(1.23, 2.34, 0);

            // Act
            var validationResult = _validator.TestValidate(result);

            // Assert
            validationResult.ShouldHaveValidationErrorFor(r => r.Period)
                .WithErrorMessage(Messages.InvalidPeriod);
        }

        [Fact]
        public void ShouldNotHaveValidationError_WhenAllFieldsAreValid()
        {
            // Arrange
            var result = new MovingAverageResult(1.23, 2.34, 14);

            // Act
            var validationResult = _validator.TestValidate(result);

            // Assert
            validationResult.ShouldNotHaveValidationErrorFor(r => r.SMA);
            validationResult.ShouldNotHaveValidationErrorFor(r => r.EMA);
            validationResult.ShouldNotHaveValidationErrorFor(r => r.Period);
        }
    }
}
