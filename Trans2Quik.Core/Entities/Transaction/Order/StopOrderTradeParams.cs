namespace Trans2Quik.Core
{
    using Entities.Transaction.Order;

    public class StopOrderTradeParams 
    {
        public OrderTradeParams OrderTradeParams { get; private set; }

        public decimal StopPrice { get; private set; }
        public decimal? StopPrice2 { get; private set; }
        public ExpiryDate ExpiryDate { get; private set; }
        public ActiveTime ActiveTime { get; private set; }
        public ProfitCondition ProfitCondition { get; private set; }

        public StopOrderTradeParams(
            OrderTradeParams orderTradeParams, 
            decimal stopPrice, 
            ProfitCondition profitCondition, 
            ExpiryDate expDate,
            decimal? stopPrice2, 
            ActiveTime activeTime)
        {
            this.OrderTradeParams = orderTradeParams;
            this.StopPrice = stopPrice;
            this.ExpiryDate = expDate;
            this.ProfitCondition = profitCondition;
            this.StopPrice2 = stopPrice2;
            this.ActiveTime = activeTime;
        }

        public StopOrderTradeParams(OrderTradeParams orderTradeParams, decimal stopPrice, ProfitCondition profitCondition, ExpiryDate expDate, decimal? stopPrice2) : 
            this(orderTradeParams, stopPrice, profitCondition, expDate, stopPrice2, null)
        {
        }

        public StopOrderTradeParams(OrderTradeParams orderTradeParams, decimal stopPrice, ProfitCondition profitCondition, ExpiryDate expDate) : 
            this(orderTradeParams, stopPrice, profitCondition, expDate, null)
        {
        }

        public StopOrderTradeParams(OrderTradeParams orderTradeParams, decimal stopPrice, ProfitCondition profitCondition) : 
            this(orderTradeParams, stopPrice, profitCondition, null)
        {
        }

        public StopOrderTradeParams(OrderTradeParams orderTradeParams, decimal stopPrice) : 
            this(orderTradeParams, stopPrice, null)
        {
        }
    }
}
