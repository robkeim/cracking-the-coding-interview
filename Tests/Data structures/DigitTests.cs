using System;
using System.Diagnostics.CodeAnalysis;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DigitTests
    {
        [TestMethod]
        public void BasicTest()
        {
            for (int i = 0; i < 10; i++)
            {
                var digit = new Digit(i);
                Assert.AreEqual(i, digit);
            }
        }

        [TestMethod]
        [SuppressMessage("Microsoft.Usage", "CA1806")]
        public void InvalidInputTest()
        {
            // Negative number
            TestHelpers.AssertExceptionThrown(() => { new Digit(-1); }, typeof(ArgumentOutOfRangeException));

            // Multiple digit number
            TestHelpers.AssertExceptionThrown(() => { new Digit(10); }, typeof(ArgumentOutOfRangeException));
        }
    }
}
