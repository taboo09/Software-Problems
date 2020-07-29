namespace Challenges
{
    public static class RandomShips
    {
        public static int[,] Ship(int[,] matrix, int length, int x, int y, int ship)
        {
            // horizontal
            // right
            if (y + length <= 10)
            {
                if (CheckCoordinatesY(matrix, length, x, y))
                {
                    WriteShipY(matrix, length, x, y, ship);

                    return matrix;
                }
            }

            // left
            if (y - (length - 1) >= 0) 
            {
                if (CheckCoordinatesY(matrix, length, x, y - (length - 1)))
                {
                    WriteShipY(matrix, length, x, y - (length - 1), ship);

                    return matrix;
                }
            }

            // vertically
            // down
            if (x + length <= 10)
            {
                if (CheckCoordinatesX(matrix, length, x, y))
                {
                    WriteShipX(matrix, length, x, y, ship);

                    return matrix;
                }
            }

            // up
            if (x - (length - 1) >= 0)
            {
                if (CheckCoordinatesX(matrix, length, x - (length - 1), y))
                {
                    WriteShipX(matrix, length, x - (length - 1), y, ship);

                    return matrix;
                }
            }

            // new coordinates need to be set up

            return matrix;
        }

        private static bool CheckCoordinatesY(int[,] matrix, int length, int x, int y)
        {
            for (int i = y; i < y + length; i++)
            {
                if (matrix[x, i] > 0) return false;
            }

            return true;
        }

        private static bool CheckCoordinatesX(int[,] matrix, int length, int x, int y)
        {
            for (int i = x; i < x + length; i++)
            {
                if (matrix[i, y] > 0) return false;
            }

            return true;
        }

        private static int[,] WriteShipY(int[,] matrix, int length, int x, int y, int ship)
        {
            for (int i = y; i < y + length; i++)
            {
                matrix[x, i] = ship;
            }

            return matrix;
        }

        private static int[,] WriteShipX(int[,] matrix, int length, int x, int y, int ship)
        {
            for (int i = x; i < x + length; i++)
            {
                matrix[i, y] = ship;
            }

            return matrix;
        }
    }
}