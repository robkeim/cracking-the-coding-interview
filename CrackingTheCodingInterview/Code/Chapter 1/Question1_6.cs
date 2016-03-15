using System;

namespace Code
{
    public static class Question1_6
    {
        // 1.6 Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes, write a method to rotate the image by 90 degrees. Can you do this in place?

        // Space: O(N^2)
        // Time: O(N^2)
        public static int[,] RotateMatrix(int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException(nameof(matrix), "Matrix needs to be square");
            }

            var size = matrix.GetLength(0);
            var result = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    result[col, size - 1 - row] = matrix[row, col];
                }
            }

            return result;
        }

        // Space: O(1)
        // Time: O(N^2)
        public static void RotateMatrixInPlace(int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
            
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException(nameof(matrix), "Matrix needs to be square");
            }

            var size = matrix.GetLength(0);
            var offset = 0;

            while (size > 1)
            {
                for (int i = 0; i < size - 1; i++)
                {
                    var orig = matrix[offset, i + offset];

                    // Top left
                    matrix[offset, i + offset] = matrix[size - 1 - i + offset, offset];

                    // Bottom left
                    matrix[size - 1 - i + offset, offset] = matrix[size - 1 + offset, size - 1 - i + offset];

                    // Bottom right
                    matrix[size - 1 + offset, size - 1 - i + offset] = matrix[i + offset, size - 1 + offset];

                    // Top right
                    matrix[i + offset, size - 1 + offset] = orig;
                }

                size -= 2;
                offset++;
            }
        }
    }
}
