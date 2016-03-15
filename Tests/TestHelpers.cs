using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public static class TestHelpers
    {
        // This is used instead of the ExpectedException test attribute to allow testing multiple exceptions
        // in the same test
        public static void AssertExceptionThrown(Action action, Type type)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                if (e.GetType() != type)
                {
                    Assert.Fail("Unexpected type of exception={0}", e.GetType());
                }

                return;
            }

            Assert.Fail("No exception thrown");
        }

        // Creates a two dimensional matrix from a one dimensional input
        // Example input:
        // 1 2 3 4 5 6 7 8 9
        // Example output:
        // 1 2 3
        // 4 5 6
        // 7 8 9
        public static T[,] CreateTwoDimensionalMatrix<T>(params T[] list)
        {
            var size = GetMatrixSize(list);

            var result = new T[size, size];
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

        private static int GetMatrixSize<T>(params T[] list)
        {
            var length = Math.Sqrt(list.Length);

            if (length % 1 != 0)
            {
                throw new ArgumentException(nameof(list), "Number of elements must be a perfect square to create an NxN matrix");
            }

            return (int)length;
        }
    }
}
