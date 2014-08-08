namespace Trans2Quik.Tests
{
    using System;
    using Core;
    using NUnit.Framework;

    [TestFixture]
    public class ConnectionTests
    {
        [Test]
        public void CanConnect()
        {
            var cw = new ConnectionWatcher(Mother.CONST_PathToQuik);
            Assert.IsTrue(cw.Connect());

            Console.WriteLine("Connection result:{0}", cw.LastResult);

            Assert.IsTrue(cw.IsDllConnected);
            Assert.IsTrue(cw.IsQuikConnected);
            Assert.IsTrue(cw.Disconnect());
        }
    }
}
