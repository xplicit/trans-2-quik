namespace Trans2Quik.Tests
{
    using System;
    using System.Threading;
    using Core;
    using Core.Entities.Transaction.Order;
    using NUnit.Framework;

    [TestFixture]
    public class TransactionTests
    {
        private static TransactionBuilder tBuilder = new TransactionBuilder(Mother.CONST_Account);

        [Test]
        public void CanSendMarketOrder()
        {
            var cw = new ConnectionListener(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());
            var tw = new TransactionManager();
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
            var tw = new TransactionManager();
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
            var tw = new TransactionManager();
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
            var tw = new TransactionManager();
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
            var tw = new TransactionManager();

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
            var tw = new TransactionManager();

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
            var tw = new TransactionManager();
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
            var tw = new TransactionManager();
            var txn = tBuilder.KillStopOrder(Mother.SBRF, "370852");
            var res = tw.SendSyncTransaction(txn.ToString());
            Console.WriteLine("{0}", res);
            Assert.IsTrue(res.ReturnValue.IsSuccess);
        }

        [Test]
        public void Sample01()
        {
            // Connect to the Quik
            var quikListener = new ConnectionListener(@"Q:\PSBQuik");
            quikListener.Connect();
            
            var txnBuilder = new TransactionBuilder("L01+00000F00");
            
            // Buy 10 "SBRF" by Market
            var order = txnBuilder.NewOrder(new OrderTradeParams("TQBR", "SBER", Direction.Buy, 1));

            // Send order
            var txnManager = new TransactionManager();
            var res = txnManager.SendSyncTransaction(order.ToString());
            
            // Check result
            Console.WriteLine("Result: {0}", res);
        }

        [Test]
        public void Sample02()
        {
            var gateway = new Gateway(@"Q:\PSBQuik", "L01+00000F00");
            gateway.NewTransaction += OnNewTransaction;
            gateway.Start();
            
            // Купить 10 акций Сбербанка по рыночной цене
            gateway.SendOrder("TQBR", "SBER", Direction.Buy, 1); 

            Thread.Sleep(10000);
        }

        [Test]
        public void Sample03()
        {
            var gateway = new Gateway(@"Q:\PSBQuik", "L01+00000F00");
            gateway.NewTransaction += OnNewTransaction;
            gateway.Start();

            var security = new Security("TQBR", "SBER");
            var tradeParams = new OrderTradeParams(security, Direction.Buy, 1);
            gateway.SendOrder(tradeParams); // Купить по рынку 10 акций Сбербанка

            // Выставить стоп-лимит: продать 10 акций Сбербанка по 75.10. Активировать при наступлении цены 75.12
            var stop = new StopOrderTradeParams(new OrderTradeParams(security, Direction.Sell, 1, 75.10m), 75.12m);
            gateway.SendStopLimitOrder(stop);

            Thread.Sleep(10000);
        }

        private void OnNewTransaction(object sender, TransactionEventArgs e)
        {
            Console.WriteLine("Result: {0}", e.TransactionResult);
        }
    }
}
