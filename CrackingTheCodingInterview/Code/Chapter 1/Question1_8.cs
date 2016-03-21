using System;

namespace Code
{
    public static class Question1_8
    {
        // 1.8 Zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column are set to 0.

        // Space: O(N + M)
        // Time: O(N * M)
        public static void ZeroMatrix(int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var rowLength = matrix.GetLength(0);
            var colLength = matrix.GetLength(1);

            var zerosInRow = new bool[rowLength];
            var zerosInCol = new bool[colLength];

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    zerosInRow[i] |= matrix[i, j] == 0;
                    zerosInCol[j] |= matrix[i, j] == 0;
                }
            }

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if (zerosInRow[i] || zerosInCol[j])
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
        }

        // Space: O(1)
        // Time: O(N * M)
        public static void ZeroMatrixNoAdditionalSpace(int[,] matrix)
        {
            // Find out if there's a zero in the first row/column
            // Use the first row/column to store the values instead of the additional arrays created above
            // Zero the matrix where needed
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var rowLength = matrix.GetLength(0);
            var colLength = matrix.GetLength(1);

            bool zeroInFirstRow = false;

            for (int i = 0; i < colLength; i++)
            {
                zeroInFirstRow |= matrix[0, i] == 0;
            }

            bool zeroInFirstCol = false;

            for (int i = 0; i < rowLength; i++)
            {
                zeroInFirstCol |= matrix[i, 0] == 0;
            }

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, 0] = 0;
                        matrix[0, j] = 0;
                    }
                }
            }

            for (int i = 1; i < rowLength; i++)
            {
                for (int j = 1; j < colLength; j++)
                {
                    if (matrix[i, 0] == 0 || matrix[0, j] == 0)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            if (zeroInFirstRow)
            {
                for (int i = 0; i < colLength; i++)
                {
                    matrix[0, i] = 0;
                }
            }

            if (zeroInFirstCol)
            {
                for (int i = 0; i < rowLength; i++)
                {
                    matrix[i, 0] = 0;
                }
            }
        }
    }
}
