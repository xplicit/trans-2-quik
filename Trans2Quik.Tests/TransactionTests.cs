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
            var ko = new OrderTransaction();
            ko.TransactionId = 1;
            ko.Action = "KILL_ALL_ORDERS";
            ko.ClassCode = "TQBR"; 
            ko.ClientCode = "Q6";
            Console.WriteLine("{0}", ko);
            Assert.IsNotEmpty(ko.ToString());
        }
    }
}
