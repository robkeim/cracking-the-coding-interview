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
            ValidateInput("abc", true);

            // Duplicates
            ValidateInput("aba", false);
        }

        [TestMethod]
        public void CaseSensitivityTest()
        {
            // 'A' and 'a' are considered different characters
            ValidateInput("Aa", true);
        }

        [TestMethod]
        public void NullAndEmptyStringsTest()
        {
            ValidateInput(null, true);
            ValidateInput(string.Empty, true);
        }

        private void ValidateInput(string input, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, Question1_1.AreAllCharactersUnique(input));
            Assert.AreEqual(expectedResult, Question1_1.AreAllCharactersUniqueNoAdditionalMemory(input));
        }
    }
}
