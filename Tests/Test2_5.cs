using System;
using System.Collections.Generic;
using System.Linq;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test2_5
    {
        [TestMethod]
        public void BasicTest()
        {
            // Sample case
            // Input: (7 -> 1 -> 6) + (5 -> 9 -> 2).  that is, 617 + 295.
            // Output: 2 -> 1 -> 9.  That is, 912.
            Validate(617, 295, 912);
        }

        [TestMethod]
        public void EdgeCasesTest()
        {
            // Zero
            Validate(42, 0, 42);

            // Last digit is a carry
            Validate(9, 9, 18);

            // Different length inputs
            Validate(1100, 22, 1122);
        }

        [TestMethod]
        public void InvalidInputTest()
        {
            var node = new Node<Digit>(new Digit(0));

            // Null node
            TestHelpers.AssertExceptionThrown(() => { Question2_5.Add(node, null); }, typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => { Question2_5.Add(null, node); }, typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => { Question2_5.Add(null, null); }, typeof(ArgumentNullException));

            TestHelpers.AssertExceptionThrown(() => { Question2_5.AddNotReversed(node, null); }, typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => { Question2_5.AddNotReversed(null, node); }, typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => { Question2_5.AddNotReversed(null, null); }, typeof(ArgumentNullException));
        }

        private void Validate(int num1, int num2, int expectedResult)
        {
            // Reversed
            ValidateHelper(num1, num2, expectedResult);
            ValidateHelper(num2, num1, expectedResult);

            // Not reversed
            ValidateNotReversedHelper(num1, num2, expectedResult);
            ValidateNotReversedHelper(num2, num1, expectedResult);
        }

        private void ValidateHelper(int num1, int num2, int expectedResult)
        {
            var expectedResultArray = CreateList(expectedResult, reversed: true);
            var list1 = CreateDigitList(num1, reversed: true);
            var list2 = CreateDigitList(num2, reversed: true);
            var result = Question2_5.Add(list1, list2);
            TestHelpers.ValidateLinkedListContent(result, expectedResultArray.Select(r => new Digit(r)).ToArray());
        }

        private void ValidateNotReversedHelper(int num1, int num2, int expectedResult)
        {
            var expectedResultArray = CreateList(expectedResult);
            var list1 = CreateDigitList(num1);
            var list2 = CreateDigitList(num2);
            var result = Question2_5.AddNotReversed(list1, list2);
            TestHelpers.ValidateLinkedListContent(result, expectedResultArray.Select(r => new Digit(r)).ToArray());
        }

        private Node<Digit> CreateDigitList(int num, bool reversed = false)
        {
            var result = CreateList(num, reversed);
            return TestHelpers.CreateLinkedList(result.Select(item => new Digit(item)).ToArray());
        }

        private List<int> CreateList(int num, bool reversed = false)
        {
            var digits = new List<int>();

            do
            {
                digits.Add(num % 10);
                num /= 10;
            }
            while (num > 0);

            if (!reversed)
            {
                digits.Reverse();
            }

            return digits;
        }
    }
}
