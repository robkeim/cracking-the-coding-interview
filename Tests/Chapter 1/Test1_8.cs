using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test1_8
    {
        [TestMethod]
        public void BasicTest()
        {
            // Sample given in problem
            ValidateResult("waterbottle", "erbottlewat", true);

            // Different length input
            ValidateResult("abc", "abcd", false);
        }

        [TestMethod]
        public void EdgeCaseTest()
        {
            // Same string two times
            ValidateResult("abc", "abc", true);

            // Case differences
            ValidateResult("abc", "ABC", false);
        }

        [TestMethod]
        public void InvalidInputTest()
        {
            // Null input
            TestHelpers.AssertExceptionThrown(() => { Question1_8.IsRotation("abc", null); }, typeof(ArgumentException));
            TestHelpers.AssertExceptionThrown(() => { Question1_8.IsRotation(null, "abc"); }, typeof(ArgumentException));
            TestHelpers.AssertExceptionThrown(() => { Question1_8.IsRotation(null, null); }, typeof(ArgumentException));

            // Empty input
            TestHelpers.AssertExceptionThrown(() => { Question1_8.IsRotation("abc", string.Empty); }, typeof(ArgumentException));
            TestHelpers.AssertExceptionThrown(() => { Question1_8.IsRotation(string.Empty, "abc"); }, typeof(ArgumentException));
            TestHelpers.AssertExceptionThrown(() => { Question1_8.IsRotation(string.Empty, string.Empty); }, typeof(ArgumentException));
        }

        private void ValidateResult(string s1, string s2, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, Question1_8.IsRotation(s1, s2));
        }
    }
}
