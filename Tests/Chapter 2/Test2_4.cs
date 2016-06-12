using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test2_4
    {
        [TestMethod]
        public void BasicTest()
        {
            var list = ListHelpers.CreateLinkedList(3, 2, 1);
            ValidateResult(2, list, 1, 3, 2);

            // No change needed (x is smaller)
            list = ListHelpers.CreateLinkedList(1, 2, 3);
            ValidateResult(0, list, 1, 2, 3);

            // No change needed (x is larger)
            list = ListHelpers.CreateLinkedList(1, 2, 3);
            ValidateResult(4, list, 1, 2, 3);

            list = ListHelpers.CreateLinkedList(1, 3, 3, 1);
            ValidateResult(2, list, 1, 1, 3, 3);
        }

        [TestMethod]
        public void EdgeCasesTest()
        {
            // One node
            var list = ListHelpers.CreateLinkedList(1);
            ValidateResult(0, list, 1);

            list = ListHelpers.CreateLinkedList(1);
            ValidateResult(1, list, 1);

            list = ListHelpers.CreateLinkedList(1);
            ValidateResult(2, list, 1);
        }

        [TestMethod]
        public void InvalidInputsTest()
        {
            // Null node
            TestHelpers.AssertExceptionThrown(() => { Question2_4.PartitionList(null, 3); }, typeof(ArgumentNullException));
        }

        private static void ValidateResult<T>(T x, Node<T> list, params T[] expectedResult)
            where T : IEquatable<T>, IComparable<T>
        {
            var result = Question2_4.PartitionList(list, x);
            ListHelpers.ValidateLinkedListContent(result, expectedResult);
        }
    }
}
