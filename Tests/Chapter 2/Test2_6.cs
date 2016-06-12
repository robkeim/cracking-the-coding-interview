using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test2_6
    {
        [TestMethod]
        public void BasicTest()
        {
            Validate(true, 1);
            Validate(true, 1, 1);
            Validate(true, 1, 2, 1);
            Validate(true, 1, 2, 2, 1);

            Validate(false, 1, 2);
            Validate(false, 1, 2, 3);
            Validate(false, 1, 2, 1, 2);
        }

        [TestMethod]
        public void InvalidInputTest()
        {
            TestHelpers.AssertExceptionThrown(() => { Question2_6.IsPalindrome<int>(null); }, typeof(ArgumentNullException));
        }

        private static void Validate(bool expectedResult, params int[] values)
        {
            var head = ListHelpers.CreateLinkedList(values);
            Assert.AreEqual(expectedResult, Question2_6.IsPalindrome(head));
        }
    }
}
