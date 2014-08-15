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
            var txn = tBuilder.NewOrder(new Quote(Mother.SBRF, Direction.Sell, 1));
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
        public void CanSendTakeProfitOrder()
        {
            var cw = new ConnectionListener(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());
            var tw = new TransactionManager(false);
            var q = new Quote(Mother.SBRF, Direction.Sell, 1);
            var sq = new StopQuote(q, 76.48m, Mother.STD_ProfitCondition);
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

            var q = new Quote(Mother.SBRF, Direction.Sell, 1, 76.48m);
            var sq = new StopQuote(q, 76.48m, Mother.STD_ProfitCondition);
            var tq = new TakeAndStopQuote(sq, 73.12m);
            var txn = tBuilder.NewTakeProfitAndStopLimitOrder(tq);
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

            var q = new Quote(Mother.SBRF, Direction.Sell, 1);
            var pq = Mother.STD_ProfitCondition;

            pq.MarketStopLimit = true;
            pq.MarketTakeProfit = true;

            var sq = new StopQuote(q, 76.48m, pq);
            var tq = new TakeAndStopQuote(sq, 73.12m);
            
            var txn = tBuilder.NewTakeProfitAndStopLimitOrder(tq);
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
