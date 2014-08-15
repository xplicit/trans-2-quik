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

        public ProfitCondition(decimal offset, Units offsetUnits, decimal spread, Units spreadUnits)
        {
            this.Offset = offset;
            this.OffsetUnits = offsetUnits;
            this.Spread = spread;
            this.SpreadUnits = spreadUnits;
        }
    }
}
