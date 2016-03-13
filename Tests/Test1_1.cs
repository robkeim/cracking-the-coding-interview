using System;
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
            Assert.IsTrue(Question1_1.AreAllCharactersUnique("abc"));
            Assert.IsTrue(Question1_1.AreAllCharactersUniqueNoAdditionalMemory("abc"));

            // Duplicates
            Assert.IsFalse(Question1_1.AreAllCharactersUnique("aba"));
            Assert.IsFalse(Question1_1.AreAllCharactersUniqueNoAdditionalMemory("aba"));
        }

        [TestMethod]
        public void CaseSensitivityTest()
        {
            // 'A' and 'a' are considered different characters
            Assert.IsTrue(Question1_1.AreAllCharactersUnique("Aa"));
            Assert.IsTrue(Question1_1.AreAllCharactersUniqueNoAdditionalMemory("Aa"));
        }

        [TestMethod]
        public void NullAndEmptyStringsTest()
        {
            // Null string
            Assert.IsTrue(Question1_1.AreAllCharactersUnique(null));
            Assert.IsTrue(Question1_1.AreAllCharactersUniqueNoAdditionalMemory(null));

            // Empty string
            Assert.IsTrue(Question1_1.AreAllCharactersUnique(string.Empty));
            Assert.IsTrue(Question1_1.AreAllCharactersUniqueNoAdditionalMemory(string.Empty));
        }
    }
}
