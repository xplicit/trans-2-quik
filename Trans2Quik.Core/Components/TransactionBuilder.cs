namespace Trans2Quik.Core
{
    public class TransactionBuilder
    {
        public int NextTxnId { get; private set; }
        public string Account { get; private set; }

        private int GetNextId()
        {
            return this.NextTxnId++;
        }

        public TransactionBuilder(string account, int initialTransId = 1)
        {
            this.Account = account;
            this.NextTxnId = initialTransId;
        }

        public Order NewOrder(OrderTradeParams tradeParams)
        {
            return new Order(this.GetNextId(), this.Account, "NEW_ORDER").SetOrderTradeParams(tradeParams);
        }

        public StopOrder NewStopLimitOrder(StopOrderTradeParams tradeParams)
        {
            return new StopOrder(this.GetNextId(), this.Account, StopOrderKind.Simple).SetStopOrderTradeParams(tradeParams);
        }

        public StopOrder NewTakeProfitOrder(StopOrderTradeParams tradeParams)
        {
            return new StopOrder(this.GetNextId(), this.Account, StopOrderKind.TakeProfit).SetStopOrderTradeParams(tradeParams);
        }

        public StopOrder NewTakeProfitAndStopLimitOrder(StopOrderTradeParams tradeParams)
        {
            return new StopOrder(this.GetNextId(), this.Account, StopOrderKind.TakeProfitAndStopLimit).SetStopOrderTradeParams(tradeParams);
        }

        public Order KillOrder(Security security, string orderKey)
        {
            return (new Order(this.GetNextId(), this.Account, "KILL_ORDER") { OrderKey = orderKey }).SetSecurity(security);
        }

        public Order KillStopOrder(Security security, string orderKey)
        {
            return (new Order(this.GetNextId(), this.Account, "KILL_STOP_ORDER") { StopOrderKey = orderKey }).SetSecurity(security);
        }
    }
}
