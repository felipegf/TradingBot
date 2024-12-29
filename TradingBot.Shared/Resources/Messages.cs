namespace TradingBot.Shared.Resources
{
    public static class Messages
    {
        // Mensagens de erro genérico
        public const string NullArgument = "O argumento fornecido não pode ser nulo.";
        public const string InvalidData = "Os dados fornecidos são inválidos.";
        public const string ValidationFailed = "A validação falhou.";
        public const string InsufficientData = "Dados insuficientes para o cálculo.";

        // Mensagens de validação
        public const string RequiredField = "O campo é obrigatório.";
        public const string InvalidFormat = "O formato fornecido é inválido.";
        public const string EmptyPriceChangeList = "A lista de mudanças de preço não pode estar vazia.";
        public const string EmptyPriceList = "A lista de preços não pode estar vazia.";
        public const string InvalidPeriod = "O período fornecido é inválido.";
        public const string EmptyVolumeList = "A lista de volumes não pode estar vazia.";
    }
}
