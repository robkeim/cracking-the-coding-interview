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
            // Sample case given in the problem
            ValideResult("Mr John Smith    ", "Mr%20John%20Smith");
        }

        [TestMethod]
        public void EdgeCasesTest()
        {
            // No spaces
            ValideResult("abc", "abc");

            // First letter is a space
            ValideResult(" abc  ", "%20abc");

            // Last letter is a space
            ValideResult("abc   ", "abc%20", 4);

            // Empty string
            ValideResult(string.Empty, string.Empty);
        }

        [TestMethod]
        public void InvalidInputsTest()
        {
            // Invalid length
            var str = "foo".ToCharArray();
            TestHelpers.AssertExceptionThrown(() => { Question1_3.ReplaceSpaces(str, -1); }, typeof(ArgumentOutOfRangeException));

            // Null input string
            str = null;
            TestHelpers.AssertExceptionThrown(() => { Question1_3.ReplaceSpaces(str, 0); }, typeof(ArgumentNullException));
        }

        private static void ValideResult(string input, string expectedResult, int? inputLength = null)
        {
            if (input.Length != expectedResult.Length)
            {
                throw new ArgumentException("Input and expected result must be the same length");
            }

            var str = input.ToCharArray();
            var length = inputLength ?? input.TrimEnd(" ".ToCharArray()).Length;

            Question1_3.ReplaceSpaces(str, length);
            
            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], str[i]);
            }
        }
    }
}
