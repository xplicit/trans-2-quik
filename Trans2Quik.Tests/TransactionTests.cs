namespace Trans2Quik.Tests
{
    using System;
    using Core;
    using NUnit.Framework;

    [TestFixture]
    public class TransactionTests
    {
        private static TransactionBuilder tBuilder = new TransactionBuilder(1000, "L01+00000F00");

        [Test]
        public void CanSendMarketOrder()
        {
            var cw = new ConnectionWatcher(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());
            var tw = new TransactionWatcher(false);
            var txn = tBuilder.NewOrder(new Quote(Mother.SBRF, Direction.Buy, 1));
            var res = tw.SendSyncTransaction(txn.ToString());
            Console.WriteLine("{0}", res);
            Assert.IsTrue(res.ReturnValue.IsSuccess);
        }

        [Test]
        public void CanSendLimitOrder()
        {
            var cw = new ConnectionWatcher(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());
            var tw = new TransactionWatcher(false);
            var txn = tBuilder.NewOrder(new Quote(Mother.SBRF, Direction.Sell, 1, 74.85M));
            var res = tw.SendSyncTransaction(txn.ToString());
            Console.WriteLine("{0}", res);
            Assert.IsTrue(res.ReturnValue.IsSuccess);
        }

        [Test]
        public void CanKillOrder()
        {
            var cw = new ConnectionWatcher(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());
            var tw = new TransactionWatcher(false);
            var txn = tBuilder.KillOrder("11761165138");
            var res = tw.SendSyncTransaction(txn.ToString());
            Console.WriteLine("{0}", res);
            Assert.IsTrue(res.ReturnValue.IsSuccess);
        }
    }
}
