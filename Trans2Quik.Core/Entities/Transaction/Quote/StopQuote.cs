namespace Trans2Quik.Core
{
    public class StopQuote 
    {
        public decimal StopPrice { get; private set; }

        public ExpiryDate ExpiryDate { get; private set; }

        public Quote Quote { get; private set; }

        public StopQuote(Quote quote, decimal stopPrice, ExpiryDate expDate)
        {
            this.Quote = quote;
            this.StopPrice = stopPrice;
            this.ExpiryDate = expDate;
        }

        public StopQuote(Quote quote, decimal stopPrice) : this(quote, stopPrice, null)
        {
        }
    }
}
