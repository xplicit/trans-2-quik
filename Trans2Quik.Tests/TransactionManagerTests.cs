﻿namespace Trans2Quik.Tests
{
    using System;
    using System.Threading;
    using Core;
    using NUnit.Framework;

    [TestFixture]
    public class TransactionManagerTests
    {
        [Test]
        public void CanSendEmptySyncTransaction()
        {
            var cw = new ConnectionListener(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());

            var tw = new TransactionManager();
            var txn = string.Empty;
            var res = tw.SendSyncTransaction(txn);
            Console.WriteLine("{0}", res);
            Assert.IsFalse(res.ReturnValue.IsSuccess);
        }

        [Test]
        public void CanSendGoodSyncTransaction()
        {
            var cw = new ConnectionListener(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());

            var tw = new TransactionManager();
            var txn = "ACCOUNT=LXX+XXXXXXXXX; TYPE=M; TRANS_ID=6546546; CLASSCODE=TQBR; SECCODE=SBER; ACTION=NEW_ORDER; OPERATION=B; PRICE=0; QUANTITY=1;";
            var res = tw.SendSyncTransaction(txn);
            Console.WriteLine("{0}", res);
            Assert.IsTrue(res.ReturnValue.IsSuccess);
        }

        [Test]
        public void CanSendGoodAsyncTransaction()
        {
            var cw = new ConnectionListener(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());

            var tw = new TransactionManager(true);
            tw.TransactionAsyncReply += TransactionAsyncReply;
            var txn = "ACCOUNT=LXX+XXXXXXXXX; TYPE=M; TRANS_ID=6546547; CLASSCODE=TQBR; SECCODE=SBER; ACTION=NEW_ORDER; OPERATION=S; PRICE=0; QUANTITY=1;";
            var res = tw.SendAsyncTransaction(txn);
            Assert.IsTrue(res);
            Console.WriteLine("Waiting for response...");
            Thread.Sleep(10000);
            Console.WriteLine("Exit.");
        }

        private void TransactionAsyncReply(object sender, TransactionEventArgs e)
        {
            var res = e.TransactionResult;
            Console.WriteLine("{0}", res);
            Assert.IsTrue(res.ReturnValue.IsSuccess);
        }
    }
}
