using System;

namespace Code
{
    public static class CountingIslands
    {
        // Given a map indicating land (value 1) and water (value 0) determine the number
        // of islands that exist on the map. Islands are composed of adjacent land blocks
        // either directly north, west, east, or south but not diagonally.
        public static int CountIslands(bool[,] map)
        {
            if (map == null)
            {
                throw new ArgumentNullException(nameof(map));
            }

            var numIslands = 0;

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (map[x, y])
                    {
                        numIslands++;
                        MarkVisited(map, x, y);
                    }
                }
            }

            return numIslands;
        }

        private static void MarkVisited(bool[,] map, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < map.GetLength(0) && y < map.GetLength(1)
                && map[x, y])
            {
                map[x, y] = false;
                MarkVisited(map, x - 1, y);
                MarkVisited(map, x + 1, y);
                MarkVisited(map, x, y - 1);
                MarkVisited(map, x, y + 1);
            }
        }
    }
}
