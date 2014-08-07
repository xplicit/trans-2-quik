namespace Trans2Quik.Core
{
    using System;
    using System.Runtime.InteropServices;
    using Entities.Trade;
    using Internals;

    internal class TradeWatcher
    {
        private readonly EntryPoint.TradeStatusCallback tradeStatusCallback;

        public ReturnValue LastResult { get; private set; }
        public string ClassCode { get; private set; }
        public string SecurityCode { get; private set; }

        public event EventHandler<TradeEventArgs> TradeStatusChanged;

        public TradeWatcher()
        {
            this.tradeStatusCallback = new EntryPoint.TradeStatusCallback(this.TradeStatusCallback);
            GCHandle.Alloc(this.tradeStatusCallback);
        }

        public bool Subscribe(string classCode, string securityCode)
        {
            this.ClassCode = classCode;
            this.SecurityCode = securityCode;
            this.LastResult = EntryPoint.SubscribeTrades(this.ClassCode, this.SecurityCode);
            return this.LastResult.IsSuccess;
        }
        public bool Unsubscribe()
        {
            this.LastResult = EntryPoint.UnsubscribeTrades();
            return this.LastResult.IsSuccess;
        }
        public bool StartTrades()
        {
            this.LastResult = EntryPoint.StartTrades(this.tradeStatusCallback);
            return this.LastResult.IsSuccess;
        }

        private void TradeStatusCallback(
                Int32 mode,
                Double number,
                Double orderNumber,
                [MarshalAs(UnmanagedType.LPStr)] string classCode,
                [MarshalAs(UnmanagedType.LPStr)] string secCode,
                Double price,
                Int32 qty,
                Double value,
                Int32 isSell,
                Int32 tradeDescriptor)
        {
            Console.WriteLine("TradeStatusCallback");

            var trade = new Trade()
            {
                Mode = (TradeMode)mode,
                Number = number,
                OrderNumber = orderNumber,
                ClassCode = classCode,
                SecCode = secCode,
                Price = price,
                Qty = qty,
                Value = value,
                Direction = TypeConverter.GetDirection(isSell),
                TradeDescriptor = tradeDescriptor
            };

            var tradeDetails = TradeDetails.Fetch(trade.TradeDescriptor);
            this.OnTradeStatusChanged(new TradeEventArgs(trade, tradeDetails));
        }

        protected virtual void OnTradeStatusChanged(TradeEventArgs args)
        {
            var tmp = this.TradeStatusChanged;

            if (tmp != null)
            {
                tmp(this, args);
            }
        }
    }
}
