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
            // 01 02 03 04 05
            // 06 07 08 09 10
            // 11 12 13 14 15
            // 16 17 18 19 20
            // 21 22 23 24 25

            // 2x2
            var input = GenerateMatrix(1, 2, 3, 4);
            var expectedResult = GenerateMatrix(3, 1, 4, 2);
            ValidateResult(input, expectedResult);

            // 3x3
            input = GenerateMatrix(1, 2, 3, 4, 5, 6, 7, 8, 9);
            expectedResult = GenerateMatrix(7, 4, 1, 8, 5, 2, 9, 6, 3);
            ValidateResult(input, expectedResult);

            // 4x4
            input = GenerateMatrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            expectedResult = GenerateMatrix(13, 9, 5, 1, 14, 10, 6, 2, 15, 11, 7, 3, 16, 12, 8, 4);
            ValidateResult(input, expectedResult);

            // 5x5
            input = GenerateMatrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25);
            expectedResult = GenerateMatrix(21, 16, 11, 6, 1, 22, 17, 12, 7, 2, 23, 18, 13, 8, 3, 24, 19, 14, 9, 4, 25, 20, 15, 10, 5);
            ValidateResult(input, expectedResult);
        }

        [TestMethod]
        public void EdgeCaseTest()
        {
            // 1x1
            var input = GenerateMatrix(1);
            var expectedResult = GenerateMatrix(1);
            ValidateResult(input, expectedResult);
        }
        
        [TestMethod]
        public void InvalidInputsTest()
        {
            // Null matrix
            TestHelpers.AssertExceptionThrown(() => { Question1_6.RotateMatrix(null); }, typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => { Question1_6.RotateMatrixInPlace(null); }, typeof(ArgumentNullException));
        }

        private void ValidateResult(int[,] input, int[,] expectedResult)
        {
            var size = (int)Math.Sqrt(input.Length);

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

            result1 = Question1_6.RotateMatrix(result1);
            Question1_6.RotateMatrixInPlace(result2);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Assert.AreEqual(expectedResult[i, j], result1[i, j]);
                    Assert.AreEqual(expectedResult[i, j], result2[i, j]);
                }
            }
        }
        
        // Generates a two dimensional matrix from a one dimensional input
        // Example input:
        // 1 2 3 4 5 6 7 8 9
        // Example output:
        // 1 2 3
        // 4 5 6
        // 7 8 9
        private int[,] GenerateMatrix(params int[] list)
        {
            if (!IsPerfectSquare(list.Length))
            {
                throw new ArgumentException(nameof(list), "Number of elements must be a perfect square to create an NxN matrix");
            }

            var size = (int)Math.Sqrt(list.Length);

            var result = new int[size, size];
            var counter = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = list[counter++];
                }
            }

            return result;
        }

        private bool IsPerfectSquare(int n)
        {
            return Math.Sqrt(n) % 1 == 0;
        }
    }
}
