namespace Trans2Quik.Core
{
    using System;

    public class TransactionGateway
    {
        private readonly ConnectionWatcher connectionWatcher;
        private readonly OrderWatcher orderWatcher;
        private readonly TradeWatcher tradeWatcher;

        protected string ClassCode { get; private set; }
        protected string SecurityCode { get; private set; }

        public bool IsConnected
        {
            get
            {
                return this.connectionWatcher.IsConnected;
            }
        }

        public event EventHandler<OrderEventArgs> OrderChanged;
        public event EventHandler<TradeEventArgs> TradeChanged;

        public TransactionGateway(string pathToQuik)
        {
            this.connectionWatcher = new ConnectionWatcher(pathToQuik);
            this.orderWatcher = new OrderWatcher();
            this.tradeWatcher = new TradeWatcher();

            this.connectionWatcher.ConnectionStatusChanged += ConnectionStatusChanged;
            this.orderWatcher.OrderStatusChanged += OnOrderChanged;
            this.tradeWatcher.TradeStatusChanged += OnTradeChanged;
        }

        public bool Start(string classCode = "", string securityCode = "")
        {
            this.ClassCode = classCode;
            this.SecurityCode = securityCode;

            if (!this.IsConnected)
            {
                if (!this.connectionWatcher.Connect())
                {
                    return false;
                }
            }

            return this.Subscribe(this.ClassCode, this.SecurityCode) && this.StartWatch();
        }

        public void Stop()
        {
            this.orderWatcher.Unsubscribe();
            this.tradeWatcher.Unsubscribe();

            this.connectionWatcher.Disconnect();
        }

        private bool Subscribe(string classCode, string securityCode)
        {
            var ordersSubscribed = this.orderWatcher.Subscribe(classCode, securityCode);
            var tradesSubscribed = this.tradeWatcher.Subscribe(classCode, securityCode);
            return ordersSubscribed && tradesSubscribed;
        }

        private bool StartWatch()
        {
            var ordersStarted = this.orderWatcher.StartOrders();
            var tradesStarted = this.tradeWatcher.StartTrades();

            return ordersStarted && tradesStarted;
        }

        private void ConnectionStatusChanged(object sender, EventArgs e)
        {
            // Restart 
            this.Start(this.ClassCode, this.SecurityCode);
        }

        private void OnOrderChanged(object sender, OrderEventArgs e)
        {
            var tmp = this.OrderChanged;

            if (tmp != null)
            {
                tmp(this, e);
            }
        }

        private void OnTradeChanged(object sender, TradeEventArgs e)
        {
            var tmp = this.TradeChanged;

            if (tmp != null)
            {
                tmp(this, e);
            }
        }
    }
}
