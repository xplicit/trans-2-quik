namespace Trans2Quik.Core
{
    public class TransactionBuilder
    {
        public int NextId { get; private set; }
        public string Account { get; private set; }
        public string ClassCode { get; private set; }
        public string SecCode { get; private set; }

        public TransactionBuilder(int initialTransId, string account, string classCode, string secCode)
        {
            this.NextId = initialTransId;
            this.Account = account;
            this.ClassCode = classCode;
            this.SecCode = secCode;
        }

        public OrderTransaction NewOrder(Direction direction, decimal price, int quantity)
        {
            var t = new OrderTransaction();
            this.InitTransaction(t, "NEW_ORDER");
            t.Operation = direction;
            t.Price = price;
            t.Quantity = quantity;
            t.IsLimitOrder = price != decimal.Zero;
            return t;
        }
        public OrderTransaction NewMarketOrder(Direction direction, int quantity)
        {
            return this.NewOrder(direction, decimal.Zero, quantity);
        }

        public OrderTransaction KillOrder(int orderKey)
        {
            var t = new OrderTransaction();
            this.InitTransaction(t, "KILL_ORDER");
            t.OrderKey = orderKey;
            return t;
        }

        private void InitTransaction(OrderTransaction txn, string action)
        {
            if (txn == null)
            {
                return;
            }

            txn.TransactionId = this.NextId++;
            txn.Account = this.Account;
            txn.ClassCode = this.ClassCode;
            txn.SecCode = this.SecCode;
            txn.Action = action;
        }
    }
}
