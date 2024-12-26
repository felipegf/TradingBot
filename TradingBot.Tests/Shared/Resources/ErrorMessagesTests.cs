using FluentAssertions;
using TradingBot.Shared.Resources;

namespace TradingBot.Tests.Shared.Resources
{
    public class ErrorMessagesTests
    {
        [Fact]
        public void ShouldContainExpectedErrorMessageKeys()
        {
            // Validando mensagens centralizadas no ErrorMessages
            ErrorMessages.EmptyPriceChangeList.Should().Be("A lista de mudanças de preço não pode estar vazia.");
            ErrorMessages.NullArgument.Should().Be("O argumento fornecido não pode ser nulo.");
            ErrorMessages.ValidationFailed.Should().Be("A validação falhou.");
        }
    }
}
