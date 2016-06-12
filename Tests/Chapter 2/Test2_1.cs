using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test2_1
    {
        [TestMethod]
        public void BasicTest()
        {
            // Single duplicate
            var list = ListHelpers.CreateLinkedList(1, 2, 2, 3);
            ValidateResult(list, 1, 2, 3);

            // No duplicates
            list = ListHelpers.CreateLinkedList(1, 2, 3);
            ValidateResult(list, 1, 2, 3);

            // Three of the same values in the row
            list = ListHelpers.CreateLinkedList(1, 2, 2, 2, 3);
            ValidateResult(list, 1, 2, 3);

            // Duplicates not next to each other
            list = ListHelpers.CreateLinkedList(1, 2, 3, 2);
            ValidateResult(list, 1, 2, 3);

            // Duplicates next to each other with a third later in the list
            list = ListHelpers.CreateLinkedList(1, 2, 2, 3, 2);
            ValidateResult(list, 1, 2, 3);

            // Several duplicates throughout the list
            list = ListHelpers.CreateLinkedList(1, 2, 2, 3, 2, 4, 3, 5, 5, 6);
            ValidateResult(list, 1, 2, 3, 4, 5, 6);
        }

        [TestMethod]
        public void EdgeCasesTest()
        {
            // First item duplicated
            var list = ListHelpers.CreateLinkedList(1, 1, 2, 3);
            ValidateResult(list, 1, 2, 3);

            // Last item duplciated
            list = ListHelpers.CreateLinkedList(1, 2, 3, 3);
            ValidateResult(list, 1, 2, 3);

            // List with only one element
            list = ListHelpers.CreateLinkedList(1);
            ValidateResult(list, 1);
        }

        [TestMethod]
        public void InvalidInputsTest()
        {
            // Null input string
            TestHelpers.AssertExceptionThrown(() => { Question2_1.RemoveDuplicates<int>(null); }, typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => { Question2_1.RemoveDuplicatesNoSpace<int>(null); }, typeof(ArgumentNullException));
        }

        private static void ValidateResult<T>(Node<T> input, params T[] expectedResult)
            where T : IEquatable<T>
        {
            var input1 = ListHelpers.CloneList(input);
            var input2 = ListHelpers.CloneList(input);

            Question2_1.RemoveDuplicates(input1);
            Question2_1.RemoveDuplicatesNoSpace(input2);

            ListHelpers.ValidateLinkedListContent(input1, expectedResult);
            ListHelpers.ValidateLinkedListContent(input2, expectedResult);
        }
    }
}
