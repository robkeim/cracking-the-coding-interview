using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test1_5
    {
        [TestMethod]
        public void BasicTest()
        {
            // Use the samples given in the problem
            ValidateResult("pale", "ple", true);
            ValidateResult("pales", "pale", true);
            ValidateResult("pale", "bale", true);
            ValidateResult("pale", "bake", false);
        }

        [TestMethod]
        public void EdgeCaseTest()
        {
            // The algorithm is case sensitive
            ValidateResult("foo", "Foo", true);
            ValidateResult("foo", "FOO", false);

            // Using the same string twice
            ValidateResult("foo", "foo", true);
        }

        [TestMethod]
        public void NullAndEmptyStringsTest()
        {
            // First argument
            TestHelpers.AssertExceptionThrown(() => { Question1_5.IsOneAway(null, "foo"); }, typeof(ArgumentException));
            TestHelpers.AssertExceptionThrown(() => { Question1_5.IsOneAway(string.Empty, "foo"); }, typeof(ArgumentException));

            // Second argument
            TestHelpers.AssertExceptionThrown(() => { Question1_5.IsOneAway("foo", null); }, typeof(ArgumentException));
            TestHelpers.AssertExceptionThrown(() => { Question1_5.IsOneAway("foo", string.Empty); }, typeof(ArgumentException));
        }

        private void ValidateResult(string s1, string s2, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, Question1_5.IsOneAway(s1, s2));
        }
    }
}
