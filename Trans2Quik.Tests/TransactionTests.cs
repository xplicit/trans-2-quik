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
            var cw = new ConnectionListener(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());
            var tw = new TransactionManager(false);
            var txn = tBuilder.NewOrder(new Quote(Mother.SBRF, Direction.Buy, 1));
            var res = tw.SendSyncTransaction(txn.ToString());
            Console.WriteLine("{0}", res);
            Assert.IsTrue(res.ReturnValue.IsSuccess);
        }

        [Test]
        public void CanSendLimitOrder()
        {
            var cw = new ConnectionListener(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());
            var tw = new TransactionManager(false);
            var txn = tBuilder.NewOrder(new Quote(Mother.SBRF, Direction.Buy, 1, 74.85M));
            var res = tw.SendSyncTransaction(txn.ToString());
            Console.WriteLine("{0}", res);
            Assert.IsTrue(res.ReturnValue.IsSuccess);
        }

        [Test]
        public void CanSendStopOrder()
        {
            var cw = new ConnectionListener(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());
            var tw = new TransactionManager(false);
            var q = new Quote(Mother.SBRF, Direction.Sell, 1, 73.45m);
            var txn = tBuilder.NewStopOrder(new StopQuote(q, 73.45m));
            var res = tw.SendSyncTransaction(txn.ToString());
            Console.WriteLine("{0}", res);
            Assert.IsTrue(res.ReturnValue.IsSuccess);
        }

        [Test]
        public void CanKillOrder()
        {
            var cw = new ConnectionListener(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());
            var tw = new TransactionManager(false);
            var txn = tBuilder.KillOrder(Mother.SBRF, "11763737651");
            var res = tw.SendSyncTransaction(txn.ToString());
            Console.WriteLine("{0}", res);
            Assert.IsTrue(res.ReturnValue.IsSuccess);
        }

        [Test]
        public void CanKillStopOrder()
        {
            var cw = new ConnectionListener(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());
            var tw = new TransactionManager(false);
            var txn = tBuilder.KillStopOrder(Mother.SBRF, "370852");
            var res = tw.SendSyncTransaction(txn.ToString());
            Console.WriteLine("{0}", res);
            Assert.IsTrue(res.ReturnValue.IsSuccess);
        }
    }
}
