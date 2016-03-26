using System;
using System.Linq;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test2_2
    {
        [TestMethod]
        public void BasicTest()
        {
            const int NumElements = 5;

            var list = TestHelpers.CreateLinkedList(Enumerable.Range(0, NumElements).Reverse().ToArray());

            for (int i = 0; i < NumElements; i++)
            {
                var input = TestHelpers.CloneList(list);
                var result = Question2_2.FindKthToLast(input, i);

                Assert.AreEqual(i, result.Data);
            }
        }

        [TestMethod]
        public void InvalidInputsTest()
        {
            // Null input
            TestHelpers.AssertExceptionThrown(() => { Question2_2.FindKthToLast<int>(null, 0); }, typeof(ArgumentNullException));

            // K invalid
            var list = TestHelpers.CreateLinkedList(1, 2, 3);
            TestHelpers.AssertExceptionThrown(() => { Question2_2.FindKthToLast(list, -1); }, typeof(ArgumentOutOfRangeException));

            list = TestHelpers.CreateLinkedList(1, 2, 3);
            TestHelpers.AssertExceptionThrown(() => { Question2_2.FindKthToLast(list, 4); }, typeof(ArgumentOutOfRangeException));
        }
    }
}
