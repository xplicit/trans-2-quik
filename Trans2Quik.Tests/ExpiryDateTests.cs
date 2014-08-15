namespace Trans2Quik.Tests
{
    using System;
    using Core;
    using NUnit.Framework;

    [TestFixture]
    public class ExpiryDateTests
    {
        [Test]
        public void CanCreateEmptyExpDate()
        {
            var ex = new ExpiryDate();
            Assert.IsTrue(!ex.Date.HasValue);
            Assert.IsFalse(ex.GoodTillCanceled);
            Assert.IsTrue(ex.ToString() == "TODAY");
        }

        [Test]
        public void CanCreateGtcExpDate()
        {
            var ex = new ExpiryDate(true);
            Assert.IsTrue(!ex.Date.HasValue);
            Assert.IsTrue(ex.GoodTillCanceled);
            Assert.IsTrue(ex.ToString() == "GTC");
        }

        [Test]
        public void CanCreateSpecificExpDate()
        {
            var ex = new ExpiryDate(new DateTime(2014, 9, 15));
            Assert.IsTrue(ex.Date.HasValue);
            Assert.IsFalse(ex.GoodTillCanceled);
            Assert.IsTrue(ex.ToString() == "20140915");
        }

        [Test]
        public void CanUseStaticExpDate()
        {
            Assert.IsTrue(ExpiryDate.GTC.ToString() == "GTC");
            Assert.IsTrue(ExpiryDate.TODAY.ToString() == "TODAY");
        }
    }
}