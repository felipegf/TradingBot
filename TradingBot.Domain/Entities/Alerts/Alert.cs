namespace TradingBot.Domain.Entities.Alerts
{
    /// <summary>
    /// Representa uma entidade de alerta no sistema.
    /// </summary>
    public abstract class Alert
    {
        public string Type { get; }
        public string Message { get; }
        public DateTime CreatedAt { get; }

        protected Alert(string type, string message)
        {
            Type = type;
            Message = message;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
