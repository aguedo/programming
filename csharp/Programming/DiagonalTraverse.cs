using System;

namespace Programming;

public class DiagonalTraverse
{
    public static List<int> FindDiagonalOrder(int[][] matrix)
    {
        int rows = matrix.Length;
        if (rows == 0)
        {
            return new List<int>();
        }

        int cols = matrix[0].Length;
        if (cols == 0)
        {
            return new List<int>();
        }

        var result = new List<int>(rows * cols);
        int diagCount = rows + cols - 1;
        int[] upDir = new int[] { -1, 1 }; // row - 1, col + 1
        int[] downDir = new int[] { 1, -1 }; // row + 1, col - 1
        int currDiag = 1;

        while (currDiag <= diagCount)
        {
            bool goingUp = currDiag % 2 == 1;
            int row, col = 0;
            int[] dir = null;
            if (goingUp)
            {
                dir = upDir;
                if (currDiag > rows)
                {
                    row = rows - 1;
                    col = currDiag - rows;
                }
                else
                {
                    row = currDiag - 1;
                    col = 0;
                }
            }
            else
            {
                dir = downDir;
                if (currDiag > cols)
                {
                    col = cols - 1;
                    row = currDiag - cols;
                }
                else
                {
                    col = currDiag - 1;
                    row = 0;
                }
            }

            while (row >= 0 && row < rows && col >= 0 && col < cols)
            {
                result.Add(matrix[row][col]);
                row += dir[0];
                col += dir[1];
            }

            currDiag++;
        }

        return result;
    }
}
