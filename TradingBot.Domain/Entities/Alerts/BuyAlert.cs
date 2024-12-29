namespace TradingBot.Domain.Entities.Alerts
{
    /// <summary>
    /// Alerta de compra.
    /// </summary>
    public class BuyAlert : Alert
    {
        public BuyAlert(string message) : base("Buy", message)
        {
        }
    }
}
