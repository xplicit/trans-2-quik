namespace Trans2Quik.Core.Entities.Transaction.Order
{
    public class ProfitCondition
    {
        public decimal Offset { get; set; }
        public Units OffsetUnits { get; set; }

        public decimal Spread { get; set; }
        public Units SpreadUnits { get; set; }

        public bool? MarketStopLimit { get; set; }
        public bool? MarketTakeProfit { get; set; }

        public ProfitCondition(decimal offset, Units offsetUnits, decimal spread, Units spreadUnits, bool marketStopLimit = false, bool marketTakeProfit = false)
        {
            this.Offset = offset;
            this.OffsetUnits = offsetUnits;
            this.Spread = spread;
            this.SpreadUnits = spreadUnits;
            this.MarketStopLimit = marketStopLimit;
            this.MarketTakeProfit = marketTakeProfit;
        }
        public ProfitCondition(decimal offset, Units offsetUnits, bool marketStopLimit = false, bool marketTakeProfit = false)
        {
            this.Offset = offset;
            this.OffsetUnits = offsetUnits;
            this.MarketStopLimit = marketStopLimit;
            this.MarketTakeProfit = marketTakeProfit;
        }
    }
}
