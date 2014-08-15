namespace Trans2Quik.Core
{
    public class TransactionBuilder
    {
        public int NextId { get; private set; }
        public string Account { get; private set; }

        public TransactionBuilder(int initialTransId, string account)
        {
            this.NextId = initialTransId;
            this.Account = account;
        }

        public Order NewOrder(Quote quote)
        {
            var t = new Order(this.NextId++, this.Account, "NEW_ORDER");
            t.SetQuote(quote);
            return t;
        }

        public StopOrder NewStopOrder(StopQuote quote)
        {
            var t = new StopOrder(this.NextId++, this.Account, StopOrderKind.Simple);
            t.SetStopQuote(quote);
            return t;
        }

        public StopOrder NewTakeProfitOrder(StopQuote quote)
        {
            var t = new StopOrder(this.NextId++, this.Account, StopOrderKind.TakeProfit);
            t.SetStopQuote(quote);
            return t;
        }

        public StopOrder NewTakeProfitAndStopLimitOrder(TakeAndStopQuote quote)
        {
            var t = new StopOrder(this.NextId++, this.Account, StopOrderKind.TakeProfitAndStopLimit);
            t.SetTakeAndStopQuote(quote);
            return t;
        }

        public Order KillOrder(Security security, string orderKey)
        {
            var t = new Order(this.NextId++, this.Account, "KILL_ORDER") { OrderKey = orderKey };
            t.SetSecurity(security);
            return t;
        }

        public Order KillStopOrder(Security security, string orderKey)
        {
            var t = new Order(this.NextId++, this.Account, "KILL_STOP_ORDER") { StopOrderKey = orderKey };
            t.SetSecurity(security);
            return t;
        }
    }
}
