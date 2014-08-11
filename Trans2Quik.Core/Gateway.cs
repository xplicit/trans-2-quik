namespace Trans2Quik.Core
{
    using System;

    public class Gateway
    {
        private readonly ConnectionWatcher connectionWatcher;
        private readonly OrderWatcher orderWatcher;
        private readonly TradeWatcher tradeWatcher;
        private readonly TransactionWatcher transactionWatcher;

        protected bool TransactionsAsyncMode { get; private set; }
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
        public event EventHandler<TransactionEventArgs> NewTransaction;

        public Gateway(string pathToQuik, bool transactionsAsyncMode = true)
        {
            this.TransactionsAsyncMode = transactionsAsyncMode;
            this.connectionWatcher = new ConnectionWatcher(pathToQuik);
            this.orderWatcher = new OrderWatcher();
            this.tradeWatcher = new TradeWatcher();
            this.transactionWatcher = new TransactionWatcher(this.TransactionsAsyncMode);

            this.connectionWatcher.ConnectionStatusChanged += ConnectionStatusChanged;
            this.orderWatcher.OrderStatusChanged += OnOrderChanged;
            this.tradeWatcher.TradeStatusChanged += OnTradeChanged;
            this.transactionWatcher.TransactionAsyncReply += TransactionAsyncReply;
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

        public bool SendTransaction(string transactionString)
        {
            if (this.TransactionsAsyncMode)
            {
                return this.transactionWatcher.SendAsyncTransaction(transactionString);
            }

            var res = this.transactionWatcher.SendSyncTransaction(transactionString);
            this.TransactionAsyncReply(this, new TransactionEventArgs(res));
            return res.ReturnValue.IsSuccess;
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

        private void TransactionAsyncReply(object sender, TransactionEventArgs e)
        {
            var tmp = this.NewTransaction;

            if (tmp != null)
            {
                tmp(this, e);
            }
        }
    }
}
