﻿namespace Trans2Quik.Tests
{
    using System;
    using Core;
    using NUnit.Framework;

    [TestFixture]
    public class TransactionBuilderTests
    {
        private TransactionBuilder tb;

        [SetUp]
        public void Setup()
        {
            this.tb = new TransactionBuilder("ABC001");
        }

        [Test]
        public void CanCreateNewOrder()
        {
            var o = this.tb.NewOrder(new OrderTradeParams(Mother.SBRF, Direction.Buy, 2, 73.45M));

            Console.WriteLine(o);
            Assert.IsNotEmpty(o.ToString());
            Assert.IsTrue(o.IsLimitOrder.GetValueOrDefault());
            Assert.IsTrue(this.tb.NextTxnId == 2);
        }

        [Test]
        public void CanCreateNewMarketOrder()
        {
            var o = this.tb.NewOrder(new OrderTradeParams(Mother.SBRF, Direction.Sell, 2));
            Console.WriteLine(o);
            Assert.IsNotEmpty(o.ToString());
            Assert.IsFalse(o.IsLimitOrder.GetValueOrDefault());
            Assert.IsTrue(this.tb.NextTxnId == 2);
        }

        [Test]
        public void CanCreateStopOrder()
        {
            var q = new OrderTradeParams(Mother.SBRF, Direction.Sell, 1);
            var o = this.tb.NewStopLimitOrder(new StopOrderTradeParams(q, 73.48m));
            Console.WriteLine(o);
            Assert.IsNotEmpty(o.ToString());
        }

        [Test]
        public void CanCreateTakeProfitOrder()
        {
            var q = new OrderTradeParams(Mother.SBRF, Direction.Sell, 1);
            var sq = new StopOrderTradeParams(q, 76.48m, Mother.STD_ProfitCondition);
            var o = this.tb.NewTakeProfitOrder(sq);
            Console.WriteLine(o);
            Assert.IsNotEmpty(o.ToString());
        }

        [Test]
        public void CanCreateTakeProfitAndStopLimitOrder()
        {
            var q = new OrderTradeParams(Mother.SBRF, Direction.Sell, 1, 76.48m);
            var sq = new StopOrderTradeParams(q, 76.48m, Mother.STD_ProfitCondition, ExpiryDate.TODAY, 73.12m);
            var o = this.tb.NewTakeProfitAndStopLimitOrder(sq);
            Console.WriteLine(o);
            Assert.IsNotEmpty(o.ToString());
        }

        [Test]
        public void CanCreateKillOrder()
        {
            var o = this.tb.KillOrder(Mother.SBRF, "2");
            Console.WriteLine(o);
            Assert.IsNotEmpty(o.ToString());
            Assert.IsTrue(o.OrderKey == "2");
        }

        [Test]
        public void CanCreateKillStopOrder()
        {
            var o = this.tb.KillStopOrder(Mother.SBRF, "22");
            Console.WriteLine(o);
            Assert.IsNotEmpty(o.ToString());
            Assert.IsTrue(o.StopOrderKey == "22");
        }
    }
}
