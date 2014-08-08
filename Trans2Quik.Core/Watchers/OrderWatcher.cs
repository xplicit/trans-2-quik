namespace Trans2Quik.Core
{
    using System;
    using System.Runtime.InteropServices;
    using Internals;

    internal class OrderWatcher
    {
        private readonly EntryPoint.OrderStatusCallback orderStatusCallback;

        public ReturnValue LastResult { get; private set; }
        public string ClassCode { get; private set; }
        public string SecurityCode { get; private set; }

        public event EventHandler<OrderEventArgs> OrderStatusChanged;

        public OrderWatcher()
        {
            this.orderStatusCallback = new EntryPoint.OrderStatusCallback(this.OrderStatusCallback);
            GCHandle.Alloc(this.orderStatusCallback);
        }

        public bool Subscribe(string classCode, string securityCode)
        {
            this.ClassCode = classCode;
            this.SecurityCode = securityCode;
            this.LastResult = EntryPoint.SubscribeOrders(this.ClassCode, this.SecurityCode);
            return this.LastResult.IsSuccess;
        }
        public bool Unsubscribe()
        {
            this.LastResult = EntryPoint.UnsubscribeOrders();
            return this.LastResult.IsSuccess;
        }
        public bool StartOrders()
        {
            this.LastResult = EntryPoint.StartOrders(this.orderStatusCallback);
            return this.LastResult.IsSuccess;
        }

        private void OrderStatusCallback(
                Int32 mode,
                Int32 transId,
                Double number,
                [MarshalAs(UnmanagedType.LPStr)] string classCode,
                [MarshalAs(UnmanagedType.LPStr)] string secCode,
                Double price,
                Int32 balance,
                Double value,
                Int32 isSell,
                Int32 status,
                Int32 orderDescriptor)
        {
            var order = new Order()
            {
                Balance = balance,
                ClassCode = classCode,
                Direction = TypeConverter.GetDirection(isSell),
                Mode = (OrderMode) mode,
                Number = number,
                OrderDescriptor = orderDescriptor,
                Price = price,
                SecCode = secCode,
                Status = TypeConverter.GetStatus(status),
                TransId = transId,
                Value = value
            };

            var orderDetails = OrderDetails.Fetch(order.OrderDescriptor);
            this.OnOrderStatusChanged(new OrderEventArgs(order, orderDetails));
        }

        protected virtual void OnOrderStatusChanged(OrderEventArgs args)
        {
            var tmp = this.OrderStatusChanged;

            if (tmp != null)
            {
                tmp(this, args);
            }
        }
    }
}
