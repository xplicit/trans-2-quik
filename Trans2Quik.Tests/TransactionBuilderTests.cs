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
            this.tb = new TransactionBuilder(1, "ABC001");
        }

        [Test]
        public void CanCreateNewOrder()
        {
            var o = this.tb.NewOrder(new Quote(Mother.SBRF, Direction.Buy, 2, 73.45M));

            Console.WriteLine(o);
            Assert.IsNotEmpty(o.ToString());
            Assert.IsTrue(o.IsLimitOrder.GetValueOrDefault());
            Assert.IsTrue(this.tb.NextId == 2);
        }

        [Test]
        public void CanCreateNewMarketOrder()
        {
            var o = this.tb.NewOrder(new Quote(Mother.SBRF, Direction.Sell, 2));
            Console.WriteLine(o);
            Assert.IsNotEmpty(o.ToString());
            Assert.IsFalse(o.IsLimitOrder.GetValueOrDefault());
            Assert.IsTrue(this.tb.NextId == 2);
        }

        [Test]
        public void CanCreateKillOrder()
        {
            var o = this.tb.KillOrder("2");

            Console.WriteLine(o);
            Assert.IsNotEmpty(o.ToString());
            Assert.IsTrue(o.OrderKey == "2");
        }
    }
}