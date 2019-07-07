using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class LeastRecentlyUsedCacheTests
    {
        private const string KeyOne = "K1";
        private const string ValueOne = "V1";
        private const string KeyTwo = "K2";
        private const string ValueTwo = "V2";
        private const string KeyThree = "K3";
        private const string ValueThree = "V3";

        [TestMethod]
        public void Get_ReturnsCachedItem()
        {
            // Arrange
            var cache = new LeastRecentlyUsedCache<string>(1);
            cache.Set(KeyOne, ValueOne);

            // Act
            var result = cache.Get(KeyOne);

            // Assert
            Assert.AreEqual(ValueOne, result);
        }

        [TestMethod]
        public void Set_EvictsOldestElement()
        {
            // Arrange
            var cache = new LeastRecentlyUsedCache<string>(1);
            cache.Set(KeyOne, ValueOne);
            cache.Set(KeyTwo, ValueTwo);

            // Act
            var result = cache.Get(KeyOne);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Get_MovesElementToFrontOfListForEviction()
        {
            // Arrange
            var cache = new LeastRecentlyUsedCache<string>(2);
            cache.Set(KeyOne, ValueOne);
            cache.Set(KeyTwo, ValueTwo);
            cache.Get(KeyOne);
            cache.Set(KeyThree, ValueThree);

            // Act
            var result = cache.Get(KeyOne);

            // Assert
            Assert.AreEqual(ValueOne, result);
        }
    }
}
