using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test1_4
    {
        [TestMethod]
        public void BasicTest()
        {
            // Given sample
            ValidateResult("tactcoa", true);

            // Input is already a palindrome
            ValidateResult("abcba", true);

            // Even number of characters
            ValidateResult("abab", true);

            // Odd number of characters
            ValidateResult("aab", true);

            // One character
            ValidateResult("a", true);

            // Two characters
            ValidateResult("aa", true);
            ValidateResult("ab", false);
        }

        [TestMethod]
        public void CaseSensitivityTest()
        {
            // 'A' and 'a' are considered different characters
            ValidateResult("Aa", false);
        }

        [TestMethod]
        public void NullAndEmptyStringsTest()
        {
            ValidateResult(null, typeof(ArgumentException));
            ValidateResult(string.Empty, typeof(ArgumentException));
        }

        private void ValidateResult(string input, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, Question1_4.IsPalindromePermutation(input));
            Assert.AreEqual(expectedResult, Question1_4.IsPalindromePermutationNoAdditionalSpace(input));
        }

        private void ValidateResult(string input, Type expectedException)
        {
            TestHelpers.AssertExceptionThrown(() => { Question1_4.IsPalindromePermutation(input); }, expectedException);
            TestHelpers.AssertExceptionThrown(() => { Question1_4.IsPalindromePermutationNoAdditionalSpace(input); }, expectedException);
        }
    }
}
