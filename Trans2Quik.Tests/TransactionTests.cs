namespace Trans2Quik.Tests
{
    using System;
    using Core;
    using NUnit.Framework;

    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void CanCreateKillOrder()
        {
            var ko = new Transaction(1);
            ko.Action = "KILL_ALL_ORDERS";
            ko.ClientCode = "Q6";
            ko.ClassCode = "TQBR";
            var ks = ko.GetTransactionString();
            Console.WriteLine("{0}", ks);
            Assert.IsNotEmpty(ks);
        }
    }
}
