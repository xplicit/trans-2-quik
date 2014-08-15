namespace Trans2Quik.Tests
{
    using System;
    using Core;
    using Core.Entities.Transaction.Order;
    using NUnit.Framework;

    [TestFixture]
    public class TransactionTests
    {
        private static TransactionBuilder tBuilder = new TransactionBuilder("L01+00000F00");

        [Test]
        public void CanSendMarketOrder()
        {
            var cw = new ConnectionListener(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());
            var tw = new TransactionManager(false);
            var txn = tBuilder.NewOrder(new OrderTradeParams(Mother.SBRF, Direction.Sell, 1));
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
            var txn = tBuilder.NewOrder(new OrderTradeParams(Mother.SBRF, Direction.Buy, 1, 74.85M));
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
            var q = new OrderTradeParams(Mother.SBRF, Direction.Sell, 1, 73.45m);
            var txn = tBuilder.NewStopLimitOrder(new StopOrderTradeParams(q, 73.45m));
            var res = tw.SendSyncTransaction(txn.ToString());
            Console.WriteLine("{0}", res);
            Assert.IsTrue(res.ReturnValue.IsSuccess);
        }

        [Test]
        public void CanSendTakeProfitOrder()
        {
            var cw = new ConnectionListener(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());
            var tw = new TransactionManager(false);
            var q = new OrderTradeParams(Mother.SBRF, Direction.Sell, 1);
            var sq = new StopOrderTradeParams(q, 76.48m, Mother.STD_ProfitCondition);
            var txn = tBuilder.NewTakeProfitOrder(sq);
            var res = tw.SendSyncTransaction(txn.ToString());
            Console.WriteLine("{0}", res);
            Assert.IsTrue(res.ReturnValue.IsSuccess);
        }

        [Test]
        public void CanSendTakeProfitAndStopLimitOrder()
        {
            var cw = new ConnectionListener(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());
            var tw = new TransactionManager(false);

            var q = new OrderTradeParams(Mother.SBRF, Direction.Sell, 1, 76.48m);
            var sq = new StopOrderTradeParams(q, 76.48m, Mother.STD_ProfitCondition, ExpiryDate.TODAY, 73.12m);
            var txn = tBuilder.NewTakeProfitAndStopLimitOrder(sq);
            var res = tw.SendSyncTransaction(txn.ToString());
            Console.WriteLine("{0}", res);
            Assert.IsTrue(res.ReturnValue.IsSuccess);
        }

        [Test]
        public void CanSendTakeProfitAndStopLimitMarketOrder()
        {
            var cw = new ConnectionListener(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());
            var tw = new TransactionManager(false);

            var q = new OrderTradeParams(Mother.SBRF, Direction.Sell, 1);
            var pq = new ProfitCondition(0.1m, Units.PriceUnits, true, true);
            var sq = new StopOrderTradeParams(q, 76.48m, pq, ExpiryDate.TODAY, 73.12m);
            var txn = tBuilder.NewTakeProfitAndStopLimitOrder(sq);
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
