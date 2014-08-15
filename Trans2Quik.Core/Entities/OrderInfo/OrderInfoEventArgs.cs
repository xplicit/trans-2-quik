namespace Trans2Quik.Core
{
    using System;

    public class OrderInfoEventArgs : EventArgs
    {
        public OrderInfo OrderInfo { get; private set; }
        public OrderInfoDetails OrderInfoDetails { get; private set; }

        public OrderInfoEventArgs(OrderInfo orderInfo, OrderInfoDetails orderInfoDetails)
        {
            this.OrderInfo = orderInfo;
            this.OrderInfoDetails = orderInfoDetails;
        }
    }
}
