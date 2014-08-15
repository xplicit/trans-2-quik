namespace Trans2Quik.Core
{
    public class TakeAndStopQuote
    {
        public StopQuote StopQuote { get; private set; }

        public ActiveTime ActiveTime { get; set; }
        public decimal StopPrice2 { get; set; }

        public TakeAndStopQuote(StopQuote stopQuote, decimal stopPrice2, ActiveTime activeTime)
        {
            this.StopQuote = stopQuote;
            this.ActiveTime = activeTime;
            this.StopPrice2 = stopPrice2;
        }
        public TakeAndStopQuote(StopQuote stopQuote, decimal stopPrice2) : this(stopQuote, stopPrice2, null)
        {
        }
    }
}