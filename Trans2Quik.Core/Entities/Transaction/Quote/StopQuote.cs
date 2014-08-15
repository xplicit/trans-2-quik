namespace Trans2Quik.Core
{
    using Entities.Transaction.Order;

    public class StopQuote 
    {
        public decimal StopPrice { get; private set; }
        public ExpiryDate ExpiryDate { get; private set; }
        public ProfitCondition ProfitCondition { get; private set; }

        public Quote Quote { get; private set; }

        public StopQuote(Quote quote, decimal stopPrice, ProfitCondition profitCondition, ExpiryDate expDate)
        {
            this.Quote = quote;
            this.StopPrice = stopPrice;
            this.ExpiryDate = expDate;
            this.ProfitCondition = profitCondition;
        }

        public StopQuote(Quote quote, decimal stopPrice, ProfitCondition profitCondition) : this(quote, stopPrice, profitCondition, null)
        {
        }

        public StopQuote(Quote quote, decimal stopPrice) : this(quote, stopPrice, null)
        {
        }
    }
}
