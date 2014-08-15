namespace Trans2Quik.Tests
{
    using System;
    using System.Threading;
    using Core;
    using NUnit.Framework;

    [TestFixture]
    public class OrderInfoTests
    {
        [Test]
        public void CanWatchOrders()
        {
            var cw = new ConnectionWatcher(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());
            Console.WriteLine("Connection result:{0}", cw.LastResult);

            var ow = new OrderInfoListener();
            ow.OrderStatusChanged += OrderStatusChanged;
            Assert.IsTrue(ow.Subscribe("", ""));
            Console.WriteLine("Start orders.");
            ow.StartOrders();
            Thread.Sleep(10000);

            Console.WriteLine("Finished.");
            ow.Unsubscribe();
            cw.Disconnect();
        }

        private void OrderStatusChanged(object sender, OrderInfoEventArgs e)
        {
            Console.WriteLine("Order status changed: {0}\n{1}", e.OrderInfo, e.OrderInfoDetails);
        }
    }
}
