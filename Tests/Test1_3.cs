using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test1_3
    {
        [TestMethod]
        public void BasicTest()
        {
            // Permutations
            ValidateResult("abc", "abc", true);
            ValidateResult("abc", "bca", true);

            // Not permutations
            ValidateResult("abc", "abca", false);
            ValidateResult("abc", "xyz", false);
        }

        [TestMethod]
        public void CaseSensitivityTest()
        {
            // 'A' and 'a' are considered different characters
            ValidateResult("A", "a", false);
        }

        [TestMethod]
        public void NullAndEmptyStringsTest()
        {
            // Null
            string str1 = null;
            string str2 = null;
            ValidateResult(str1, str2, typeof(ArgumentException));
            
            // Empty string
            str1 = string.Empty;
            str2 = string.Empty;
            ValidateResult(str1, str2, typeof(ArgumentException));

            // One one argument invalid
            str1 = "abc";
            str2 = null;
            ValidateResult(str1, str2, typeof(ArgumentException));

            str2 = string.Empty;
            ValidateResult(str1, str2, typeof(ArgumentException));

            str1 = null;
            str2 = "abc";
            ValidateResult(str1, str2, typeof(ArgumentException));

            str1 = string.Empty;
            ValidateResult(str1, str2, typeof(ArgumentException));
        }

        private void ValidateResult(string str1, string str2, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, Question1_3.AreStringsPermutation(str1, str2));
            Assert.AreEqual(expectedResult, Question1_3.AreStringsPermutationNoSort(str1, str2));
        }

        private void ValidateResult(string str1, string str2, Type expectedException)
        {
            TestHelpers.AssertExceptionThrown(() => { Question1_3.AreStringsPermutation(str1, str2); }, expectedException);
            TestHelpers.AssertExceptionThrown(() => { Question1_3.AreStringsPermutationNoSort(str1, str2); }, expectedException);
        }
    }
}
