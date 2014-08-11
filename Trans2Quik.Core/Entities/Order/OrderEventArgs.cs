namespace Trans2Quik.Core
{
    using System;

    public class OrderEventArgs : EventArgs
    {
        public Order Order { get; private set; }
        public OrderDetails OrderDetails { get; private set; }

        public OrderEventArgs(Order order, OrderDetails orderDetails)
        {
            this.Order = order;
            this.OrderDetails = orderDetails;
        }
    }
}
