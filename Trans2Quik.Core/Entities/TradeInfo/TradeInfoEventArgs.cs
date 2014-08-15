namespace Trans2Quik.Core
{
    using System;

    public class TradeInfoEventArgs : EventArgs
    {
        public TradeInfo TradeInfo { get; private set; }
        public TradeInfoDetails TradeInfoDetails { get; private set; }

        public TradeInfoEventArgs(TradeInfo tradeInfo, TradeInfoDetails tradeInfoDetails)
        {
            this.TradeInfo = tradeInfo;
            this.TradeInfoDetails = tradeInfoDetails;
        }
    }
}
