namespace Trans2Quik.Core
{
    using System;

    public class Gateway
    {
        private readonly ConnectionWatcher connectionWatcher;
        private readonly OrderWatcher orderWatcher;
        private readonly TradeWatcher tradeWatcher;

        public bool IsConnected
        {
            get
            {
                return this.connectionWatcher.IsConnected;
            }
        }

        public event EventHandler<OrderEventArgs> OrderChanged;
        public event EventHandler<TradeEventArgs> TradeChanged;

        public Gateway(string pathToQuik)
        {
            this.connectionWatcher = new ConnectionWatcher(pathToQuik);
            this.orderWatcher = new OrderWatcher();
            this.tradeWatcher = new TradeWatcher();
            this.connectionWatcher.ConnectionStatusChanged += ConnectionStatusChanged;
            this.orderWatcher.OrderStatusChanged += OnOrderChanged;
            this.tradeWatcher.TradeStatusChanged += OnTradeChanged;
        }

        public bool Subscribe(string classCode, string securityCode)
        {
            return 
                this.orderWatcher.Subscribe(classCode, securityCode) && 
                this.tradeWatcher.Subscribe(classCode, securityCode);
        }

        public bool Start()
        {
            if (this.connectionWatcher.IsConnected)
            {
                // already connected
                return this.StartWatchers();
            }
            else
            {
                if (this.connectionWatcher.Connect())
                {
                    return this.StartWatchers();
                }
                else
                {
                    return false;
                }
            }
        }

        public void Stop()
        {
            this.orderWatcher.Unsubscribe();
            this.tradeWatcher.Unsubscribe();
            this.connectionWatcher.Disconnect();
        }

        private void ConnectionStatusChanged(object sender, EventArgs e)
        {
            // Restart 
            this.Start();
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

        private bool StartWatchers()
        {
            return 
                this.orderWatcher.StartOrders() && 
                this.tradeWatcher.StartTrades();
        }
    }
}
