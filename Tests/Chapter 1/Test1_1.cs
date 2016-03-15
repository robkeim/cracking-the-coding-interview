using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test1_1
    {
        [TestMethod]
        public void BasicTest()
        {
            // No duplicates
            ValidateResult("abc", true);

            // Duplicates
            ValidateResult("aba", false);
        }

        [TestMethod]
        public void CaseSensitivityTest()
        {
            // 'A' and 'a' are considered different characters
            ValidateResult("Aa", true);
        }

        [TestMethod]
        public void NullAndEmptyStringsTest()
        {
            ValidateResult(null, true);
            ValidateResult(string.Empty, true);
        }

        private void ValidateResult(string input, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, Question1_1.AreAllCharactersUnique(input));
            Assert.AreEqual(expectedResult, Question1_1.AreAllCharactersUniqueNoAdditionalMemory(input));
        }
    }
}
