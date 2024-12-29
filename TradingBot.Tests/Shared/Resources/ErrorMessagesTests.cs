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
            Messages.EmptyPriceChangeList.Should().Be("A lista de mudanças de preço não pode estar vazia.");
            Messages.NullArgument.Should().Be("O argumento fornecido não pode ser nulo.");
            Messages.ValidationFailed.Should().Be("A validação falhou.");
        }
    }
}
