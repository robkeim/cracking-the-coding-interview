using System;

namespace Code
{
    public static class Question16_4
    {
        // 16.4 Tic Tac Win: Design an algorithm to figure out if someone has won a game
        // of tic-tac-toe.

        // Space: O(1)
        // Time: O(N^2) where N is the size of one dimension of the board
        public static bool HasWinner(int?[,] board)
        {
            board = board ?? throw new ArgumentNullException(nameof(board));

            const int numDimensions = 3;

            // Check horizontal
            for (int i = 0; i < numDimensions; i++)
            {
                if (!board[0, i].HasValue)
                {
                    continue;
                }

                var value = board[0, i];
                bool hasWinner = true;

                for (int j = 1; j < numDimensions; j++)
                {
                    if (board[j, i] != value)
                    {
                        hasWinner = false;
                        break;
                    }
                }

                if (hasWinner)
                {
                    return true;
                }
            }

            // Check vertical
            for (int i = 0; i < numDimensions; i++)
            {
                if (!board[i, 0].HasValue)
                {
                    continue;
                }

                var value = board[i, 0];
                bool hasWinner = true;

                for (int j = 1; j < numDimensions; j++)
                {
                    if (board[i, j] != value)
                    {
                        hasWinner = false;
                        break;
                    }
                }

                if (hasWinner)
                {
                    return true;
                }
            }

            // Check diagonal top left to bottom right
            if (board[0, 0].HasValue)
            {
                var value = board[0, 0];
                var hasWinner = true;

                for (int i = 1; i < numDimensions; i++)
                {
                    if (board[i, i] != value)
                    {
                        hasWinner = false;
                        break;
                    }
                }

                if (hasWinner)
                {
                    return true;
                }
            }

            // Check diagonal top right to bottom left
            if (board[numDimensions - 1, 0].HasValue)
            {
                var value = board[numDimensions - 1, 0];
                var hasWinner = true;

                for (int i = 1; i < numDimensions; i++)
                {
                    if (board[numDimensions - 1 - i, i] != value)
                    {
                        hasWinner = false;
                        break;
                    }
                }

                if (hasWinner)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
