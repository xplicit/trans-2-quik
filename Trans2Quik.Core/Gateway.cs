namespace Trans2Quik.Core
{
    using System;

    public class Gateway
    {
        private readonly ConnectionListener connectionListener;
        private readonly OrderInfoListener orderInfoListener;
        private readonly TradeInfoListener tradeInfoListener;
        private readonly TransactionManager transactionManager;

        protected bool TransactionsAsyncMode { get; private set; }
        protected string ClassCode { get; private set; }
        protected string SecurityCode { get; private set; }

        public bool IsConnected
        {
            get
            {
                return this.connectionListener.IsConnected;
            }
        }

        public event EventHandler<OrderInfoEventArgs> OrderChanged;
        public event EventHandler<TradeInfoEventArgs> TradeChanged;
        public event EventHandler<TransactionEventArgs> NewTransaction;

        public Gateway(string pathToQuik, bool transactionsAsyncMode = true)
        {
            this.TransactionsAsyncMode = transactionsAsyncMode;
            this.connectionListener = new ConnectionListener(pathToQuik);
            this.orderInfoListener = new OrderInfoListener();
            this.tradeInfoListener = new TradeInfoListener();
            this.transactionManager = new TransactionManager(this.TransactionsAsyncMode);

            this.connectionListener.ConnectionStatusChanged += ConnectionStatusChanged;
            this.orderInfoListener.OrderStatusChanged += OnOrderChanged;
            this.tradeInfoListener.TradeStatusChanged += OnTradeChanged;
            this.transactionManager.TransactionAsyncReply += TransactionAsyncReply;
        }

        public bool Start(string classCode = "", string securityCode = "")
        {
            this.ClassCode = classCode;
            this.SecurityCode = securityCode;

            if (!this.IsConnected)
            {
                if (!this.connectionListener.Connect())
                {
                    return false;
                }
            }

            return this.Subscribe(this.ClassCode, this.SecurityCode) && this.StartWatch();
        }

        public void Stop()
        {
            this.orderInfoListener.Unsubscribe();
            this.tradeInfoListener.Unsubscribe();

            this.connectionListener.Disconnect();
        }

        public bool SendTransaction(string transactionString)
        {
            if (this.TransactionsAsyncMode)
            {
                return this.transactionManager.SendAsyncTransaction(transactionString);
            }

            var res = this.transactionManager.SendSyncTransaction(transactionString);
            this.TransactionAsyncReply(this, new TransactionEventArgs(res));
            return res.ReturnValue.IsSuccess;
        }

        private bool Subscribe(string classCode, string securityCode)
        {
            var ordersSubscribed = this.orderInfoListener.Subscribe(classCode, securityCode);
            var tradesSubscribed = this.tradeInfoListener.Subscribe(classCode, securityCode);
            return ordersSubscribed && tradesSubscribed;
        }

        private bool StartWatch()
        {
            var ordersStarted = this.orderInfoListener.StartOrders();
            var tradesStarted = this.tradeInfoListener.StartTrades();

            return ordersStarted && tradesStarted;
        }

        private void ConnectionStatusChanged(object sender, EventArgs e)
        {
            // Restart 
            this.Start(this.ClassCode, this.SecurityCode);
        }

        private void OnOrderChanged(object sender, OrderInfoEventArgs e)
        {
            var tmp = this.OrderChanged;

            if (tmp != null)
            {
                tmp(this, e);
            }
        }

        private void OnTradeChanged(object sender, TradeInfoEventArgs e)
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
