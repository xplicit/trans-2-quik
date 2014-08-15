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

        public Order KillOrder(string orderKey)
        {
            return new Order(this.NextId++, this.Account, "KILL_ORDER") { OrderKey = orderKey };
        }

        public StopOrder NewStopOrder(StopQuote quote)
        {
            var t = new StopOrder(this.NextId++, this.Account, StopOrderKind.Simple);
            t.SetStopQuote(quote);
            return t;
        }
    }
}
