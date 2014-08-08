namespace Trans2Quik.Core
{
    using Entities.Trade;

    public class TradeEventArgs
    {
        public Trade Trade { get; private set; }
        public TradeDetails TradeDetails { get; private set; }

        public TradeEventArgs(Trade trade, TradeDetails tradeDetails)
        {
            this.Trade = trade;
            this.TradeDetails = tradeDetails;
        }
    }
}
