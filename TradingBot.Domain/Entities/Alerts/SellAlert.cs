namespace TradingBot.Domain.Entities.Alerts
{
    /// <summary>
    /// Alerta de venda.
    /// </summary>
    public class SellAlert : Alert
    {
        public SellAlert(string message) : base("Sell", message)
        {
        }
    }
}
