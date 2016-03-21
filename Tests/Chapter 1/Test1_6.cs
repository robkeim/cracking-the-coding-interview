using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test1_6
    {
        [TestMethod]
        public void BasicTest()
        {
            // Sample case given in the problem
            ValidateResult("aabcccccaaa", "a2b1c5a3");

            ValidateResult("aaaaaaa", "a7");

            // Return original string is returned as compressed string would be larger/same size
            ValidateResult("a", "a");
            ValidateResult("aa", "aa");
        }

        [TestMethod]
        public void CaseSensitivityTest()
        {
            // 'A' and 'a' are considered different characters
            ValidateResult("AAaaa", "A2a3");
        }

        [TestMethod]
        public void InvalidInputsTest()
        {
            // Null input
            TestHelpers.AssertExceptionThrown(() => { Question1_6.Compress(null); }, typeof(ArgumentException));

            // Empty input
            TestHelpers.AssertExceptionThrown(() => { Question1_6.Compress(string.Empty); }, typeof(ArgumentException));
        }

        private void ValidateResult(string input, string expectedResult)
        {
            Assert.AreEqual(expectedResult, Question1_6.Compress(input));
        }
    }
}
