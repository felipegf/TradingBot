namespace TradingBot.Domain.Entities.Alerts
{
    /// <summary>
    /// Alerta de risco.
    /// </summary>
    public class RiskAlert : Alert
    {
        public RiskAlert(string message) : base("Risk", message)
        {
        }
    }
}
