namespace Trans2Quik.Tests
{
    using System;
    using System.Threading;
    using Core;
    using NUnit.Framework;

    [TestFixture]
    public class GatewayTests
    {
        [Test]
        public void CanWatchOrders()
        {
            var tg = new Gateway(Mother.CONST_PathToQuik);
            tg.OrderChanged += OrderChanged;
            tg.Start();
            
            Console.WriteLine("Started");
            Thread.Sleep(10000);
            tg.Stop();
            Console.WriteLine("Stopped");
        }

        private void OrderChanged(object sender, OrderInfoEventArgs e)
        {
            Console.WriteLine("Order status changed: {0}\n{1}", e.OrderInfo, e.OrderInfoDetails);
        }
    }
}
