using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test1_7
    {
        [TestMethod]
        public void BasicTest()
        {
            // All ones
            // 1 1 1    1 1 1
            // 1 1 1 -> 1 1 1
            // 1 1 1    1 1 1
            var input = TestHelpers.CreateTwoDimensionalMatrix(1, 1, 1, 1, 1, 1, 1, 1, 1);
            var expectedResult = TestHelpers.CreateTwoDimensionalMatrix(1, 1, 1, 1, 1, 1, 1, 1, 1);
            ValidateResult(input, expectedResult);

            // All zeros
            // 0 0 0    0 0 0
            // 0 0 0 -> 0 0 0
            // 0 0 0    0 0 0
            input = TestHelpers.CreateTwoDimensionalMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0);
            expectedResult = TestHelpers.CreateTwoDimensionalMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0);
            ValidateResult(input, expectedResult);

            // Forward slash
            // 1 1 0    0 0 0
            // 1 0 1 -> 0 0 0
            // 0 1 1    0 0 0
            input = TestHelpers.CreateTwoDimensionalMatrix(1, 1, 0, 1, 0, 1, 0, 1, 1);
            expectedResult = TestHelpers.CreateTwoDimensionalMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0);
            ValidateResult(input, expectedResult);

            // Backward slash
            // 0 1 1    0 0 0
            // 1 0 1 -> 0 0 0
            // 1 1 0    0 0 0
            input = TestHelpers.CreateTwoDimensionalMatrix(0, 1, 1, 1, 0, 1, 1, 1, 0);
            expectedResult = TestHelpers.CreateTwoDimensionalMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0);
            ValidateResult(input, expectedResult);

            // One zero
            // 0 1 1    0 0 0
            // 1 1 1 -> 0 1 1
            // 1 1 1    0 1 1
            input = TestHelpers.CreateTwoDimensionalMatrix(0, 1, 1, 1, 1, 1, 1, 1, 1);
            expectedResult = TestHelpers.CreateTwoDimensionalMatrix(0, 0, 0, 0, 1, 1, 0, 1, 1);
            ValidateResult(input, expectedResult);

            // Corners
            // 0 1 1    0 0 0
            // 1 1 1 -> 0 1 0
            // 1 1 0    0 0 0
            input = TestHelpers.CreateTwoDimensionalMatrix(0, 1, 1, 1, 1, 1, 1, 1, 0);
            expectedResult = TestHelpers.CreateTwoDimensionalMatrix(0, 0, 0, 0, 1, 0, 0, 0, 0);
            ValidateResult(input, expectedResult);

            // Center
            // 1 1 1    1 0 1
            // 1 0 1 -> 0 0 0
            // 1 1 1    1 0 1
            input = TestHelpers.CreateTwoDimensionalMatrix(1, 1, 1, 1, 0, 1, 1, 1, 1);
            expectedResult = TestHelpers.CreateTwoDimensionalMatrix(1, 0, 1, 0, 0, 0, 1, 0, 1);
            ValidateResult(input, expectedResult);

            // Random
            // 1 0 1    0 0 0
            // 1 1 1 -> 1 0 1
            // 1 1 1    1 0 1
            input = TestHelpers.CreateTwoDimensionalMatrix(1, 0, 1, 1, 1, 1, 1, 1, 1);
            expectedResult = TestHelpers.CreateTwoDimensionalMatrix(0, 0, 0, 1, 0, 1, 1, 0, 1);
            ValidateResult(input, expectedResult);
        }

        [TestMethod]
        public void EdgeCaseTest()
        {
            // 1x1 with 0
            var input = TestHelpers.CreateTwoDimensionalMatrix(0);
            var expectedResult = TestHelpers.CreateTwoDimensionalMatrix(0);
            ValidateResult(input, expectedResult);

            // 1x1 with 1
            input = TestHelpers.CreateTwoDimensionalMatrix(1);
            expectedResult = TestHelpers.CreateTwoDimensionalMatrix(1);
            ValidateResult(input, expectedResult);
        }

        [TestMethod]
        public void InvalidInputsTest()
        {
            // Null matrix
            TestHelpers.AssertExceptionThrown(() => { Question1_7.ZeroMatrix(null); }, typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => { Question1_7.ZeroMatrixNoAdditionalSpace(null); }, typeof(ArgumentNullException));
        }

        private void ValidateResult(int[,] input, int[,] expectedResult)
        {
            var size = input.GetLength(0);

            var result1 = new int[size, size];
            var result2 = new int[size, size];

            // Perform deep-copies of the original array
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result1[i, j] = input[i, j];
                    result2[i, j] = input[i, j];
                }
            }

            Question1_7.ZeroMatrix(result1);
            Question1_7.ZeroMatrixNoAdditionalSpace(result2);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Assert.AreEqual(expectedResult[i, j], result1[i, j]);
                    Assert.AreEqual(expectedResult[i, j], result2[i, j]);
                }
            }
        }
    }
}
